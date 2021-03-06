﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Diggidag
{
    public partial class Form1 : Form
    {
        //int totalDataRows;

        DiggidagConfig currentConfig;

        CancellationTokenSource tokenSource;

        enum SyncTypes
        {
            ChangesAddRemove, ChangesAdd, ChangesRemove, AddRemove, Changes, Add, Remove
        }

        public Form1()
        {
            InitializeComponent();

            ImportConfigFile();
            CheckForConfigErrors();

            tokenSource = new CancellationTokenSource();

            toolStripSpringTextBox1.Text = currentConfig.defaultFilterTextBoxText;

            BeforeDataImport();
        }

        private async void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop)) 
            {
                var data = e.Data.GetData(DataFormats.FileDrop);

                await ImportData(data as string[]);
            }
        }

        private async Task ImportData(string[] paths, DataTable datatable = null)
        {
            BeforeDataImport();

            var dataList = new List<KeyValuePair<string, List<Dictionary<string, string>>>>();

            if(datatable == null)
                datatable = new DataTable();

            foreach (string s in paths)
            {
                if (Directory.Exists(s))
                {
                    toolStripStatusLabelStatus.Text = "Parsing directory: " + s;

                    dataList.Add(new KeyValuePair<string, List<Dictionary<string, string>>>(s, await ParseMetaFolderAsync(s)));
                }
                else if (File.Exists(s) && Path.GetExtension(s).ToLower().Equals(".dbx"))
                {
                    toolStripStatusLabelStatus.Text = "Parsing dbx file: " + s;

                    var meta = await GetMetaDataAsync(s);
                    
                    if(meta.Count > 0)
                        dataList.Add(new KeyValuePair<string, List<Dictionary<string, string>>>(s, new List<Dictionary<string, string>>() { meta }));
                }
                else if (File.Exists(s) && Path.GetExtension(s).ToLower().Equals(".xml"))
                {
                    toolStripStatusLabelStatus.Text = "Parsing xml file: " + s;

                    GetDataTableFromXmlFile(s, datatable);
                }
            }

            toolStripStatusLabelStatus.Text = "Creating data view";
            await CreateDataViewAsync(dataList, datatable);

            AfterDataImport(dataGridView1);
        }

        private async Task SyncFoldersInCurrentDataViewAsync(DataGridView datagridview, SyncTypes syncType = SyncTypes.ChangesAddRemove)
        {
            datagridview.Enabled = false;

            var datatable = ((datagridview.DataSource as BindingSource)?.DataSource as DataView)?.Table;

            var sourceColumnIndex = datagridview.Columns["Source"]?.Index;
            var fileLastWriteTimeIndex = datagridview.Columns["File Last Write Time"]?.Index;

            var currentBindingSource = datagridview.DataSource as BindingSource;
            datagridview.DataSource = null;

            if (datatable != null && sourceColumnIndex.HasValue && fileLastWriteTimeIndex.HasValue)
            {
                var rollbackDatatable = datatable.Copy();

                var editDatatable = datatable.Clone();

                tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;

                await Task.Run(() => {                    
                    
                    var syncTask = Task.Run(async () => {
                        
                        this.Invoke((MethodInvoker)delegate {
                            toolStripStatusLabelStatus.Text = "Syncing changes in view";
                        });
                        
                        toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                            toolStripProgressBar1.Value = 0;
                            toolStripProgressBar1.Maximum = datatable.Rows.Count;
                        });

                        List<int> removeRows = new List<int>();

                        var allSourceFiles = new Dictionary<int,string>();

                        HashSet<string> allFoldersInSource = new HashSet<string>();

                        for(int i = 0; i < datatable.Rows.Count; i++)
                        {
                            var sourceFile = datatable.Rows[i][sourceColumnIndex.Value] as string;
                            if (File.Exists(sourceFile))
                            {
                                allSourceFiles.Add(i, sourceFile);
                                editDatatable.LoadDataRow(datatable.Rows[i].ItemArray, LoadOption.OverwriteChanges);
                            }

                            allFoldersInSource.Add(Path.GetDirectoryName(sourceFile));
                        }

                        if ((syncType == SyncTypes.ChangesAddRemove || syncType == SyncTypes.ChangesAdd || syncType == SyncTypes.ChangesRemove || syncType == SyncTypes.Changes))
                        {
                            foreach(DataRow row in editDatatable.Rows)
                            {
                                token.ThrowIfCancellationRequested();

                                var sourceFile = row[sourceColumnIndex.Value] as string;

                                if (DateTime.TryParse(row[fileLastWriteTimeIndex.Value] as string, out var currentSourceWriteTime))
                                {
                                    var fi = new FileInfo(sourceFile);

                                    if (DateTime.TryParse(fi.LastWriteTime.ToString(), out var lastWriteTime) && lastWriteTime > currentSourceWriteTime)
                                    {
                                        var newRowDict = await GetMetaDataAsync(sourceFile, fi);

                                        if (newRowDict.Count > 0)
                                        {
                                            foreach (var kv in newRowDict)
                                            {
                                                if (datatable.Columns.Contains(kv.Key))
                                                    row[kv.Key] = kv.Value;
                                            }
                                        }
                                    }
                                }

                                toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate
                                {
                                    toolStripProgressBar1.Value++;
                                });
                            }
                        }

                        if (syncType == SyncTypes.ChangesAddRemove || syncType == SyncTypes.ChangesRemove || syncType == SyncTypes.AddRemove || syncType == SyncTypes.Remove)
                        {
                            this.Invoke((MethodInvoker)delegate {
                                toolStripStatusLabelStatus.Text = "Removing files from view";
                            });

                            toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                                toolStripProgressBar1.Value = 0;
                                toolStripProgressBar1.Maximum = removeRows.Count;
                            });

                            datatable.Clear();
                            datatable.Load(editDatatable.CreateDataReader());
                        }

                        // Add slow add bad way to add new files to datatable
                        if (syncType == SyncTypes.ChangesAddRemove || syncType == SyncTypes.ChangesAdd || syncType == SyncTypes.AddRemove || syncType == SyncTypes.Add)
                        {
                            toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                                toolStripProgressBar1.Value = 0;
                            });

                            var allFilesInAllDirectories = new HashSet<string>();

                            foreach (var folder in allFoldersInSource)
                            {
                                token.ThrowIfCancellationRequested();
                                
                                this.Invoke((MethodInvoker)delegate {
                                    toolStripStatusLabelStatus.Text = "Checking for new files in folder: " + folder;
                                });
                               
                                var files = Directory.GetFiles(folder, "*.DBX", SearchOption.AllDirectories);

                                foreach(var file in files)
                                {
                                    allFilesInAllDirectories.Add(file);
                                }
                            }

                            if(allSourceFiles.Count > 0)
                                foreach(var file in allSourceFiles.Values)
                                    allFilesInAllDirectories.Remove(file);

                            toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                                toolStripProgressBar1.Maximum = allFilesInAllDirectories.Count;
                            });
                            
                            this.Invoke((MethodInvoker)delegate {
                                toolStripStatusLabelStatus.Text = "Adding new files to view";
                            });
                            
                            foreach (var file in allFilesInAllDirectories)
                            {                            
                                token.ThrowIfCancellationRequested();

                                var newRowDict = await GetMetaDataAsync(file);

                                if (newRowDict.Count > 0)
                                {
                                    var row = datatable.NewRow();

                                    foreach (var kv in newRowDict)
                                    {
                                        if (datatable.Columns.Contains(kv.Key))
                                            row[kv.Key] = kv.Value;
                                    }

                                    datatable.Rows.Add(row);
                                }

                                toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                                    toolStripProgressBar1.Value++;
                                });
                            }
                        }
                    }, token);
                    
                    try
                    {
                        syncTask.Wait();
                    }
                    catch (AggregateException e)
                    {
                        /*
                        this.Invoke((MethodInvoker)delegate {
                            toolStripStatusLabelStatus.Text = "Sync canceled";
                        });
                        */
                    }
                });

                if(token.IsCancellationRequested)
                {
                    if (MessageBox.Show("Sync was canceled, do you want to rollback your data view?", "Rollback Data view", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        datatable.Clear();
                        datatable.Load(rollbackDatatable.CreateDataReader());
                    }
                }

                tokenSource.Dispose();

                datagridview.DataSource = currentBindingSource;

                AfterDataImport(datagridview);
            }
            toolStripStatusLabelStatus.Text = "Sync complete";
            toolStripProgressBar1.Value = 0;
            datagridview.Enabled = true;
        }

        private DataTable GetDataTableFromXmlFile(string filename, DataTable datatable = null)
        {
            if (datatable == null)
            {
                datatable = new DataTable();          
            }

            var dbname = string.Empty;
            
            using (var reader = XmlReader.Create(filename))
            {
                reader.ReadToFollowing("xs:element");
                
                dbname = reader.GetAttribute("msdata:MainDataTable");

                dbname = XmlConvert.DecodeName(dbname);
            }
            
            if (string.IsNullOrEmpty(datatable.TableName))
                datatable.TableName = filename;

            var tempdatatable = new DataTable();
            tempdatatable.TableName = dbname;
            tempdatatable.ReadXml(filename);

            datatable.Merge(tempdatatable, true, MissingSchemaAction.Add);

            return datatable;
        }

        private void CreateViewFromDataTable(DataTable datatable)
        {
            var dataView = new DataView(datatable);
            bindingSource1.DataSource = dataView;

            dataGridView1.DataSource = bindingSource1;
        }

        private void ImportViewFromFile(string filename, DataTable datatable = null)
        {
            datatable = GetDataTableFromXmlFile(filename);
            CreateViewFromDataTable(datatable);
        }

        private void BeforeDataImport()
        {
            toolStripStatusLabelStatus.Text = string.Empty;
            toolStripStatusLabelRows.Text = string.Empty;
            toolStripStatusLabelTotalRows.Text = string.Empty;
            toolStripStatusLabelSelected.Text = string.Empty;
        }

        private void AfterDataImport(DataGridView datagridview)
        {
            var currentSelectedFilterIndex = toolStripComboBoxFilterTypes.SelectedIndex > 0 ? toolStripComboBoxFilterTypes.SelectedIndex : 0;

            toolStripComboBoxFilterTypes.Items.Clear();

            foreach (DataGridViewColumn c in datagridview.Columns)
                toolStripComboBoxFilterTypes.Items.Add(c.Name);

            if (toolStripComboBoxFilterTypes.Items.Count > 0)
            {
                toolStripComboBoxFilterTypes.SelectedIndex = currentSelectedFilterIndex;

                saveViewAsToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveViewAsToolStripMenuItem.Enabled = false;
            }

            var totalDataRows = ((datagridview.DataSource as BindingSource)?.DataSource as DataView)?.Table?.Rows.Count ?? 0;

            toolStripStatusLabelStatus.Text = string.Empty;
            toolStripStatusLabelRows.Text = bindingSource1.Count.ToString();
            toolStripStatusLabelTotalRows.Text = "/ " + totalDataRows + " Rows";
            if(datagridview.SelectedRows.Count == 0)
                toolStripStatusLabelSelected.Text = string.Empty;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private async Task CreateDataViewAsync(List<KeyValuePair<string, List<Dictionary<string, string>>>> dataList, DataTable datatable = null)
        {
            if (datatable == null)
                datatable = new DataTable();

            var i = dataList.FirstOrDefault((o) => { return o.Value.Count > 0 ? true : false; });

            if (!i.Equals(default(KeyValuePair<string, List<Dictionary<string, string>>>)))
            {
                foreach (var k in i.Value[0].Keys)
                {
                    if(!datatable.Columns.Contains(k))
                        datatable.Columns.Add(k);
                }
            }

            await Task.Run(() =>
            {
                toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                    toolStripProgressBar1.Maximum = dataList.Count;
                });

                foreach (var dataTable in dataList)
                {
                    foreach (var table in dataTable.Value)
                    {
                        var tableRow = datatable.NewRow();

                        foreach (var row in table)
                        {
                            tableRow[row.Key] = row.Value;
                        }

                        datatable.Rows.Add(tableRow);
                    }

                    toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)(() => {
                        toolStripProgressBar1.Value++;
                    }));
                }
            });

            var dataView = new DataView(datatable);
            bindingSource1.DataSource = dataView;

            dataGridView1.DataSource = bindingSource1;

            toolStripProgressBar1.Value = 0;
        }

        private async Task<List<Dictionary<string, string>>> ParseMetaFolderAsync(string path, List<Dictionary<string, string>> dataList = null)
        {
            toolStripProgressBar1.Value = 0;

            if(dataList == null)
                dataList = new List<Dictionary<string, string>>();

            await Task.Run(async () =>
            {
                var files = Directory.GetFiles(@path, "*.DBX",SearchOption.AllDirectories);

                toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)delegate {
                    toolStripProgressBar1.Maximum = files.Length;
                });

                foreach (var dbxFile in files)
                {
                    var meta = await GetMetaDataAsync(dbxFile);
                    if(meta.Count > 0)
                        dataList.Add(meta);

                    toolStripProgressBar1.ProgressBar.Invoke((MethodInvoker)(() => {
                        toolStripProgressBar1.Value++;
                    }));
                }
            });
          
            toolStripProgressBar1.Value = 0;

            return dataList;
        }

        private async Task<Dictionary<string, string>> GetMetaDataAsync(string dbxFile, FileInfo fi = null)
        {
            var dataRow = new Dictionary<string, string>();

            await Task.Run(() =>
            {
                try
                {
                    using (var reader = XmlReader.Create(dbxFile))
                    {
                        for(var i = 0; i < currentConfig.importXMLTags.Length; i++)
                        //foreach (var tag in dbxMetaTags)
                        {
                            reader.ReadToFollowing(currentConfig.importXMLTags[i]);
                            if (reader.NodeType != XmlNodeType.None)
                                dataRow[currentConfig.columnNames[i]] = reader.ReadElementContentAsString();
                        }
                    }

                    dataRow["Source"] = dbxFile;

                    if(fi == null)
                        fi = new FileInfo(dbxFile);

                    dataRow["File Last Write Time"] = fi.LastWriteTime.ToString();
                    dataRow["File Creation Time"] = fi.CreationTime.ToString();
                }
                catch (Exception ex)
                {
                    dataRow = new Dictionary<string, string>();
                }
            });

            return dataRow;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripSpringTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripSpringTextBox1.Text) && !toolStripSpringTextBox1.Text.Equals(currentConfig.defaultFilterTextBoxText))
            {
                if (!string.IsNullOrEmpty((string)toolStripComboBoxFilterTypes.SelectedItem))
                    bindingSource1.Filter = "[" + (string)toolStripComboBoxFilterTypes.SelectedItem + "]" + " like '*" + toolStripSpringTextBox1.Text + "*'";
                else
                {
                    try
                    {
                        bindingSource1.Filter = toolStripSpringTextBox1.Text;
                    }
                    catch (Exception ex)
                    {
                        bindingSource1.Filter = null;
                    }
                }
            }
            else if (!toolStripSpringTextBox1.Text.Equals(currentConfig.defaultFilterTextBoxText))
            {
                bindingSource1.Filter = null;
                toolStripStatusLabelRows.Text = currentConfig.defaultFilterTextBoxText;
            }

            toolStripStatusLabelRows.Text = !toolStripSpringTextBox1.Text.Equals(currentConfig.defaultFilterTextBoxText) ? bindingSource1.Count.ToString() : string.Empty;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                toolStripStatusLabelSelected.Text = "Selected Row: " + (row.Index + 1);
            }
        }

        private void saveViewAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    ((dataGridView1.DataSource as BindingSource).DataSource as DataView).Table.TableName = saveFileDialog1.FileName;
                    ((dataGridView1.DataSource as BindingSource).DataSource as DataView).Table.WriteXml(saveFileDialog1.FileName, XmlWriteMode.WriteSchema);

                    toolStripStatusLabelSelected.Text = "Saved As " + saveFileDialog1.FileName;
                }
            }
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Multiselect = true;

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|dbx files (*.dbx)|*.dbx|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                await ImportData(openFileDialog1.FileNames);
            }
        }

        private async void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Multiselect = true;

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|dbx files (*.dbx)|*.dbx|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                await ImportData(openFileDialog1.FileNames, ((dataGridView1.DataSource as BindingSource)?.DataSource as DataView)?.Table);
            }
        }

        private void OpenFileInDefaultApplication(string filename)
        {
            var expat = string.Empty;

            if (!File.Exists(filename))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (File.Exists(@row.Cells[dataGridView1.Columns["Source"].Index].Value as string))
                    {
                        expat = Path.GetDirectoryName(@row.Cells[dataGridView1.Columns["Source"].Index].Value as string) + "\\";
                    }
                }
            }

            if (File.Exists(@expat + filename))
                System.Diagnostics.Process.Start(@expat + filename);
            else
                MessageBox.Show("Could not open file, check if file exist on path.\n\n" + @expat + filename);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileInDefaultApplication(dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns[currentConfig.mediaColumns.First()].Index].Value as string);
        }

        private void playMediaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                OpenFileInDefaultApplication(row.Cells[dataGridView1.Columns[currentConfig.mediaColumns.First()].Index].Value as string);
            }
        }

        private void openDBXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                OpenFileInDefaultApplication(@row.Cells[dataGridView1.Columns["Source"].Index].Value as string);
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string path = string.Empty;
                try
                {
                    path = Path.GetDirectoryName(@row.Cells[dataGridView1.Columns["Source"].Index].Value as string);
                    if (Directory.Exists(path))
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    else
                        throw new Exception("Could not open file location.\n\n" + path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void syncCurrentViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var senderGridView = ((sender as ToolStripMenuItem)?.Owner as ContextMenuStrip)?.SourceControl as DataGridView;

            if(!Enum.TryParse<SyncTypes>((sender as ToolStripMenuItem).Tag as string, out var syncType))
                syncType = SyncTypes.ChangesAddRemove;

            cancelCurrentSyncToolStripMenuItem.Enabled = true;
            syncCurrentViewToolStripMenuItem.Enabled = false;

            await SyncFoldersInCurrentDataViewAsync(senderGridView ?? dataGridView1, syncType);

            cancelCurrentSyncToolStripMenuItem.Enabled = false;
            syncCurrentViewToolStripMenuItem.Enabled = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((dataGridView1.DataSource as BindingSource)?.DataSource as DataView)?.Table?.Clear();

            dataGridView1.DataSource = null;

            AfterDataImport(dataGridView1);
        }

        private void toolStripSpringTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripSpringTextBox1.Text))
            {
                toolStripSpringTextBox1.Text = currentConfig.defaultFilterTextBoxText;
            }
        }

        private void toolStripSpringTextBox1_Enter(object sender, EventArgs e)
        {
            if (toolStripSpringTextBox1.Text.Equals(currentConfig.defaultFilterTextBoxText))
            {
                toolStripSpringTextBox1.Text = string.Empty;
            }
        }

        private void cancelCurrentSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to cancel current sync?", "Cancel Current Sync", MessageBoxButtons.YesNo);

            if(res == DialogResult.Yes)
            {
                tokenSource.Cancel(true);
            }
        }

        private void openMediaLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string path = string.Empty;
                try
                {
                    path = Path.GetDirectoryName(@row.Cells[dataGridView1.Columns[currentConfig.mediaColumns.First()].Index].Value as string);
                    if (Directory.Exists(path))
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    else
                        throw new Exception("Could not open file location.\n\n" + path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExportConfigFile()
        {
            var serializer = new DataContractJsonSerializer(typeof(DiggidagConfig));

            FileStream file = null;

            try
            {
                file = File.Open("config.json", FileMode.Create);

                if (currentConfig == null)
                    currentConfig = new DiggidagConfig();

                serializer.WriteObject(file, currentConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem writing config file.\n" + ex.Message);
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        private void ImportConfigFile()
        {
            var serializer = new DataContractJsonSerializer(typeof(DiggidagConfig));

            FileStream file = null;

            try
            {
                file = File.Open("config.json", FileMode.Open);
                currentConfig = serializer.ReadObject(file) as DiggidagConfig;
            }
            catch (Exception ex)
            {
                currentConfig = new DiggidagConfig();
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        private void exportConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportConfigFile();
        }

        public void CheckForConfigErrors()
        {
            while (currentConfig.importXMLTags.Length > currentConfig.columnNames.Length)
            {
                var cl = currentConfig.columnNames.ToList();
                cl.Add(currentConfig.importXMLTags[currentConfig.columnNames.Length]);

                currentConfig.columnNames = cl.ToArray();
            }

            HashSet<string> dubTest = new HashSet<string>();

            foreach(var name in currentConfig.columnNames)
            {
                if (!dubTest.Add(name))
                    dubTest.Add(name + dubTest.Count);
            }

            currentConfig.columnNames = dubTest.ToArray();
        }
    }

    public class ToolStripSpringTextBox : ToolStripTextBox
    {
        public override Size GetPreferredSize(Size constrainingSize)
        {
            // Use the default size if the text box is on the overflow menu
            // or is on a vertical ToolStrip.
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
            {
                return DefaultSize;
            }

            // Declare a variable to store the total available width as 
            // it is calculated, starting with the display width of the 
            // owning ToolStrip.
            Int32 width = Owner.DisplayRectangle.Width;

            // Subtract the width of the overflow button if it is displayed. 
            if (Owner.OverflowButton.Visible)
            {
                width = width - Owner.OverflowButton.Width -
                    Owner.OverflowButton.Margin.Horizontal;
            }

            // Declare a variable to maintain a count of ToolStripSpringTextBox 
            // items currently displayed in the owning ToolStrip. 
            Int32 springBoxCount = 0;

            foreach (ToolStripItem item in Owner.Items)
            {
                // Ignore items on the overflow menu.
                if (item.IsOnOverflow) continue;

                if (item is ToolStripSpringTextBox)
                {
                    // For ToolStripSpringTextBox items, increment the count and 
                    // subtract the margin width from the total available width.
                    springBoxCount++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    // For all other items, subtract the full width from the total
                    // available width.
                    width = width - item.Width - item.Margin.Horizontal;
                }
            }

            // If there are multiple ToolStripSpringTextBox items in the owning
            // ToolStrip, divide the total available width between them. 
            if (springBoxCount > 1) width /= springBoxCount;

            // If the available width is less than the default width, use the
            // default width, forcing one or more items onto the overflow menu.
            if (width < DefaultSize.Width) width = DefaultSize.Width;

            // Retrieve the preferred size from the base class, but change the
            // width to the calculated width. 
            Size size = base.GetPreferredSize(constrainingSize);
            size.Width = width;
            return size;
        }
    }
}

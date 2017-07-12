using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Runtime.Serialization.Json;
using System;
using System.IO;

namespace DiggidagWpf
{
    [Serializable]
    public class DiggidagConfig
    {
        public string tablename = string.Empty;
        public string[] import_columns = new string[] {"hep", "hop", "hip", "hap"};
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class MyData
        {
            public string File { get; set; }
        }

        DiggidagConfig myconfig;

        public MainWindow()
        {
            InitializeComponent();

            
            var textColumn = new DataGridTextColumn();
            textColumn.Header = "File";
            textColumn.Binding = new Binding("File");
            myDataGrid.Columns.Add(textColumn);
        }

        private void DataGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var data = e.Data.GetData(DataFormats.FileDrop) as string[];

                foreach(var s in data)
                    myDataGrid.Items.Add( new MyData() { File = s });

                //await ImportData(data as string[]);
            }
        }

        private void DataGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void ExportConfigFile()
        {
            var serializer = new DataContractJsonSerializer(typeof(DiggidagConfig));

            FileStream file = null;

            try
            {
                file = File.Open("config.json", FileMode.Create);

                if (myconfig == null)
                    myconfig = new DiggidagConfig();

                myconfig.tablename = "Hej hop " + DateTime.Now;

                serializer.WriteObject(file, myconfig);
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
                myconfig = serializer.ReadObject(file) as DiggidagConfig;
            }
            catch (Exception ex)
            {
                myconfig = new DiggidagConfig();
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        private void ExportConfigFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ExportConfigFile();
            //ImportConfigFile();
        }
    }
}

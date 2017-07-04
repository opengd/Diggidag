namespace Diggidag
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotalRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playMediaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBXFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveViewAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.syncCurrentViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changesAddRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.changesAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changesRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.changesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSpringTextBox1 = new Diggidag.ToolStripSpringTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxFilterTypes = new System.Windows.Forms.ToolStripComboBox();
            this.dataSet1 = new System.Data.DataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cancelCurrentSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripGridView.SuspendLayout();
            this.toolStripTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1690, 714);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1690, 792);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripTop);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabelRows,
            this.toolStripStatusLabelTotalRows,
            this.toolStripStatusLabelSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1690, 38);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 32);
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(79, 33);
            this.toolStripStatusLabelStatus.Text = "Status";
            // 
            // toolStripStatusLabelRows
            // 
            this.toolStripStatusLabelRows.Name = "toolStripStatusLabelRows";
            this.toolStripStatusLabelRows.Size = new System.Drawing.Size(69, 33);
            this.toolStripStatusLabelRows.Text = "Rows";
            // 
            // toolStripStatusLabelTotalRows
            // 
            this.toolStripStatusLabelTotalRows.Name = "toolStripStatusLabelTotalRows";
            this.toolStripStatusLabelTotalRows.Size = new System.Drawing.Size(120, 33);
            this.toolStripStatusLabelTotalRows.Text = "TotalRows";
            // 
            // toolStripStatusLabelSelected
            // 
            this.toolStripStatusLabelSelected.Name = "toolStripStatusLabelSelected";
            this.toolStripStatusLabelSelected.Size = new System.Drawing.Size(106, 33);
            this.toolStripStatusLabelSelected.Text = "Selected";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripGridView;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1690, 714);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // contextMenuStripGridView
            // 
            this.contextMenuStripGridView.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playMediaFileToolStripMenuItem,
            this.openDBXFileToolStripMenuItem,
            this.openFileLocationToolStripMenuItem});
            this.contextMenuStripGridView.Name = "contextMenuStripGridView";
            this.contextMenuStripGridView.Size = new System.Drawing.Size(291, 156);
            // 
            // playMediaFileToolStripMenuItem
            // 
            this.playMediaFileToolStripMenuItem.Name = "playMediaFileToolStripMenuItem";
            this.playMediaFileToolStripMenuItem.Size = new System.Drawing.Size(290, 36);
            this.playMediaFileToolStripMenuItem.Text = "Play Media File";
            this.playMediaFileToolStripMenuItem.Click += new System.EventHandler(this.playMediaFileToolStripMenuItem_Click);
            // 
            // openDBXFileToolStripMenuItem
            // 
            this.openDBXFileToolStripMenuItem.Name = "openDBXFileToolStripMenuItem";
            this.openDBXFileToolStripMenuItem.Size = new System.Drawing.Size(290, 36);
            this.openDBXFileToolStripMenuItem.Text = "Open DBX File";
            this.openDBXFileToolStripMenuItem.Click += new System.EventHandler(this.openDBXFileToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(290, 36);
            this.openFileLocationToolStripMenuItem.Text = "Open File Location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // toolStripTop
            // 
            this.toolStripTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripTop.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripSpringTextBox1,
            this.toolStripLabel1,
            this.toolStripComboBoxFilterTypes});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(1690, 40);
            this.toolStripTop.Stretch = true;
            this.toolStripTop.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openViewToolStripMenuItem,
            this.saveViewAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.syncCurrentViewToolStripMenuItem,
            this.cancelCurrentSyncToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.ShowDropDownArrow = false;
            this.toolStripButton1.Size = new System.Drawing.Size(56, 37);
            this.toolStripButton1.Text = "File";
            // 
            // openViewToolStripMenuItem
            // 
            this.openViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.appendToolStripMenuItem});
            this.openViewToolStripMenuItem.Name = "openViewToolStripMenuItem";
            this.openViewToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.openViewToolStripMenuItem.Text = "Open Xml As View...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 38);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(213, 38);
            this.appendToolStripMenuItem.Text = "Append...";
            this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
            // 
            // saveViewAsToolStripMenuItem
            // 
            this.saveViewAsToolStripMenuItem.Name = "saveViewAsToolStripMenuItem";
            this.saveViewAsToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.saveViewAsToolStripMenuItem.Text = "Save View As Xml...";
            this.saveViewAsToolStripMenuItem.Click += new System.EventHandler(this.saveViewAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(325, 6);
            // 
            // syncCurrentViewToolStripMenuItem
            // 
            this.syncCurrentViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changesAddRemoveToolStripMenuItem,
            this.toolStripSeparator7,
            this.changesAddToolStripMenuItem,
            this.changesRemoveToolStripMenuItem,
            this.addRemoveToolStripMenuItem,
            this.toolStripSeparator6,
            this.changesToolStripMenuItem,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.syncCurrentViewToolStripMenuItem.Name = "syncCurrentViewToolStripMenuItem";
            this.syncCurrentViewToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.syncCurrentViewToolStripMenuItem.Text = "Sync Current View";
            // 
            // changesAddRemoveToolStripMenuItem
            // 
            this.changesAddRemoveToolStripMenuItem.Name = "changesAddRemoveToolStripMenuItem";
            this.changesAddRemoveToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.changesAddRemoveToolStripMenuItem.Tag = "0";
            this.changesAddRemoveToolStripMenuItem.Text = "Changes/Add/Remove";
            this.changesAddRemoveToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(350, 6);
            // 
            // changesAddToolStripMenuItem
            // 
            this.changesAddToolStripMenuItem.Name = "changesAddToolStripMenuItem";
            this.changesAddToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.changesAddToolStripMenuItem.Tag = "1";
            this.changesAddToolStripMenuItem.Text = "Changes/Add";
            this.changesAddToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // changesRemoveToolStripMenuItem
            // 
            this.changesRemoveToolStripMenuItem.Name = "changesRemoveToolStripMenuItem";
            this.changesRemoveToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.changesRemoveToolStripMenuItem.Tag = "2";
            this.changesRemoveToolStripMenuItem.Text = "Changes/Remove";
            this.changesRemoveToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // addRemoveToolStripMenuItem
            // 
            this.addRemoveToolStripMenuItem.Name = "addRemoveToolStripMenuItem";
            this.addRemoveToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.addRemoveToolStripMenuItem.Tag = "3";
            this.addRemoveToolStripMenuItem.Text = "Add/Remove";
            this.addRemoveToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(350, 6);
            // 
            // changesToolStripMenuItem
            // 
            this.changesToolStripMenuItem.Name = "changesToolStripMenuItem";
            this.changesToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.changesToolStripMenuItem.Tag = "4";
            this.changesToolStripMenuItem.Text = "Changes";
            this.changesToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.addToolStripMenuItem.Tag = "5";
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.removeToolStripMenuItem.Tag = "6";
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.syncCurrentViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(325, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.clearToolStripMenuItem.Text = "Clear Current View";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(325, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripSpringTextBox1
            // 
            this.toolStripSpringTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSpringTextBox1.Name = "toolStripSpringTextBox1";
            this.toolStripSpringTextBox1.Size = new System.Drawing.Size(1358, 40);
            this.toolStripSpringTextBox1.Text = "Your filter text...";
            this.toolStripSpringTextBox1.Enter += new System.EventHandler(this.toolStripSpringTextBox1_Enter);
            this.toolStripSpringTextBox1.Leave += new System.EventHandler(this.toolStripSpringTextBox1_Leave);
            this.toolStripSpringTextBox1.TextChanged += new System.EventHandler(this.toolStripSpringTextBox1_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 37);
            this.toolStripLabel1.Text = "Filter:";
            // 
            // toolStripComboBoxFilterTypes
            // 
            this.toolStripComboBoxFilterTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolStripComboBoxFilterTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripComboBoxFilterTypes.Name = "toolStripComboBoxFilterTypes";
            this.toolStripComboBoxFilterTypes.Size = new System.Drawing.Size(121, 40);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // cancelCurrentSyncToolStripMenuItem
            // 
            this.cancelCurrentSyncToolStripMenuItem.Enabled = false;
            this.cancelCurrentSyncToolStripMenuItem.Name = "cancelCurrentSyncToolStripMenuItem";
            this.cancelCurrentSyncToolStripMenuItem.Size = new System.Drawing.Size(328, 38);
            this.cancelCurrentSyncToolStripMenuItem.Text = "Cancel Current Sync";
            this.cancelCurrentSyncToolStripMenuItem.Click += new System.EventHandler(this.cancelCurrentSyncToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1690, 792);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Diggidag";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripGridView.ResumeLayout(false);
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRows;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private ToolStripSpringTextBox toolStripSpringTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFilterTypes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelected;
        private System.Windows.Forms.ToolStripMenuItem saveViewAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridView;
        private System.Windows.Forms.ToolStripMenuItem playMediaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDBXFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotalRows;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem syncCurrentViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem changesAddRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem changesAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changesRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem changesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelCurrentSyncToolStripMenuItem;
    }
}


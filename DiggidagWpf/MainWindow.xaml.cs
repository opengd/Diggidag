using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Runtime.Serialization.Json;

namespace DiggidagWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class MyData
        {
            public string File { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            
            var textColumn = new DataGridTextColumn();
            textColumn.Header = "File";
            textColumn.Binding = new Binding("File");
            myDataGrid.Columns.Add(textColumn);

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
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
    }
}

using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace DataTableDataSetDataGrid
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
      
            
     
          

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _ClassTable = new ClassTable();
            _ClassTable.newTab("fggg");
         //  ass();
            base.OnNavigatedTo(e);
        }
        public void ass()
        {
            if (_ClassTable.booksTable != null) // table is a DataTable
            {
                int i = 0;
                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {
                // booksTable.Columns.Add(
                //  new DataGridTextColumn
                //  {
                //    Header = col.ColumnName,

                //   Binding = new Binding(string.Format("[{0}]", col.ColumnName))



                //  });
               
                    DataGridTeleric.Columns.Add(new DataGridNumericalColumn()
                    {
                        Header = col.ColumnName,
                      PropertyName= col.ColumnName.ToString()

                    });
                    dataGrid1.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
                    {
                        Header = col.ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + col.ColumnName.ToString() + "]") },
                        IsReadOnly = false
                    });

                }
               
            }
        }
       public ObservableCollection<DataRow> collection = new ObservableCollection<DataRow>();
        DataSet bookStore;
        DataTable booksTable;
        ClassTable _ClassTable { get; set; }
        TextBox _TextBox = new TextBox();
        public void newColon(DataGrid dataGrid, string name)
        {
            dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
            {
                Header = name,
                Binding = new Binding { Path = new PropertyPath("[" + name + "]") },
                IsReadOnly = false
            });
          

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            newColon(_ClassTable.dataGrid, _ClassTable.newColums());
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            _ClassTable.newRows();
                         //   collection.Add(row);            // dataGrid1.ItemsSource = booksTable.DefaultView;



        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string s = "g";
            foreach (DataRow r in _ClassTable.booksTable.Rows)
            {
                foreach (var cell in r.ItemArray)
                    s += cell.ToString() + "\n";// Console.Write("\t{0}", cell);
               /// Console.WriteLine();
            }
            MessageDialog messageDialog = new MessageDialog(s);
           await messageDialog.ShowAsync();
        }

        private void DataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Create a new template column.
            var templateColumn = new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTemplateColumn();
            Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn templateColumn1 = new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
            {
                Header = "id",
                Binding = new Binding { Path = new PropertyPath("[id]") },
                IsReadOnly = false
            };
            DataGrid dataGrid = (DataGrid)sender;
            dataGrid.Columns.Add(templateColumn1);
           // templateColumn.Header = "Due Date";
           // e.Column = templateColumn;
        }
      
        private void DataGrid1_Loading(FrameworkElement sender, object args)
        {
          
            DataGrid dataGrid = (DataGrid)sender;
            _ClassTable.dataGrid = dataGrid;
            if (_ClassTable.booksTable != null) // table is a DataTable
            {
                int i = 0;
                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {
                    // booksTable.Columns.Add(
                    //  new DataGridTextColumn
                    //  {
                    //    Header = col.ColumnName,

                    //   Binding = new Binding(string.Format("[{0}]", col.ColumnName))



                    //  });
                  
                    dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
                    {
                        Header = col.ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + col.ColumnName.ToString() + "]") },
                        IsReadOnly = false
                    });

                }

            }
        }
    }
    
}

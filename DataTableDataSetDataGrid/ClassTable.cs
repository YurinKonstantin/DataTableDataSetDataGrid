using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DataTableDataSetDataGrid
{
   public class ClassTable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        DataTable _booksTable;
        public DataTable booksTable
        {
            get
            {
                return _booksTable;
            }
            set
            {
                _booksTable = value;
                this.OnPropertyChanged("booksTable");
            }
        }
   
        public DataGrid dataGrid = new DataGrid();
        public void newTab(string name)
        {
          //  bookStore = new DataSet("BookStore");
            booksTable = new DataTable("name");
            
            collection = new ObservableCollection<DataRow>();
            // bookStore.Tables.Add(booksTable);
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn nameColumn = new DataColumn("Колонка 1", Type.GetType("System.Int32"));
            DataColumn priceColumn = new DataColumn("Колонка 2", Type.GetType("System.Int32"));
          
            DataColumn discountColumn = new DataColumn("Колонка 3", Type.GetType("System.Int32"));
         

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);
            booksTable.Columns.Add(discountColumn);
            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };
            DataRow row = booksTable.NewRow();
            row.ItemArray = new object[] { null, 1, 200, 12 };
           collection.Add(row); // добавляем первую строку
            booksTable.Rows.Add(row);
        
         
            // добавляем вторую строку
        }

        public string newColums()
        {
            if (booksTable != null) // table is a DataTable
            {
               int x =  booksTable.Columns.Count;
                   DataColumn priceColumn = new DataColumn("Колонка "+x.ToString(), Type.GetType("System.Int32"));
                priceColumn.AllowDBNull = true;
                booksTable.Columns.Add(priceColumn);

                return "Колонка " + x.ToString();

            }
            return null;
        }
        public ObservableCollection<DataRow> collection { get; set; }
        public void newRows()
        {
           // row.ItemArray = new object[] { null, "Война и мир", 200 };
            DataRow row = booksTable.NewRow();
            int x = booksTable.Columns.Count-1;
        
            for (int i=0; i<x; i++)
                {
                    row[i+1] = "0";
                }
            // DataRow row1 = booksTable.NewRow();
            
            booksTable.Rows.Add(row);
            collection.Add(row);
            booksTable.AcceptChanges();
       
        

            }
    
    }
}

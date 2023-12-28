using SchoolGrades;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for frmEditLookupTable.xaml
    /// </summary>
    public partial class frmEditLookupTable : Window
    {
        private string table;
        private string idTable;

        public frmEditLookupTable(string Table, string IdTable)
        {
            InitializeComponent();

            table = Table;
            idTable = IdTable;
        }

        private void frmEditLookupTable_Load(object sender, RoutedEventArgs e)
        {
            Title += ". Tabella: " + table;
            DataSet ds = null;
            DataAdapter da = null;
            Commons.bl.GetLookupTable(table, ref ds, ref da);
            dgwTable.ItemsSource = (System.Collections.IEnumerable)ds.Tables[0];
            da.Dispose();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da aggiustare, NON salvato!");
            //DataTable t = (DataTable)dgwTable.ItemsSource;
            //DataTable modifiche = t.GetChanges();
            //if (modifiche != null)
            //{
            //    foreach (DataRow riga in modifiche.Items)
            //    {
            //        if (riga.RowState == DataRowState.Modified)
            //            db.UpdateLookupTableRow(table, idTable, riga);
            //        else if (riga.RowState == DataRowState.Added)
            //            db.CreateLookupTableRow(table, idTable, riga);
            //    }
            //}
        }
        private void frmEditLookupTable_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

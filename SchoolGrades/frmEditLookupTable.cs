using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmEditLookupTable : Form
    {
        private string table;
        private string idTable;

        public frmEditLookupTable(string Table, string IdTable)
        {
            InitializeComponent();

            table = Table;
            idTable = IdTable; 
        }

        private void frmEditLookupTable_Load(object sender, EventArgs e)
        {
            this.Text += ". Tabella: " + table; 
            DataSet ds = null;
            DataAdapter da = null; 
            Commons.bl.GetLookupTable(table, ref ds, ref da);
            dgwTable.DataSource = ds.Tables[0];
            da.Dispose(); 
        }
        private void frmEditLookupTable_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void BtnSalva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da aggiustare, NON salvato!"); 
            //DataTable t = (DataTable)dgwTable.DataSource;
            //DataTable modifiche = t.GetChanges();
            //if (modifiche != null)
            //{
            //    foreach (DataRow riga in modifiche.Rows)
            //    {
            //        if (riga.RowState == DataRowState.Modified)
            //            db.UpdateLookupTableRow(table, idTable, riga);
            //        else if (riga.RowState == DataRowState.Added)
            //            db.CreateLookupTableRow(table, idTable, riga);
            //    }
            //}
        }
    }
}

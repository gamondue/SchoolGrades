using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmLookupTablesChoose : Form
    {
        private string idTable;
        private string table;

        public frmLookupTablesChoose()
        {
            InitializeComponent();
        }
        private void frmTables_Load(object sender, EventArgs e)
        {

        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            frmLookupTableEdit f = new frmLookupTableEdit(table, idTable);
            f.ShowDialog();
        }
        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            table = ((RadioButton)sender).Name.Substring(3); 
            idTable = "id" + table;
            idTable = idTable.Substring(0, idTable.Length - 1);
            if (table == "GradeCategories")
                idTable = "idGradeCategory"; 
        }
    }
}

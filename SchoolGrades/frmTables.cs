using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTables : Form
    {
        private string idTable;
        private string table;

        public frmTables()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            frmEditLookupTable f = new frmEditLookupTable(table, idTable);
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

        private void frmTables_Load(object sender, EventArgs e)
        {

        }
    }
}

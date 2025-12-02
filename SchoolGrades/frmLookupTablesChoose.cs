using System;
using System.Windows.Forms;
using SchoolGrades.Resources;

namespace SchoolGrades
{
    public partial class frmLookupTablesChoose : Form
    {
        private string idTable;
        private string table;

        public frmLookupTablesChoose()
        {
            InitializeComponent();
            LocalizeForm();
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
        private void LocalizeForm()
        {
            // Title
            this.Text = Strings.LookupTables_Title;

            // Radio buttons
            rdbSchoolSubjects.Text = Strings.LookupTables_Subjects;
            rdbTestTypes.Text = Strings.LookupTables_TestTypes;
            rdbQuestionTypes.Text = Strings.LookupTables_QuestionTypes;
            rdbAnswerTypes.Text = Strings.LookupTables_AnswerTypes;
            rdbGradeTypes.Text = Strings.LookupTables_GradeTypes;
            rdbGradeCategories.Text = Strings.LookupTables_GradeCategories;
            rdbSchools.Text = Strings.LookupTables_Schools;
            rdbSchoolYears.Text = Strings.LookupTables_SchoolYears;

            // Button
            btnOpen.Text = Strings.LookupTables_OpenTable;
        }
    }
}

using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmNewYear : Form
    {
        string idStartYear;
        private School currentSchool;

        private SchoolYear currentSchoolYear = new SchoolYear();
        private Class currentClass = new Class();

        private SchoolYear nextSchoolYear = new SchoolYear();
        private Class nextClass = new Class();

        private bool loading;

        public frmNewYear(string IdStartYear)
        {
            InitializeComponent();
            LocalizeForm();
            idStartYear = IdStartYear;
        }
        private void frmNewYear_Load(object sender, EventArgs e)
        {
            loading = true;
            // currentSchool data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);

            // years's data in combo
            List<SchoolYear> ly = Commons.bl.GetAllSchoolYears();
            cmbSchoolYearCurrents.DataSource = ly;
            if (ly.Count > 0)
                cmbSchoolYearCurrents.SelectedItem = ly[ly.Count - 1];
            cmbSchoolYearCurrents.SelectedItem = idStartYear;
            currentSchoolYear = (SchoolYear)cmbSchoolYearCurrents.SelectedItem;

            cmbClasses.DataSource = Commons.bl.GetClassesOfYear(
                currentSchool.IdSchool, currentSchoolYear.IdSchoolYear);
            //cmbClasses.SelectedIndex = 0;

            currentClass = (Class)cmbClasses.SelectedItem;

            //nextClass = new Class(); 
            //nextSchoolYear = new SchoolYear();

            loading = false;
            nextSchoolYear = Commons.bl.GenerateNewYearData(currentSchoolYear);
            nextClass = Commons.bl.GenerateNewClassData(currentClass);
            FromClassesToUi();
        }
        private void FromClassesToUi()
        {
            txtYearDescriptionCurrent.Text = currentSchoolYear.ShortDescription;
            txtYearNotesCurrent.Text = currentSchoolYear.Notes;

            txtSchoolYearNext.Text = nextSchoolYear.IdSchoolYear;
            txtYearDescriptionNext.Text = nextSchoolYear.ShortDescription;
            txtYearNotesNext.Text = nextSchoolYear.Notes;

            if (currentClass != null)
                txtClassDescriptionCurrent.Text = currentClass.Description;

            txtClassAbbreviationNext.Text = nextClass.Abbreviation;
            txtClassDescriptionNext.Text = nextClass.Description;
        }
        private void FromUiToClasses()
        {
            currentSchoolYear.ShortDescription = txtYearDescriptionCurrent.Text;
            currentSchoolYear.Notes = txtYearNotesCurrent.Text;

            nextSchoolYear.ShortDescription = txtYearDescriptionNext.Text;
            nextSchoolYear.Notes = txtYearNotesNext.Text;

            currentClass.Description = txtClassDescriptionCurrent.Text;

            nextClass.Abbreviation = txtClassAbbreviationNext.Text;
            nextClass.Description = txtClassDescriptionNext.Text;
        }
        private void BtnClassMigration_Click(object sender, EventArgs e)
        {
            BtnStudentNew.Visible = true;
            if (cmbClasses.Text == "")
            {
                MessageBox.Show(Loc.Get("NewYear_SelectStartClass"));
                return;
            }
            Class c = (Class)cmbClasses.SelectedItem;
            if (c != null)
            {
                DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList((Class)cmbClasses.SelectedItem, true);

                currentClass = (Class)cmbClasses.SelectedItem;
                // check all the student's rows 
                foreach (DataGridViewRow dr in DgwStudents.Rows)
                {
                    Student st = (Student)dr.DataBoundItem;
                    st.IdClass = 0;
                    st.RegisterNumber = "";
                    st.SchoolYear = txtSchoolYearNext.Text;
                    st.ClassAbbreviation = txtClassAbbreviationNext.Text;

                    st.Disabled = false;
                    st.Eligible = false;

                    dr.Cells[0].Value = false;
                }
                //txtClassDescriptionNext.Text = currentSchool.Name + " " + txtSchoolYearNext.Text +
                //    " " + txtClassAbbreviationNext.Text;
                //txtClassDescriptionNext.Visible = true;
                //lblClassDescription.Visible = true; 

                MessageBox.Show(Loc.Get("NewYear_AdjustClassData"),Loc.Get("NewYear_ClassChangesTitle"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            BtnClassGeneration.Visible = true;
            BtnClassMigration.Visible = false;
        }
        private void BtnClassGeneration_Click(object sender, EventArgs e)
        {
            if (txtClassAbbreviationNext.Text == "")
            {
                MessageBox.Show(Loc.Get("NewYear_EnterClassCode"));
                return;
            }

            if (txtClassDescriptionNext.Text == "")
                txtClassDescriptionNext.Text = currentSchool.Desc + " " + txtSchoolYearNext.Text + " " + txtClassAbbreviationNext.Text;

            List<Student> SelectedStudents = new List<Student>();
            foreach (DataGridViewRow r in DgwStudents.Rows)
            {
                // don't include students whose rows are non checked
                if ((bool)r.Cells["SaveThisStudent"].Value == true)
                {
                    SelectedStudents.Add((Student)r.DataBoundItem);
                }
            }
            Commons.bl.GenerateNewClassFromPrevious(SelectedStudents, txtClassAbbreviationNext.Text, txtClassDescriptionNext.Text,
                nextSchoolYear, cmbSchoolYearCurrents.Text, TxtOfficialSchoolAbbreviation.Text);

            MessageBox.Show(string.Format(Loc.Get("NewYear_ClassCreated"), 
                txtClassAbbreviationNext.Text, txtSchoolYearNext.Text));
            //BtnStudentNew.Visible = false;
            FromUiToClasses();
        }
        private void BtnStudentNew_Click(object sender, EventArgs e)
        {
            frmStudent sf = new frmStudent(null, true);
            sf.ShowDialog();

            if (sf.UserHasChosen)
            {
                List<Student> ls = (List<Student>)DgwStudents.DataSource;
                ls.Add(sf.CurrentStudent);
                DgwStudents.DataSource = null;
                DgwStudents.DataSource = ls;
                DgwStudents.Refresh();
            }
        }
        private void BtnClassNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Loc.Get("NewYear_TodoFeature"));
        }
        private void TxtSchoolYearPresent_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtSchoolYearPresent_Leave(object sender, EventArgs e)
        {

        }
        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolYear = (SchoolYear)cmbSchoolYearCurrents.SelectedItem;
            if (!loading)
            {
                nextSchoolYear = Commons.bl.GenerateNewYearData(currentSchoolYear);
                FromClassesToUi();
                cmbClasses.DataSource = null;
                cmbClasses.DataSource = Commons.bl.GetClassesOfYear(
                    currentSchool.IdSchool, currentSchoolYear.IdSchoolYear);
            }
        }
        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                BtnClassMigration.Visible = true;
                currentClass = (Class)cmbClasses.SelectedItem;
                try
                {
                    nextClass = Commons.bl.GenerateNewClassData(currentClass);
                }
                catch
                {
                    nextClass.Abbreviation = "";
                }
                FromClassesToUi();
            }
        }
        private void btnAssociateSchoolPeriodsToTheYear_Click(object sender, EventArgs e)
        {
            frmSchoolYearAndPeriodsManagement f = new frmSchoolYearAndPeriodsManagement(cmbSchoolYearCurrents.Text);
            f.ShowDialog();
        }
        private void btnNewYear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format(Loc.Get("NewYear_CreateYearConfirm"), txtSchoolYearNext.Text),
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                != DialogResult.Yes)
            {
                return;
            }
            SchoolYear sy = new SchoolYear(txtSchoolYearNext.Text);
            if (!Commons.bl.AddSchoolYearIfNotExists(sy))
            {
                MessageBox.Show(string.Format(Loc.Get("NewYear_YearExists"), txtSchoolYearNext.Text));
            }
            else
            {
                MessageBox.Show(string.Format(Loc.Get("NewYear_YearCreated"), txtSchoolYearNext.Text));
                List<SchoolYear> ly = Commons.bl.GetAllSchoolYears();
                cmbSchoolYearCurrents.DataSource = ly;
                cmbSchoolYearCurrents.SelectedItem = ly[ly.Count - 1];
            }
        }
        private void LocalizeForm()
        {
            try
            {
                // Form Title
                this.Text = Loc.Get("NewYear_Title");

                // GroupBoxes
                groupBox1.Text = Loc.Get("NewYear_PreviousYear");
                groupBox2.Text = Loc.Get("NewYear_NewYear");
                groupBox3.Text = Loc.Get("NewYear_PreviousClass");
                groupBox4.Text = Loc.Get("NewYear_NewClass");

                // Labels - Previous Year (groupBox1)
                label3.Text = Loc.Get("NewYear_YearId");
                label2.Text = Loc.Get("NewYear_ShortDescription");
                label8.Text = Loc.Get("NewYear_Notes");

                // Labels - New Year (groupBox2)
                label6.Text = Loc.Get("NewYear_NewYearId");
                label5.Text = Loc.Get("NewYear_ShortDescription");
                label10.Text = Loc.Get("NewYear_Notes");

                // Labels - Previous Class (groupBox3)
                label1.Text = Loc.Get("NewYear_PreviousClassCode");
                label9.Text = Loc.Get("NewYear_Description");

                // Labels - New Class (groupBox4)
                label12.Text = Loc.Get("NewYear_ClassCode");
                label11.Text = Loc.Get("NewYear_Description");
                label7.Text = Loc.Get("NewYear_NextClassCode");

                // Labels - Other
                label4.Text = Loc.Get("NewYear_SchoolCode");
                lblChooseNextStudents.Text = Loc.Get("NewYear_StudentsToInclude");
                lblClassDescription.Text = Loc.Get("NewYear_NewClassDescription");

                // Buttons
                BtnClassNew.Text = Loc.Get("NewYear_NewClass");
                BtnClassMigration.Text = Loc.Get("NewYear_PrepareClass");
                BtnClassGeneration.Text = Loc.Get("NewYear_GenerateClass");
                BtnStudentNew.Text = Loc.Get("NewYear_NewStudent");
                btnNewYear.Text = Loc.Get("NewYear_CreateNewYear");
                btnAssociateSchoolPeriodsToTheYear.Text = Loc.Get("NewYear_PreparePeriods");

                // DataGridView Columns
                SaveThisStudent.HeaderText = Loc.Get("NewYear_SaveStudent");

                // Tooltips
                toolTip1.SetToolTip(btnNewYear, Loc.Get("NewYear_Tooltip_CreateNewYear"));
                toolTip1.SetToolTip(btnAssociateSchoolPeriodsToTheYear, Loc.Get("NewYear_Tooltip_PreparePeriods"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmNewYear.LocalizeForm: {ex.Message}");
            }
        }
    }
}

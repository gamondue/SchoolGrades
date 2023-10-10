using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            idStartYear = IdStartYear;
        }
        private void frmNewYear_Load(object sender, EventArgs e)
        {
            loading = true;
            
            // school data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);

            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            cmbSchoolYearCurrents.DataSource = ly;

            //Rehab was suppose
            
            // years's data in combo
            
            if (ly.Count > 0)
                cmbSchoolYearCurrents.SelectedItem = ly[ly.Count - 1];
            cmbSchoolYearCurrents.SelectedItem = idStartYear;
            currentSchoolYear = (SchoolYear)cmbSchoolYearCurrents.SelectedItem;

            cmbClasses.DataSource = Commons.bl.GetClassesOfYear(
                currentSchool.IdSchool, currentSchoolYear.IdSchoolYear);
            cmbClasses.SelectedIndex = 0;

            currentClass = (Class)cmbClasses.SelectedItem;

            //nextClass = new Class(); 
            //nextSchoolYear = new SchoolYear();

            loading = false;
            nextSchoolYear = Commons.bl.GenerateNewYearData(currentSchoolYear);
            nextClass= Commons.bl.GenerateNewClassData(currentClass);
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
                Commons.bl.msgChooseClass();
            }
            Class c = (Class)cmbClasses.SelectedItem;
            if (c != null)
            {
                DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                    cmbSchoolYearCurrents.Text, cmbClasses.Text, true);

                currentClass = (Class)cmbClasses.SelectedItem;
                // check all the student's rows 
                foreach (DataGridViewRow dr in DgwStudents.Rows)
                {
                    string sy = txtSchoolYearNext.Text;
                    string ca = txtClassAbbreviationNext.Text;

                    Commons.bl.resetStudent(sy, ca, dr);
                    
                }
                //txtClassDescriptionNext.Text = currentSchool.Name + " " + txtSchoolYearNext.Text +
                //    " " + txtClassAbbreviationNext.Text;
                //txtClassDescriptionNext.Visible = true;
                //lblClassDescription.Visible = true; 

                Commons.bl.messaggioAggiustareDati();
            }
            BtnClassGeneration.Visible = true;
            BtnClassMigration.Visible = false;
        }
        private void BtnClassGeneration_Click(object sender, EventArgs e)
        {
            if (txtClassAbbreviationNext.Text == "")
            {
                Commons.bl.SiglaClasse();
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

            MessageBox.Show("Creazione classe " + txtClassAbbreviationNext.Text + " " + txtSchoolYearNext.Text + " terminata");
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
            Commons.bl.ToDo();
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
            frmSchoolYearAndPeriodsManagement f = new frmSchoolYearAndPeriodsManagement(txtSchoolYearNext.Text);
            f.ShowDialog();
        }
        //rehab was supposed to be a fresh start 🐎🍾
    }
}

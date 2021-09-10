using SchoolGrades.DbClasses;
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

        DataSet dsClass;
        DataTable dtClass;

        DataSet dsStudents;
        DataTable dtStudents;
        private int addedRowIndex;

        public frmNewYear(string IdStartYear)
        {
            InitializeComponent();

            idStartYear = IdStartYear;
        }

        private void frmNewYear_Load(object sender, EventArgs e)
        {
            // school data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);

            // first default year in the "years" combo
            int anno = 2009;

            for (; anno <= DateTime.Now.Year; anno++)
            {
                CmbPresentSchoolYear.Items.Add((anno - 2000).ToString("00") + ((anno + 1) - 2000).ToString("00"));
            }
            int nAnni = CmbPresentSchoolYear.Items.Count;
            if (DateTime.Now.Month >= 9)
                CmbPresentSchoolYear.SelectedItem = CmbPresentSchoolYear.Items[nAnni - 1];
            else
                CmbPresentSchoolYear.SelectedItem = CmbPresentSchoolYear.Items[nAnni - 2];

            CmbPresentSchoolYear.Text = idStartYear;
        }

        private void BtnClassMigration_Click(object sender, EventArgs e)
        {
            Class currentClass;
            //BtnStudentNew.Visible = true;
            if (CmbClasses.Text == "")
            {
                MessageBox.Show("Scegliere una classe di partenza");
                return; 
            }
            // try to increase the number of the class, leaving the rest untouched 
            string previousClass = CmbClasses.Text;
            string oldClassNo = new String(previousClass.Where(Char.IsDigit).ToArray()); // LINQ
            int newNo = int.Parse(oldClassNo);
            newNo++;
            string newClassNo = newNo.ToString(); 
            string nextClass = previousClass.Replace(oldClassNo, (newNo).ToString());
            TxtClassNext.Text = nextClass; 

            Class c = (Class)CmbClasses.SelectedItem;
            if (c != null)
            {
                dtClass = Commons.bl.GetClassTable(c.IdClass);

                DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                    CmbPresentSchoolYear.Text, CmbClasses.Text, true);

                currentClass = (Class)CmbClasses.SelectedItem;
                // check all the student's rows 
                foreach (DataGridViewRow dr in DgwStudents.Rows)
                {
                    Student st = (Student)dr.DataBoundItem;
                    st.IdClass = 0;
                    st.RegisterNumber = "";
                    st.SchoolYear = TxtSchoolYearNext.Text;
                    st.Class = TxtClassNext.Text;

                    st.Disabled = false;
                    st.Eligible = false;

                    dr.Cells[0].Value = false;
                }
                TxtClassDescription.Text = currentSchool.Name + " " + TxtSchoolYearNext.Text +
                    " " + TxtClassNext.Text;
                TxtClassDescription.Visible = true;
                lblClassDescription.Visible = true; 

                MessageBox.Show("Aggiustare i dati della classe e degli studenti\r\nSegnare gli studenti da INCLUDERE " +
                    "nella nuova classe, con il segno di spunta a sinistra, poi premere 'Genera classe'"+
                    "\r\nPer aggiungere allievi tornare alla finestra precedente di gestione classi" +
                    "\r\nPremendo 'Annulla' non si importerà la classe",
                    "Modifiche classe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            BtnClassGenerate.Visible = true;
            BtnClassMigration.Visible = false;
        }

        private void txtNextSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = txtNextSchoolYear.SelectedIndex + 1; 
            //txtNextSchoolYear.Text = txtNextSchoolYear.Items[index].ToString(); 
        }

        private void BtnClassGenerate_Click(object sender, EventArgs e)
        {
            if (TxtClassNext.Text == "")
            {
                MessageBox.Show("Scrivere la sigla della nuova classe!");
                return; 
            }
            string classDescription = currentSchool.Desc + " " + TxtSchoolYearNext.Text + " " + TxtClassNext.Text; 
            int classCode = Commons.bl.CreateClass(TxtClassNext.Text, classDescription, 
                TxtSchoolYearNext.Text, TxtOfficialSchoolAbbreviation.Text);

            int studentDone = 0; 
            foreach(DataGridViewRow r in DgwStudents.Rows)
            {   
                // don't include students whose rows are non checked
                if ((bool)r.Cells["SaveThisStudent"].Value == true)  
                {
                    studentDone++;
                    ((Student)r.DataBoundItem).RegisterNumber = studentDone.ToString(); 
                    Commons.bl.PutStudentInClass((int)r.Cells["idStudent"].Value, classCode);
                    Commons.bl.AddLinkToOldPhoto((int)r.Cells["idStudent"].Value, CmbPresentSchoolYear.Text, TxtSchoolYearNext.Text);
                    Commons.bl.UpdateStudent((Student)r.DataBoundItem); 
                }
            }
            MessageBox.Show("Creazione classe " + TxtClassNext.Text + " " + TxtSchoolYearNext.Text + " terminata");
            //BtnStudentNew.Visible = false;
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
            MessageBox.Show("!!!! TO DO !!!!"); 
        }

        private void DgwStudents_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            addedRowIndex = e.RowIndex;
        }

        private void TxtSchoolYearPresent_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSchoolYearPresent_Leave(object sender, EventArgs e)
        {

        }

        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string next = CmbPresentSchoolYear.Text.Substring(2, 2);
            int yea = int.Parse(next);
            TxtSchoolYearNext.Text = yea.ToString() + (yea + 1).ToString();

            string idSchoolYear = CmbPresentSchoolYear.SelectedItem.ToString();
            CmbClasses.DataSource = null; 
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnClassMigration.Visible = true;
        }
    }
}

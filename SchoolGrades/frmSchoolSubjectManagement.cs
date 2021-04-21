using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class FrmSchoolSubjectManagement : Form
    {
        DbAndBusiness db;
        SchoolSubject currentSubject;
        List<SchoolSubject> subjectList;  

        public FrmSchoolSubjectManagement()
        {
            InitializeComponent();
            db = new DbAndBusiness(Commons.PathAndFileDatabase);
        }

        private void frmSchoolSubjectManagement_Load(object sender, EventArgs e)
        {
            subjectList = db.GetListSchoolSubjects(false); 
            DgwSubjects.DataSource = subjectList; 
        }

        private void btn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgwSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? index; 
            if (e.RowIndex > -1)
            {
                DgwSubjects.Rows[e.RowIndex].Selected = true;
                subjectList = ((List<SchoolSubject>)DgwSubjects.DataSource); 
                currentSubject = subjectList[e.RowIndex]; 
                int color = (int)currentSubject.Color;
                picSubjectColor.BackColor = Color.FromArgb((color & 0xFF0000) >> 16, (color & 0xFF00) >> 8, color & 0xFF);
            }
        }

        private void picSubjectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = picSubjectColor.BackColor;
            colorDialog1.ShowDialog();
            picSubjectColor.BackColor = colorDialog1.Color;
            currentSubject.Color = colorDialog1.Color.ToArgb();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.SaveSubjects(subjectList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SchoolSubject ss = new SchoolSubject (); 
            subjectList.Add(ss);
            DgwSubjects.DataSource = null; 
            DgwSubjects.DataSource = subjectList;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (DgwSubjects.SelectedRows == null)
            {
                MessageBox.Show("Scegliere la materia da cancellare");
                return; 
            }
            
            if (MessageBox.Show("Cancellare la materia " + currentSubject.Name, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                db.SaveSubjects(subjectList); 
                subjectList = db.GetListSchoolSubjects(false);
                DgwSubjects.DataSource = subjectList;
            }
        }
    }
}

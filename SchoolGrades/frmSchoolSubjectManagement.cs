using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmSchoolSubjectManagement : Form
    {
        SchoolSubject currentSubject;
        List<SchoolSubject> subjectList;  
        public frmSchoolSubjectManagement()
        {
            InitializeComponent();
        }
        private void frmSchoolSubjectManagement_Load(object sender, EventArgs e)
        {
            RefreshGrid(); 
        }
        private void RefreshGrid()
        {
            subjectList = Commons.bl.GetListSchoolSubjects(false);
            DgwSubjects.DataSource = subjectList;
            DgwSubjects.Columns["OldId"].Visible = false;
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
                if (currentSubject.Color != null)
                {
                    int color = (int)currentSubject.Color;
                    picSubjectColor.BackColor = Color.FromArgb((color & 0xFF0000) >> 16, (color & 0xFF00) >> 8, color & 0xFF);
                }
            }
        }
        private void DgwSubjects_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 
                && (DgwSubjects.Rows[e.RowIndex].Cells["OldId"].Value != DgwSubjects.Rows[e.RowIndex].Cells["IdSchoolSubject"].Value
                    || DgwSubjects.Rows[e.RowIndex].Cells["OldId"].Value == null)
                )
            {
                object newKey = DgwSubjects.Rows[e.RowIndex].Cells["IdSchoolSubject"].Value;
                if (newKey != null)
                {
                    string warning = Commons.bl.CheckNewKeySchoolSubject(newKey.ToString());
                    if (warning != "")
                    {
                        MessageBox.Show(warning);
                        DgwSubjects[e.ColumnIndex, e.RowIndex].Value = "";
                    }
                }
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
            Commons.bl.SaveSubjects(subjectList);
            subjectList = Commons.bl.GetListSchoolSubjects(false);
            DgwSubjects.DataSource = subjectList;
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
                Commons.bl.EraseSchoolSubjectById(currentSubject.IdSchoolSubject); 
                subjectList = Commons.bl.GetListSchoolSubjects(false);
                DgwSubjects.DataSource = subjectList;
            }
        }
    }
}

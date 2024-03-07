using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    internal partial class frmAnnotationsPopUp : Form
    {
        internal DataTable tableOfActivePopUpAnnotations;

        internal frmAnnotationsPopUp(DataTable TableOfClassAnnotations)
        {
            InitializeComponent();

            tableOfActivePopUpAnnotations = TableOfClassAnnotations;
        }
        private void frmAnnotationsPopUp_Load(object sender, EventArgs e)
        {
            dgwStudentsAllPopUpAnnotations.DataSource = tableOfActivePopUpAnnotations; 
        }
        private void lblCurrentStudent_Click(object sender, EventArgs e)
        {

        }
        private void dgwStudentsActivePopUpAnnotations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwStudentsAllPopUpAnnotations.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgwStudentsAllPopUpAnnotations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwStudentsAllPopUpAnnotations.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgwStudentsActivePopUpAnnotations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgwStudentsAllPopUpAnnotations.Rows[e.RowIndex].Selected = true;
                if (dgwStudentsAllPopUpAnnotations.SelectedRows.Count > 0)
                {
                    int idStudent = (int)dgwStudentsAllPopUpAnnotations.SelectedRows[0].Cells["IdStudent"].Value;
                    Student s = Commons.bl.GetStudent(idStudent);
                    List<Student> SingleStudent = new List<Student>();
                    SingleStudent.Add(s);

                    frmAnnotationsAboutStudents f = new frmAnnotationsAboutStudents(SingleStudent, null);
                    f.StartPosition = FormStartPosition.CenterParent; 
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Scegliere un'annotazione da modificare");
                }
            }
        }
    }
}

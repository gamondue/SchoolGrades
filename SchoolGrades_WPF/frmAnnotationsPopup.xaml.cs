using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for AnnotationPopup.xaml
    /// </summary>
    public partial class frmAnnotationsPopUp : Window
    {
        public DataTable tableOfActivePopUpAnnotations;

        public frmAnnotationsPopUp(DataTable TableOfClassAnnotations)
        {
            InitializeComponent();

            tableOfActivePopUpAnnotations = TableOfClassAnnotations;
        }
        public void frmAnnotationsPopUp_Load(object sender, EventArgs e)
        {
            dgwStudentsAllPopUpAnnotations.ItemsSource = (System.Collections.IEnumerable)tableOfActivePopUpAnnotations;
        }
        private void lblCurrentStudent_Click(object sender, EventArgs e)
        {

        }
        private void dgwStudentsActivePopUpAnnotations_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                //dgwStudentsAllPopUpAnnotations.Items[RowIndex].Selected = true;
                dgwStudentsAllPopUpAnnotations.SelectedIndex = RowIndex;
                if (dgwStudentsAllPopUpAnnotations.SelectedItems.Count > 0)
                {
                    Student s = (Student)(dgwStudentsAllPopUpAnnotations.SelectedItems[0]);
                    int? idStudent = s.IdStudent;
                    s = Commons.bl.GetStudent(idStudent);
                    List<Student> SingleStudent = new List<Student>();
                    SingleStudent.Add(s);

                    frmAnnotationsAboutStudents f = new frmAnnotationsAboutStudents(SingleStudent, null);
                    //////////f.StartPosition = FormStartPosition.CenterParent;
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

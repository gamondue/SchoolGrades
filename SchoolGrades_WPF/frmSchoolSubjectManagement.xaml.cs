using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmSchoolSubjectManagement.xaml
    /// </summary>
    public partial class frmSchoolSubjectManagement : Page
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
            DgwSubjects.ItemsSource = subjectList;
            DgwSubjects.Columns["OldId"].Visibility = Visibility.Hidden;
        }

        private void btn_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void DgwSubjects_CellClick(object sender, RoutedEvent e)
        {
            int? index;
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                DgwSubjects.Items[RowIndex].Selected = true;
                subjectList = ((List<SchoolSubject>)DgwSubjects.ItemsSource);
                currentSubject = subjectList[RowIndex];
                if (currentSubject.Color != null)
                {
                    int color = (int)currentSubject.Color;
                    picSubjectColor.Background = Color.FromArgb((color & 0xFF0000) >> 16, (color & 0xFF00) >> 8, color & 0xFF);
                }
            }
        }
        private void DgwSubjects_CellLeave(object sender, RoutedEvent e)
        {
            if (e.ColumnIndex == 0
                && (DgwSubjects.Items[RowIndex].Cells["OldId"].Value != DgwSubjects.Items[RowIndex].Cells["IdSchoolSubject"].Value
                    || DgwSubjects.Items[RowIndex].Cells["OldId"].Value == null)
                )
            {
                object newKey = DgwSubjects.Items[RowIndex].Cells["IdSchoolSubject"].Value;
                if (newKey != null)
                {
                    string warning = Commons.bl.CheckNewKeySchoolSubject(newKey.ToString());
                    if (warning != "")
                    {
                        MessageBox.Show(warning);
                        DgwSubjects[e.ColumnIndex, RowIndex].Value = "";
                    }
                }
            }
        }
        private void picSubjectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = picSubjectColor.Background;
            colorDialog1.ShowDialog();
            picSubjectColor.Background = colorDialog1.Color;
            currentSubject.Color = colorDialog1.Color.ToArgb();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Commons.bl.SaveSubjects(subjectList);
            subjectList = Commons.bl.GetListSchoolSubjects(false);
            DgwSubjects.ItemsSource = subjectList;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SchoolSubject ss = new SchoolSubject();
            subjectList.Add(ss);
            DgwSubjects.ItemsSource = null;
            DgwSubjects.ItemsSource = subjectList;
        }
        private void btnErase_Click(object sender, EventArgs e)
        {
            if (DgwSubjects.SelectedItems == null)
            {
                MessageBox.Show("Scegliere la materia da cancellare");
                return;
            }

            if (MessageBox.Show("Cancellare la materia " + currentSubject.Name, "", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Commons.bl.EraseSchoolSubjectById(currentSubject.IdSchoolSubject);
                subjectList = Commons.bl.GetListSchoolSubjects(false);
                DgwSubjects.ItemsSource = subjectList;
            }
        }
    }
}

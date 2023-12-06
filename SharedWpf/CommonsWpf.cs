using SchoolGrades.BusinessObjects;
using SchoolGrades_WPF;
using System;
using System.Windows;
using System.Windows.Media;

namespace SharedWpf
{
    internal class CommonsWpf
    {
        internal static System.Windows.Controls.Image globalPicLed;
        //internal static TreeMptt SaveTreeMptt;

        private static Color ColorNoSubject = Colors.PowderBlue;

        internal static bool CheckIfTypeOfAssessmentChosen(GradeType GradeType)
        {
            if (GradeType == null)
            {
                MessageBox.Show("Scegliere un tipo di valutazione", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfSubjectChosen(SchoolSubject SchoolSubject)
        {
            if (SchoolSubject == null)
            //if (cmbSchoolSubject.SelectedItem == null || cmbSchoolSubject.Text == "")
            {
                MessageBox.Show("Scegliere una materia", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfClassChosen(Class CurrentClass)
        {
            // Commons.CurrentClass 
            if (CurrentClass == null)
            {
                MessageBox.Show("Scegliere una classe", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                MessageBox.Show("Scegliere un allievo"
                    , "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static Color ColorFromNumber(SchoolSubject Subject)
        {
            if (Subject == null || Subject.Color == null || Subject.Color == 0)
                return ColorNoSubject;
            // extract the color components from the RGB number
            byte red = (byte)((Subject.Color & 0xFF0000) >> 16);
            byte green = (byte)((Subject.Color & 0xFF00) >> 8);
            byte blue = (byte)(Subject.Color & 0xFF);
            Color bgColor = Color.FromRgb(red, green, blue);
            return bgColor;
        }

        internal static void RestoreCurrentValuesOfAllControls(frmMain frmMain, string file)
        {
            throw new NotImplementedException();
        }
    }
}

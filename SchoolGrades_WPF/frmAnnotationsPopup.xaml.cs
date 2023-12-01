using System.Data;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for AnnotationPopup.xaml
    /// </summary>
    public partial class frmAnnotationsPopup : Window
    {
        public frmAnnotationsPopup()
        {
            InitializeComponent();
        }

        public frmAnnotationsPopup(DataTable popUpAnnotations)
        {
        }
    }
}

using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmColorTimer.xaml
    /// </summary>
    public partial class frmColorTimer : Window
    {
        public frmColorTimer(double SecondsFirst, double SecondsSecond, bool SoundEffectsInTimer)
        {
            InitializeComponent();

        }

        public string FormCaption { get; internal set; }
    }
}

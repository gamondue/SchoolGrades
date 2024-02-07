using SchoolGrades;
using System;
using System.Windows;
using System.Windows.Media;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmRandom.xaml
    /// </summary>
    public partial class frmRandom : Window
    {
        Random rnd = new Random();
        public frmRandom()
        {
            InitializeComponent();
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // !!!! TODO protect program from user's bad input !!!! 
            //int randomNumber = rnd.Next(int.Parse(txtFrom.Text), int.Parse(txtTo.Text.ToString())+1);
            int randomNumber = Commons.bl.RandomNumber(int.Parse(txtFrom.Text),
                int.Parse(txtTo.Text.ToString()) + 1);
            txtResult.Text = randomNumber.ToString();
            if (txtResult.Background == Brushes.Goldenrod)
                txtResult.Background = Brushes.YellowGreen;
            else
                txtResult.Background = Brushes.Goldenrod;
            Clipboard.SetText(txtResult.Text);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            int randomNumber = Commons.bl.RandomNumber(int.Parse(txtFrom.Text), int.Parse(txtTo.Text.ToString()) + 1);
            txtResult.Text = randomNumber.ToString();
            if (txtResult.BackColor == Color.Goldenrod)
                txtResult.BackColor = Color.YellowGreen;
            else
                txtResult.BackColor = Color.Goldenrod;
            Clipboard.SetText(txtResult.Text);
        }

    }
}

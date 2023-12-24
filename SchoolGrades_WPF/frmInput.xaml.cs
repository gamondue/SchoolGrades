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
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class frmInput : Window
    {
        public frmInput(string Label1, string Label2, string Label3,
            Color BackColor, bool ThirdIsPassword)
        {
            InitializeComponent();

            this.label1.Text = Label1;
            this.label2.Text = Label2;
            this.label3.Text = Label3;
            this.Background = BackColor;
            if (ThirdIsPassword)
                txtInput3.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void frmInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}

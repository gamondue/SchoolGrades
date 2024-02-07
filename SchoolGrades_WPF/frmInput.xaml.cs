using System;
using System.Windows;
using System.Windows.Media;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class frmInput : Window
    {
        public frmInput(string Label1, string Label2, string Label3,
            SolidColorBrush BackColor, bool ThirdIsPassword)
        {
            InitializeComponent();

            this.label1.Content = Label1;
            this.label2.Content = Label2;
            this.label3.Content = Label3;
            this.Background = BackColor;
            //////////if (ThirdIsPassword)
            //////////    txtInput3.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult;
            this.Close();
        }
        ////////////private void frmInput_KeyDown(object sender, KeyEventArgs e)
        ////////////{
        ////////////    if (e.KeyCode == Keys.Enter)
        ////////////        button1_Click(null, null);
        ////////////}
    }
}

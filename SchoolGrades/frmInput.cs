using System;
using System.Drawing;
using System.Windows.Forms;
using SchoolGrades.Localization;

namespace gamon.gamon
{
    public partial class frmInput : Form
    {
        public frmInput (string Label1, string Label2, string Label3, 
            Color BackColor, bool ThirdIsPassword)
        {
            InitializeComponent();

            LocalizeForm();

            this.label1.Text = Label1;
            this.label2.Text = Label2;
            this.label3.Text = Label3;
            this.BackColor = BackColor;
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
        private void LocalizeForm()
        {
            try
            {
                // Button
                button1.Text = Loc.Get("Input_OK");

                // NOTA: I labels label1, label2, label3 vengono impostati
                // dinamicamente nel codice prima di mostrare il form.
                // Non necessitano di localizzazione qui.
            }
            catch (Exception ex)
            {
                // NOTA: Commons potrebbe non essere accessibile dal namespace gamon.gamon
                Console.WriteLine($"frmInput.LocalizeForm: {ex.Message}");
            }
        }
    }
}

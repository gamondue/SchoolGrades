using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmInputBox : Form
    {
        public string Value { get; set; }
        public frmInputBox(string Title, string PromptText, string InitialValue)
        {
            InitializeComponent();
            this.Text = Title;
            label.Text = PromptText;
            textBox.Text = InitialValue;
            Value = InitialValue;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = buttonOk;
            this.CancelButton = buttonCancel;
            //this.ClientSize = new Size(Math.Max(300, label.Right + 10), this.ClientSize.Height);
        }
        private void frmInputBox_Load(object sender, EventArgs e)
        {

        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Value = textBox.Text;
            DialogResult dialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Value = "";
            DialogResult dialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

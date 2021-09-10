using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gamon.gamon
{
    public partial class frmInput : Form
    {
        public frmInput (string Label1, string Label2, string Label3, 
            Color BackColor, bool ThirdIsPassword)
        {
            InitializeComponent();

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
    }
}

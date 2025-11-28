using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolGrades.Localization;

namespace SchoolGrades
{
    public partial class frmRandom : Form
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

        private void frmRandom_Load(object sender, EventArgs e)
        {
            // Initialize localization
            LocalizeForm();
        }

        private void LocalizeForm()
        {
            try
            {
                this.Text = Loc.Get("Random_Title");
                label1.Text = Loc.Get("Random_From");
                label2.Text = Loc.Get("Random_To");
                btnDraw.Text = Loc.Get("Random_Draw");
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmRandom.LocalizeForm: {ex.Message}");
            }
        }
    }
}

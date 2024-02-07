using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Windows;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmAnswer.xaml
    /// </summary>
    public partial class frmAnswer : Window
    {
        internal Answer currentAnswer = new Answer();

        public frmAnswer()
        {
            InitializeComponent();
        }
        public frmAnswer(Answer Answer)
        {
            InitializeComponent();
            currentAnswer = Answer;
        }
        public frmAnswer(int? IdQuestion)
        {
            InitializeComponent();
            this.currentAnswer.IdQuestion = IdQuestion;
        }
        private void frmAnswer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            txtIdAnswer.Text = currentAnswer.IdAnswer.ToString();
            txtIdQuestion.Text = currentAnswer.IdQuestion.ToString();
            txtErrorCost.Text = currentAnswer.ErrorCost.ToString();
            txtText.Text = currentAnswer.Text;
            rdbIsOpenAnswer.IsChecked = (bool)currentAnswer.IsOpenAnswer;
            rdbIsCorrect.IsChecked = (bool)currentAnswer.IsCorrect;
        }
        private void txtErrorCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currentAnswer.ErrorCost = int.Parse(txtErrorCost.Text);
            }
            catch
            {
                currentAnswer.ErrorCost = 0;
            }
        }
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            currentAnswer.Text = txtText.Text;
        }
        private void rdbIsOpenAnswer_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer.IsOpenAnswer = rdbIsOpenAnswer.IsChecked;
        }
        private void rdbIsCorrect_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer.IsCorrect = rdbIsCorrect.IsChecked;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentAnswer.IdQuestion == 0)
            {
                MessageBox.Show("Salvare prima il testo della domanda");
                return;
            }
            if (currentAnswer.IdAnswer == 0)
            {
                currentAnswer.IdAnswer = Commons.bl.CreateAnswer(currentAnswer);
                txtIdAnswer.Text = currentAnswer.IdAnswer.ToString();
            }
            Commons.bl.SaveAnswer(currentAnswer);
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            Commons.bl.SaveAnswer(currentAnswer);
            this.Close();
        }
        private void frmAnswer_FormClosing(object sender, RoutedEvent e)
        {
            // id I close without having saved, I don't save! 
            // to signal the calling program tha it has'nt to save, I put 0 in the answer code
            currentAnswer.IdAnswer = 0;
        }
    }
}

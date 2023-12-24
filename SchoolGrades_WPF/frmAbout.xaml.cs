using SchoolGrades;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmAbout.xaml
    /// </summary>
    public partial class frmAbout : Window
    {
        //public System.Windows.Forms.Label lblData;
        //public System.Windows.Forms.ToolTip ToolTip1;
        //public System.Windows.Forms.Label lblVersione;
        //public System.Windows.Forms.Timer Timer1;
        //public System.Windows.Forms.Label lblAssemblyTitle;
        //public System.Windows.Forms.Label lblAssemblyDescription;
        public Label label1;
        public Label label3;
        private Panel panel1;
        public Label label2;
        public Label label4;
        public Label label5;
        private Image pictureBox1;
        private System.ComponentModel.IContainer components;
        public frmAbout()
        {
            //
            // Necessario per il supporto di Progettazione Windows Form
            //
            InitializeComponent();

            // costruttore
        }
        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        //////////protected override void Dispose(bool disposing)
        //////////{
        //////////    if (disposing)
        //////////    {
        //////////        if (components != null)
        //////////        {
        //////////            components.Dispose();
        //////////        }
        //////////    }
        //////////    //base.Dispose(disposing);
        //////////}
        private void frmAbout_Load(object sender, System.EventArgs e)
        {
            lblAssemblyTitle.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .FileDescription;
            lblAssemblyDescription.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .Comments;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersione.Text += version;
            lblData.Text = Commons.DateCompiled().ToString();
        }
        private void frmAbout_Activated(object sender, System.EventArgs e)
        {
            //////////Timer1.IsEnabled = false;
            //////////Timer1.Interval = 4000;
            //////////Timer1.IsEnabled = true;
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

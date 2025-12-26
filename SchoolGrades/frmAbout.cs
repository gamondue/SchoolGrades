using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using SchoolGrades;

namespace gamon
{
    /// <summary>
    /// Descrizione di riepilogo per frmAbout.
    /// </summary>
    public class frmAbout : Form
    {
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Timer Timer1;
        public System.Windows.Forms.Label lblAssemblyTitle;
        public System.Windows.Forms.Label lblAssemblyDescription;
        public Label label1;
        public Label label3;
        private Panel panel1;
        public Label label2;
        public Label label4;
        public Label label5;
        private PictureBox pictureBox1;
        public Label label6;
        public Label lblLicense;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Codice generato da Progettazione Windows Form
        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmAbout));
            lblDate = new Label();
            lblAssemblyTitle = new Label();
            ToolTip1 = new ToolTip(components);
            lblVersion = new Label();
            Timer1 = new Timer(components);
            lblAssemblyDescription = new Label();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            lblLicense = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.BackColor = System.Drawing.Color.White;
            lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Location = new System.Drawing.Point(305, 180);
            lblDate.Name = "lblDate";
            lblDate.RightToLeft = RightToLeft.No;
            lblDate.Size = new System.Drawing.Size(349, 36);
            lblDate.TabIndex = 16;
            lblDate.Text = "lblDate";
            lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAssemblyTitle
            // 
            lblAssemblyTitle.BackColor = System.Drawing.Color.White;
            lblAssemblyTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold);
            lblAssemblyTitle.ForeColor = System.Drawing.Color.Black;
            lblAssemblyTitle.Location = new System.Drawing.Point(303, 62);
            lblAssemblyTitle.Name = "lblAssemblyTitle";
            lblAssemblyTitle.RightToLeft = RightToLeft.No;
            lblAssemblyTitle.Size = new System.Drawing.Size(353, 47);
            lblAssemblyTitle.TabIndex = 17;
            lblAssemblyTitle.Text = "lblAssemblyTitle";
            lblAssemblyTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVersion
            // 
            lblVersion.BackColor = System.Drawing.Color.White;
            lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblVersion.ForeColor = System.Drawing.Color.Black;
            lblVersion.Location = new System.Drawing.Point(301, 144);
            lblVersion.Name = "lblVersion";
            lblVersion.RightToLeft = RightToLeft.No;
            lblVersion.Size = new System.Drawing.Size(357, 36);
            lblVersion.TabIndex = 11;
            lblVersion.Text = "Version";
            lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Interval = 5000;
            Timer1.Tick += Timer1_Tick;
            // 
            // lblAssemblyDescription
            // 
            lblAssemblyDescription.BackColor = System.Drawing.Color.White;
            lblAssemblyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblAssemblyDescription.ForeColor = System.Drawing.Color.Black;
            lblAssemblyDescription.Location = new System.Drawing.Point(305, 109);
            lblAssemblyDescription.Name = "lblAssemblyDescription";
            lblAssemblyDescription.RightToLeft = RightToLeft.No;
            lblAssemblyDescription.Size = new System.Drawing.Size(349, 35);
            lblAssemblyDescription.TabIndex = 10;
            lblAssemblyDescription.Text = "lblAssemblyDescription";
            lblAssemblyDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.White;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(366, 258);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new System.Drawing.Size(239, 30);
            label1.TabIndex = 23;
            label1.Text = "prof. Gabriele MONTI";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.White;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(332, 295);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new System.Drawing.Size(307, 26);
            label3.TabIndex = 21;
            label3.Text = "ITT Pascal - Cesena";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblLicense);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblDate);
            panel1.Controls.Add(lblAssemblyTitle);
            panel1.Controls.Add(lblVersion);
            panel1.Controls.Add(lblAssemblyDescription);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(11, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(658, 404);
            panel1.TabIndex = 24;
            // 
            // lblLicense
            // 
            lblLicense.BackColor = System.Drawing.Color.White;
            lblLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblLicense.ForeColor = System.Drawing.Color.Black;
            lblLicense.Location = new System.Drawing.Point(303, 216);
            lblLicense.Name = "lblLicense";
            lblLicense.RightToLeft = RightToLeft.No;
            lblLicense.Size = new System.Drawing.Size(349, 42);
            lblLicense.TabIndex = 29;
            lblLicense.Tag = "";
            lblLicense.Text = "SchoolGrades is free (Libre) software, under GPL v.2 license.";
            lblLicense.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.Color.White;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(374, 328);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new System.Drawing.Size(223, 26);
            label5.TabIndex = 27;
            label5.Text = "ITALIA";
            label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.Color.White;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic);
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Location = new System.Drawing.Point(366, 361);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new System.Drawing.Size(239, 29);
            label4.TabIndex = 26;
            label4.Text = "prof@ingmonti.it";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label2.ForeColor = System.Drawing.SystemColors.ControlText;
            label2.Location = new System.Drawing.Point(-1, 15);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new System.Drawing.Size(658, 47);
            label2.TabIndex = 25;
            label2.Text = "Questo programma è gratuito. L'Autore non fornisce alcuna forma di garanzia, nè di funzionalità, nè di rispondenza alle esigenze dell'utente.  ";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(-1, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(307, 315);
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new System.Drawing.Size(680, 428);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Activated += frmAbout_Activated;
            Load += frmAbout_Load;
            panel1.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }
        #endregion
        private void frmAbout_Load(object sender, System.EventArgs e)
        {
            lblAssemblyTitle.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .FileDescription;
            lblAssemblyDescription.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .Comments;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text += " " + version;
            DateTime? dt = Commons.DateCompiled();
            if (dt != null)
                lblDate.Text = ((DateTime)dt).ToString("yyyy-MM-dd HH:mm:ss");
            else
                lblDate.Text = "";
        }
        private void frmAbout_Activated(object sender, System.EventArgs e)
        {
            Timer1.Enabled = false;
            Timer1.Interval = 4000;
            Timer1.Enabled = true;
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

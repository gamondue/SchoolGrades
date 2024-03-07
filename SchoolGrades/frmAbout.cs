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
        public System.Windows.Forms.Label lblData;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.Label lblVersione;
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Codice generato da Progettazione Windows Form
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblData = new System.Windows.Forms.Label();
            this.lblAssemblyTitle = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblVersione = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblAssemblyDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblData.ForeColor = System.Drawing.Color.Black;
            this.lblData.Location = new System.Drawing.Point(304, 206);
            this.lblData.Name = "lblData";
            this.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblData.Size = new System.Drawing.Size(313, 24);
            this.lblData.TabIndex = 16;
            this.lblData.Text = "lblData";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblData.Visible = false;
            // 
            // lblAssemblyTitle
            // 
            this.lblAssemblyTitle.BackColor = System.Drawing.Color.White;
            this.lblAssemblyTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAssemblyTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAssemblyTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyTitle.Location = new System.Drawing.Point(304, 74);
            this.lblAssemblyTitle.Name = "lblAssemblyTitle";
            this.lblAssemblyTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAssemblyTitle.Size = new System.Drawing.Size(313, 47);
            this.lblAssemblyTitle.TabIndex = 17;
            this.lblAssemblyTitle.Text = "lblAssemblyTitle";
            this.lblAssemblyTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVersione
            // 
            this.lblVersione.BackColor = System.Drawing.Color.White;
            this.lblVersione.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVersione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersione.ForeColor = System.Drawing.Color.Black;
            this.lblVersione.Location = new System.Drawing.Point(296, 170);
            this.lblVersione.Name = "lblVersione";
            this.lblVersione.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersione.Size = new System.Drawing.Size(328, 36);
            this.lblVersione.TabIndex = 11;
            this.lblVersione.Text = "Versione ";
            this.lblVersione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 5000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblAssemblyDescription
            // 
            this.lblAssemblyDescription.BackColor = System.Drawing.Color.White;
            this.lblAssemblyDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAssemblyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAssemblyDescription.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyDescription.Location = new System.Drawing.Point(296, 121);
            this.lblAssemblyDescription.Name = "lblAssemblyDescription";
            this.lblAssemblyDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAssemblyDescription.Size = new System.Drawing.Size(328, 49);
            this.lblAssemblyDescription.TabIndex = 10;
            this.lblAssemblyDescription.Text = "lblAssemblyDescription";
            this.lblAssemblyDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(342, 230);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(239, 30);
            this.label1.TabIndex = 23;
            this.label1.Text = "prof. Gabriele MONTI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(317, 271);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(307, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "ITT Pascal - Cesena";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.lblAssemblyTitle);
            this.panel1.Controls.Add(this.lblVersione);
            this.panel1.Controls.Add(this.lblAssemblyDescription);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 384);
            this.panel1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(349, 308);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(223, 26);
            this.label5.TabIndex = 27;
            this.label5.Text = "ITALIA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(342, 345);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(239, 29);
            this.label4.TabIndex = 26;
            this.label4.Text = "prof@ingmonti.it";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 27);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(642, 47);
            this.label2.TabIndex = 25;
            this.label2.Text = "Questo programma è gratuito. L\'Autore non fornisce alcuna forma di garanzia, nè d" +
    "i funzionalità, nè di rispondenza alle esigenze dell\'utente.  ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 315);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(680, 403);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Activated += new System.EventHandler(this.frmAbout_Activated);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
            lblVersione.Text += version; 
            lblData.Text = Commons.DateCompiled().ToString();
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

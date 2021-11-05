
namespace SchoolGrades
{
    partial class frmRandom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRandom));
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(12, 32);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 33);
            this.txtFrom.TabIndex = 0;
            this.txtFrom.Text = "1";
            this.txtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(137, 32);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 33);
            this.txtTo.TabIndex = 1;
            this.txtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Da";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(137, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "A";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(137, 108);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(102, 54);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Sorteggio";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtResult.Location = new System.Drawing.Point(12, 108);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(100, 54);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(262, 174);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRandom";
            this.Text = "Numero casuale";
            this.Load += new System.EventHandler(this.frmRandom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ImageList imageList1;
    }
}

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRandom));
            txtFrom = new System.Windows.Forms.TextBox();
            txtTo = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnDraw = new System.Windows.Forms.Button();
            txtResult = new System.Windows.Forms.TextBox();
            imageList1 = new System.Windows.Forms.ImageList(components);
            SuspendLayout();
            // 
            // txtFrom
            // 
            txtFrom.Location = new System.Drawing.Point(12, 32);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new System.Drawing.Size(100, 33);
            txtFrom.TabIndex = 0;
            txtFrom.Text = "1";
            txtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtFrom.TextChanged += txtFrom_TextChanged;
            // 
            // txtTo
            // 
            txtTo.Location = new System.Drawing.Point(137, 32);
            txtTo.Name = "txtTo";
            txtTo.Size = new System.Drawing.Size(100, 33);
            txtTo.TabIndex = 1;
            txtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 25);
            label1.TabIndex = 2;
            label1.Text = "Da";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.PowderBlue;
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(137, 4);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 25);
            label2.TabIndex = 3;
            label2.Text = "A";
            // 
            // btnDraw
            // 
            btnDraw.Location = new System.Drawing.Point(137, 108);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new System.Drawing.Size(102, 54);
            btnDraw.TabIndex = 4;
            btnDraw.Text = "Sorteggio";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // txtResult
            // 
            txtResult.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtResult.Location = new System.Drawing.Point(12, 108);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new System.Drawing.Size(100, 54);
            txtResult.TabIndex = 5;
            txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            imageList1.ImageSize = new System.Drawing.Size(16, 16);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmRandom
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(262, 174);
            Controls.Add(txtResult);
            Controls.Add(btnDraw);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmRandom";
            Text = "Numero casuale";
            Load += frmRandom_Load;
            ResumeLayout(false);
            PerformLayout();
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
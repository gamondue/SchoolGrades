
namespace SchoolGrades
{
    partial class frmMosaic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMosaic));
            this.txtStudentsName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStudentsName
            // 
            this.txtStudentsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentsName.Location = new System.Drawing.Point(303, 217);
            this.txtStudentsName.Name = "txtStudentsName";
            this.txtStudentsName.Size = new System.Drawing.Size(311, 29);
            this.txtStudentsName.TabIndex = 0;
            this.txtStudentsName.Visible = false;
            // 
            // frmMosaic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.txtStudentsName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMosaic";
            this.Text = "Mosaico delle foto";
            this.Load += new System.EventHandler(this.frmMosaic_Load);
            this.Resize += new System.EventHandler(this.frmMosaic_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentsName;
    }
}
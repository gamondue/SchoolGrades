
namespace SchoolGrades
{
    partial class frmUsersManagement
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
            this.mtAddUser = new MetroFramework.Controls.MetroTile();
            this.mtDeleteUser = new MetroFramework.Controls.MetroTile();
            this.mtRefresh = new MetroFramework.Controls.MetroTile();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.mtSave = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // mtAddUser
            // 
            this.mtAddUser.ActiveControl = null;
            this.mtAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtAddUser.Location = new System.Drawing.Point(23, 63);
            this.mtAddUser.Name = "mtAddUser";
            this.mtAddUser.Size = new System.Drawing.Size(108, 67);
            this.mtAddUser.TabIndex = 0;
            this.mtAddUser.Text = "Add user";
            this.mtAddUser.UseCustomBackColor = true;
            this.mtAddUser.UseSelectable = true;
            this.mtAddUser.UseVisualStyleBackColor = false;
            this.mtAddUser.Click += new System.EventHandler(this.mtAddUser_Click);
            // 
            // mtDeleteUser
            // 
            this.mtDeleteUser.ActiveControl = null;
            this.mtDeleteUser.BackColor = System.Drawing.Color.Green;
            this.mtDeleteUser.Location = new System.Drawing.Point(137, 63);
            this.mtDeleteUser.Name = "mtDeleteUser";
            this.mtDeleteUser.Size = new System.Drawing.Size(113, 67);
            this.mtDeleteUser.TabIndex = 1;
            this.mtDeleteUser.Text = "Delete user";
            this.mtDeleteUser.UseCustomBackColor = true;
            this.mtDeleteUser.UseSelectable = true;
            this.mtDeleteUser.UseVisualStyleBackColor = false;
            this.mtDeleteUser.Click += new System.EventHandler(this.mtDeleteUser_Click);
            // 
            // mtRefresh
            // 
            this.mtRefresh.ActiveControl = null;
            this.mtRefresh.BackColor = System.Drawing.Color.Red;
            this.mtRefresh.Location = new System.Drawing.Point(256, 63);
            this.mtRefresh.Name = "mtRefresh";
            this.mtRefresh.Size = new System.Drawing.Size(102, 67);
            this.mtRefresh.TabIndex = 3;
            this.mtRefresh.Text = "Refresh";
            this.mtRefresh.UseCustomBackColor = true;
            this.mtRefresh.UseSelectable = true;
            this.mtRefresh.UseVisualStyleBackColor = false;
            this.mtRefresh.Click += new System.EventHandler(this.mtRefresh_Click);
            // 
            // grdUsers
            // 
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Location = new System.Drawing.Point(23, 136);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.RowHeadersWidth = 51;
            this.grdUsers.RowTemplate.Height = 29;
            this.grdUsers.Size = new System.Drawing.Size(934, 392);
            this.grdUsers.TabIndex = 4;
            this.grdUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellClick_1);
            this.grdUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellContentClick);
            // 
            // mtSave
            // 
            this.mtSave.ActiveControl = null;
            this.mtSave.BackColor = System.Drawing.Color.Blue;
            this.mtSave.Location = new System.Drawing.Point(364, 63);
            this.mtSave.Name = "mtSave";
            this.mtSave.Size = new System.Drawing.Size(107, 67);
            this.mtSave.TabIndex = 5;
            this.mtSave.Text = "Save all";
            this.mtSave.UseCustomBackColor = true;
            this.mtSave.UseSelectable = true;
            this.mtSave.UseVisualStyleBackColor = false;
            this.mtSave.Click += new System.EventHandler(this.mtSave_Click);
            // 
            // frmUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 551);
            this.Controls.Add(this.mtSave);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.mtRefresh);
            this.Controls.Add(this.mtDeleteUser);
            this.Controls.Add(this.mtAddUser);
            this.Name = "frmUsersManagement";
            this.Text = "USERS MANAGEMENT";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.frmUsersManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile mtAddUser;
        private MetroFramework.Controls.MetroTile mtDeleteUser;
        private MetroFramework.Controls.MetroTile mtRefresh;
        private System.Windows.Forms.DataGridView grdUsers;
        private MetroFramework.Controls.MetroTile mtSave;
    }
}
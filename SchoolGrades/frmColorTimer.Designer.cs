namespace gamon
{
    partial class ColorTimer
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorTimer));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStartNextInterval = new System.Windows.Forms.Button();
            this.txtIntervalNext = new System.Windows.Forms.TextBox();
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtInitialInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartFirstInterval = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkServer = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtMinutesLeft = new System.Windows.Forms.TextBox();
            this.txtSecondsLeft = new System.Windows.Forms.TextBox();
            this.lblMinutesLeft = new System.Windows.Forms.Label();
            this.lblSecondsLeft = new System.Windows.Forms.Label();
            this.chkSoundsInColorTimer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStartNextInterval
            // 
            this.btnStartNextInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartNextInterval.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartNextInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStartNextInterval.ForeColor = System.Drawing.Color.Black;
            this.btnStartNextInterval.Location = new System.Drawing.Point(200, 137);
            this.btnStartNextInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartNextInterval.Name = "btnStartNextInterval";
            this.btnStartNextInterval.Size = new System.Drawing.Size(192, 74);
            this.btnStartNextInterval.TabIndex = 0;
            this.btnStartNextInterval.Text = "Start Next";
            this.btnStartNextInterval.UseVisualStyleBackColor = false;
            this.btnStartNextInterval.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtIntervalNext
            // 
            this.txtIntervalNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntervalNext.BackColor = System.Drawing.Color.White;
            this.txtIntervalNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntervalNext.Location = new System.Drawing.Point(270, 50);
            this.txtIntervalNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIntervalNext.Name = "txtIntervalNext";
            this.txtIntervalNext.Size = new System.Drawing.Size(73, 35);
            this.txtIntervalNext.TabIndex = 7;
            this.txtIntervalNext.Text = "7";
            this.txtIntervalNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIntervalNext.TextChanged += new System.EventHandler(this.txtIntervallo_TextChanged);
            // 
            // txtCountDown
            // 
            this.txtCountDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountDown.BackColor = System.Drawing.Color.White;
            this.txtCountDown.Enabled = false;
            this.txtCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCountDown.Location = new System.Drawing.Point(79, 50);
            this.txtCountDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCountDown.Name = "txtCountDown";
            this.txtCountDown.ReadOnly = true;
            this.txtCountDown.Size = new System.Drawing.Size(83, 35);
            this.txtCountDown.TabIndex = 2;
            this.txtCountDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(343, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "min";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(170, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "s";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.Color.Black;
            this.progressBar1.Location = new System.Drawing.Point(6, 97);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 36);
            this.progressBar1.TabIndex = 5;
            // 
            // txtInitialInterval
            // 
            this.txtInitialInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialInterval.BackColor = System.Drawing.Color.White;
            this.txtInitialInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInitialInterval.Location = new System.Drawing.Point(270, 6);
            this.txtInitialInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInitialInterval.Name = "txtInitialInterval";
            this.txtInitialInterval.Size = new System.Drawing.Size(73, 35);
            this.txtInitialInterval.TabIndex = 7;
            this.txtInitialInterval.Text = "10";
            this.txtInitialInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitialInterval.TextChanged += new System.EventHandler(this.txtIntervalloIniziale_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(343, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "min";
            // 
            // btnStartFirstInterval
            // 
            this.btnStartFirstInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartFirstInterval.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartFirstInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStartFirstInterval.ForeColor = System.Drawing.Color.Black;
            this.btnStartFirstInterval.Location = new System.Drawing.Point(6, 137);
            this.btnStartFirstInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartFirstInterval.Name = "btnStartFirstInterval";
            this.btnStartFirstInterval.Size = new System.Drawing.Size(194, 74);
            this.btnStartFirstInterval.TabIndex = 9;
            this.btnStartFirstInterval.Text = "Start First";
            this.btnStartFirstInterval.UseVisualStyleBackColor = false;
            this.btnStartFirstInterval.Click += new System.EventHandler(this.btnStartFirstInterval_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(209, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "First";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(206, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Next";
            // 
            // chkServer
            // 
            this.chkServer.AutoSize = true;
            this.chkServer.ForeColor = System.Drawing.Color.Black;
            this.chkServer.Location = new System.Drawing.Point(6, 14);
            this.chkServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkServer.Name = "chkServer";
            this.chkServer.Size = new System.Drawing.Size(58, 19);
            this.chkServer.TabIndex = 12;
            this.chkServer.Text = "Server";
            this.chkServer.UseVisualStyleBackColor = true;
            this.chkServer.Visible = false;
            this.chkServer.CheckedChanged += new System.EventHandler(this.chkServer_CheckedChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(6, 48);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(66, 40);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Visible = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(6, -2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 19);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "R.C.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // txtMinutesLeft
            // 
            this.txtMinutesLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinutesLeft.BackColor = System.Drawing.Color.White;
            this.txtMinutesLeft.Enabled = false;
            this.txtMinutesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMinutesLeft.Location = new System.Drawing.Point(79, 6);
            this.txtMinutesLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMinutesLeft.Name = "txtMinutesLeft";
            this.txtMinutesLeft.ReadOnly = true;
            this.txtMinutesLeft.Size = new System.Drawing.Size(40, 35);
            this.txtMinutesLeft.TabIndex = 15;
            this.txtMinutesLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSecondsLeft
            // 
            this.txtSecondsLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecondsLeft.BackColor = System.Drawing.Color.White;
            this.txtSecondsLeft.Enabled = false;
            this.txtSecondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSecondsLeft.Location = new System.Drawing.Point(124, 6);
            this.txtSecondsLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSecondsLeft.Name = "txtSecondsLeft";
            this.txtSecondsLeft.ReadOnly = true;
            this.txtSecondsLeft.Size = new System.Drawing.Size(40, 35);
            this.txtSecondsLeft.TabIndex = 17;
            this.txtSecondsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinutesLeft
            // 
            this.lblMinutesLeft.AutoSize = true;
            this.lblMinutesLeft.BackColor = System.Drawing.Color.White;
            this.lblMinutesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMinutesLeft.ForeColor = System.Drawing.Color.Black;
            this.lblMinutesLeft.Location = new System.Drawing.Point(13, 215);
            this.lblMinutesLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinutesLeft.Name = "lblMinutesLeft";
            this.lblMinutesLeft.Size = new System.Drawing.Size(152, 55);
            this.lblMinutesLeft.TabIndex = 18;
            this.lblMinutesLeft.Text = "XXXX";
            this.lblMinutesLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecondsLeft
            // 
            this.lblSecondsLeft.AutoSize = true;
            this.lblSecondsLeft.BackColor = System.Drawing.Color.White;
            this.lblSecondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSecondsLeft.ForeColor = System.Drawing.Color.Black;
            this.lblSecondsLeft.Location = new System.Drawing.Point(209, 215);
            this.lblSecondsLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSecondsLeft.Name = "lblSecondsLeft";
            this.lblSecondsLeft.Size = new System.Drawing.Size(152, 55);
            this.lblSecondsLeft.TabIndex = 19;
            this.lblSecondsLeft.Text = "XXXX";
            this.lblSecondsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSoundsInColorTimer
            // 
            this.chkSoundsInColorTimer.AutoSize = true;
            this.chkSoundsInColorTimer.Checked = true;
            this.chkSoundsInColorTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoundsInColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkSoundsInColorTimer.ForeColor = System.Drawing.Color.Black;
            this.chkSoundsInColorTimer.Location = new System.Drawing.Point(6, 19);
            this.chkSoundsInColorTimer.Name = "chkSoundsInColorTimer";
            this.chkSoundsInColorTimer.Size = new System.Drawing.Size(70, 22);
            this.chkSoundsInColorTimer.TabIndex = 185;
            this.chkSoundsInColorTimer.Text = "Suoni";
            this.chkSoundsInColorTimer.UseVisualStyleBackColor = true;
            this.chkSoundsInColorTimer.CheckedChanged += new System.EventHandler(this.chkSoundsInColorTimer_CheckedChanged);
            // 
            // ColorTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 293);
            this.Controls.Add(this.chkSoundsInColorTimer);
            this.Controls.Add(this.lblSecondsLeft);
            this.Controls.Add(this.lblMinutesLeft);
            this.Controls.Add(this.txtSecondsLeft);
            this.Controls.Add(this.txtMinutesLeft);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chkServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStartFirstInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInitialInterval);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCountDown);
            this.Controls.Add(this.txtIntervalNext);
            this.Controls.Add(this.btnStartNextInterval);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ColorTimer";
            this.Text = "gamon Color Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorTimer_FormClosing);
            this.Load += new System.EventHandler(this.ColorTimer_Load);
            this.Resize += new System.EventHandler(this.ColorTimer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStartNextInterval;
        private System.Windows.Forms.TextBox txtIntervalNext;
        private System.Windows.Forms.TextBox txtCountDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtInitialInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartFirstInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtMinutesLeft;
        private System.Windows.Forms.TextBox txtSecondsLeft;
        private System.Windows.Forms.Label lblMinutesLeft;
        private System.Windows.Forms.Label lblSecondsLeft;
        private System.Windows.Forms.CheckBox chkSoun;
        private System.Windows.Forms.CheckBox chkSoundsInColorTimer;
    }
}


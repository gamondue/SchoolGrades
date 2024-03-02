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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorTimer));
            timer1 = new System.Windows.Forms.Timer(components);
            btnStartNextInterval = new System.Windows.Forms.Button();
            txtIntervalNext = new System.Windows.Forms.TextBox();
            txtCountDown = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            txtInitialInterval = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            btnStartFirstInterval = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            chkServer = new System.Windows.Forms.CheckBox();
            btnConnect = new System.Windows.Forms.Button();
            checkBox1 = new System.Windows.Forms.CheckBox();
            txtMinutesLeft = new System.Windows.Forms.TextBox();
            txtSecondsLeft = new System.Windows.Forms.TextBox();
            lblMinutesLeft = new System.Windows.Forms.Label();
            lblSecondsLeft = new System.Windows.Forms.Label();
            chkSoundsInColorTimer = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // btnStartNextInterval
            // 
            btnStartNextInterval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStartNextInterval.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnStartNextInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStartNextInterval.ForeColor = System.Drawing.Color.Black;
            btnStartNextInterval.Location = new System.Drawing.Point(200, 137);
            btnStartNextInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnStartNextInterval.Name = "btnStartNextInterval";
            btnStartNextInterval.Size = new System.Drawing.Size(192, 74);
            btnStartNextInterval.TabIndex = 0;
            btnStartNextInterval.Text = "Start Next";
            btnStartNextInterval.UseVisualStyleBackColor = false;
            btnStartNextInterval.Click += btnStart_Click;
            // 
            // txtIntervalNext
            // 
            txtIntervalNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtIntervalNext.BackColor = System.Drawing.Color.White;
            txtIntervalNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtIntervalNext.Location = new System.Drawing.Point(270, 50);
            txtIntervalNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtIntervalNext.Name = "txtIntervalNext";
            txtIntervalNext.Size = new System.Drawing.Size(73, 35);
            txtIntervalNext.TabIndex = 7;
            txtIntervalNext.Text = "7";
            txtIntervalNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtIntervalNext.TextChanged += txtIntervallo_TextChanged;
            // 
            // txtCountDown
            // 
            txtCountDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtCountDown.BackColor = System.Drawing.Color.White;
            txtCountDown.Enabled = false;
            txtCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCountDown.Location = new System.Drawing.Point(79, 50);
            txtCountDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCountDown.Name = "txtCountDown";
            txtCountDown.ReadOnly = true;
            txtCountDown.Size = new System.Drawing.Size(83, 35);
            txtCountDown.TabIndex = 2;
            txtCountDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(343, 55);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 25);
            label1.TabIndex = 3;
            label1.Text = "min";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(170, 55);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 25);
            label2.TabIndex = 4;
            label2.Text = "s";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar1.ForeColor = System.Drawing.Color.Black;
            progressBar1.Location = new System.Drawing.Point(6, 97);
            progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(386, 36);
            progressBar1.TabIndex = 5;
            // 
            // txtInitialInterval
            // 
            txtInitialInterval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtInitialInterval.BackColor = System.Drawing.Color.White;
            txtInitialInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtInitialInterval.Location = new System.Drawing.Point(270, 6);
            txtInitialInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtInitialInterval.Name = "txtInitialInterval";
            txtInitialInterval.Size = new System.Drawing.Size(73, 35);
            txtInitialInterval.TabIndex = 7;
            txtInitialInterval.Text = "10";
            txtInitialInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtInitialInterval.TextChanged += txtIntervalloIniziale_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(343, 12);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 25);
            label3.TabIndex = 8;
            label3.Text = "min";
            // 
            // btnStartFirstInterval
            // 
            btnStartFirstInterval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStartFirstInterval.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnStartFirstInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStartFirstInterval.ForeColor = System.Drawing.Color.Black;
            btnStartFirstInterval.Location = new System.Drawing.Point(6, 137);
            btnStartFirstInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnStartFirstInterval.Name = "btnStartFirstInterval";
            btnStartFirstInterval.Size = new System.Drawing.Size(194, 74);
            btnStartFirstInterval.TabIndex = 9;
            btnStartFirstInterval.Text = "Start First";
            btnStartFirstInterval.UseVisualStyleBackColor = false;
            btnStartFirstInterval.Click += btnStartFirstInterval_Click;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Location = new System.Drawing.Point(209, 13);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 25);
            label4.TabIndex = 10;
            label4.Text = "First";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(206, 55);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 25);
            label5.TabIndex = 11;
            label5.Text = "Next";
            // 
            // chkServer
            // 
            chkServer.AutoSize = true;
            chkServer.ForeColor = System.Drawing.Color.Black;
            chkServer.Location = new System.Drawing.Point(6, 6);
            chkServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkServer.Name = "chkServer";
            chkServer.Size = new System.Drawing.Size(58, 19);
            chkServer.TabIndex = 12;
            chkServer.Text = "Server";
            chkServer.UseVisualStyleBackColor = true;
            chkServer.Visible = false;
            chkServer.CheckedChanged += chkServer_CheckedChanged;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConnect.ForeColor = System.Drawing.Color.Black;
            btnConnect.Location = new System.Drawing.Point(6, 48);
            btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(66, 40);
            btnConnect.TabIndex = 13;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Visible = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = System.Drawing.Color.Black;
            checkBox1.Location = new System.Drawing.Point(170, 6);
            checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(47, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "R.C.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // txtMinutesLeft
            // 
            txtMinutesLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtMinutesLeft.BackColor = System.Drawing.Color.White;
            txtMinutesLeft.Enabled = false;
            txtMinutesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtMinutesLeft.Location = new System.Drawing.Point(79, 6);
            txtMinutesLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtMinutesLeft.Name = "txtMinutesLeft";
            txtMinutesLeft.ReadOnly = true;
            txtMinutesLeft.Size = new System.Drawing.Size(40, 35);
            txtMinutesLeft.TabIndex = 15;
            txtMinutesLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSecondsLeft
            // 
            txtSecondsLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSecondsLeft.BackColor = System.Drawing.Color.White;
            txtSecondsLeft.Enabled = false;
            txtSecondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSecondsLeft.Location = new System.Drawing.Point(124, 6);
            txtSecondsLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtSecondsLeft.Name = "txtSecondsLeft";
            txtSecondsLeft.ReadOnly = true;
            txtSecondsLeft.Size = new System.Drawing.Size(40, 35);
            txtSecondsLeft.TabIndex = 17;
            txtSecondsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinutesLeft
            // 
            lblMinutesLeft.AutoSize = true;
            lblMinutesLeft.BackColor = System.Drawing.Color.White;
            lblMinutesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMinutesLeft.ForeColor = System.Drawing.Color.Black;
            lblMinutesLeft.Location = new System.Drawing.Point(13, 215);
            lblMinutesLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblMinutesLeft.Name = "lblMinutesLeft";
            lblMinutesLeft.Size = new System.Drawing.Size(152, 55);
            lblMinutesLeft.TabIndex = 18;
            lblMinutesLeft.Text = "XXXX";
            lblMinutesLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecondsLeft
            // 
            lblSecondsLeft.AutoSize = true;
            lblSecondsLeft.BackColor = System.Drawing.Color.White;
            lblSecondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSecondsLeft.ForeColor = System.Drawing.Color.Black;
            lblSecondsLeft.Location = new System.Drawing.Point(209, 215);
            lblSecondsLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblSecondsLeft.Name = "lblSecondsLeft";
            lblSecondsLeft.Size = new System.Drawing.Size(152, 55);
            lblSecondsLeft.TabIndex = 19;
            lblSecondsLeft.Text = "XXXX";
            lblSecondsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSoundsInColorTimer
            // 
            chkSoundsInColorTimer.AutoSize = true;
            chkSoundsInColorTimer.Checked = true;
            chkSoundsInColorTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSoundsInColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chkSoundsInColorTimer.ForeColor = System.Drawing.Color.Black;
            chkSoundsInColorTimer.Location = new System.Drawing.Point(6, 31);
            chkSoundsInColorTimer.Name = "chkSoundsInColorTimer";
            chkSoundsInColorTimer.Size = new System.Drawing.Size(70, 22);
            chkSoundsInColorTimer.TabIndex = 185;
            chkSoundsInColorTimer.Text = "Suoni";
            chkSoundsInColorTimer.UseVisualStyleBackColor = true;
            chkSoundsInColorTimer.CheckedChanged += chkSoundsInColorTimer_CheckedChanged;
            // 
            // ColorTimer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(399, 293);
            Controls.Add(chkSoundsInColorTimer);
            Controls.Add(lblSecondsLeft);
            Controls.Add(lblMinutesLeft);
            Controls.Add(txtSecondsLeft);
            Controls.Add(txtMinutesLeft);
            Controls.Add(checkBox1);
            Controls.Add(btnConnect);
            Controls.Add(chkServer);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnStartFirstInterval);
            Controls.Add(label3);
            Controls.Add(txtInitialInterval);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCountDown);
            Controls.Add(txtIntervalNext);
            Controls.Add(btnStartNextInterval);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ColorTimer";
            Text = "gamon Color Timer";
            FormClosing += ColorTimer_FormClosing;
            Load += ColorTimer_Load;
            Resize += ColorTimer_Resize;
            ResumeLayout(false);
            PerformLayout();
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


using gamon.gamon;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace gamon
{
    public partial class ColorTimer : Form
    {
        bool alarmClock = false;
        bool isLoading = true;

        System.Media.SoundPlayer suonatore = new System.Media.SoundPlayer();

        double timeTotalSeconds;
        private double secondsFirst;
        private double secondsSecond;
        double timeLeftSeconds;

        Color initialColor = Color.Lime;
        //Color coloreIniziale = Color.Green;
        Color finalColor = Color.Red;
        Color currentColor;

        float spanHue;          // differenza di tinta da coprire
        float spanSaturation;   // differenza di saturazione da coprire
        float spanLuminance;    // differenza di saturazione da coprire

        string file = "C:\\temp\\ColorTimer.dat";

        private string password;
        int tcpPort;

        // Threading 
        ThreadServerReceiver receivingObjectForThead = null;
        Thread receivingThread;
        private bool clientConnected = false;
        private bool serverConnected = false;
        private string comandoAttuale;
        private string passwordDalClient;

        private bool firstCommand = false;
        private int nTentativi = 3;

        private int lastFormSize;

        bool playSoundEffects;
        DateTime initialTime;
        private DateTime finaltime;
        private double timeTotalMinutes;

        public string FormCaption { get => this.Text; set => this.Text = value; }
        public bool PlaySoundEffects
        {
            get
            {
                return playSoundEffects;
            }
            set
            {
                playSoundEffects = value;
                chkSoundsInColorTimer.Checked = value;
            }
        }
        public ColorTimer(double SecondsFirst, double SecondsSecond, bool SoundEffectsInTimer)
        {
            InitializeComponent();

            PlaySoundEffects = SoundEffectsInTimer;
            timeTotalSeconds = Convert.ToSingle(txtIntervalNext.Text);
            secondsFirst = SecondsFirst;
            secondsSecond = SecondsSecond;
        }
        private void ColorTimer_Load(object sender, EventArgs e)
        {
            lastFormSize = GetFormArea(this.Size);
            SetLabelsSizeAndPosition();

            //this.Text += " v." + System.Diagnostics.FileVersionInfo.GetVersionInfo
            //        (System.Reflection.Assembly.GetExecutingAssembly().Location)
            //        .ProductVersion;
            if (secondsFirst != 0)
            {
                txtInitialInterval.Text = secondsFirst.ToString();
                txtIntervalNext.Text = secondsSecond.ToString();
                btnStartFirstInterval_Click(null, null);
            }
            SetInitialColor();

            btnConnect.BackColor = currentColor;
            // set the difference of hue to cover from start to finish
            spanHue = finalColor.GetHue() - initialColor.GetHue();
            // we don't want to change Saturation and Luminance
            spanSaturation = 0;
            spanLuminance = 0;
            //spanSaturation = coloreFinale.GetSaturation() - coloreIniziale.GetSaturation(); // differenza da coprire
            //spanLuminance = coloreFinale.GetBrightness() - coloreIniziale.GetBrightness(); // differenza da coprire

            isLoading = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                VerifyExternalCommands();

                timeLeftSeconds = finaltime.Subtract(DateTime.Now).TotalSeconds;
                txtCountDown.Text = timeLeftSeconds.ToString("#");

                int minutes = (int)timeLeftSeconds / 60;
                txtMinutesLeft.Text = minutes.ToString("00");
                txtSecondsLeft.Text = (timeLeftSeconds % 60).ToString("00");
                lblMinutesLeft.Text = txtMinutesLeft.Text;
                lblSecondsLeft.Text = txtSecondsLeft.Text;

                //Color nuovo;
                ColorHelper.RGB colRGB = new ColorHelper.RGB();
                ColorHelper.HSL colHSL = new ColorHelper.HSL();

                // cambia colore dal colore iniziale a quello finale
                colHSL.Hue = (int)(initialColor.GetHue() + spanHue * (timeTotalSeconds - timeLeftSeconds) / (timeTotalSeconds));
                colHSL.Saturation = initialColor.GetSaturation() + spanSaturation * (timeTotalSeconds - timeLeftSeconds) / (timeTotalSeconds * 60);
                colHSL.Luminance = initialColor.GetBrightness() + spanLuminance * (timeTotalSeconds - timeLeftSeconds) / timeTotalSeconds;
                ColorHelper.ColorConverter.HSL2RGB(colHSL, colRGB);
                currentColor = colRGB.Color;
                try
                {
                    progressBar1.Value = (int)((timeTotalSeconds - timeLeftSeconds) / timeTotalSeconds * 100.0F);
                    //progressBar1.ForeColor = coloreAttuale;
                }
                catch
                {
                }
                this.BackColor = currentColor;
                btnStartNextInterval.BackColor = currentColor;
                btnStartFirstInterval.BackColor = currentColor;
                lblMinutesLeft.BackColor = currentColor;
                lblSecondsLeft.BackColor = currentColor;

                btnConnect.BackColor = currentColor;
                if (timeLeftSeconds < timeTotalSeconds * 0.2 * 60.0 && timeLeftSeconds > 1 && !alarmClock)
                {
                    if (PlaySoundEffects)
                    {
                        suonatore.SoundLocation = ".\\La Sveglia.wav";
                        suonatore.Play();
                    }
                    alarmClock = true;
                }
                if (timeLeftSeconds < 1)
                {
                    // reset period counter to the "next" value
                    alarmClock = false;
                    // read in timeTotalSeconds the interval
                    double.TryParse(txtIntervalNext.Text, out timeTotalMinutes);
                    if (timeTotalMinutes > 0)
                    {
                        finaltime = DateTime.Now.AddMinutes(timeTotalMinutes);
                        timeTotalSeconds = timeTotalMinutes * 60;
                        timeLeftSeconds = timeTotalSeconds;
                        txtCountDown.Text = timeLeftSeconds.ToString("#");
                    }
                    if (PlaySoundEffects)
                    {
                        suonatore.SoundLocation = ".\\Il silenzio.wav";
                        suonatore.Play();
                    }
                }
            }
            catch { }
            txtDayTime.Text = DateTime.Now.ToString("HH:mm:ss");
            TimeSpan timePassed = DateTime.Now - initialTime;
            txtTotalTime.Text = timePassed.ToString(@"hh\:mm\:ss");
        }
        private void VerifyExternalCommands()
        {
            if (receivingObjectForThead != null)
            {
                if (receivingObjectForThead.newCommand)
                {
                    receivingObjectForThead.newCommand = false;
                    comandoAttuale = receivingObjectForThead.command;
                    // primo contatto dal client: deve essere la password
                    if (firstCommand)
                    {
                        passwordDalClient = comandoAttuale.Substring(2);
                        if (nTentativi > 0)
                        {
                            if (comandoAttuale.Substring(0, 2) != "PW" ||
                                    password != passwordDalClient)
                            {
                                nTentativi--;
                            }
                        }

                        else
                        {
                            // password corretta

                        }
                        firstCommand = false;
                    } // non primo comando
                    else
                    {   // parse del comando "non password"
                        if (comandoAttuale == "START")
                        {
                            btnStartNext_Click(null, null);
                        }
                        else if (comandoAttuale == "BEGIN")
                        {
                            btnStartFirstInterval_Click(null, null);
                        }
                        else if (comandoAttuale.IndexOf("INT0") > -1)
                        {
                            txtInitialInterval.Text =
                                comandoAttuale.Substring(4);
                        }
                        else if (comandoAttuale.IndexOf("INT1") > -1)
                        {
                            txtIntervalNext.Text =
                                comandoAttuale.Substring(4);
                        }
                        else if (comandoAttuale.IndexOf("Collegamento interrotto") > -1)
                        {
                            chkServer.Checked = false;
                        }
                    }
                }
            }
        }
        private void txtIntervNext_TextChanged(object sender, EventArgs e)
        {
            //timer1.Enabled = false;  // per evitare corse
            //try
            //{
            //    aggiorna la durata ed anche il tempo rimasto, togliendogli il
            //    tempo già passato in questo periodo
            //    double giaFatti = (timeTotalSeconds * 60) - timeLeftSeconds;
            //    if (giaFatti > 0)
            //    {
            //        double temp = Convert.ToSingle(txtIntervalNext.Text);
            //        if (temp > 0)
            //        {
            //            timeTotalSeconds = Convert.ToSingle(txtIntervalNext.Text);
            //            timeLeftSeconds = timeTotalSeconds * 60 - giaFatti;
            //            txtCountDown.Text = timeLeftSeconds.ToString("#");
            //        }
            //    }
            //}
            //catch
            //{

            //}
            if (clientConnected)
                ClientTcp.Write("INT1" + txtIntervalNext.Text);
            //timer1.Enabled = true;
        }
        private void txtIntervalInitial_TextChanged(object sender, EventArgs e)
        {
            if (clientConnected)
                ClientTcp.Write("INT0" + txtInitialInterval.Text);
        }
        private void btnStartNext_Click(object sender, EventArgs e)
        {
            // read in timeTotalSeconds the interval
            double.TryParse(txtIntervalNext.Text, out timeTotalMinutes);
            if (timeTotalMinutes > 0)
            {
                finaltime = initialTime.AddMinutes(timeTotalMinutes);
                timeTotalSeconds = timeTotalMinutes * 60;
                timeLeftSeconds = timeTotalSeconds = timeTotalMinutes * 60;
                txtCountDown.Text = timeLeftSeconds.ToString("#");
                timer1.Enabled = true;
                SetInitialColor();
            }
            if (clientConnected)
                ClientTcp.Write("START");
            // set focus to hidden control to avoid clicking on a button
            // when the computer goes to a screen saver mode
            chkServer.Focus();
        }
        private void btnStartFirstInterval_Click(object sender, EventArgs e)
        {
            initialTime = DateTime.Now;
            // read in timeTotalSeconds the interval
            double.TryParse(txtInitialInterval.Text, out timeTotalMinutes);
            if (timeTotalMinutes > 0)
            {
                finaltime = initialTime.AddMinutes(timeTotalMinutes);
                timeTotalSeconds = timeTotalMinutes * 60;
                timeLeftSeconds = timeTotalSeconds;
                txtCountDown.Text = timeLeftSeconds.ToString("#");
                timer1.Enabled = true;
                SetInitialColor();
                if (clientConnected)
                    ClientTcp.Write("BEGIN");
                // set focus to hidden control to avoid clicking on a button
                // when the computer goes to a screen saver mode
                chkServer.Focus();
            }
        }
        private void SetInitialColor()
        {
            this.BackColor = initialColor;
            btnStartNextInterval.BackColor = initialColor;
            btnStartFirstInterval.BackColor = initialColor;

            lblSecondsLeft.BackColor = initialColor;
            lblMinutesLeft.BackColor = initialColor;

            currentColor = initialColor;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            frmInput f = new frmInput("IP Address or DNS name", "TCP Port", "Password (!! watch: it is sniffable !!)",
                initialColor, true);
            f.txtInput1.Text = "127.0.0.1";
            f.txtInput2.Text = "27759";
            f.txtInput3.Text = password;

            if (f.ShowDialog() == DialogResult.Cancel) return;

            string ipOrDns = f.txtInput1.Text;
            int tcpPort = Convert.ToInt16(f.txtInput2.Text);
            password = f.txtInput3.Text;

            try
            {
                //ClientTcp.Connect(ipOrDns, tcpPort, password);
                ClientTcp.Connect(ipOrDns, tcpPort);
                ClientTcp.Write("PW" + password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Collegamento impossibile \n" + ex.Message);
                return;
            }
            chkServer.Enabled = false;
            btnConnect.Enabled = false;
            clientConnected = true;
        }
        private void chkServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServer.Checked)
            {
                frmInput f = new frmInput("IP Address or DNS name", "TCP Port", "Password",
                    initialColor, true);
                f.txtInput1.Text = "127.0.0.1";
                f.txtInput2.Text = "27759";
                f.txtInput3.Text = password;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    chkServer.Checked = false;
                    return;
                }
                string ipOrDns = f.txtInput1.Text;
                int tcpPort = Convert.ToInt16(f.txtInput2.Text);
                password = f.txtInput3.Text;

                // istanzia un oggetto della classe che contiene il codice da eseguire in thread
                receivingObjectForThead = new ThreadServerReceiver(ipOrDns, tcpPort, password);
                // crea il thread Inizia()
                receivingThread = new Thread(receivingObjectForThead.StartColorTimerThread);
                serverConnected = true;
                chkServer.Enabled = false;
                btnConnect.Enabled = false;
                timer1.Enabled = true;
                // fa partire il thread Inizia()
                receivingThread.Start();

                firstCommand = true;
            }
            else // server non checked
            {
                if (receivingObjectForThead != null)
                {
                    receivingObjectForThead.RequestStop();
                    ServerTcp.Close();
                    receivingObjectForThead = null;
                    serverConnected = false;
                    chkServer.Enabled = true;
                    btnConnect.Enabled = true;
                }
            }
        }
        private void ColorTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receivingObjectForThead != null)
            {
                receivingObjectForThead.RequestStop();
                receivingObjectForThead = null;
            }
            ServerTcp.Close();
        }
        private void ColorTimer_Resize(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            SetLabelsSizeAndPosition();

            float scaleFactor = (float)GetFormArea(this.Size) / (float)lastFormSize;

            // scale font in minute's and second's labels
            lblMinutesLeft.Font = new Font(lblMinutesLeft.Font.FontFamily.Name,
                lblMinutesLeft.Font.Size * scaleFactor);
            lblSecondsLeft.Font = new Font(lblSecondsLeft.Font.FontFamily.Name,
                lblSecondsLeft.Font.Size * scaleFactor);

            // ResizeAllFontsInControls(this.Controls, scaleFactor);

            lastFormSize = GetFormArea(this.Size);
        }
        private void SetLabelsSizeAndPosition()
        {
            int Y = btnStartFirstInterval.Location.Y + btnStartFirstInterval.Size.Height;
            int height = this.Size.Height - Y;
            int width = (int)(this.Size.Width / 2);
            lblMinutesLeft.Size = new Size(width, height);
            lblSecondsLeft.Size = new Size(width, height);
            lblMinutesLeft.Location = new Point(0, Y);
            lblSecondsLeft.Location = new Point(width, Y);
        }
        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }
        private void ResizeAllFontsInControls(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeAllFontsInControls(c.Controls, scaleFactor);
                }
                else
                {
                    //if (c.GetType().ToString() == "System.Windows.Form.Label")
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }
        private void chkSoundsInColorTimer_CheckedChanged(object sender, EventArgs e)
        {
            playSoundEffects = chkSoundsInColorTimer.Checked;
        }
    }
}
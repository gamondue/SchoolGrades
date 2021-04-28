using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using gamon.gamon;

namespace gamon

{
    public partial class ColorTimer : Form
    {
        bool alarmClock = false;
        bool isLoading = true;

        System.Media.SoundPlayer suonatore = new System.Media.SoundPlayer();

        float timeTotalSeconds;
        private double secondsFirst;
        private double secondsSecond;
        float timeLeftSeconds;

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
        ThreadServerReceiver oggettoRicevitore = null;
        Thread threadRicevitore;
        private bool clientConnected = false;
        private bool serverConnected = false;
        private string comandoAttuale;
        private string passwordDalClient;

        private bool primoComando = false;
        private int nTentativi = 3;

        private int lastFormSize;

        bool playSoundEffects;
        public string FormCaption { get => this.Text; set => this.Text = value; }
        public bool PlaySoundEffects {
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

            this.Text += " v." + System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .ProductVersion;
            if (secondsFirst != 0)
            {
                txtInitialInterval.Text = secondsFirst.ToString();
                txtIntervalNext.Text = secondsSecond.ToString();
                btnStartFirstInterval_Click(null, null);
            }

            SetInitialColor(); 

            btnConnect.BackColor = currentColor;

            spanHue = finalColor.GetHue() - initialColor.GetHue(); // differenza di tinta da coprire
            //spanSaturation = coloreFinale.GetSaturation() - coloreIniziale.GetSaturation(); // differenza da coprire
            spanSaturation = 0;
            //spanLuminance = coloreFinale.GetBrightness() - coloreIniziale.GetBrightness(); // differenza da coprire
            spanLuminance = 0;

            isLoading = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                VerifyExternalCommands();

                timeLeftSeconds = Convert.ToSingle(txtCountDown.Text);
                timeLeftSeconds -= timer1.Interval / 1000;
                if (timeLeftSeconds < 0) timeLeftSeconds = Convert.ToSingle(txtIntervalNext.Text) * 60;
                txtCountDown.Text = Convert.ToString(timeLeftSeconds);

                int minutes = (int)timeLeftSeconds / 60;
                txtMinutesLeft.Text = minutes.ToString("00");
                txtSecondsLeft.Text = (timeLeftSeconds % 60).ToString("00");
                lblMinutesLeft.Text = txtMinutesLeft.Text;
                lblSecondsLeft.Text = txtSecondsLeft.Text;

                //Color nuovo;
                //nuovo.

                AForge.Imaging.RGB colRGB = new AForge.Imaging.RGB();
                AForge.Imaging.HSL colHSL = new AForge.Imaging.HSL();

                // cambia colore dal colore iniziale a quello finale
                colHSL.Hue = (int)(initialColor.GetHue() + spanHue * (timeTotalSeconds * 60 - timeLeftSeconds) / (timeTotalSeconds * 60));
                colHSL.Saturation = initialColor.GetSaturation() + spanSaturation * (timeTotalSeconds * 60 - timeLeftSeconds) / (timeTotalSeconds * 60);
                colHSL.Luminance = initialColor.GetBrightness() + spanLuminance * (timeTotalSeconds * 60 - timeLeftSeconds) / timeTotalSeconds;
                AForge.Imaging.ColorConverter.HSL2RGB(colHSL, colRGB);
                currentColor = colRGB.Color;
                try
                {
                    progressBar1.Value = (int)((timeTotalSeconds * 60 - timeLeftSeconds) / (timeTotalSeconds * 60) * 100.0F);
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

                if (timeLeftSeconds < timeTotalSeconds * 0.2 * 60.0 && !alarmClock)
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
                    if (PlaySoundEffects)
                    {
                        suonatore.SoundLocation = ".\\Il silenzio.wav";
                        suonatore.Play();
                    }
                    txtCountDown.Text = Convert.ToString(timeTotalSeconds * 60);
                    alarmClock = false;

                    timeTotalSeconds = Convert.ToSingle(txtIntervalNext.Text);
                    timeLeftSeconds = timeTotalSeconds * 60;
                    txtCountDown.Text = timeLeftSeconds.ToString();
                }
            }
            catch { }
        }
        private void VerifyExternalCommands()
        {
            if (oggettoRicevitore != null)
            {
                if (oggettoRicevitore.NuovoComando)
                {
                    oggettoRicevitore.NuovoComando = false;
                    comandoAttuale = oggettoRicevitore.Comando;

                    // primo contatto dal client: deve essere la password
                    if (primoComando)
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
                        primoComando = false;
                    } // non primo comando
                    else
                    {   // parse del comando "non password"
                        if (comandoAttuale == "START")
                        {
                            btnStart_Click(null, null);
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
        private void txtIntervallo_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;  // per evitare corse
            try
            {
                // aggiorna la durata ed anche il tempo rimasto, togliendogli il
                // tempo già passato in questo periodo
                float giaFatti = (timeTotalSeconds * 60) - timeLeftSeconds;
                if (giaFatti > 0)
                {
                    float temp = Convert.ToSingle(txtIntervalNext.Text);
                    if (temp > 0)
                    {
                        timeTotalSeconds = Convert.ToSingle(txtIntervalNext.Text);
                        timeLeftSeconds = timeTotalSeconds * 60 - giaFatti;
                        txtCountDown.Text = timeLeftSeconds.ToString();
                    }
                }
            }
            catch
            {

            }
            if (clientConnected)
                ClientTcp.Write("INT1" + txtIntervalNext.Text);
            timer1.Enabled = true;
        }
        private void txtIntervalloIniziale_TextChanged(object sender, EventArgs e)
        {
            if (clientConnected)
                ClientTcp.Write("INT0" + txtInitialInterval.Text);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timeTotalSeconds > 0)
            {
                timeTotalSeconds = Convert.ToSingle(txtIntervalNext.Text);
                timeLeftSeconds = timeTotalSeconds * 60;
                txtCountDown.Text = timeLeftSeconds.ToString();

                timer1.Enabled = true;

                SetInitialColor();
            }
            if (clientConnected)
                ClientTcp.Write("START");

            // set focus to hidden control to avoid clicking on a button
            // when the computer goes to a screen saver mode
            txtCountDown.Focus();
        }
        private void btnStartFirstInterval_Click(object sender, EventArgs e)
        {
            if (timeTotalSeconds > 0)
            {
                timeTotalSeconds = Convert.ToSingle(txtInitialInterval.Text);
                timeLeftSeconds = timeTotalSeconds * 60;
                txtCountDown.Text = timeLeftSeconds.ToString();

                txtCountDown.Text = Convert.ToString(timeTotalSeconds * 60.0);
                timer1.Enabled = true;

                SetInitialColor(); 

                if (clientConnected)
                    ClientTcp.Write("BEGIN");
                // set focus to hidden control to avoid clicking on a button
                // when the computer goes to a screen saver mode
                txtCountDown.Focus();
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
                oggettoRicevitore = new ThreadServerReceiver(ipOrDns, tcpPort, password);
                // crea il thread Inizia()
                threadRicevitore = new Thread(oggettoRicevitore.Inizia);
                serverConnected = true;
                chkServer.Enabled = false;
                btnConnect.Enabled = false;

                timer1.Enabled = true;
                // fa partire il thread Inizia()
                threadRicevitore.Start();

                primoComando = true;
            }
            else // server non checked
            {
                if (oggettoRicevitore != null)
                {
                    oggettoRicevitore.RequestStop();
                    ServerTcp.Close();
                    oggettoRicevitore = null;
                    serverConnected = false;
                    chkServer.Enabled = true;
                    btnConnect.Enabled = true;
                }
            }
        }
        private void ColorTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oggettoRicevitore != null)
            {
                oggettoRicevitore.RequestStop();
                oggettoRicevitore = null;
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
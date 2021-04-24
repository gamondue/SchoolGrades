namespace SchoolGrades
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnDraw = new System.Windows.Forms.Button();
            this.butComeOn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtMinuteStartLesson = new System.Windows.Forms.TextBox();
            this.txtDurationLesson = new System.Windows.Forms.TextBox();
            this.txtMinuteStartAlarm = new System.Windows.Forms.TextBox();
            this.txtRevengeFactor = new System.Windows.Forms.TextBox();
            this.btnCheckNone = new System.Windows.Forms.Button();
            this.lstClasses = new System.Windows.Forms.ListBox();
            this.pgbTimeQuestion = new System.Windows.Forms.ProgressBar();
            this.chkNomeVisibile = new System.Windows.Forms.CheckBox();
            this.chkFotoVisibile = new System.Windows.Forms.CheckBox();
            this.chkStudentsListVisible = new System.Windows.Forms.CheckBox();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.TxtPathImages = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.BtnShowRandomImage = new System.Windows.Forms.Button();
            this.rdbDrawByRevengeFactor = new System.Windows.Forms.RadioButton();
            this.rdbDrawByOldestFirst = new System.Windows.Forms.RadioButton();
            this.rdbDrawNoOfGrades = new System.Windows.Forms.RadioButton();
            this.rdbDrawLowGradesFirst = new System.Windows.Forms.RadioButton();
            this.rdbSortByAlphbetical = new System.Windows.Forms.RadioButton();
            this.rdbDrawByWeightsSum = new System.Windows.Forms.RadioButton();
            this.rdbDrawEqualProbability = new System.Windows.Forms.RadioButton();
            this.BtnSetup = new System.Windows.Forms.Button();
            this.btnStudentsGradesSummary = new System.Windows.Forms.Button();
            this.btnOldestGrade = new System.Windows.Forms.Button();
            this.cmbGradeType = new System.Windows.Forms.ComboBox();
            this.btnLessonsTopics = new System.Windows.Forms.Button();
            this.cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            this.btnTopicsDone = new System.Windows.Forms.Button();
            this.btnStartLinks = new System.Windows.Forms.Button();
            this.btnQuestion = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnMakeGroups = new System.Windows.Forms.Button();
            this.BtnLessonTime = new System.Windows.Forms.Button();
            this.btnVindicationFactorPlus = new System.Windows.Forms.Button();
            this.btnVindicationFactorMinus = new System.Windows.Forms.Button();
            this.btnCheckToggle = new System.Windows.Forms.Button();
            this.chkSuspence = new System.Windows.Forms.CheckBox();
            this.btnCheckRevenge = new System.Windows.Forms.Button();
            this.lblVindicationFactor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClassesGradesSummary = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnCheckNoGrade = new System.Windows.Forms.Button();
            this.lstNames = new System.Windows.Forms.CheckedListBox();
            this.lblDatabaseFile = new System.Windows.Forms.Label();
            this.btnYearTopics = new System.Windows.Forms.Button();
            this.ChkActivateLessonClock = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdStudent = new System.Windows.Forms.TextBox();
            this.btnTemporary = new System.Windows.Forms.Button();
            this.txtTimeInterval = new System.Windows.Forms.TextBox();
            this.btnStartColorTimer = new System.Windows.Forms.Button();
            this.btnMosaic = new System.Windows.Forms.Button();
            this.btnStartBarTimer = new System.Windows.Forms.Button();
            this.chkLessonsPictures = new System.Windows.Forms.CheckBox();
            this.chkGivenFolder = new System.Windows.Forms.CheckBox();
            this.picBackgroundSaveRunning = new System.Windows.Forms.PictureBox();
            this.txtNStudents = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStudentsNotes = new System.Windows.Forms.Button();
            this.txtIdClass = new System.Windows.Forms.TextBox();
            this.chkPopUpQuestionsEnabled = new System.Windows.Forms.CheckBox();
            this.txtPopUpQuestionCentralTime = new System.Windows.Forms.TextBox();
            this.btnRandomNumber = new System.Windows.Forms.Button();
            this.lblStudentChosen = new System.Windows.Forms.Label();
            this.lblCodYear = new System.Windows.Forms.Label();
            this.timerQuestion = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.grpSorts = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAssess = new System.Windows.Forms.Button();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.lblGradeType = new System.Windows.Forms.Label();
            this.timerLesson = new System.Windows.Forms.Timer(this.components);
            this.ChkEnableEndLessonWarning = new System.Windows.Forms.CheckBox();
            this.grpImageSource = new System.Windows.Forms.GroupBox();
            this.grpChooseDrawSort = new System.Windows.Forms.GroupBox();
            this.rdbMustSort = new System.Windows.Forms.RadioButton();
            this.rdbMustDraw = new System.Windows.Forms.RadioButton();
            this.lstTimeInterval = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timerPopUp = new System.Windows.Forms.Timer(this.components);
            this.chkSoundsInColorTimer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundSaveRunning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.grpSorts.SuspendLayout();
            this.grpImageSource.SuspendLayout();
            this.grpChooseDrawSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.BackColor = System.Drawing.Color.Transparent;
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDraw.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDraw.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDraw.Location = new System.Drawing.Point(847, 361);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(101, 54);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Sorteggio o ordinam.";
            this.toolTip1.SetToolTip(this.btnDraw, "Fa l\'ordinamento od il sorteggio");
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDrawOrSort_Click);
            // 
            // butComeOn
            // 
            this.butComeOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butComeOn.BackColor = System.Drawing.Color.Transparent;
            this.butComeOn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.butComeOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.butComeOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.butComeOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butComeOn.ForeColor = System.Drawing.Color.DarkBlue;
            this.butComeOn.Location = new System.Drawing.Point(954, 361);
            this.butComeOn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.butComeOn.Name = "butComeOn";
            this.butComeOn.Size = new System.Drawing.Size(101, 54);
            this.butComeOn.TabIndex = 0;
            this.butComeOn.Text = "Costretto";
            this.toolTip1.SetToolTip(this.butComeOn, "Scelta del prossimo allievo dell\'elenco");
            this.butComeOn.UseVisualStyleBackColor = false;
            this.butComeOn.Click += new System.EventHandler(this.btnComeOn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolTip1.ForeColor = System.Drawing.Color.Lime;
            // 
            // txtMinuteStartLesson
            // 
            this.txtMinuteStartLesson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinuteStartLesson.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtMinuteStartLesson.Location = new System.Drawing.Point(543, 8);
            this.txtMinuteStartLesson.Name = "txtMinuteStartLesson";
            this.txtMinuteStartLesson.Size = new System.Drawing.Size(46, 24);
            this.txtMinuteStartLesson.TabIndex = 139;
            this.txtMinuteStartLesson.Text = "0";
            this.txtMinuteStartLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMinuteStartLesson, "Minuto inizio lezione");
            this.txtMinuteStartLesson.Leave += new System.EventHandler(this.LessonAlarmChanged);
            // 
            // txtDurationLesson
            // 
            this.txtDurationLesson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDurationLesson.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtDurationLesson.Location = new System.Drawing.Point(543, 33);
            this.txtDurationLesson.Name = "txtDurationLesson";
            this.txtDurationLesson.Size = new System.Drawing.Size(46, 24);
            this.txtDurationLesson.TabIndex = 140;
            this.txtDurationLesson.Text = "45";
            this.txtDurationLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtDurationLesson, "Minuti durata lezione");
            this.txtDurationLesson.Leave += new System.EventHandler(this.LessonAlarmChanged);
            // 
            // txtMinuteStartAlarm
            // 
            this.txtMinuteStartAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinuteStartAlarm.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtMinuteStartAlarm.Location = new System.Drawing.Point(543, 58);
            this.txtMinuteStartAlarm.Name = "txtMinuteStartAlarm";
            this.txtMinuteStartAlarm.Size = new System.Drawing.Size(46, 24);
            this.txtMinuteStartAlarm.TabIndex = 141;
            this.txtMinuteStartAlarm.Text = "1";
            this.txtMinuteStartAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMinuteStartAlarm, "Minuti per allarme prima della fine");
            this.txtMinuteStartAlarm.Leave += new System.EventHandler(this.LessonAlarmChanged);
            // 
            // txtRevengeFactor
            // 
            this.txtRevengeFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRevengeFactor.Location = new System.Drawing.Point(912, 511);
            this.txtRevengeFactor.Name = "txtRevengeFactor";
            this.txtRevengeFactor.ReadOnly = true;
            this.txtRevengeFactor.Size = new System.Drawing.Size(36, 24);
            this.txtRevengeFactor.TabIndex = 144;
            this.txtRevengeFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtRevengeFactor, "Fattore di vendetta dell\'allievo corrente");
            // 
            // btnCheckNone
            // 
            this.btnCheckNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckNone.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckNone.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheckNone.Location = new System.Drawing.Point(723, 617);
            this.btnCheckNone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCheckNone.Name = "btnCheckNone";
            this.btnCheckNone.Size = new System.Drawing.Size(91, 54);
            this.btnCheckNone.TabIndex = 29;
            this.btnCheckNone.Text = "X nessuno";
            this.toolTip1.SetToolTip(this.btnCheckNone, "Check nessun allievo");
            this.btnCheckNone.UseVisualStyleBackColor = false;
            this.btnCheckNone.Click += new System.EventHandler(this.btnCheckNone_Click);
            // 
            // lstClasses
            // 
            this.lstClasses.BackColor = System.Drawing.Color.PowderBlue;
            this.lstClasses.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.ItemHeight = 18;
            this.lstClasses.Location = new System.Drawing.Point(86, 4);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(76, 130);
            this.lstClasses.TabIndex = 46;
            this.lstClasses.TabStop = false;
            this.toolTip1.SetToolTip(this.lstClasses, "Classi dell\'anno scolastico selezionato");
            this.lstClasses.SelectedIndexChanged += new System.EventHandler(this.lstClassi_SelectedIndexChanged);
            this.lstClasses.DoubleClick += new System.EventHandler(this.lstClassi_DoubleClick);
            // 
            // pgbTimeQuestion
            // 
            this.pgbTimeQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbTimeQuestion.Location = new System.Drawing.Point(8, 168);
            this.pgbTimeQuestion.Name = "pgbTimeQuestion";
            this.pgbTimeQuestion.Size = new System.Drawing.Size(711, 23);
            this.pgbTimeQuestion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbTimeQuestion.TabIndex = 50;
            this.toolTip1.SetToolTip(this.pgbTimeQuestion, "Barra tempo per la risposta, Click  per far partire il cronometro.");
            this.pgbTimeQuestion.Click += new System.EventHandler(this.pgbTimeQuestion_Click);
            // 
            // chkNomeVisibile
            // 
            this.chkNomeVisibile.AutoSize = true;
            this.chkNomeVisibile.Checked = true;
            this.chkNomeVisibile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNomeVisibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkNomeVisibile.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkNomeVisibile.Location = new System.Drawing.Point(297, 66);
            this.chkNomeVisibile.Name = "chkNomeVisibile";
            this.chkNomeVisibile.Size = new System.Drawing.Size(128, 22);
            this.chkNomeVisibile.TabIndex = 14;
            this.chkNomeVisibile.Text = "Nome visibile";
            this.toolTip1.SetToolTip(this.chkNomeVisibile, "Visualizza il nome dell\'allievo");
            this.chkNomeVisibile.UseVisualStyleBackColor = true;
            this.chkNomeVisibile.CheckedChanged += new System.EventHandler(this.chkNomeVisibile_CheckedChanged);
            // 
            // chkFotoVisibile
            // 
            this.chkFotoVisibile.AutoSize = true;
            this.chkFotoVisibile.Checked = true;
            this.chkFotoVisibile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFotoVisibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkFotoVisibile.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFotoVisibile.Location = new System.Drawing.Point(297, 91);
            this.chkFotoVisibile.Name = "chkFotoVisibile";
            this.chkFotoVisibile.Size = new System.Drawing.Size(118, 22);
            this.chkFotoVisibile.TabIndex = 16;
            this.chkFotoVisibile.Text = "Foto visibile";
            this.toolTip1.SetToolTip(this.chkFotoVisibile, "Visualizza la foto dell\'allievo");
            this.chkFotoVisibile.UseVisualStyleBackColor = true;
            this.chkFotoVisibile.CheckedChanged += new System.EventHandler(this.chkFotoVisibile_CheckedChanged);
            // 
            // chkStudentsListVisible
            // 
            this.chkStudentsListVisible.AutoSize = true;
            this.chkStudentsListVisible.Checked = true;
            this.chkStudentsListVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStudentsListVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkStudentsListVisible.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkStudentsListVisible.Location = new System.Drawing.Point(297, 116);
            this.chkStudentsListVisible.Name = "chkStudentsListVisible";
            this.chkStudentsListVisible.Size = new System.Drawing.Size(119, 22);
            this.chkStudentsListVisible.TabIndex = 18;
            this.chkStudentsListVisible.Text = "Lista visibile";
            this.toolTip1.SetToolTip(this.chkStudentsListVisible, "Visualizza l\'elenco degli allievi della classe");
            this.chkStudentsListVisible.UseVisualStyleBackColor = true;
            this.chkStudentsListVisible.CheckedChanged += new System.EventHandler(this.chkStudentsListVisible_CheckedChanged);
            // 
            // CmbSchoolYear
            // 
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(4, 28);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(72, 26);
            this.CmbSchoolYear.TabIndex = 62;
            this.toolTip1.SetToolTip(this.CmbSchoolYear, "Anno scolastico senza \"-\"");
            this.CmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolYear_SelectedIndexChanged);
            // 
            // TxtPathImages
            // 
            this.TxtPathImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            this.TxtPathImages.Location = new System.Drawing.Point(8, 142);
            this.TxtPathImages.Name = "TxtPathImages";
            this.TxtPathImages.Size = new System.Drawing.Size(671, 24);
            this.TxtPathImages.TabIndex = 20;
            this.toolTip1.SetToolTip(this.TxtPathImages, "Cartella in cui trovare l\'immagine casuale (click per aprire un file nella cartel" +
        "la) ");
            this.TxtPathImages.Click += new System.EventHandler(this.txtPathImages_Click);
            this.TxtPathImages.TextChanged += new System.EventHandler(this.txtPathImages_TextChanged);
            this.TxtPathImages.DoubleClick += new System.EventHandler(this.txtPathImages_DoubleClick);
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.ForeColor = System.Drawing.Color.Black;
            this.btnPath.Location = new System.Drawing.Point(685, 140);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(34, 27);
            this.btnPath.TabIndex = 67;
            this.btnPath.Text = "..";
            this.toolTip1.SetToolTip(this.btnPath, "Scelta cartella immagini");
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // BtnShowRandomImage
            // 
            this.BtnShowRandomImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnShowRandomImage.BackColor = System.Drawing.Color.Transparent;
            this.BtnShowRandomImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnShowRandomImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnShowRandomImage.Location = new System.Drawing.Point(723, 131);
            this.BtnShowRandomImage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnShowRandomImage.Name = "BtnShowRandomImage";
            this.BtnShowRandomImage.Size = new System.Drawing.Size(91, 59);
            this.BtnShowRandomImage.TabIndex = 22;
            this.BtnShowRandomImage.Text = "Immagine casuale";
            this.toolTip1.SetToolTip(this.BtnShowRandomImage, "Visualizzazione di un\'immagine casuale dalla cartella  qui sotto");
            this.BtnShowRandomImage.UseVisualStyleBackColor = false;
            this.BtnShowRandomImage.Click += new System.EventHandler(this.BtnShowRandomImage_Click);
            // 
            // rdbDrawByRevengeFactor
            // 
            this.rdbDrawByRevengeFactor.AutoSize = true;
            this.rdbDrawByRevengeFactor.Location = new System.Drawing.Point(6, 152);
            this.rdbDrawByRevengeFactor.Name = "rdbDrawByRevengeFactor";
            this.rdbDrawByRevengeFactor.Size = new System.Drawing.Size(169, 22);
            this.rdbDrawByRevengeFactor.TabIndex = 6;
            this.rdbDrawByRevengeFactor.Text = "Tremenda vendetta";
            this.toolTip1.SetToolTip(this.rdbDrawByRevengeFactor, "Sorteggio con probabilità più alta per maggiori fattori di vendetta");
            this.rdbDrawByRevengeFactor.UseVisualStyleBackColor = true;
            this.rdbDrawByRevengeFactor.CheckedChanged += new System.EventHandler(this.rdbDrawOnVindicationFactor_CheckedChanged);
            // 
            // rdbDrawByOldestFirst
            // 
            this.rdbDrawByOldestFirst.AutoSize = true;
            this.rdbDrawByOldestFirst.Enabled = false;
            this.rdbDrawByOldestFirst.Location = new System.Drawing.Point(6, 86);
            this.rdbDrawByOldestFirst.Name = "rdbDrawByOldestFirst";
            this.rdbDrawByOldestFirst.Size = new System.Drawing.Size(155, 22);
            this.rdbDrawByOldestFirst.TabIndex = 4;
            this.rdbDrawByOldestFirst.Text = "Prima voti vecchi";
            this.toolTip1.SetToolTip(this.rdbDrawByOldestFirst, "Ordinamento con prima i voti più vecchi del tipo selezionato");
            this.rdbDrawByOldestFirst.UseVisualStyleBackColor = true;
            // 
            // rdbDrawNoOfGrades
            // 
            this.rdbDrawNoOfGrades.AutoSize = true;
            this.rdbDrawNoOfGrades.Location = new System.Drawing.Point(6, 64);
            this.rdbDrawNoOfGrades.Name = "rdbDrawNoOfGrades";
            this.rdbDrawNoOfGrades.Size = new System.Drawing.Size(118, 22);
            this.rdbDrawNoOfGrades.TabIndex = 5;
            this.rdbDrawNoOfGrades.Text = "Numero voti";
            this.toolTip1.SetToolTip(this.rdbDrawNoOfGrades, "Ordinamento in base al numero dei voti del tipo selezionato");
            this.rdbDrawNoOfGrades.UseVisualStyleBackColor = true;
            // 
            // rdbDrawLowGradesFirst
            // 
            this.rdbDrawLowGradesFirst.AutoSize = true;
            this.rdbDrawLowGradesFirst.Enabled = false;
            this.rdbDrawLowGradesFirst.Location = new System.Drawing.Point(6, 130);
            this.rdbDrawLowGradesFirst.Name = "rdbDrawLowGradesFirst";
            this.rdbDrawLowGradesFirst.Size = new System.Drawing.Size(147, 22);
            this.rdbDrawLowGradesFirst.TabIndex = 3;
            this.rdbDrawLowGradesFirst.Text = "Prima voti bassi";
            this.toolTip1.SetToolTip(this.rdbDrawLowGradesFirst, "Ordinamento per voto descrescente");
            this.rdbDrawLowGradesFirst.UseVisualStyleBackColor = true;
            // 
            // rdbSortByAlphbetical
            // 
            this.rdbSortByAlphbetical.AutoSize = true;
            this.rdbSortByAlphbetical.Location = new System.Drawing.Point(6, 108);
            this.rdbSortByAlphbetical.Name = "rdbSortByAlphbetical";
            this.rdbSortByAlphbetical.Size = new System.Drawing.Size(100, 22);
            this.rdbSortByAlphbetical.TabIndex = 2;
            this.rdbSortByAlphbetical.Text = "Alfabetico";
            this.toolTip1.SetToolTip(this.rdbSortByAlphbetical, "Ordinamento alfabetico");
            this.rdbSortByAlphbetical.UseVisualStyleBackColor = true;
            // 
            // rdbDrawByWeightsSum
            // 
            this.rdbDrawByWeightsSum.AutoSize = true;
            this.rdbDrawByWeightsSum.Location = new System.Drawing.Point(6, 42);
            this.rdbDrawByWeightsSum.Name = "rdbDrawByWeightsSum";
            this.rdbDrawByWeightsSum.Size = new System.Drawing.Size(171, 22);
            this.rdbDrawByWeightsSum.TabIndex = 1;
            this.rdbDrawByWeightsSum.Text = "Peso totale dei voti";
            this.toolTip1.SetToolTip(this.rdbDrawByWeightsSum, "Ordinamento secondo il peso totale del tipo di voto selezionato");
            this.rdbDrawByWeightsSum.UseVisualStyleBackColor = true;
            // 
            // rdbDrawEqualProbability
            // 
            this.rdbDrawEqualProbability.AutoSize = true;
            this.rdbDrawEqualProbability.Checked = true;
            this.rdbDrawEqualProbability.Location = new System.Drawing.Point(6, 20);
            this.rdbDrawEqualProbability.Name = "rdbDrawEqualProbability";
            this.rdbDrawEqualProbability.Size = new System.Drawing.Size(155, 22);
            this.rdbDrawEqualProbability.TabIndex = 0;
            this.rdbDrawEqualProbability.TabStop = true;
            this.rdbDrawEqualProbability.Text = "Probabilità uguali";
            this.toolTip1.SetToolTip(this.rdbDrawEqualProbability, "Sorteggio con uguali probabilitàfra ogni allievo");
            this.rdbDrawEqualProbability.UseVisualStyleBackColor = true;
            // 
            // BtnSetup
            // 
            this.BtnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSetup.BackColor = System.Drawing.Color.Transparent;
            this.BtnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSetup.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnSetup.Location = new System.Drawing.Point(711, 5);
            this.BtnSetup.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnSetup.Name = "BtnSetup";
            this.BtnSetup.Size = new System.Drawing.Size(107, 59);
            this.BtnSetup.TabIndex = 73;
            this.BtnSetup.Text = "Setup";
            this.toolTip1.SetToolTip(this.BtnSetup, "Finestra opzioni di configurazione");
            this.BtnSetup.UseVisualStyleBackColor = false;
            this.BtnSetup.Click += new System.EventHandler(this.BtnSetup_Click);
            // 
            // btnStudentsGradesSummary
            // 
            this.btnStudentsGradesSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStudentsGradesSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentsGradesSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStudentsGradesSummary.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStudentsGradesSummary.Location = new System.Drawing.Point(954, 617);
            this.btnStudentsGradesSummary.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStudentsGradesSummary.Name = "btnStudentsGradesSummary";
            this.btnStudentsGradesSummary.Size = new System.Drawing.Size(101, 54);
            this.btnStudentsGradesSummary.TabIndex = 74;
            this.btnStudentsGradesSummary.Text = "Voti allievo";
            this.toolTip1.SetToolTip(this.btnStudentsGradesSummary, "Finestra di riepilogo dei voti e delle annotazioni sull\'allievo corrente");
            this.btnStudentsGradesSummary.UseVisualStyleBackColor = false;
            this.btnStudentsGradesSummary.Click += new System.EventHandler(this.btnStudentsGradesSummary_Click);
            // 
            // btnOldestGrade
            // 
            this.btnOldestGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOldestGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnOldestGrade.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOldestGrade.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOldestGrade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOldestGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOldestGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnOldestGrade.Location = new System.Drawing.Point(954, 489);
            this.btnOldestGrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOldestGrade.Name = "btnOldestGrade";
            this.btnOldestGrade.Size = new System.Drawing.Size(101, 54);
            this.btnOldestGrade.TabIndex = 75;
            this.btnOldestGrade.Text = "Voto più vecchio";
            this.toolTip1.SetToolTip(this.btnOldestGrade, "Sceglie l\'allievo che ha il voto più vecchio");
            this.btnOldestGrade.UseVisualStyleBackColor = false;
            this.btnOldestGrade.Click += new System.EventHandler(this.btnOldestGrade_Click);
            // 
            // cmbGradeType
            // 
            this.cmbGradeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGradeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbGradeType.FormattingEnabled = true;
            this.cmbGradeType.Items.AddRange(new object[] {
            "Voticini",
            "Orali",
            "Scritti",
            "Pratici",
            "Scritto-grafici"});
            this.cmbGradeType.Location = new System.Drawing.Point(820, 246);
            this.cmbGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGradeType.Name = "cmbGradeType";
            this.cmbGradeType.Size = new System.Drawing.Size(239, 28);
            this.cmbGradeType.TabIndex = 96;
            this.toolTip1.SetToolTip(this.cmbGradeType, "Scelta del tipo di voto");
            this.cmbGradeType.SelectedIndexChanged += new System.EventHandler(this.cmbGradeType_SelectedIndexChanged);
            // 
            // btnLessonsTopics
            // 
            this.btnLessonsTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLessonsTopics.BackColor = System.Drawing.Color.Transparent;
            this.btnLessonsTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLessonsTopics.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLessonsTopics.Location = new System.Drawing.Point(847, 678);
            this.btnLessonsTopics.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLessonsTopics.Name = "btnLessonsTopics";
            this.btnLessonsTopics.Size = new System.Drawing.Size(101, 54);
            this.btnLessonsTopics.TabIndex = 97;
            this.btnLessonsTopics.Text = "Lezioni";
            this.toolTip1.SetToolTip(this.btnLessonsTopics, "Finestra gestione lezioni della  materia selezionata");
            this.btnLessonsTopics.UseVisualStyleBackColor = false;
            this.btnLessonsTopics.Click += new System.EventHandler(this.btnLessonsTopics_Click);
            // 
            // cmbSchoolSubject
            // 
            this.cmbSchoolSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSchoolSubject.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSchoolSubject.FormattingEnabled = true;
            this.cmbSchoolSubject.Location = new System.Drawing.Point(820, 300);
            this.cmbSchoolSubject.Name = "cmbSchoolSubject";
            this.cmbSchoolSubject.Size = new System.Drawing.Size(239, 26);
            this.cmbSchoolSubject.TabIndex = 108;
            this.toolTip1.SetToolTip(this.cmbSchoolSubject, "Scelta materia");
            this.cmbSchoolSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubject_SelectedIndexChanged);
            // 
            // btnTopicsDone
            // 
            this.btnTopicsDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopicsDone.BackColor = System.Drawing.Color.Transparent;
            this.btnTopicsDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTopicsDone.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnTopicsDone.Location = new System.Drawing.Point(847, 553);
            this.btnTopicsDone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnTopicsDone.Name = "btnTopicsDone";
            this.btnTopicsDone.Size = new System.Drawing.Size(101, 54);
            this.btnTopicsDone.TabIndex = 112;
            this.btnTopicsDone.Text = "Argomenti fatti";
            this.toolTip1.SetToolTip(this.btnTopicsDone, "Apre pagina ricerca argomenti già spiegati nel programma didattico");
            this.btnTopicsDone.UseVisualStyleBackColor = false;
            this.btnTopicsDone.Click += new System.EventHandler(this.btnTopicsDone_Click);
            // 
            // btnStartLinks
            // 
            this.btnStartLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartLinks.Location = new System.Drawing.Point(723, 256);
            this.btnStartLinks.Name = "btnStartLinks";
            this.btnStartLinks.Size = new System.Drawing.Size(91, 54);
            this.btnStartLinks.TabIndex = 132;
            this.btnStartLinks.Text = "Start links";
            this.toolTip1.SetToolTip(this.btnStartLinks, "Lancio dei link e programmi legati alla classe");
            this.btnStartLinks.UseVisualStyleBackColor = true;
            this.btnStartLinks.Click += new System.EventHandler(this.btnStartLinks_Click);
            // 
            // btnQuestion
            // 
            this.btnQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestion.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuestion.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnQuestion.Location = new System.Drawing.Point(847, 425);
            this.btnQuestion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(101, 54);
            this.btnQuestion.TabIndex = 133;
            this.btnQuestion.Text = "Scelta domanda";
            this.toolTip1.SetToolTip(this.btnQuestion, "Scelta domanda \"di default\" da fare a tutti");
            this.btnQuestion.UseVisualStyleBackColor = false;
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestion.Location = new System.Drawing.Point(8, 193);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(711, 24);
            this.txtQuestion.TabIndex = 134;
            this.toolTip1.SetToolTip(this.txtQuestion, "Testo della domanda corrente");
            this.txtQuestion.TextChanged += new System.EventHandler(this.txtQuestion_TextChanged);
            this.txtQuestion.DoubleClick += new System.EventHandler(this.txtQuestion_DoubleClick);
            // 
            // btnMakeGroups
            // 
            this.btnMakeGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeGroups.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMakeGroups.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnMakeGroups.Location = new System.Drawing.Point(597, 72);
            this.btnMakeGroups.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnMakeGroups.Name = "btnMakeGroups";
            this.btnMakeGroups.Size = new System.Drawing.Size(107, 59);
            this.btnMakeGroups.TabIndex = 135;
            this.btnMakeGroups.Text = "Gruppi";
            this.toolTip1.SetToolTip(this.btnMakeGroups, "Formazione dei gruppi");
            this.btnMakeGroups.UseVisualStyleBackColor = false;
            this.btnMakeGroups.Click += new System.EventHandler(this.btnMakeGroups_Click);
            // 
            // BtnLessonTime
            // 
            this.BtnLessonTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLessonTime.BackColor = System.Drawing.Color.Transparent;
            this.BtnLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnLessonTime.Location = new System.Drawing.Point(597, 5);
            this.BtnLessonTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnLessonTime.Name = "BtnLessonTime";
            this.BtnLessonTime.Size = new System.Drawing.Size(107, 59);
            this.BtnLessonTime.TabIndex = 138;
            this.BtnLessonTime.Text = "Inizio lezione";
            this.toolTip1.SetToolTip(this.BtnLessonTime, "Colorazione in base al tempo che manca alla fine della lezione");
            this.BtnLessonTime.UseVisualStyleBackColor = false;
            this.BtnLessonTime.Click += new System.EventHandler(this.btnLessonTime_Click);
            // 
            // btnVindicationFactorPlus
            // 
            this.btnVindicationFactorPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVindicationFactorPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnVindicationFactorPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVindicationFactorPlus.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnVindicationFactorPlus.Location = new System.Drawing.Point(847, 489);
            this.btnVindicationFactorPlus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnVindicationFactorPlus.Name = "btnVindicationFactorPlus";
            this.btnVindicationFactorPlus.Size = new System.Drawing.Size(57, 27);
            this.btnVindicationFactorPlus.TabIndex = 142;
            this.btnVindicationFactorPlus.Text = "FV++";
            this.toolTip1.SetToolTip(this.btnVindicationFactorPlus, "Aumento del fattore di vendetta");
            this.btnVindicationFactorPlus.UseVisualStyleBackColor = false;
            this.btnVindicationFactorPlus.Click += new System.EventHandler(this.btnRevengeFactorPlus_Click);
            // 
            // btnVindicationFactorMinus
            // 
            this.btnVindicationFactorMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVindicationFactorMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnVindicationFactorMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVindicationFactorMinus.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnVindicationFactorMinus.Location = new System.Drawing.Point(847, 516);
            this.btnVindicationFactorMinus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnVindicationFactorMinus.Name = "btnVindicationFactorMinus";
            this.btnVindicationFactorMinus.Size = new System.Drawing.Size(57, 27);
            this.btnVindicationFactorMinus.TabIndex = 143;
            this.btnVindicationFactorMinus.Text = "FV--";
            this.toolTip1.SetToolTip(this.btnVindicationFactorMinus, "Decremento del fattore di vendetta");
            this.btnVindicationFactorMinus.UseVisualStyleBackColor = false;
            this.btnVindicationFactorMinus.Click += new System.EventHandler(this.btnRevengeFactorMinus_Click);
            // 
            // btnCheckToggle
            // 
            this.btnCheckToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckToggle.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheckToggle.Location = new System.Drawing.Point(723, 425);
            this.btnCheckToggle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCheckToggle.Name = "btnCheckToggle";
            this.btnCheckToggle.Size = new System.Drawing.Size(91, 54);
            this.btnCheckToggle.TabIndex = 146;
            this.btnCheckToggle.Text = "cambio X";
            this.toolTip1.SetToolTip(this.btnCheckToggle, "Cambia check di tutti gli allievi");
            this.btnCheckToggle.UseVisualStyleBackColor = false;
            this.btnCheckToggle.Click += new System.EventHandler(this.btnCheckToggle_Click);
            // 
            // chkSuspence
            // 
            this.chkSuspence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSuspence.AutoSize = true;
            this.chkSuspence.Location = new System.Drawing.Point(960, 223);
            this.chkSuspence.Name = "chkSuspence";
            this.chkSuspence.Size = new System.Drawing.Size(99, 22);
            this.chkSuspence.TabIndex = 147;
            this.chkSuspence.Text = "suspence";
            this.toolTip1.SetToolTip(this.chkSuspence, "Aspetta un po\' prima di estrarre, suonando una musica");
            this.chkSuspence.UseVisualStyleBackColor = true;
            // 
            // btnCheckRevenge
            // 
            this.btnCheckRevenge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckRevenge.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckRevenge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckRevenge.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheckRevenge.Location = new System.Drawing.Point(723, 489);
            this.btnCheckRevenge.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCheckRevenge.Name = "btnCheckRevenge";
            this.btnCheckRevenge.Size = new System.Drawing.Size(91, 54);
            this.btnCheckRevenge.TabIndex = 148;
            this.btnCheckRevenge.Text = "X di vendetta";
            this.toolTip1.SetToolTip(this.btnCheckRevenge, "Fattore vendetta per allievi checked");
            this.btnCheckRevenge.UseVisualStyleBackColor = false;
            this.btnCheckRevenge.Click += new System.EventHandler(this.btnCheckRevenge_Click);
            // 
            // lblVindicationFactor
            // 
            this.lblVindicationFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVindicationFactor.AutoSize = true;
            this.lblVindicationFactor.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblVindicationFactor.Location = new System.Drawing.Point(912, 491);
            this.lblVindicationFactor.Name = "lblVindicationFactor";
            this.lblVindicationFactor.Size = new System.Drawing.Size(38, 18);
            this.lblVindicationFactor.TabIndex = 145;
            this.lblVindicationFactor.Text = "F.V.";
            this.toolTip1.SetToolTip(this.lblVindicationFactor, "Fattore di vendetta dell\'allievo corrente");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(423, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 149;
            this.label1.Text = "Minuto inizio";
            this.toolTip1.SetToolTip(this.label1, "Minuto di  inizio della lezione");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(423, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 150;
            this.label3.Text = "Minuti durata";
            this.toolTip1.SetToolTip(this.label3, "Minuti di durata della lezione");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(423, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 151;
            this.label4.Text = "Anticipo minuti";
            this.toolTip1.SetToolTip(this.label4, "Minuti di anticipo dell\'allarme rispetto a fine lezione ");
            // 
            // btnClassesGradesSummary
            // 
            this.btnClassesGradesSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassesGradesSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnClassesGradesSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClassesGradesSummary.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnClassesGradesSummary.Location = new System.Drawing.Point(847, 617);
            this.btnClassesGradesSummary.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClassesGradesSummary.Name = "btnClassesGradesSummary";
            this.btnClassesGradesSummary.Size = new System.Drawing.Size(101, 54);
            this.btnClassesGradesSummary.TabIndex = 153;
            this.btnClassesGradesSummary.Text = "Voti classe";
            this.toolTip1.SetToolTip(this.btnClassesGradesSummary, "Finestra di riepilogo dei voti della classe corrente");
            this.btnClassesGradesSummary.UseVisualStyleBackColor = false;
            this.btnClassesGradesSummary.Click += new System.EventHandler(this.btnClassesGradesSummary_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckAll.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheckAll.Location = new System.Drawing.Point(723, 678);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(91, 54);
            this.btnCheckAll.TabIndex = 28;
            this.btnCheckAll.Text = "X tutti";
            this.toolTip1.SetToolTip(this.btnCheckAll, "Check tutti allievi");
            this.btnCheckAll.UseVisualStyleBackColor = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnCheckNoGrade
            // 
            this.btnCheckNoGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckNoGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckNoGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckNoGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheckNoGrade.Location = new System.Drawing.Point(723, 553);
            this.btnCheckNoGrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCheckNoGrade.Name = "btnCheckNoGrade";
            this.btnCheckNoGrade.Size = new System.Drawing.Size(91, 54);
            this.btnCheckNoGrade.TabIndex = 155;
            this.btnCheckNoGrade.Text = " X no voti";
            this.toolTip1.SetToolTip(this.btnCheckNoGrade, "Check allievi che non hanno voti");
            this.btnCheckNoGrade.UseVisualStyleBackColor = false;
            this.btnCheckNoGrade.Click += new System.EventHandler(this.btnCheckNoGrade_Click);
            // 
            // lstNames
            // 
            this.lstNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNames.BackColor = System.Drawing.Color.PowderBlue;
            this.lstNames.ColumnWidth = 350;
            this.lstNames.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstNames.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstNames.HorizontalScrollbar = true;
            this.lstNames.Location = new System.Drawing.Point(8, 222);
            this.lstNames.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lstNames.MultiColumn = true;
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(711, 508);
            this.lstNames.TabIndex = 26;
            this.toolTip1.SetToolTip(this.lstNames, "Nomi degli allievi della classe. ");
            this.lstNames.UseCompatibleTextRendering = true;
            this.lstNames.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstNames_ItemCheck);
            this.lstNames.SelectedIndexChanged += new System.EventHandler(this.lstNomi_SelectedIndexChanged);
            this.lstNames.SelectedValueChanged += new System.EventHandler(this.lstNomi_SelectedValueChanged);
            this.lstNames.DoubleClick += new System.EventHandler(this.lstNomi_DoubleClick);
            // 
            // lblDatabaseFile
            // 
            this.lblDatabaseFile.AutoSize = true;
            this.lblDatabaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDatabaseFile.ForeColor = System.Drawing.Color.Red;
            this.lblDatabaseFile.Location = new System.Drawing.Point(216, 0);
            this.lblDatabaseFile.Name = "lblDatabaseFile";
            this.lblDatabaseFile.Size = new System.Drawing.Size(94, 13);
            this.lblDatabaseFile.TabIndex = 111;
            this.lblDatabaseFile.Text = "lblDatabaseFile";
            this.toolTip1.SetToolTip(this.lblDatabaseFile, "Nome del file del database. ");
            this.lblDatabaseFile.Visible = false;
            // 
            // btnYearTopics
            // 
            this.btnYearTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYearTopics.BackColor = System.Drawing.Color.Transparent;
            this.btnYearTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYearTopics.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnYearTopics.Location = new System.Drawing.Point(954, 553);
            this.btnYearTopics.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnYearTopics.Name = "btnYearTopics";
            this.btnYearTopics.Size = new System.Drawing.Size(101, 54);
            this.btnYearTopics.TabIndex = 157;
            this.btnYearTopics.Text = "File arg. anno";
            this.toolTip1.SetToolTip(this.btnYearTopics, "Crea un file con tutti gli argomenti fatti nell\'anno scolatico");
            this.btnYearTopics.UseVisualStyleBackColor = false;
            this.btnYearTopics.Click += new System.EventHandler(this.btnYearTopics_Click);
            // 
            // ChkActivateLessonClock
            // 
            this.ChkActivateLessonClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkActivateLessonClock.AutoSize = true;
            this.ChkActivateLessonClock.Checked = true;
            this.ChkActivateLessonClock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkActivateLessonClock.Location = new System.Drawing.Point(423, 92);
            this.ChkActivateLessonClock.Name = "ChkActivateLessonClock";
            this.ChkActivateLessonClock.Size = new System.Drawing.Size(154, 22);
            this.ChkActivateLessonClock.TabIndex = 159;
            this.ChkActivateLessonClock.Text = "orologio lezione ";
            this.toolTip1.SetToolTip(this.ChkActivateLessonClock, "Abilita orologio a colori per bottone lezione");
            this.ChkActivateLessonClock.UseVisualStyleBackColor = true;
            this.ChkActivateLessonClock.CheckedChanged += new System.EventHandler(this.ChkActivateLessonClock_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(639, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 163;
            this.label5.Text = "Id allievo";
            this.toolTip1.SetToolTip(this.label5, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si " +
        "può modificare. ");
            // 
            // txtIdStudent
            // 
            this.txtIdStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdStudent.Location = new System.Drawing.Point(642, 241);
            this.txtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdStudent.Name = "txtIdStudent";
            this.txtIdStudent.ReadOnly = true;
            this.txtIdStudent.Size = new System.Drawing.Size(77, 24);
            this.txtIdStudent.TabIndex = 162;
            this.txtIdStudent.TabStop = false;
            this.txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtIdStudent, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // btnTemporary
            // 
            this.btnTemporary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemporary.BackColor = System.Drawing.Color.Red;
            this.btnTemporary.ForeColor = System.Drawing.Color.Yellow;
            this.btnTemporary.Location = new System.Drawing.Point(563, 163);
            this.btnTemporary.Name = "btnTemporary";
            this.btnTemporary.Size = new System.Drawing.Size(91, 54);
            this.btnTemporary.TabIndex = 164;
            this.btnTemporary.Text = "Test";
            this.toolTip1.SetToolTip(this.btnTemporary, "Lancio dei link e programmi legati alla classe");
            this.btnTemporary.UseVisualStyleBackColor = false;
            this.btnTemporary.Click += new System.EventHandler(this.btnTemporary_Click);
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtTimeInterval.Location = new System.Drawing.Point(168, 4);
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.Size = new System.Drawing.Size(46, 24);
            this.txtTimeInterval.TabIndex = 168;
            this.txtTimeInterval.Text = "0";
            this.txtTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtTimeInterval, "Minuti per allarme prima della fine");
            // 
            // btnStartColorTimer
            // 
            this.btnStartColorTimer.BackColor = System.Drawing.Color.Transparent;
            this.btnStartColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartColorTimer.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStartColorTimer.Location = new System.Drawing.Point(216, 27);
            this.btnStartColorTimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStartColorTimer.Name = "btnStartColorTimer";
            this.btnStartColorTimer.Size = new System.Drawing.Size(71, 27);
            this.btnStartColorTimer.TabIndex = 169;
            this.btnStartColorTimer.Text = "t.colori";
            this.toolTip1.SetToolTip(this.btnStartColorTimer, "Partenza di un cronometro a colori");
            this.btnStartColorTimer.UseVisualStyleBackColor = false;
            this.btnStartColorTimer.Click += new System.EventHandler(this.btnStartColorTimer_Click);
            // 
            // btnMosaic
            // 
            this.btnMosaic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMosaic.Location = new System.Drawing.Point(723, 316);
            this.btnMosaic.Name = "btnMosaic";
            this.btnMosaic.Size = new System.Drawing.Size(91, 54);
            this.btnMosaic.TabIndex = 170;
            this.btnMosaic.Text = "Mosaico";
            this.toolTip1.SetToolTip(this.btnMosaic, "Visualizzazione di tutte le foto della classe");
            this.btnMosaic.UseVisualStyleBackColor = true;
            this.btnMosaic.Click += new System.EventHandler(this.btnMosaic_Click);
            // 
            // btnStartBarTimer
            // 
            this.btnStartBarTimer.BackColor = System.Drawing.Color.Transparent;
            this.btnStartBarTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartBarTimer.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStartBarTimer.Location = new System.Drawing.Point(297, 27);
            this.btnStartBarTimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStartBarTimer.Name = "btnStartBarTimer";
            this.btnStartBarTimer.Size = new System.Drawing.Size(71, 27);
            this.btnStartBarTimer.TabIndex = 173;
            this.btnStartBarTimer.Text = "t.barra";
            this.toolTip1.SetToolTip(this.btnStartBarTimer, "Partenza di un cronometro a barra");
            this.btnStartBarTimer.UseVisualStyleBackColor = false;
            this.btnStartBarTimer.Click += new System.EventHandler(this.btnStartBarTimer_Click);
            // 
            // chkLessonsPictures
            // 
            this.chkLessonsPictures.AutoSize = true;
            this.chkLessonsPictures.Checked = true;
            this.chkLessonsPictures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLessonsPictures.Location = new System.Drawing.Point(5, 19);
            this.chkLessonsPictures.Name = "chkLessonsPictures";
            this.chkLessonsPictures.Size = new System.Drawing.Size(76, 22);
            this.chkLessonsPictures.TabIndex = 10;
            this.chkLessonsPictures.Text = "lezioni";
            this.toolTip1.SetToolTip(this.chkLessonsPictures, "Estrazione fra  le immagini mostrate durante le lezioni");
            this.chkLessonsPictures.UseVisualStyleBackColor = true;
            // 
            // chkGivenFolder
            // 
            this.chkGivenFolder.AutoSize = true;
            this.chkGivenFolder.Location = new System.Drawing.Point(5, 41);
            this.chkGivenFolder.Name = "chkGivenFolder";
            this.chkGivenFolder.Size = new System.Drawing.Size(82, 22);
            this.chkGivenFolder.TabIndex = 174;
            this.chkGivenFolder.Text = "cartella";
            this.toolTip1.SetToolTip(this.chkGivenFolder, "Estrazione fra le immmagini che stanno sotto la cartella data");
            this.chkGivenFolder.UseVisualStyleBackColor = true;
            // 
            // picBackgroundSaveRunning
            // 
            this.picBackgroundSaveRunning.BackColor = System.Drawing.Color.DarkGray;
            this.picBackgroundSaveRunning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBackgroundSaveRunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackgroundSaveRunning.Location = new System.Drawing.Point(25, 124);
            this.picBackgroundSaveRunning.Name = "picBackgroundSaveRunning";
            this.picBackgroundSaveRunning.Size = new System.Drawing.Size(30, 14);
            this.picBackgroundSaveRunning.TabIndex = 171;
            this.picBackgroundSaveRunning.TabStop = false;
            this.toolTip1.SetToolTip(this.picBackgroundSaveRunning, "Rosso mentre il programma salva in background");
            // 
            // txtNStudents
            // 
            this.txtNStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNStudents.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtNStudents.Location = new System.Drawing.Point(745, 394);
            this.txtNStudents.Name = "txtNStudents";
            this.txtNStudents.Size = new System.Drawing.Size(46, 24);
            this.txtNStudents.TabIndex = 174;
            this.txtNStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtNStudents, "Minuti per allarme prima della fine");
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(736, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 175;
            this.label6.Text = "n.Allievi";
            this.toolTip1.SetToolTip(this.label6, "Minuto di  inizio della lezione");
            // 
            // btnStudentsNotes
            // 
            this.btnStudentsNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStudentsNotes.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentsNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStudentsNotes.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStudentsNotes.Location = new System.Drawing.Point(953, 678);
            this.btnStudentsNotes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStudentsNotes.Name = "btnStudentsNotes";
            this.btnStudentsNotes.Size = new System.Drawing.Size(101, 54);
            this.btnStudentsNotes.TabIndex = 176;
            this.btnStudentsNotes.Text = "Annotaz.";
            this.toolTip1.SetToolTip(this.btnStudentsNotes, "Finestra per assegnare annotazioni di gruppo");
            this.btnStudentsNotes.UseVisualStyleBackColor = false;
            this.btnStudentsNotes.Click += new System.EventHandler(this.btnStudentsNotes_Click);
            // 
            // txtIdClass
            // 
            this.txtIdClass.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtIdClass.Location = new System.Drawing.Point(17, 77);
            this.txtIdClass.Name = "txtIdClass";
            this.txtIdClass.Size = new System.Drawing.Size(46, 24);
            this.txtIdClass.TabIndex = 177;
            this.txtIdClass.Text = "0";
            this.txtIdClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtIdClass, "Minuti per allarme prima della fine");
            // 
            // chkPopUpQuestionsEnabled
            // 
            this.chkPopUpQuestionsEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPopUpQuestionsEnabled.AutoSize = true;
            this.chkPopUpQuestionsEnabled.Location = new System.Drawing.Point(822, 338);
            this.chkPopUpQuestionsEnabled.Name = "chkPopUpQuestionsEnabled";
            this.chkPopUpQuestionsEnabled.Size = new System.Drawing.Size(167, 22);
            this.chkPopUpQuestionsEnabled.TabIndex = 179;
            this.chkPopUpQuestionsEnabled.Text = "Domande \"pop up\"";
            this.toolTip1.SetToolTip(this.chkPopUpQuestionsEnabled, "Aspetta un po\' prima di estrarre, suonando una musica");
            this.chkPopUpQuestionsEnabled.UseVisualStyleBackColor = true;
            this.chkPopUpQuestionsEnabled.CheckedChanged += new System.EventHandler(this.chkPopUpQuestionsEnabled_CheckedChanged);
            // 
            // txtPopUpQuestionCentralTime
            // 
            this.txtPopUpQuestionCentralTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPopUpQuestionCentralTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPopUpQuestionCentralTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtPopUpQuestionCentralTime.Location = new System.Drawing.Point(992, 342);
            this.txtPopUpQuestionCentralTime.Name = "txtPopUpQuestionCentralTime";
            this.txtPopUpQuestionCentralTime.Size = new System.Drawing.Size(46, 21);
            this.txtPopUpQuestionCentralTime.TabIndex = 181;
            this.txtPopUpQuestionCentralTime.Text = "7";
            this.txtPopUpQuestionCentralTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtPopUpQuestionCentralTime, "Minuti per allarme prima della fine");
            // 
            // btnRandomNumber
            // 
            this.btnRandomNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandomNumber.BackColor = System.Drawing.Color.Transparent;
            this.btnRandomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRandomNumber.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRandomNumber.Location = new System.Drawing.Point(723, 193);
            this.btnRandomNumber.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRandomNumber.Name = "btnRandomNumber";
            this.btnRandomNumber.Size = new System.Drawing.Size(91, 59);
            this.btnRandomNumber.TabIndex = 183;
            this.btnRandomNumber.Text = "Numero casuale";
            this.toolTip1.SetToolTip(this.btnRandomNumber, "Visualizzazione di un\'immagine casuale dalla cartella  qui sotto");
            this.btnRandomNumber.UseVisualStyleBackColor = false;
            this.btnRandomNumber.Click += new System.EventHandler(this.btnRandomNumber_Click);
            // 
            // lblStudentChosen
            // 
            this.lblStudentChosen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudentChosen.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentChosen.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudentChosen.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStudentChosen.Location = new System.Drawing.Point(8, 222);
            this.lblStudentChosen.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStudentChosen.Name = "lblStudentChosen";
            this.lblStudentChosen.Size = new System.Drawing.Size(625, 43);
            this.lblStudentChosen.TabIndex = 27;
            this.lblStudentChosen.Text = "Allievo";
            this.lblStudentChosen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodYear
            // 
            this.lblCodYear.AutoSize = true;
            this.lblCodYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCodYear.Location = new System.Drawing.Point(-1, 5);
            this.lblCodYear.Name = "lblCodYear";
            this.lblCodYear.Size = new System.Drawing.Size(82, 18);
            this.lblCodYear.TabIndex = 48;
            this.lblCodYear.Text = "Cod.Anno";
            // 
            // timerQuestion
            // 
            this.timerQuestion.Interval = 250;
            this.timerQuestion.Tick += new System.EventHandler(this.timerQuestion_Tick);
            // 
            // picStudent
            // 
            this.picStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picStudent.Location = new System.Drawing.Point(10, 222);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(709, 510);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStudent.TabIndex = 52;
            this.picStudent.TabStop = false;
            this.picStudent.DoubleClick += new System.EventHandler(this.picStudent_DoubleClick);
            // 
            // grpSorts
            // 
            this.grpSorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSorts.Controls.Add(this.rdbDrawByRevengeFactor);
            this.grpSorts.Controls.Add(this.rdbDrawByOldestFirst);
            this.grpSorts.Controls.Add(this.rdbDrawNoOfGrades);
            this.grpSorts.Controls.Add(this.rdbDrawLowGradesFirst);
            this.grpSorts.Controls.Add(this.rdbSortByAlphbetical);
            this.grpSorts.Controls.Add(this.rdbDrawByWeightsSum);
            this.grpSorts.Controls.Add(this.rdbDrawEqualProbability);
            this.grpSorts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpSorts.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpSorts.Location = new System.Drawing.Point(847, 38);
            this.grpSorts.Name = "grpSorts";
            this.grpSorts.Size = new System.Drawing.Size(216, 179);
            this.grpSorts.TabIndex = 69;
            this.grpSorts.TabStop = false;
            this.grpSorts.Text = "Criteri sorteg. o ordinam.";
            // 
            // btnAssess
            // 
            this.btnAssess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssess.BackColor = System.Drawing.Color.Transparent;
            this.btnAssess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAssess.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAssess.Location = new System.Drawing.Point(954, 425);
            this.btnAssess.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.Size = new System.Drawing.Size(101, 54);
            this.btnAssess.TabIndex = 30;
            this.btnAssess.Text = "Valutazione";
            this.btnAssess.UseVisualStyleBackColor = false;
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolSubject.Location = new System.Drawing.Point(819, 279);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(64, 18);
            this.lblSchoolSubject.TabIndex = 109;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // lblGradeType
            // 
            this.lblGradeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGradeType.AutoSize = true;
            this.lblGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGradeType.Location = new System.Drawing.Point(817, 224);
            this.lblGradeType.Name = "lblGradeType";
            this.lblGradeType.Size = new System.Drawing.Size(131, 18);
            this.lblGradeType.TabIndex = 110;
            this.lblGradeType.Text = "Tipo valutazione";
            // 
            // timerLesson
            // 
            this.timerLesson.Tick += new System.EventHandler(this.timerLesson_Tick);
            // 
            // ChkEnableEndLessonWarning
            // 
            this.ChkEnableEndLessonWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkEnableEndLessonWarning.AutoSize = true;
            this.ChkEnableEndLessonWarning.Checked = true;
            this.ChkEnableEndLessonWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnableEndLessonWarning.Location = new System.Drawing.Point(423, 117);
            this.ChkEnableEndLessonWarning.Name = "ChkEnableEndLessonWarning";
            this.ChkEnableEndLessonWarning.Size = new System.Drawing.Size(173, 22);
            this.ChkEnableEndLessonWarning.TabIndex = 158;
            this.ChkEnableEndLessonWarning.Text = "allarme fine lezione";
            this.ChkEnableEndLessonWarning.UseVisualStyleBackColor = true;
            this.ChkEnableEndLessonWarning.CheckedChanged += new System.EventHandler(this.ChkEnableEndLessonWarning_CheckedChanged);
            // 
            // grpImageSource
            // 
            this.grpImageSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImageSource.Controls.Add(this.chkLessonsPictures);
            this.grpImageSource.Controls.Add(this.chkGivenFolder);
            this.grpImageSource.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpImageSource.Location = new System.Drawing.Point(723, 67);
            this.grpImageSource.Name = "grpImageSource";
            this.grpImageSource.Size = new System.Drawing.Size(118, 64);
            this.grpImageSource.TabIndex = 158;
            this.grpImageSource.TabStop = false;
            this.grpImageSource.Text = "Sorg.immag.";
            // 
            // grpChooseDrawSort
            // 
            this.grpChooseDrawSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChooseDrawSort.Controls.Add(this.rdbMustSort);
            this.grpChooseDrawSort.Controls.Add(this.rdbMustDraw);
            this.grpChooseDrawSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpChooseDrawSort.Location = new System.Drawing.Point(847, 0);
            this.grpChooseDrawSort.Name = "grpChooseDrawSort";
            this.grpChooseDrawSort.Size = new System.Drawing.Size(216, 33);
            this.grpChooseDrawSort.TabIndex = 165;
            this.grpChooseDrawSort.TabStop = false;
            // 
            // rdbMustSort
            // 
            this.rdbMustSort.AutoSize = true;
            this.rdbMustSort.Location = new System.Drawing.Point(112, 9);
            this.rdbMustSort.Name = "rdbMustSort";
            this.rdbMustSort.Size = new System.Drawing.Size(95, 22);
            this.rdbMustSort.TabIndex = 1;
            this.rdbMustSort.Text = "Ordinam.";
            this.rdbMustSort.UseVisualStyleBackColor = true;
            // 
            // rdbMustDraw
            // 
            this.rdbMustDraw.AutoSize = true;
            this.rdbMustDraw.Checked = true;
            this.rdbMustDraw.Location = new System.Drawing.Point(6, 9);
            this.rdbMustDraw.Name = "rdbMustDraw";
            this.rdbMustDraw.Size = new System.Drawing.Size(99, 22);
            this.rdbMustDraw.TabIndex = 0;
            this.rdbMustDraw.TabStop = true;
            this.rdbMustDraw.Text = "Sorteggio";
            this.rdbMustDraw.UseVisualStyleBackColor = true;
            // 
            // lstTimeInterval
            // 
            this.lstTimeInterval.ForeColor = System.Drawing.Color.DarkBlue;
            this.lstTimeInterval.FormattingEnabled = true;
            this.lstTimeInterval.ItemHeight = 18;
            this.lstTimeInterval.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "45",
            "60"});
            this.lstTimeInterval.Location = new System.Drawing.Point(168, 28);
            this.lstTimeInterval.Name = "lstTimeInterval";
            this.lstTimeInterval.Size = new System.Drawing.Size(46, 112);
            this.lstTimeInterval.TabIndex = 166;
            this.lstTimeInterval.SelectedIndexChanged += new System.EventHandler(this.lstTimeInterval_SelectedIndexChanged);
            this.lstTimeInterval.DoubleClick += new System.EventHandler(this.lstTimeInterval_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 172;
            this.label2.Text = "salv.db";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(11, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 178;
            this.label7.Text = "Id classe";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(995, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 180;
            this.label8.Text = "tempo";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(1039, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 182;
            this.label9.Text = "min";
            // 
            // timerPopUp
            // 
            this.timerPopUp.Tick += new System.EventHandler(this.timerPopUp_Tick);
            // 
            // chkSoundsInColorTimer
            // 
            this.chkSoundsInColorTimer.AutoSize = true;
            this.chkSoundsInColorTimer.Checked = true;
            this.chkSoundsInColorTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoundsInColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkSoundsInColorTimer.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkSoundsInColorTimer.Location = new System.Drawing.Point(217, 66);
            this.chkSoundsInColorTimer.Name = "chkSoundsInColorTimer";
            this.chkSoundsInColorTimer.Size = new System.Drawing.Size(70, 22);
            this.chkSoundsInColorTimer.TabIndex = 184;
            this.chkSoundsInColorTimer.Text = "Suoni";
            this.toolTip1.SetToolTip(this.chkSoundsInColorTimer, "Esegue i suoni nel timer a colori");
            this.chkSoundsInColorTimer.UseVisualStyleBackColor = true;
            this.chkSoundsInColorTimer.CheckedChanged += new System.EventHandler(this.chkSoundsInColorTimer_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1069, 741);
            this.Controls.Add(this.chkSoundsInColorTimer);
            this.Controls.Add(this.btnTemporary);
            this.Controls.Add(this.btnRandomNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPopUpQuestionCentralTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkPopUpQuestionsEnabled);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdClass);
            this.Controls.Add(this.btnStudentsNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNStudents);
            this.Controls.Add(this.BtnShowRandomImage);
            this.Controls.Add(this.btnStartBarTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBackgroundSaveRunning);
            this.Controls.Add(this.btnMosaic);
            this.Controls.Add(this.btnStartColorTimer);
            this.Controls.Add(this.txtTimeInterval);
            this.Controls.Add(this.lstTimeInterval);
            this.Controls.Add(this.grpChooseDrawSort);
            this.Controls.Add(this.lstNames);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdStudent);
            this.Controls.Add(this.grpImageSource);
            this.Controls.Add(this.ChkActivateLessonClock);
            this.Controls.Add(this.ChkEnableEndLessonWarning);
            this.Controls.Add(this.btnOldestGrade);
            this.Controls.Add(this.btnAssess);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.butComeOn);
            this.Controls.Add(this.btnYearTopics);
            this.Controls.Add(this.btnCheckNoGrade);
            this.Controls.Add(this.btnClassesGradesSummary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckRevenge);
            this.Controls.Add(this.chkSuspence);
            this.Controls.Add(this.btnCheckToggle);
            this.Controls.Add(this.lblVindicationFactor);
            this.Controls.Add(this.txtRevengeFactor);
            this.Controls.Add(this.btnVindicationFactorMinus);
            this.Controls.Add(this.btnVindicationFactorPlus);
            this.Controls.Add(this.lblDatabaseFile);
            this.Controls.Add(this.txtMinuteStartAlarm);
            this.Controls.Add(this.txtDurationLesson);
            this.Controls.Add(this.txtMinuteStartLesson);
            this.Controls.Add(this.BtnLessonTime);
            this.Controls.Add(this.btnMakeGroups);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.btnQuestion);
            this.Controls.Add(this.btnStartLinks);
            this.Controls.Add(this.btnTopicsDone);
            this.Controls.Add(this.lblGradeType);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbSchoolSubject);
            this.Controls.Add(this.btnLessonsTopics);
            this.Controls.Add(this.cmbGradeType);
            this.Controls.Add(this.btnStudentsGradesSummary);
            this.Controls.Add(this.BtnSetup);
            this.Controls.Add(this.grpSorts);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.TxtPathImages);
            this.Controls.Add(this.CmbSchoolYear);
            this.Controls.Add(this.chkStudentsListVisible);
            this.Controls.Add(this.chkFotoVisibile);
            this.Controls.Add(this.chkNomeVisibile);
            this.Controls.Add(this.pgbTimeQuestion);
            this.Controls.Add(this.lblCodYear);
            this.Controls.Add(this.lstClasses);
            this.Controls.Add(this.btnCheckNone);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.lblStudentChosen);
            this.Controls.Add(this.picStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchoolGrades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundSaveRunning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.grpSorts.ResumeLayout(false);
            this.grpSorts.PerformLayout();
            this.grpImageSource.ResumeLayout(false);
            this.grpImageSource.PerformLayout();
            this.grpChooseDrawSort.ResumeLayout(false);
            this.grpChooseDrawSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butComeOn;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCheckNone;
        private System.Windows.Forms.Label lblStudentChosen;
        private System.Windows.Forms.ListBox lstClasses;
        private System.Windows.Forms.Label lblCodYear;
        private System.Windows.Forms.ProgressBar pgbTimeQuestion;
        private System.Windows.Forms.Timer timerQuestion;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.CheckBox chkNomeVisibile;
        private System.Windows.Forms.CheckBox chkFotoVisibile;
        private System.Windows.Forms.CheckBox chkStudentsListVisible;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.CheckedListBox lstNames;
        private System.Windows.Forms.TextBox TxtPathImages;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button BtnShowRandomImage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpSorts;
        private System.Windows.Forms.RadioButton rdbSortByAlphbetical;
        private System.Windows.Forms.RadioButton rdbDrawByWeightsSum;
        private System.Windows.Forms.RadioButton rdbDrawEqualProbability;
        private System.Windows.Forms.RadioButton rdbDrawLowGradesFirst;
        private System.Windows.Forms.Button BtnSetup;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnStudentsGradesSummary;
        private System.Windows.Forms.Button btnOldestGrade;
        private System.Windows.Forms.RadioButton rdbDrawByOldestFirst;
        private System.Windows.Forms.Button btnAssess;
        private System.Windows.Forms.ComboBox cmbGradeType;
        private System.Windows.Forms.Button btnLessonsTopics;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbSchoolSubject;
        private System.Windows.Forms.Label lblGradeType;
        private System.Windows.Forms.RadioButton rdbDrawNoOfGrades;
        private System.Windows.Forms.Label lblDatabaseFile;
        private System.Windows.Forms.Button btnTopicsDone;
        private System.Windows.Forms.Button btnStartLinks;
        private System.Windows.Forms.Button btnQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnMakeGroups;
        private System.Windows.Forms.Button BtnLessonTime;
        private System.Windows.Forms.TextBox txtMinuteStartLesson;
        private System.Windows.Forms.TextBox txtDurationLesson;
        private System.Windows.Forms.TextBox txtMinuteStartAlarm;
        private System.Windows.Forms.Timer timerLesson;
        private System.Windows.Forms.RadioButton rdbDrawByRevengeFactor;
        private System.Windows.Forms.Button btnVindicationFactorPlus;
        private System.Windows.Forms.Button btnVindicationFactorMinus;
        private System.Windows.Forms.TextBox txtRevengeFactor;
        private System.Windows.Forms.Label lblVindicationFactor;
        private System.Windows.Forms.Button btnCheckToggle;
        private System.Windows.Forms.CheckBox chkSuspence;
        private System.Windows.Forms.Button btnCheckRevenge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClassesGradesSummary;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnCheckNoGrade;
        private System.Windows.Forms.Button btnYearTopics;
        private System.Windows.Forms.CheckBox ChkEnableEndLessonWarning;
        private System.Windows.Forms.CheckBox ChkActivateLessonClock;
        private System.Windows.Forms.GroupBox grpImageSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdStudent;
        private System.Windows.Forms.Button btnTemporary;
        private System.Windows.Forms.GroupBox grpChooseDrawSort;
        private System.Windows.Forms.RadioButton rdbMustSort;
        private System.Windows.Forms.RadioButton rdbMustDraw;
        private System.Windows.Forms.ListBox lstTimeInterval;
        private System.Windows.Forms.TextBox txtTimeInterval;
        private System.Windows.Forms.Button btnStartColorTimer;
        private System.Windows.Forms.Button btnMosaic;
        private System.Windows.Forms.PictureBox picBackgroundSaveRunning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartBarTimer;
        private System.Windows.Forms.CheckBox chkLessonsPictures;
        private System.Windows.Forms.CheckBox chkGivenFolder;
        private System.Windows.Forms.TextBox txtNStudents;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStudentsNotes;
        private System.Windows.Forms.TextBox txtIdClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPopUpQuestionsEnabled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPopUpQuestionCentralTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timerPopUp;
        private System.Windows.Forms.Button btnRandomNumber;
        private System.Windows.Forms.CheckBox chkSoundsInColorTimer;
    }
}


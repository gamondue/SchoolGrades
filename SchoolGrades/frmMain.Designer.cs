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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnDraw = new System.Windows.Forms.Button();
            butComeOn = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            txtMinuteStartLesson = new System.Windows.Forms.TextBox();
            txtDurationLesson = new System.Windows.Forms.TextBox();
            txtAdvanceMinutes = new System.Windows.Forms.TextBox();
            txtRevengeFactor = new System.Windows.Forms.TextBox();
            btnCheckNone = new System.Windows.Forms.Button();
            lstClasses = new System.Windows.Forms.ListBox();
            pgbTimeQuestion = new System.Windows.Forms.ProgressBar();
            chkNameIsVisible = new System.Windows.Forms.CheckBox();
            chkPhotoVisibile = new System.Windows.Forms.CheckBox();
            chkStudentsListVisible = new System.Windows.Forms.CheckBox();
            cmbSchoolYear = new System.Windows.Forms.ComboBox();
            txtPathImages = new System.Windows.Forms.TextBox();
            btnPath = new System.Windows.Forms.Button();
            btnShowRandomImage = new System.Windows.Forms.Button();
            rdbDrawByRevengeFactor = new System.Windows.Forms.RadioButton();
            rdbDrawByOldestFirst = new System.Windows.Forms.RadioButton();
            rdbDrawNoOfGrades = new System.Windows.Forms.RadioButton();
            rdbDrawLowGradesFirst = new System.Windows.Forms.RadioButton();
            rdbSortByAlphbetical = new System.Windows.Forms.RadioButton();
            rdbDrawByWeightsSum = new System.Windows.Forms.RadioButton();
            rdbDrawEqualProbability = new System.Windows.Forms.RadioButton();
            btnSetup = new System.Windows.Forms.Button();
            btnStudentsGradesSummary = new System.Windows.Forms.Button();
            btnOldestGrade = new System.Windows.Forms.Button();
            cmbGradeType = new System.Windows.Forms.ComboBox();
            btnLessonsTopics = new System.Windows.Forms.Button();
            cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            btnTopicsDone = new System.Windows.Forms.Button();
            btnStartLinks = new System.Windows.Forms.Button();
            btnQuestion = new System.Windows.Forms.Button();
            txtQuestion = new System.Windows.Forms.TextBox();
            btnMakeGroups = new System.Windows.Forms.Button();
            btnLessonTime = new System.Windows.Forms.Button();
            btnVindicationFactorPlus = new System.Windows.Forms.Button();
            btnVindicationFactorMinus = new System.Windows.Forms.Button();
            btnCheckToggle = new System.Windows.Forms.Button();
            chkSuspence = new System.Windows.Forms.CheckBox();
            btnCheckRevenge = new System.Windows.Forms.Button();
            lblVindicationFactor = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            btnClassesGradesSummary = new System.Windows.Forms.Button();
            btnCheckAll = new System.Windows.Forms.Button();
            btnCheckNoGrade = new System.Windows.Forms.Button();
            lblDatabaseFile = new System.Windows.Forms.Label();
            btnYearTopics = new System.Windows.Forms.Button();
            chkActivateLessonClock = new System.Windows.Forms.CheckBox();
            lblIdStudent = new System.Windows.Forms.Label();
            txtIdStudent = new System.Windows.Forms.TextBox();
            btnTemporary = new System.Windows.Forms.Button();
            txtTimeInterval = new System.Windows.Forms.TextBox();
            btnStartColorTimer = new System.Windows.Forms.Button();
            btnMosaic = new System.Windows.Forms.Button();
            btnStartBarTimer = new System.Windows.Forms.Button();
            chkLessonsPictures = new System.Windows.Forms.CheckBox();
            chkGivenFolder = new System.Windows.Forms.CheckBox();
            picBackgroundSaveRunning = new System.Windows.Forms.PictureBox();
            txtNStudents = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            btnStudentsNotes = new System.Windows.Forms.Button();
            txtIdClass = new System.Windows.Forms.TextBox();
            chkPopUpQuestionsEnabled = new System.Windows.Forms.CheckBox();
            txtPopUpQuestionCentralTime = new System.Windows.Forms.TextBox();
            btnRandomNumber = new System.Windows.Forms.Button();
            chkSoundsInColorTimer = new System.Windows.Forms.CheckBox();
            lblLastDatabaseModification = new System.Windows.Forms.Label();
            lblStudentChosen = new System.Windows.Forms.Label();
            lblCodYear = new System.Windows.Forms.Label();
            timerQuestion = new System.Windows.Forms.Timer(components);
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            picStudent = new System.Windows.Forms.PictureBox();
            grpSorts = new System.Windows.Forms.GroupBox();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            btnAssess = new System.Windows.Forms.Button();
            lblSchoolSubject = new System.Windows.Forms.Label();
            lblGradeType = new System.Windows.Forms.Label();
            timerLesson = new System.Windows.Forms.Timer(components);
            chkEnableEndLessonWarning = new System.Windows.Forms.CheckBox();
            grpImageSource = new System.Windows.Forms.GroupBox();
            grpChooseDrawSort = new System.Windows.Forms.GroupBox();
            rdbMustSort = new System.Windows.Forms.RadioButton();
            rdbMustDraw = new System.Windows.Forms.RadioButton();
            lstTimeInterval = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            timerPopUp = new System.Windows.Forms.Timer(components);
            dgwStudents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)picBackgroundSaveRunning).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            grpSorts.SuspendLayout();
            grpImageSource.SuspendLayout();
            grpChooseDrawSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwStudents).BeginInit();
            SuspendLayout();
            // 
            // btnDraw
            // 
            btnDraw.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDraw.BackColor = System.Drawing.Color.Transparent;
            btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDraw.ForeColor = System.Drawing.Color.DarkBlue;
            btnDraw.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnDraw.Location = new System.Drawing.Point(698, 377);
            btnDraw.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new System.Drawing.Size(94, 48);
            btnDraw.TabIndex = 1;
            btnDraw.Text = "Sortegg. o ordin.";
            toolTip1.SetToolTip(btnDraw, "Fa l'ordinamento od il sorteggio");
            btnDraw.UseVisualStyleBackColor = false;
            btnDraw.Click += btnDrawOrSort_Click;
            // 
            // butComeOn
            // 
            butComeOn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            butComeOn.BackColor = System.Drawing.Color.Transparent;
            butComeOn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            butComeOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            butComeOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            butComeOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            butComeOn.ForeColor = System.Drawing.Color.DarkBlue;
            butComeOn.Location = new System.Drawing.Point(803, 377);
            butComeOn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            butComeOn.Name = "butComeOn";
            butComeOn.Size = new System.Drawing.Size(94, 48);
            butComeOn.TabIndex = 0;
            butComeOn.Text = "Costretto";
            toolTip1.SetToolTip(butComeOn, "Scelta del prossimo allievo dell'elenco");
            butComeOn.UseVisualStyleBackColor = false;
            butComeOn.Click += btnComeOn_Click;
            // 
            // toolTip1
            // 
            toolTip1.BackColor = System.Drawing.SystemColors.ControlText;
            toolTip1.ForeColor = System.Drawing.Color.Lime;
            // 
            // txtMinuteStartLesson
            // 
            txtMinuteStartLesson.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtMinuteStartLesson.ForeColor = System.Drawing.Color.DarkBlue;
            txtMinuteStartLesson.Location = new System.Drawing.Point(516, 294);
            txtMinuteStartLesson.Name = "txtMinuteStartLesson";
            txtMinuteStartLesson.Size = new System.Drawing.Size(46, 24);
            txtMinuteStartLesson.TabIndex = 139;
            txtMinuteStartLesson.Text = "0";
            txtMinuteStartLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtMinuteStartLesson, "Minuto inizio lezione");
            txtMinuteStartLesson.Leave += LessonAlarmChanged;
            // 
            // txtDurationLesson
            // 
            txtDurationLesson.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtDurationLesson.ForeColor = System.Drawing.Color.DarkBlue;
            txtDurationLesson.Location = new System.Drawing.Point(516, 319);
            txtDurationLesson.Name = "txtDurationLesson";
            txtDurationLesson.Size = new System.Drawing.Size(46, 24);
            txtDurationLesson.TabIndex = 140;
            txtDurationLesson.Text = "60";
            txtDurationLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtDurationLesson, "Minuti durata lezione");
            txtDurationLesson.Leave += LessonAlarmChanged;
            // 
            // txtAdvanceMinutes
            // 
            txtAdvanceMinutes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtAdvanceMinutes.ForeColor = System.Drawing.Color.DarkBlue;
            txtAdvanceMinutes.Location = new System.Drawing.Point(516, 344);
            txtAdvanceMinutes.Name = "txtAdvanceMinutes";
            txtAdvanceMinutes.Size = new System.Drawing.Size(46, 24);
            txtAdvanceMinutes.TabIndex = 141;
            txtAdvanceMinutes.Text = "8";
            txtAdvanceMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtAdvanceMinutes, "Minuti per allarme prima della fine");
            txtAdvanceMinutes.Leave += LessonAlarmChanged;
            // 
            // txtRevengeFactor
            // 
            txtRevengeFactor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtRevengeFactor.Location = new System.Drawing.Point(761, 499);
            txtRevengeFactor.Name = "txtRevengeFactor";
            txtRevengeFactor.ReadOnly = true;
            txtRevengeFactor.Size = new System.Drawing.Size(36, 24);
            txtRevengeFactor.TabIndex = 144;
            txtRevengeFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtRevengeFactor, "Fattore di vendetta dell'allievo corrente");
            // 
            // btnCheckNone
            // 
            btnCheckNone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCheckNone.BackColor = System.Drawing.Color.Transparent;
            btnCheckNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckNone.ForeColor = System.Drawing.Color.DarkBlue;
            btnCheckNone.Location = new System.Drawing.Point(573, 588);
            btnCheckNone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnCheckNone.Name = "btnCheckNone";
            btnCheckNone.Size = new System.Drawing.Size(94, 48);
            btnCheckNone.TabIndex = 29;
            btnCheckNone.Text = "X nessuno";
            toolTip1.SetToolTip(btnCheckNone, "Check nessun allievo");
            btnCheckNone.UseVisualStyleBackColor = false;
            btnCheckNone.Click += btnCheckNone_Click;
            // 
            // lstClasses
            // 
            lstClasses.BackColor = System.Drawing.Color.PowderBlue;
            lstClasses.ForeColor = System.Drawing.Color.DarkBlue;
            lstClasses.FormattingEnabled = true;
            lstClasses.ItemHeight = 18;
            lstClasses.Location = new System.Drawing.Point(86, 4);
            lstClasses.Name = "lstClasses";
            lstClasses.Size = new System.Drawing.Size(76, 130);
            lstClasses.TabIndex = 46;
            lstClasses.TabStop = false;
            toolTip1.SetToolTip(lstClasses, "Classi dell'anno scolastico selezionato");
            lstClasses.SelectedIndexChanged += lstClassi_SelectedIndexChanged;
            lstClasses.DoubleClick += lstClassi_DoubleClick;
            // 
            // pgbTimeQuestion
            // 
            pgbTimeQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pgbTimeQuestion.Location = new System.Drawing.Point(8, 168);
            pgbTimeQuestion.Name = "pgbTimeQuestion";
            pgbTimeQuestion.Size = new System.Drawing.Size(560, 23);
            pgbTimeQuestion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            pgbTimeQuestion.TabIndex = 50;
            toolTip1.SetToolTip(pgbTimeQuestion, "Barra tempo per la risposta, Click  per far partire il cronometro.");
            pgbTimeQuestion.Click += pgbTimeQuestion_Click;
            // 
            // chkNameIsVisible
            // 
            chkNameIsVisible.AutoSize = true;
            chkNameIsVisible.Checked = true;
            chkNameIsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            chkNameIsVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chkNameIsVisible.ForeColor = System.Drawing.Color.DarkBlue;
            chkNameIsVisible.Location = new System.Drawing.Point(297, 66);
            chkNameIsVisible.Name = "chkNomeVisibile";
            chkNameIsVisible.Size = new System.Drawing.Size(128, 22);
            chkNameIsVisible.TabIndex = 14;
            chkNameIsVisible.Text = "Nome visibile";
            toolTip1.SetToolTip(chkNameIsVisible, "Visualizza il nome dell'allievo");
            chkNameIsVisible.UseVisualStyleBackColor = true;
            chkNameIsVisible.CheckedChanged += chkNameIsVisible_CheckedChanged;
            // 
            // chkPhotoVisibile
            // 
            chkPhotoVisibile.AutoSize = true;
            chkPhotoVisibile.Checked = true;
            chkPhotoVisibile.CheckState = System.Windows.Forms.CheckState.Checked;
            chkPhotoVisibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chkPhotoVisibile.ForeColor = System.Drawing.Color.DarkBlue;
            chkPhotoVisibile.Location = new System.Drawing.Point(297, 91);
            chkPhotoVisibile.Name = "chkPhotoVisibile";
            chkPhotoVisibile.Size = new System.Drawing.Size(118, 22);
            chkPhotoVisibile.TabIndex = 16;
            chkPhotoVisibile.Text = "Foto visibile";
            toolTip1.SetToolTip(chkPhotoVisibile, "Visualizza la foto dell'allievo");
            chkPhotoVisibile.UseVisualStyleBackColor = true;
            chkPhotoVisibile.CheckedChanged += chkPhotoVisibible_CheckedChanged;
            // 
            // chkStudentsListVisible
            // 
            chkStudentsListVisible.AutoSize = true;
            chkStudentsListVisible.Checked = true;
            chkStudentsListVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            chkStudentsListVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chkStudentsListVisible.ForeColor = System.Drawing.Color.DarkBlue;
            chkStudentsListVisible.Location = new System.Drawing.Point(297, 116);
            chkStudentsListVisible.Name = "chkStudentsListVisible";
            chkStudentsListVisible.Size = new System.Drawing.Size(119, 22);
            chkStudentsListVisible.TabIndex = 18;
            chkStudentsListVisible.Text = "Lista visibile";
            toolTip1.SetToolTip(chkStudentsListVisible, "Visualizza l'elenco degli allievi della classe");
            chkStudentsListVisible.UseVisualStyleBackColor = true;
            chkStudentsListVisible.CheckedChanged += chkStudentsListVisible_CheckedChanged;
            // 
            // cmbSchoolYear
            // 
            cmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolYear.FormattingEnabled = true;
            cmbSchoolYear.Location = new System.Drawing.Point(4, 28);
            cmbSchoolYear.Name = "cmbSchoolYear";
            cmbSchoolYear.Size = new System.Drawing.Size(72, 26);
            cmbSchoolYear.TabIndex = 62;
            toolTip1.SetToolTip(cmbSchoolYear, "Anno scolastico senza \"-\"");
            cmbSchoolYear.SelectedIndexChanged += cmbSchoolYear_SelectedIndexChanged;
            // 
            // txtPathImages
            // 
            txtPathImages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            txtPathImages.Location = new System.Drawing.Point(8, 142);
            txtPathImages.Name = "txtPathImages";
            txtPathImages.Size = new System.Drawing.Size(520, 24);
            txtPathImages.TabIndex = 20;
            toolTip1.SetToolTip(txtPathImages, "Cartella in cui trovare l'immagine casuale (click per aprire un file nella cartella) ");
            txtPathImages.Click += txtPathImages_Click;
            txtPathImages.TextChanged += txtPathImages_TextChanged;
            txtPathImages.DoubleClick += txtPathImages_DoubleClick;
            // 
            // btnPath
            // 
            btnPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPath.ForeColor = System.Drawing.Color.Black;
            btnPath.Location = new System.Drawing.Point(534, 140);
            btnPath.Name = "btnPath";
            btnPath.Size = new System.Drawing.Size(34, 27);
            btnPath.TabIndex = 67;
            btnPath.Text = "..";
            toolTip1.SetToolTip(btnPath, "Scelta cartella immagini");
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // btnShowRandomImage
            // 
            btnShowRandomImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnShowRandomImage.BackColor = System.Drawing.Color.Transparent;
            btnShowRandomImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnShowRandomImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnShowRandomImage.Location = new System.Drawing.Point(572, 131);
            btnShowRandomImage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnShowRandomImage.Name = "btnShowRandomImage";
            btnShowRandomImage.Size = new System.Drawing.Size(94, 48);
            btnShowRandomImage.TabIndex = 22;
            btnShowRandomImage.Text = "Immagine casuale";
            toolTip1.SetToolTip(btnShowRandomImage, "Visualizzazione di un'immagine casuale dalla cartella  qui a lato");
            btnShowRandomImage.UseVisualStyleBackColor = false;
            btnShowRandomImage.Click += BtnShowRandomImage_Click;
            // 
            // rdbDrawByRevengeFactor
            // 
            rdbDrawByRevengeFactor.AutoSize = true;
            rdbDrawByRevengeFactor.Location = new System.Drawing.Point(6, 152);
            rdbDrawByRevengeFactor.Name = "rdbDrawByRevengeFactor";
            rdbDrawByRevengeFactor.Size = new System.Drawing.Size(169, 22);
            rdbDrawByRevengeFactor.TabIndex = 6;
            rdbDrawByRevengeFactor.Text = "Tremenda vendetta";
            toolTip1.SetToolTip(rdbDrawByRevengeFactor, "Sorteggio con probabilità più alta per maggiori fattori di vendetta");
            rdbDrawByRevengeFactor.UseVisualStyleBackColor = true;
            rdbDrawByRevengeFactor.CheckedChanged += rdbDrawByRevengeFactor_CheckedChanged;
            // 
            // rdbDrawByOldestFirst
            // 
            rdbDrawByOldestFirst.AutoSize = true;
            rdbDrawByOldestFirst.Enabled = false;
            rdbDrawByOldestFirst.Location = new System.Drawing.Point(6, 86);
            rdbDrawByOldestFirst.Name = "rdbDrawByOldestFirst";
            rdbDrawByOldestFirst.Size = new System.Drawing.Size(155, 22);
            rdbDrawByOldestFirst.TabIndex = 4;
            rdbDrawByOldestFirst.Text = "Prima voti vecchi";
            toolTip1.SetToolTip(rdbDrawByOldestFirst, "Ordinamento con prima i voti più vecchi del tipo selezionato");
            rdbDrawByOldestFirst.UseVisualStyleBackColor = true;
            // 
            // rdbDrawNoOfGrades
            // 
            rdbDrawNoOfGrades.AutoSize = true;
            rdbDrawNoOfGrades.Location = new System.Drawing.Point(6, 64);
            rdbDrawNoOfGrades.Name = "rdbDrawNoOfGrades";
            rdbDrawNoOfGrades.Size = new System.Drawing.Size(118, 22);
            rdbDrawNoOfGrades.TabIndex = 5;
            rdbDrawNoOfGrades.Text = "Numero voti";
            toolTip1.SetToolTip(rdbDrawNoOfGrades, "Ordinamento in base al numero dei voti del tipo selezionato");
            rdbDrawNoOfGrades.UseVisualStyleBackColor = true;
            // 
            // rdbDrawLowGradesFirst
            // 
            rdbDrawLowGradesFirst.AutoSize = true;
            rdbDrawLowGradesFirst.Enabled = false;
            rdbDrawLowGradesFirst.Location = new System.Drawing.Point(6, 130);
            rdbDrawLowGradesFirst.Name = "rdbDrawLowGradesFirst";
            rdbDrawLowGradesFirst.Size = new System.Drawing.Size(147, 22);
            rdbDrawLowGradesFirst.TabIndex = 3;
            rdbDrawLowGradesFirst.Text = "Prima voti bassi";
            toolTip1.SetToolTip(rdbDrawLowGradesFirst, "Ordinamento per voto descrescente");
            rdbDrawLowGradesFirst.UseVisualStyleBackColor = true;
            // 
            // rdbSortByAlphbetical
            // 
            rdbSortByAlphbetical.AutoSize = true;
            rdbSortByAlphbetical.Location = new System.Drawing.Point(6, 108);
            rdbSortByAlphbetical.Name = "rdbSortByAlphbetical";
            rdbSortByAlphbetical.Size = new System.Drawing.Size(100, 22);
            rdbSortByAlphbetical.TabIndex = 2;
            rdbSortByAlphbetical.Text = "Alfabetico";
            toolTip1.SetToolTip(rdbSortByAlphbetical, "Ordinamento alfabetico");
            rdbSortByAlphbetical.UseVisualStyleBackColor = true;
            // 
            // rdbDrawByWeightsSum
            // 
            rdbDrawByWeightsSum.AutoSize = true;
            rdbDrawByWeightsSum.Location = new System.Drawing.Point(6, 42);
            rdbDrawByWeightsSum.Name = "rdbDrawByWeightsSum";
            rdbDrawByWeightsSum.Size = new System.Drawing.Size(171, 22);
            rdbDrawByWeightsSum.TabIndex = 1;
            rdbDrawByWeightsSum.Text = "Peso totale dei voti";
            toolTip1.SetToolTip(rdbDrawByWeightsSum, "Ordinamento secondo il peso totale del tipo di voto selezionato");
            rdbDrawByWeightsSum.UseVisualStyleBackColor = true;
            // 
            // rdbDrawEqualProbability
            // 
            rdbDrawEqualProbability.AutoSize = true;
            rdbDrawEqualProbability.Checked = true;
            rdbDrawEqualProbability.Location = new System.Drawing.Point(6, 20);
            rdbDrawEqualProbability.Name = "rdbDrawEqualProbability";
            rdbDrawEqualProbability.Size = new System.Drawing.Size(155, 22);
            rdbDrawEqualProbability.TabIndex = 0;
            rdbDrawEqualProbability.TabStop = true;
            rdbDrawEqualProbability.Text = "Probabilità uguali";
            toolTip1.SetToolTip(rdbDrawEqualProbability, "Sorteggio con uguali probabilitàfra ogni allievo");
            rdbDrawEqualProbability.UseVisualStyleBackColor = true;
            // 
            // btnSetup
            // 
            btnSetup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSetup.BackColor = System.Drawing.Color.Transparent;
            btnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSetup.ForeColor = System.Drawing.Color.DarkBlue;
            btnSetup.Location = new System.Drawing.Point(566, 5);
            btnSetup.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnSetup.Name = "btnSetup";
            btnSetup.Size = new System.Drawing.Size(107, 59);
            btnSetup.TabIndex = 73;
            btnSetup.Text = "Setup";
            toolTip1.SetToolTip(btnSetup, "Finestra opzioni di configurazione");
            btnSetup.UseVisualStyleBackColor = false;
            btnSetup.Click += btnSetup_Click;
            // 
            // btnStudentsGradesSummary
            // 
            btnStudentsGradesSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStudentsGradesSummary.BackColor = System.Drawing.Color.Transparent;
            btnStudentsGradesSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStudentsGradesSummary.ForeColor = System.Drawing.Color.DarkBlue;
            btnStudentsGradesSummary.Location = new System.Drawing.Point(803, 588);
            btnStudentsGradesSummary.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnStudentsGradesSummary.Name = "btnStudentsGradesSummary";
            btnStudentsGradesSummary.Size = new System.Drawing.Size(94, 48);
            btnStudentsGradesSummary.TabIndex = 74;
            btnStudentsGradesSummary.Text = "Voti allievo";
            toolTip1.SetToolTip(btnStudentsGradesSummary, "Finestra di riepilogo dei voti e delle annotazioni sull'allievo corrente");
            btnStudentsGradesSummary.UseVisualStyleBackColor = false;
            btnStudentsGradesSummary.Click += btnStudentsGradesSummary_Click;
            // 
            // btnOldestGrade
            // 
            btnOldestGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOldestGrade.BackColor = System.Drawing.Color.Transparent;
            btnOldestGrade.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            btnOldestGrade.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            btnOldestGrade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            btnOldestGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOldestGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnOldestGrade.Location = new System.Drawing.Point(803, 482);
            btnOldestGrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnOldestGrade.Name = "btnOldestGrade";
            btnOldestGrade.Size = new System.Drawing.Size(94, 48);
            btnOldestGrade.TabIndex = 75;
            btnOldestGrade.Text = "Voto più vecchio";
            toolTip1.SetToolTip(btnOldestGrade, "Sceglie l'allievo che ha il voto più vecchio");
            btnOldestGrade.UseVisualStyleBackColor = false;
            btnOldestGrade.Click += btnOldestGrade_Click;
            // 
            // cmbGradeType
            // 
            cmbGradeType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbGradeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            cmbGradeType.FormattingEnabled = true;
            cmbGradeType.Items.AddRange(new object[] { "Voticini", "Orali", "Scritti", "Pratici", "Scritto-grafici" });
            cmbGradeType.Location = new System.Drawing.Point(669, 246);
            cmbGradeType.Margin = new System.Windows.Forms.Padding(4);
            cmbGradeType.Name = "cmbGradeType";
            cmbGradeType.Size = new System.Drawing.Size(239, 28);
            cmbGradeType.TabIndex = 96;
            toolTip1.SetToolTip(cmbGradeType, "Scelta del tipo di voto");
            cmbGradeType.SelectedIndexChanged += cmbGradeType_SelectedIndexChanged;
            // 
            // btnLessonsTopics
            // 
            btnLessonsTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLessonsTopics.BackColor = System.Drawing.Color.Transparent;
            btnLessonsTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLessonsTopics.ForeColor = System.Drawing.Color.DarkBlue;
            btnLessonsTopics.Location = new System.Drawing.Point(698, 641);
            btnLessonsTopics.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnLessonsTopics.Name = "btnLessonsTopics";
            btnLessonsTopics.Size = new System.Drawing.Size(94, 48);
            btnLessonsTopics.TabIndex = 97;
            btnLessonsTopics.Text = "Lezioni";
            toolTip1.SetToolTip(btnLessonsTopics, "Finestra gestione lezioni della  materia selezionata");
            btnLessonsTopics.UseVisualStyleBackColor = false;
            btnLessonsTopics.Click += btnLessonsTopics_Click;
            // 
            // cmbSchoolSubject
            // 
            cmbSchoolSubject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbSchoolSubject.BackColor = System.Drawing.SystemColors.Window;
            cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            cmbSchoolSubject.FormattingEnabled = true;
            cmbSchoolSubject.Location = new System.Drawing.Point(669, 300);
            cmbSchoolSubject.Name = "cmbSchoolSubject";
            cmbSchoolSubject.Size = new System.Drawing.Size(239, 26);
            cmbSchoolSubject.TabIndex = 108;
            toolTip1.SetToolTip(cmbSchoolSubject, "Scelta materia");
            cmbSchoolSubject.SelectedIndexChanged += cmbSchoolSubject_SelectedIndexChanged;
            // 
            // btnTopicsDone
            // 
            btnTopicsDone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTopicsDone.BackColor = System.Drawing.Color.Transparent;
            btnTopicsDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnTopicsDone.ForeColor = System.Drawing.Color.DarkBlue;
            btnTopicsDone.Location = new System.Drawing.Point(698, 535);
            btnTopicsDone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnTopicsDone.Name = "btnTopicsDone";
            btnTopicsDone.Size = new System.Drawing.Size(94, 48);
            btnTopicsDone.TabIndex = 112;
            btnTopicsDone.Text = "Argom. fatti";
            toolTip1.SetToolTip(btnTopicsDone, "Apre pagina ricerca argomenti già spiegati nel programma didattico");
            btnTopicsDone.UseVisualStyleBackColor = false;
            btnTopicsDone.Click += btnTopicsDone_Click;
            // 
            // btnStartLinks
            // 
            btnStartLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStartLinks.Location = new System.Drawing.Point(572, 256);
            btnStartLinks.Name = "btnStartLinks";
            btnStartLinks.Size = new System.Drawing.Size(94, 48);
            btnStartLinks.TabIndex = 132;
            btnStartLinks.Text = "Start links";
            toolTip1.SetToolTip(btnStartLinks, "Lancio dei link e programmi legati alla classe");
            btnStartLinks.UseVisualStyleBackColor = true;
            btnStartLinks.Click += btnStartLinks_Click;
            // 
            // btnQuestion
            // 
            btnQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQuestion.BackColor = System.Drawing.Color.Transparent;
            btnQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnQuestion.ForeColor = System.Drawing.Color.DarkBlue;
            btnQuestion.Location = new System.Drawing.Point(698, 429);
            btnQuestion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnQuestion.Name = "btnQuestion";
            btnQuestion.Size = new System.Drawing.Size(94, 48);
            btnQuestion.TabIndex = 133;
            btnQuestion.Text = "Scelta domanda";
            toolTip1.SetToolTip(btnQuestion, "Scelta domanda \"di default\" da fare a tutti");
            btnQuestion.UseVisualStyleBackColor = false;
            btnQuestion.Click += btnQuestion_Click;
            // 
            // txtQuestion
            // 
            txtQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtQuestion.Location = new System.Drawing.Point(8, 193);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ReadOnly = true;
            txtQuestion.Size = new System.Drawing.Size(560, 24);
            txtQuestion.TabIndex = 134;
            toolTip1.SetToolTip(txtQuestion, "Testo della domanda corrente");
            txtQuestion.TextChanged += txtQuestion_TextChanged;
            txtQuestion.DoubleClick += txtQuestion_DoubleClick;
            // 
            // btnMakeGroups
            // 
            btnMakeGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMakeGroups.BackColor = System.Drawing.Color.Transparent;
            btnMakeGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMakeGroups.ForeColor = System.Drawing.Color.DarkBlue;
            btnMakeGroups.Location = new System.Drawing.Point(446, 72);
            btnMakeGroups.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnMakeGroups.Name = "btnMakeGroups";
            btnMakeGroups.Size = new System.Drawing.Size(107, 59);
            btnMakeGroups.TabIndex = 135;
            btnMakeGroups.Text = "Gruppi";
            toolTip1.SetToolTip(btnMakeGroups, "Formazione dei gruppi");
            btnMakeGroups.UseVisualStyleBackColor = false;
            btnMakeGroups.Click += btnMakeGroups_Click;
            // 
            // btnLessonTime
            // 
            btnLessonTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLessonTime.BackColor = System.Drawing.Color.Transparent;
            btnLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            btnLessonTime.Location = new System.Drawing.Point(432, 230);
            btnLessonTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnLessonTime.Name = "btnLessonTime";
            btnLessonTime.Size = new System.Drawing.Size(107, 59);
            btnLessonTime.TabIndex = 138;
            btnLessonTime.Text = "Inizio lezione";
            toolTip1.SetToolTip(btnLessonTime, "Colorazione in base al tempo che manca alla fine della lezione");
            btnLessonTime.UseVisualStyleBackColor = false;
            btnLessonTime.Click += btnLessonTime_Click;
            // 
            // btnVindicationFactorPlus
            // 
            btnVindicationFactorPlus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnVindicationFactorPlus.BackColor = System.Drawing.Color.Transparent;
            btnVindicationFactorPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnVindicationFactorPlus.ForeColor = System.Drawing.Color.DarkBlue;
            btnVindicationFactorPlus.Location = new System.Drawing.Point(696, 477);
            btnVindicationFactorPlus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnVindicationFactorPlus.Name = "btnVindicationFactorPlus";
            btnVindicationFactorPlus.Size = new System.Drawing.Size(57, 27);
            btnVindicationFactorPlus.TabIndex = 142;
            btnVindicationFactorPlus.Text = "FV++";
            toolTip1.SetToolTip(btnVindicationFactorPlus, "Aumento del fattore di vendetta");
            btnVindicationFactorPlus.UseVisualStyleBackColor = false;
            btnVindicationFactorPlus.Click += btnRevengeFactorPlus_Click;
            // 
            // btnVindicationFactorMinus
            // 
            btnVindicationFactorMinus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnVindicationFactorMinus.BackColor = System.Drawing.Color.Transparent;
            btnVindicationFactorMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnVindicationFactorMinus.ForeColor = System.Drawing.Color.DarkBlue;
            btnVindicationFactorMinus.Location = new System.Drawing.Point(696, 504);
            btnVindicationFactorMinus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnVindicationFactorMinus.Name = "btnVindicationFactorMinus";
            btnVindicationFactorMinus.Size = new System.Drawing.Size(57, 27);
            btnVindicationFactorMinus.TabIndex = 143;
            btnVindicationFactorMinus.Text = "FV--";
            toolTip1.SetToolTip(btnVindicationFactorMinus, "Decremento del fattore di vendetta");
            btnVindicationFactorMinus.UseVisualStyleBackColor = false;
            btnVindicationFactorMinus.Click += btnRevengeFactorMinus_Click;
            // 
            // btnCheckToggle
            // 
            btnCheckToggle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCheckToggle.BackColor = System.Drawing.Color.Transparent;
            btnCheckToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckToggle.ForeColor = System.Drawing.Color.DarkBlue;
            btnCheckToggle.Location = new System.Drawing.Point(573, 429);
            btnCheckToggle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnCheckToggle.Name = "btnCheckToggle";
            btnCheckToggle.Size = new System.Drawing.Size(94, 48);
            btnCheckToggle.TabIndex = 146;
            btnCheckToggle.Text = "cambio X";
            toolTip1.SetToolTip(btnCheckToggle, "Cambia check di tutti gli allievi");
            btnCheckToggle.UseVisualStyleBackColor = false;
            btnCheckToggle.Click += btnCheckToggle_Click;
            // 
            // chkSuspence
            // 
            chkSuspence.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkSuspence.AutoSize = true;
            chkSuspence.Location = new System.Drawing.Point(809, 223);
            chkSuspence.Name = "chkSuspence";
            chkSuspence.Size = new System.Drawing.Size(99, 22);
            chkSuspence.TabIndex = 147;
            chkSuspence.Text = "suspence";
            toolTip1.SetToolTip(chkSuspence, "Aspetta un po' prima di estrarre, suonando una musica");
            chkSuspence.UseVisualStyleBackColor = true;
            // 
            // btnCheckRevenge
            // 
            btnCheckRevenge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCheckRevenge.BackColor = System.Drawing.Color.Transparent;
            btnCheckRevenge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckRevenge.ForeColor = System.Drawing.Color.DarkBlue;
            btnCheckRevenge.Location = new System.Drawing.Point(573, 482);
            btnCheckRevenge.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnCheckRevenge.Name = "btnCheckRevenge";
            btnCheckRevenge.Size = new System.Drawing.Size(94, 48);
            btnCheckRevenge.TabIndex = 148;
            btnCheckRevenge.Text = "X di vendetta";
            toolTip1.SetToolTip(btnCheckRevenge, "Fattore vendetta per allievi checked");
            btnCheckRevenge.UseVisualStyleBackColor = false;
            btnCheckRevenge.Click += btnCheckRevenge_Click;
            // 
            // lblVindicationFactor
            // 
            lblVindicationFactor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblVindicationFactor.AutoSize = true;
            lblVindicationFactor.ForeColor = System.Drawing.Color.DarkBlue;
            lblVindicationFactor.Location = new System.Drawing.Point(761, 479);
            lblVindicationFactor.Name = "lblVindicationFactor";
            lblVindicationFactor.Size = new System.Drawing.Size(38, 18);
            lblVindicationFactor.TabIndex = 145;
            lblVindicationFactor.Text = "F.V.";
            toolTip1.SetToolTip(lblVindicationFactor, "Fattore di vendetta dell'allievo corrente");
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(396, 297);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 18);
            label1.TabIndex = 149;
            label1.Text = "Minuto inizio";
            toolTip1.SetToolTip(label1, "Minuto di  inizio della lezione");
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.DarkBlue;
            label3.Location = new System.Drawing.Point(396, 322);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(105, 18);
            label3.TabIndex = 150;
            label3.Text = "Minuti durata";
            toolTip1.SetToolTip(label3, "Minuti di durata della lezione");
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(396, 347);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(118, 18);
            label4.TabIndex = 151;
            label4.Text = "Anticipo minuti";
            toolTip1.SetToolTip(label4, "Minuti di anticipo dell'allarme rispetto a fine lezione ");
            // 
            // btnClassesGradesSummary
            // 
            btnClassesGradesSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClassesGradesSummary.BackColor = System.Drawing.Color.Transparent;
            btnClassesGradesSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnClassesGradesSummary.ForeColor = System.Drawing.Color.DarkBlue;
            btnClassesGradesSummary.Location = new System.Drawing.Point(698, 588);
            btnClassesGradesSummary.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnClassesGradesSummary.Name = "btnClassesGradesSummary";
            btnClassesGradesSummary.Size = new System.Drawing.Size(94, 48);
            btnClassesGradesSummary.TabIndex = 153;
            btnClassesGradesSummary.Text = "Voti classe";
            toolTip1.SetToolTip(btnClassesGradesSummary, "Finestra di riepilogo dei voti della classe corrente");
            btnClassesGradesSummary.UseVisualStyleBackColor = false;
            btnClassesGradesSummary.Click += btnClassesGradesSummary_Click;
            // 
            // btnCheckAll
            // 
            btnCheckAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCheckAll.BackColor = System.Drawing.Color.Transparent;
            btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckAll.ForeColor = System.Drawing.Color.DarkBlue;
            btnCheckAll.Location = new System.Drawing.Point(573, 641);
            btnCheckAll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new System.Drawing.Size(94, 48);
            btnCheckAll.TabIndex = 28;
            btnCheckAll.Text = "X tutti";
            toolTip1.SetToolTip(btnCheckAll, "Check tutti allievi");
            btnCheckAll.UseVisualStyleBackColor = false;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // btnCheckNoGrade
            // 
            btnCheckNoGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCheckNoGrade.BackColor = System.Drawing.Color.Transparent;
            btnCheckNoGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckNoGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnCheckNoGrade.Location = new System.Drawing.Point(573, 535);
            btnCheckNoGrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnCheckNoGrade.Name = "btnCheckNoGrade";
            btnCheckNoGrade.Size = new System.Drawing.Size(94, 48);
            btnCheckNoGrade.TabIndex = 155;
            btnCheckNoGrade.Text = " X no voti";
            toolTip1.SetToolTip(btnCheckNoGrade, "Check allievi che non hanno voti");
            btnCheckNoGrade.UseVisualStyleBackColor = false;
            btnCheckNoGrade.Click += btnCheckNoGrade_Click;
            // 
            // lblDatabaseFile
            // 
            lblDatabaseFile.AutoSize = true;
            lblDatabaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDatabaseFile.ForeColor = System.Drawing.Color.Red;
            lblDatabaseFile.Location = new System.Drawing.Point(216, 2);
            lblDatabaseFile.Name = "lblDatabaseFile";
            lblDatabaseFile.Size = new System.Drawing.Size(94, 13);
            lblDatabaseFile.TabIndex = 111;
            lblDatabaseFile.Text = "lblDatabaseFile";
            toolTip1.SetToolTip(lblDatabaseFile, "Nome del file del database. ");
            lblDatabaseFile.Visible = false;
            // 
            // btnYearTopics
            // 
            btnYearTopics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnYearTopics.BackColor = System.Drawing.Color.Transparent;
            btnYearTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnYearTopics.ForeColor = System.Drawing.Color.DarkBlue;
            btnYearTopics.Location = new System.Drawing.Point(803, 535);
            btnYearTopics.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnYearTopics.Name = "btnYearTopics";
            btnYearTopics.Size = new System.Drawing.Size(94, 48);
            btnYearTopics.TabIndex = 157;
            btnYearTopics.Text = "File arg. anno";
            toolTip1.SetToolTip(btnYearTopics, "Crea un file con tutti gli argomenti fatti nell'anno scolatico");
            btnYearTopics.UseVisualStyleBackColor = false;
            btnYearTopics.Click += btnYearTopics_Click;
            // 
            // chkActivateLessonClock
            // 
            chkActivateLessonClock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkActivateLessonClock.AutoSize = true;
            chkActivateLessonClock.Checked = true;
            chkActivateLessonClock.CheckState = System.Windows.Forms.CheckState.Checked;
            chkActivateLessonClock.Location = new System.Drawing.Point(396, 378);
            chkActivateLessonClock.Name = "chkActivateLessonClock";
            chkActivateLessonClock.Size = new System.Drawing.Size(157, 22);
            chkActivateLessonClock.TabIndex = 159;
            chkActivateLessonClock.Text = "Orologio lezione ";
            toolTip1.SetToolTip(chkActivateLessonClock, "Abilita orologio a colori per bottone lezione");
            chkActivateLessonClock.UseVisualStyleBackColor = true;
            chkActivateLessonClock.CheckedChanged += chkActivateLessonClock_CheckedChanged;
            // 
            // lblIdStudent
            // 
            lblIdStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblIdStudent.AutoSize = true;
            lblIdStudent.Enabled = false;
            lblIdStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblIdStudent.ForeColor = System.Drawing.Color.DarkBlue;
            lblIdStudent.Location = new System.Drawing.Point(488, 218);
            lblIdStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIdStudent.Name = "lblIdStudent";
            lblIdStudent.Size = new System.Drawing.Size(65, 15);
            lblIdStudent.TabIndex = 163;
            lblIdStudent.Text = "Id allievo";
            toolTip1.SetToolTip(lblIdStudent, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si può modificare. ");
            // 
            // txtIdStudent
            // 
            txtIdStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtIdStudent.Location = new System.Drawing.Point(491, 236);
            txtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            txtIdStudent.Name = "txtIdStudent";
            txtIdStudent.ReadOnly = true;
            txtIdStudent.Size = new System.Drawing.Size(77, 24);
            txtIdStudent.TabIndex = 162;
            txtIdStudent.TabStop = false;
            txtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtIdStudent, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // btnTemporary
            // 
            btnTemporary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTemporary.BackColor = System.Drawing.Color.Red;
            btnTemporary.ForeColor = System.Drawing.Color.Yellow;
            btnTemporary.Location = new System.Drawing.Point(412, 163);
            btnTemporary.Name = "btnTemporary";
            btnTemporary.Size = new System.Drawing.Size(91, 54);
            btnTemporary.TabIndex = 164;
            btnTemporary.Text = "Test";
            toolTip1.SetToolTip(btnTemporary, "Bottone per test, visibile solo quando in debug");
            btnTemporary.UseVisualStyleBackColor = false;
            btnTemporary.Click += btnTemporary_Click;
            // 
            // txtTimeInterval
            // 
            txtTimeInterval.ForeColor = System.Drawing.Color.DarkBlue;
            txtTimeInterval.Location = new System.Drawing.Point(168, 4);
            txtTimeInterval.Name = "txtTimeInterval";
            txtTimeInterval.Size = new System.Drawing.Size(41, 24);
            txtTimeInterval.TabIndex = 168;
            txtTimeInterval.Text = "0";
            txtTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtTimeInterval, "Minuti per allarme prima della fine");
            // 
            // btnStartColorTimer
            // 
            btnStartColorTimer.BackColor = System.Drawing.Color.Transparent;
            btnStartColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStartColorTimer.ForeColor = System.Drawing.Color.DarkBlue;
            btnStartColorTimer.Location = new System.Drawing.Point(217, 36);
            btnStartColorTimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnStartColorTimer.Name = "btnStartColorTimer";
            btnStartColorTimer.Size = new System.Drawing.Size(74, 28);
            btnStartColorTimer.TabIndex = 169;
            btnStartColorTimer.Text = "T.colori";
            toolTip1.SetToolTip(btnStartColorTimer, "Partenza di un cronometro a colori");
            btnStartColorTimer.UseVisualStyleBackColor = false;
            btnStartColorTimer.Click += btnStartColorTimer_Click;
            // 
            // btnMosaic
            // 
            btnMosaic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMosaic.Location = new System.Drawing.Point(572, 316);
            btnMosaic.Name = "btnMosaic";
            btnMosaic.Size = new System.Drawing.Size(94, 48);
            btnMosaic.TabIndex = 170;
            btnMosaic.Text = "Mosaico";
            toolTip1.SetToolTip(btnMosaic, "Visualizzazione di tutte le foto della classe");
            btnMosaic.UseVisualStyleBackColor = true;
            btnMosaic.Click += btnMosaic_Click;
            // 
            // btnStartBarTimer
            // 
            btnStartBarTimer.BackColor = System.Drawing.Color.Transparent;
            btnStartBarTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStartBarTimer.ForeColor = System.Drawing.Color.DarkBlue;
            btnStartBarTimer.Location = new System.Drawing.Point(298, 36);
            btnStartBarTimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnStartBarTimer.Name = "btnStartBarTimer";
            btnStartBarTimer.Size = new System.Drawing.Size(74, 28);
            btnStartBarTimer.TabIndex = 173;
            btnStartBarTimer.Text = "T.barra";
            toolTip1.SetToolTip(btnStartBarTimer, "Partenza di un cronometro a barra");
            btnStartBarTimer.UseVisualStyleBackColor = false;
            btnStartBarTimer.Click += btnStartBarTimer_Click;
            // 
            // chkLessonsPictures
            // 
            chkLessonsPictures.AutoSize = true;
            chkLessonsPictures.Checked = true;
            chkLessonsPictures.CheckState = System.Windows.Forms.CheckState.Checked;
            chkLessonsPictures.Location = new System.Drawing.Point(5, 19);
            chkLessonsPictures.Name = "chkLessonsPictures";
            chkLessonsPictures.Size = new System.Drawing.Size(76, 22);
            chkLessonsPictures.TabIndex = 10;
            chkLessonsPictures.Text = "lezioni";
            toolTip1.SetToolTip(chkLessonsPictures, "Estrazione fra  le immagini mostrate durante le lezioni");
            chkLessonsPictures.UseVisualStyleBackColor = true;
            // 
            // chkGivenFolder
            // 
            chkGivenFolder.AutoSize = true;
            chkGivenFolder.Location = new System.Drawing.Point(5, 41);
            chkGivenFolder.Name = "chkGivenFolder";
            chkGivenFolder.Size = new System.Drawing.Size(82, 22);
            chkGivenFolder.TabIndex = 174;
            chkGivenFolder.Text = "cartella";
            toolTip1.SetToolTip(chkGivenFolder, "Estrazione fra le immmagini che stanno sotto la cartella data");
            chkGivenFolder.UseVisualStyleBackColor = true;
            // 
            // picBackgroundSaveRunning
            // 
            picBackgroundSaveRunning.BackColor = System.Drawing.Color.DarkGray;
            picBackgroundSaveRunning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            picBackgroundSaveRunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picBackgroundSaveRunning.Location = new System.Drawing.Point(25, 124);
            picBackgroundSaveRunning.Name = "picBackgroundSaveRunning";
            picBackgroundSaveRunning.Size = new System.Drawing.Size(30, 14);
            picBackgroundSaveRunning.TabIndex = 171;
            picBackgroundSaveRunning.TabStop = false;
            toolTip1.SetToolTip(picBackgroundSaveRunning, "Rosso mentre il programma salva in background");
            // 
            // txtNStudents
            // 
            txtNStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtNStudents.ForeColor = System.Drawing.Color.DarkBlue;
            txtNStudents.Location = new System.Drawing.Point(454, 465);
            txtNStudents.Name = "txtNStudents";
            txtNStudents.Size = new System.Drawing.Size(46, 24);
            txtNStudents.TabIndex = 174;
            txtNStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtNStudents, "Minuti per allarme prima della fine");
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(445, 444);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 18);
            label6.TabIndex = 175;
            label6.Text = "n.Allievi";
            toolTip1.SetToolTip(label6, "Minuto di  inizio della lezione");
            // 
            // btnStudentsNotes
            // 
            btnStudentsNotes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnStudentsNotes.BackColor = System.Drawing.Color.Transparent;
            btnStudentsNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStudentsNotes.ForeColor = System.Drawing.Color.DarkBlue;
            btnStudentsNotes.Location = new System.Drawing.Point(803, 641);
            btnStudentsNotes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnStudentsNotes.Name = "btnStudentsNotes";
            btnStudentsNotes.Size = new System.Drawing.Size(94, 48);
            btnStudentsNotes.TabIndex = 176;
            btnStudentsNotes.Text = "Annotaz.";
            toolTip1.SetToolTip(btnStudentsNotes, "Finestra per assegnare annotazioni di gruppo");
            btnStudentsNotes.UseVisualStyleBackColor = false;
            btnStudentsNotes.Click += btnStudentsNotes_Click;
            // 
            // txtIdClass
            // 
            txtIdClass.ForeColor = System.Drawing.Color.DarkBlue;
            txtIdClass.Location = new System.Drawing.Point(17, 77);
            txtIdClass.Name = "txtIdClass";
            txtIdClass.Size = new System.Drawing.Size(46, 24);
            txtIdClass.TabIndex = 177;
            txtIdClass.Text = "0";
            txtIdClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtIdClass, "Minuti per allarme prima della fine");
            // 
            // chkPopUpQuestionsEnabled
            // 
            chkPopUpQuestionsEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkPopUpQuestionsEnabled.AutoSize = true;
            chkPopUpQuestionsEnabled.Location = new System.Drawing.Point(671, 338);
            chkPopUpQuestionsEnabled.Name = "chkPopUpQuestionsEnabled";
            chkPopUpQuestionsEnabled.Size = new System.Drawing.Size(167, 22);
            chkPopUpQuestionsEnabled.TabIndex = 179;
            chkPopUpQuestionsEnabled.Text = "Domande \"pop up\"";
            toolTip1.SetToolTip(chkPopUpQuestionsEnabled, "Aspetta un po' prima di estrarre, suonando una musica");
            chkPopUpQuestionsEnabled.UseVisualStyleBackColor = true;
            chkPopUpQuestionsEnabled.CheckedChanged += chkPopUpQuestionsEnabled_CheckedChanged;
            // 
            // txtPopUpQuestionCentralTime
            // 
            txtPopUpQuestionCentralTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtPopUpQuestionCentralTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtPopUpQuestionCentralTime.ForeColor = System.Drawing.Color.DarkBlue;
            txtPopUpQuestionCentralTime.Location = new System.Drawing.Point(841, 342);
            txtPopUpQuestionCentralTime.Name = "txtPopUpQuestionCentralTime";
            txtPopUpQuestionCentralTime.Size = new System.Drawing.Size(46, 21);
            txtPopUpQuestionCentralTime.TabIndex = 181;
            txtPopUpQuestionCentralTime.Text = "7";
            txtPopUpQuestionCentralTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtPopUpQuestionCentralTime, "Minuti per allarme prima della fine");
            txtPopUpQuestionCentralTime.TextChanged += txtPopUpQuestionCentralTime_TextChanged;
            // 
            // btnRandomNumber
            // 
            btnRandomNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRandomNumber.BackColor = System.Drawing.Color.Transparent;
            btnRandomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRandomNumber.ForeColor = System.Drawing.Color.DarkBlue;
            btnRandomNumber.Location = new System.Drawing.Point(572, 193);
            btnRandomNumber.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnRandomNumber.Name = "btnRandomNumber";
            btnRandomNumber.Size = new System.Drawing.Size(94, 48);
            btnRandomNumber.TabIndex = 183;
            btnRandomNumber.Text = "Numero casuale";
            toolTip1.SetToolTip(btnRandomNumber, "Visualizzazione di un'immagine casuale dalla cartella  qui sotto");
            btnRandomNumber.UseVisualStyleBackColor = false;
            btnRandomNumber.Click += btnRandomNumber_Click;
            // 
            // chkSoundsInColorTimer
            // 
            chkSoundsInColorTimer.AutoSize = true;
            chkSoundsInColorTimer.Checked = true;
            chkSoundsInColorTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSoundsInColorTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chkSoundsInColorTimer.ForeColor = System.Drawing.Color.DarkBlue;
            chkSoundsInColorTimer.Location = new System.Drawing.Point(217, 66);
            chkSoundsInColorTimer.Name = "chkSoundsInColorTimer";
            chkSoundsInColorTimer.Size = new System.Drawing.Size(70, 22);
            chkSoundsInColorTimer.TabIndex = 184;
            chkSoundsInColorTimer.Text = "Suoni";
            toolTip1.SetToolTip(chkSoundsInColorTimer, "Esegue i suoni nel timer a colori");
            chkSoundsInColorTimer.UseVisualStyleBackColor = true;
            chkSoundsInColorTimer.CheckedChanged += chkSoundsInColorTimer_CheckedChanged;
            // 
            // lblLastDatabaseModification
            // 
            lblLastDatabaseModification.AutoSize = true;
            lblLastDatabaseModification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblLastDatabaseModification.ForeColor = System.Drawing.Color.Red;
            lblLastDatabaseModification.Location = new System.Drawing.Point(216, 19);
            lblLastDatabaseModification.Name = "lblLastDatabaseModification";
            lblLastDatabaseModification.Size = new System.Drawing.Size(167, 13);
            lblLastDatabaseModification.TabIndex = 187;
            lblLastDatabaseModification.Text = "lblLastDatabaseModification";
            toolTip1.SetToolTip(lblLastDatabaseModification, "Nome del file del database. ");
            lblLastDatabaseModification.Visible = false;
            // 
            // lblStudentChosen
            // 
            lblStudentChosen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStudentChosen.BackColor = System.Drawing.Color.Transparent;
            lblStudentChosen.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudentChosen.ForeColor = System.Drawing.Color.DarkBlue;
            lblStudentChosen.Location = new System.Drawing.Point(8, 222);
            lblStudentChosen.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblStudentChosen.Name = "lblStudentChosen";
            lblStudentChosen.Size = new System.Drawing.Size(474, 43);
            lblStudentChosen.TabIndex = 27;
            lblStudentChosen.Text = "Allievo";
            lblStudentChosen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodYear
            // 
            lblCodYear.AutoSize = true;
            lblCodYear.ForeColor = System.Drawing.Color.DarkBlue;
            lblCodYear.Location = new System.Drawing.Point(-1, 5);
            lblCodYear.Name = "lblCodYear";
            lblCodYear.Size = new System.Drawing.Size(82, 18);
            lblCodYear.TabIndex = 48;
            lblCodYear.Text = "Cod.Anno";
            // 
            // timerQuestion
            // 
            timerQuestion.Interval = 250;
            timerQuestion.Tick += timerQuestion_Tick;
            // 
            // picStudent
            // 
            picStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            picStudent.Location = new System.Drawing.Point(10, 222);
            picStudent.Name = "picStudent";
            picStudent.Size = new System.Drawing.Size(558, 490);
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 52;
            picStudent.TabStop = false;
            picStudent.Visible = false;
            picStudent.DoubleClick += picStudent_DoubleClick;
            // 
            // grpSorts
            // 
            grpSorts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpSorts.Controls.Add(rdbDrawByRevengeFactor);
            grpSorts.Controls.Add(rdbDrawByOldestFirst);
            grpSorts.Controls.Add(rdbDrawNoOfGrades);
            grpSorts.Controls.Add(rdbDrawLowGradesFirst);
            grpSorts.Controls.Add(rdbSortByAlphbetical);
            grpSorts.Controls.Add(rdbDrawByWeightsSum);
            grpSorts.Controls.Add(rdbDrawEqualProbability);
            grpSorts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            grpSorts.ForeColor = System.Drawing.Color.DarkBlue;
            grpSorts.Location = new System.Drawing.Point(696, 38);
            grpSorts.Name = "grpSorts";
            grpSorts.Size = new System.Drawing.Size(216, 179);
            grpSorts.TabIndex = 69;
            grpSorts.TabStop = false;
            grpSorts.Text = "Criteri sorteg. o ordinam.";
            // 
            // btnAssess
            // 
            btnAssess.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAssess.BackColor = System.Drawing.Color.Transparent;
            btnAssess.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAssess.ForeColor = System.Drawing.Color.DarkBlue;
            btnAssess.Location = new System.Drawing.Point(803, 429);
            btnAssess.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnAssess.Name = "btnAssess";
            btnAssess.Size = new System.Drawing.Size(94, 48);
            btnAssess.TabIndex = 30;
            btnAssess.Text = "Valutaz.";
            btnAssess.UseVisualStyleBackColor = false;
            btnAssess.Click += btnAssess_Click;
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolSubject.Location = new System.Drawing.Point(668, 279);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(64, 18);
            lblSchoolSubject.TabIndex = 109;
            lblSchoolSubject.Text = "Materia";
            // 
            // lblGradeType
            // 
            lblGradeType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblGradeType.AutoSize = true;
            lblGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            lblGradeType.Location = new System.Drawing.Point(666, 224);
            lblGradeType.Name = "lblGradeType";
            lblGradeType.Size = new System.Drawing.Size(131, 18);
            lblGradeType.TabIndex = 110;
            lblGradeType.Text = "Tipo valutazione";
            // 
            // timerLesson
            // 
            timerLesson.Tick += timerLesson_Tick;
            // 
            // chkEnableEndLessonWarning
            // 
            chkEnableEndLessonWarning.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkEnableEndLessonWarning.AutoSize = true;
            chkEnableEndLessonWarning.Checked = true;
            chkEnableEndLessonWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            chkEnableEndLessonWarning.Location = new System.Drawing.Point(396, 403);
            chkEnableEndLessonWarning.Name = "chkEnableEndLessonWarning";
            chkEnableEndLessonWarning.Size = new System.Drawing.Size(174, 22);
            chkEnableEndLessonWarning.TabIndex = 158;
            chkEnableEndLessonWarning.Text = "Allarme fine lezione";
            chkEnableEndLessonWarning.UseVisualStyleBackColor = true;
            chkEnableEndLessonWarning.CheckedChanged += chkEnableEndLessonWarning_CheckedChanged;
            // 
            // grpImageSource
            // 
            grpImageSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpImageSource.Controls.Add(chkLessonsPictures);
            grpImageSource.Controls.Add(chkGivenFolder);
            grpImageSource.ForeColor = System.Drawing.Color.DarkBlue;
            grpImageSource.Location = new System.Drawing.Point(572, 67);
            grpImageSource.Name = "grpImageSource";
            grpImageSource.Size = new System.Drawing.Size(118, 64);
            grpImageSource.TabIndex = 158;
            grpImageSource.TabStop = false;
            grpImageSource.Text = "Sorg.immag.";
            // 
            // grpChooseDrawSort
            // 
            grpChooseDrawSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpChooseDrawSort.Controls.Add(rdbMustSort);
            grpChooseDrawSort.Controls.Add(rdbMustDraw);
            grpChooseDrawSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            grpChooseDrawSort.Location = new System.Drawing.Point(696, 0);
            grpChooseDrawSort.Name = "grpChooseDrawSort";
            grpChooseDrawSort.Size = new System.Drawing.Size(216, 33);
            grpChooseDrawSort.TabIndex = 165;
            grpChooseDrawSort.TabStop = false;
            // 
            // rdbMustSort
            // 
            rdbMustSort.AutoSize = true;
            rdbMustSort.Location = new System.Drawing.Point(112, 9);
            rdbMustSort.Name = "rdbMustSort";
            rdbMustSort.Size = new System.Drawing.Size(95, 22);
            rdbMustSort.TabIndex = 1;
            rdbMustSort.Text = "Ordinam.";
            rdbMustSort.UseVisualStyleBackColor = true;
            // 
            // rdbMustDraw
            // 
            rdbMustDraw.AutoSize = true;
            rdbMustDraw.Checked = true;
            rdbMustDraw.Location = new System.Drawing.Point(6, 9);
            rdbMustDraw.Name = "rdbMustDraw";
            rdbMustDraw.Size = new System.Drawing.Size(99, 22);
            rdbMustDraw.TabIndex = 0;
            rdbMustDraw.TabStop = true;
            rdbMustDraw.Text = "Sorteggio";
            rdbMustDraw.UseVisualStyleBackColor = true;
            // 
            // lstTimeInterval
            // 
            lstTimeInterval.ForeColor = System.Drawing.Color.DarkBlue;
            lstTimeInterval.FormattingEnabled = true;
            lstTimeInterval.ItemHeight = 18;
            lstTimeInterval.Items.AddRange(new object[] { "05", "10", "15", "30", "45", "60" });
            lstTimeInterval.Location = new System.Drawing.Point(172, 28);
            lstTimeInterval.Name = "lstTimeInterval";
            lstTimeInterval.Size = new System.Drawing.Size(32, 112);
            lstTimeInterval.TabIndex = 166;
            lstTimeInterval.SelectedIndexChanged += lstTimeInterval_SelectedIndexChanged;
            lstTimeInterval.DoubleClick += lstTimeInterval_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(16, 107);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 13);
            label2.TabIndex = 172;
            label2.Text = "salv.db";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(11, 64);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(58, 13);
            label7.TabIndex = 178;
            label7.Text = "Id classe";
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(844, 326);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(41, 13);
            label8.TabIndex = 180;
            label8.Text = "tempo";
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(888, 346);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(26, 13);
            label9.TabIndex = 182;
            label9.Text = "min";
            // 
            // timerPopUp
            // 
            timerPopUp.Tick += timerPopUp_Tick;
            // 
            // dgwStudents
            // 
            dgwStudents.AllowUserToAddRows = false;
            dgwStudents.AllowUserToDeleteRows = false;
            dgwStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwStudents.Location = new System.Drawing.Point(8, 222);
            dgwStudents.Name = "dgwStudents";
            dgwStudents.ReadOnly = true;
            dgwStudents.Size = new System.Drawing.Size(382, 489);
            dgwStudents.TabIndex = 185;
            dgwStudents.CellContentClick += dgwStudents_CellContentClick;
            dgwStudents.CellDoubleClick += dgwStudents_CellDoubleClick;
            dgwStudents.DataBindingComplete += dgwStudents_DataBindingComplete;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(918, 721);
            Controls.Add(lblLastDatabaseModification);
            Controls.Add(lblIdStudent);
            Controls.Add(txtIdStudent);
            Controls.Add(dgwStudents);
            Controls.Add(chkSoundsInColorTimer);
            Controls.Add(btnTemporary);
            Controls.Add(btnRandomNumber);
            Controls.Add(label9);
            Controls.Add(txtPopUpQuestionCentralTime);
            Controls.Add(label8);
            Controls.Add(chkPopUpQuestionsEnabled);
            Controls.Add(label7);
            Controls.Add(txtIdClass);
            Controls.Add(btnStudentsNotes);
            Controls.Add(label6);
            Controls.Add(txtNStudents);
            Controls.Add(btnShowRandomImage);
            Controls.Add(btnStartBarTimer);
            Controls.Add(label2);
            Controls.Add(picBackgroundSaveRunning);
            Controls.Add(btnMosaic);
            Controls.Add(btnStartColorTimer);
            Controls.Add(txtTimeInterval);
            Controls.Add(lstTimeInterval);
            Controls.Add(grpChooseDrawSort);
            Controls.Add(grpImageSource);
            Controls.Add(chkActivateLessonClock);
            Controls.Add(chkEnableEndLessonWarning);
            Controls.Add(btnOldestGrade);
            Controls.Add(btnAssess);
            Controls.Add(btnDraw);
            Controls.Add(butComeOn);
            Controls.Add(btnYearTopics);
            Controls.Add(btnCheckNoGrade);
            Controls.Add(btnClassesGradesSummary);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCheckRevenge);
            Controls.Add(chkSuspence);
            Controls.Add(btnCheckToggle);
            Controls.Add(lblVindicationFactor);
            Controls.Add(txtRevengeFactor);
            Controls.Add(btnVindicationFactorMinus);
            Controls.Add(btnVindicationFactorPlus);
            Controls.Add(lblDatabaseFile);
            Controls.Add(txtAdvanceMinutes);
            Controls.Add(txtDurationLesson);
            Controls.Add(txtMinuteStartLesson);
            Controls.Add(btnLessonTime);
            Controls.Add(btnMakeGroups);
            Controls.Add(txtQuestion);
            Controls.Add(btnQuestion);
            Controls.Add(btnStartLinks);
            Controls.Add(btnTopicsDone);
            Controls.Add(lblGradeType);
            Controls.Add(lblSchoolSubject);
            Controls.Add(cmbSchoolSubject);
            Controls.Add(btnLessonsTopics);
            Controls.Add(cmbGradeType);
            Controls.Add(btnStudentsGradesSummary);
            Controls.Add(btnSetup);
            Controls.Add(grpSorts);
            Controls.Add(btnPath);
            Controls.Add(txtPathImages);
            Controls.Add(cmbSchoolYear);
            Controls.Add(chkStudentsListVisible);
            Controls.Add(chkPhotoVisibile);
            Controls.Add(chkNameIsVisible);
            Controls.Add(pgbTimeQuestion);
            Controls.Add(lblCodYear);
            Controls.Add(lstClasses);
            Controls.Add(btnCheckNone);
            Controls.Add(btnCheckAll);
            Controls.Add(lblStudentChosen);
            Controls.Add(picStudent);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SchoolGrades";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)picBackgroundSaveRunning).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            grpSorts.ResumeLayout(false);
            grpSorts.PerformLayout();
            grpImageSource.ResumeLayout(false);
            grpImageSource.PerformLayout();
            grpChooseDrawSort.ResumeLayout(false);
            grpChooseDrawSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.CheckBox chkNameIsVisible;
        private System.Windows.Forms.CheckBox chkPhotoVisibile;
        private System.Windows.Forms.CheckBox chkStudentsListVisible;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.TextBox txtPathImages;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnShowRandomImage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpSorts;
        private System.Windows.Forms.RadioButton rdbSortByAlphbetical;
        private System.Windows.Forms.RadioButton rdbDrawByWeightsSum;
        private System.Windows.Forms.RadioButton rdbDrawEqualProbability;
        private System.Windows.Forms.RadioButton rdbDrawLowGradesFirst;
        private System.Windows.Forms.Button btnSetup;
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
        public System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnMakeGroups;
        private System.Windows.Forms.Button btnLessonTime;
        private System.Windows.Forms.TextBox txtMinuteStartLesson;
        private System.Windows.Forms.TextBox txtDurationLesson;
        private System.Windows.Forms.TextBox txtAdvanceMinutes;
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
        private System.Windows.Forms.CheckBox chkEnableEndLessonWarning;
        private System.Windows.Forms.CheckBox chkActivateLessonClock;
        private System.Windows.Forms.GroupBox grpImageSource;
        private System.Windows.Forms.Label lblIdStudent;
        private System.Windows.Forms.TextBox txtIdStudent;
        private System.Windows.Forms.Button btnTemporary;
        private System.Windows.Forms.GroupBox grpChooseDrawSort;
        private System.Windows.Forms.RadioButton rdbMustSort;
        private System.Windows.Forms.RadioButton rdbMustDraw;
        public System.Windows.Forms.ListBox lstTimeInterval;
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
        private System.Windows.Forms.DataGridView dgwStudents;
        private System.Windows.Forms.Label lblLastDatabaseModification;
        private System.Windows.Forms.ComboBox cmbSchoolYear;
    }
}


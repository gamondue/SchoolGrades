namespace SchoolGrades
{
    partial class FrmClassesManagement
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClassesManagement));
            this.TxtClassDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RdbPhotoAlreadyPresent = new System.Windows.Forms.RadioButton();
            this.RdbPhotoUserChoosen = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RdbPhotoNone = new System.Windows.Forms.RadioButton();
            this.DgwClass = new System.Windows.Forms.DataGridView();
            this.BtnSaveClassData = new System.Windows.Forms.Button();
            this.BtnStudentErase = new System.Windows.Forms.Button();
            this.BtnModifyStudent = new System.Windows.Forms.Button();
            this.BtnEndingPeriod = new System.Windows.Forms.Button();
            this.TxtEmailGenerationPattern = new System.Windows.Forms.TextBox();
            this.BtnCreateEmailAddresses = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnImportStudentsOfClass = new System.Windows.Forms.Button();
            this.BtnFileChoose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.BtnNewYear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DgwStudents = new System.Windows.Forms.DataGridView();
            this.BtnClassErase = new System.Windows.Forms.Button();
            this.grpImportClasses = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnPathImages = new System.Windows.Forms.Button();
            this.TxtPathImages = new System.Windows.Forms.TextBox();
            this.CmbClasses = new System.Windows.Forms.ComboBox();
            this.BtnStudentNew = new System.Windows.Forms.Button();
            this.BtnPhotoChange = new System.Windows.Forms.Button();
            this.lblClassData = new System.Windows.Forms.Label();
            this.BtnToggleDisableStudent = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnPhotoErase = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.TxtImagesOriginFolder = new System.Windows.Forms.TextBox();
            this.rdbStudentsPhotosAlreadyPresent = new System.Windows.Forms.RadioButton();
            this.rdbChooseStudentsPhotoWhileImporting = new System.Windows.Forms.RadioButton();
            this.rdbDoNotImportPhotos = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.TxtStartLinksFolder = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnStudentsInfoList = new System.Windows.Forms.Button();
            this.TxtFileOfStudentsImport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgwClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).BeginInit();
            this.grpImportClasses.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtClassDescription
            // 
            this.TxtClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClassDescription.Location = new System.Drawing.Point(399, 38);
            this.TxtClassDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClassDescription.Name = "TxtClassDescription";
            this.TxtClassDescription.Size = new System.Drawing.Size(309, 24);
            this.TxtClassDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(397, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrizione classe";
            // 
            // RdbPhotoAlreadyPresent
            // 
            this.RdbPhotoAlreadyPresent.AutoSize = true;
            this.RdbPhotoAlreadyPresent.ForeColor = System.Drawing.Color.DarkBlue;
            this.RdbPhotoAlreadyPresent.Location = new System.Drawing.Point(888, 15);
            this.RdbPhotoAlreadyPresent.Margin = new System.Windows.Forms.Padding(4);
            this.RdbPhotoAlreadyPresent.Name = "RdbPhotoAlreadyPresent";
            this.RdbPhotoAlreadyPresent.Size = new System.Drawing.Size(136, 22);
            this.RdbPhotoAlreadyPresent.TabIndex = 7;
            this.RdbPhotoAlreadyPresent.Text = "Foto già presenti";
            this.toolTip1.SetToolTip(this.RdbPhotoAlreadyPresent, "Le foto hanno già il nome giusto e sono nella giusta cartella");
            this.RdbPhotoAlreadyPresent.UseVisualStyleBackColor = true;
            // 
            // RdbPhotoUserChoosen
            // 
            this.RdbPhotoUserChoosen.AutoSize = true;
            this.RdbPhotoUserChoosen.Checked = true;
            this.RdbPhotoUserChoosen.ForeColor = System.Drawing.Color.DarkBlue;
            this.RdbPhotoUserChoosen.Location = new System.Drawing.Point(888, 46);
            this.RdbPhotoUserChoosen.Margin = new System.Windows.Forms.Padding(4);
            this.RdbPhotoUserChoosen.Name = "RdbPhotoUserChoosen";
            this.RdbPhotoUserChoosen.Size = new System.Drawing.Size(131, 22);
            this.RdbPhotoUserChoosen.TabIndex = 8;
            this.RdbPhotoUserChoosen.TabStop = true;
            this.RdbPhotoUserChoosen.Text = "Scelta della foto";
            this.toolTip1.SetToolTip(this.RdbPhotoUserChoosen, "Verrà chiesto di scegliere la foto, che verrà copiata nella cartella giusta e rin" +
        "ominata");
            this.RdbPhotoUserChoosen.UseVisualStyleBackColor = true;
            // 
            // RdbPhotoNone
            // 
            this.RdbPhotoNone.AutoSize = true;
            this.RdbPhotoNone.ForeColor = System.Drawing.Color.DarkBlue;
            this.RdbPhotoNone.Location = new System.Drawing.Point(888, 77);
            this.RdbPhotoNone.Margin = new System.Windows.Forms.Padding(4);
            this.RdbPhotoNone.Name = "RdbPhotoNone";
            this.RdbPhotoNone.Size = new System.Drawing.Size(115, 22);
            this.RdbPhotoNone.TabIndex = 9;
            this.RdbPhotoNone.Text = "Nessuna foto";
            this.toolTip1.SetToolTip(this.RdbPhotoNone, "Allo studente non verrà associata alcuna foto");
            this.RdbPhotoNone.UseVisualStyleBackColor = true;
            // 
            // DgwClass
            // 
            this.DgwClass.AllowUserToAddRows = false;
            this.DgwClass.AllowUserToDeleteRows = false;
            this.DgwClass.AllowUserToOrderColumns = true;
            this.DgwClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwClass.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.DgwClass.Location = new System.Drawing.Point(11, 340);
            this.DgwClass.Margin = new System.Windows.Forms.Padding(4);
            this.DgwClass.MultiSelect = false;
            this.DgwClass.Name = "DgwClass";
            this.DgwClass.RowTemplate.Height = 24;
            this.DgwClass.Size = new System.Drawing.Size(1024, 62);
            this.DgwClass.TabIndex = 86;
            this.toolTip1.SetToolTip(this.DgwClass, "F2 per modificare");
            this.DgwClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwClass_CellContentClick);
            this.DgwClass.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwClass_CellDoubleClick);
            // 
            // BtnSaveClassData
            // 
            this.BtnSaveClassData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveClassData.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveClassData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveClassData.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnSaveClassData.Location = new System.Drawing.Point(1040, 340);
            this.BtnSaveClassData.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnSaveClassData.Name = "BtnSaveClassData";
            this.BtnSaveClassData.Size = new System.Drawing.Size(81, 62);
            this.BtnSaveClassData.TabIndex = 96;
            this.BtnSaveClassData.Text = "Salva dati classe";
            this.toolTip1.SetToolTip(this.BtnSaveClassData, "Salva i dati sulla classe, qui accanto");
            this.BtnSaveClassData.UseVisualStyleBackColor = false;
            this.BtnSaveClassData.Click += new System.EventHandler(this.BtnSaveClassData_Click);
            // 
            // BtnStudentErase
            // 
            this.BtnStudentErase.BackColor = System.Drawing.Color.Transparent;
            this.BtnStudentErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStudentErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnStudentErase.Location = new System.Drawing.Point(96, 182);
            this.BtnStudentErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnStudentErase.Name = "BtnStudentErase";
            this.BtnStudentErase.Size = new System.Drawing.Size(81, 62);
            this.BtnStudentErase.TabIndex = 12;
            this.BtnStudentErase.Text = "Elimina allievo";
            this.toolTip1.SetToolTip(this.BtnStudentErase, "Elimina allievo dalla classe ");
            this.BtnStudentErase.UseVisualStyleBackColor = false;
            this.BtnStudentErase.Click += new System.EventHandler(this.BtnStudentErase_Click);
            // 
            // BtnModifyStudent
            // 
            this.BtnModifyStudent.BackColor = System.Drawing.Color.Transparent;
            this.BtnModifyStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifyStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnModifyStudent.Location = new System.Drawing.Point(625, 182);
            this.BtnModifyStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnModifyStudent.Name = "BtnModifyStudent";
            this.BtnModifyStudent.Size = new System.Drawing.Size(81, 62);
            this.BtnModifyStudent.TabIndex = 98;
            this.BtnModifyStudent.Text = "Modifica allievo";
            this.toolTip1.SetToolTip(this.BtnModifyStudent, "Elimina allievo dalla classe ");
            this.BtnModifyStudent.UseVisualStyleBackColor = false;
            this.BtnModifyStudent.Click += new System.EventHandler(this.BtnModifyStudent_Click);
            // 
            // BtnEndingPeriod
            // 
            this.BtnEndingPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEndingPeriod.BackColor = System.Drawing.Color.Transparent;
            this.BtnEndingPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEndingPeriod.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnEndingPeriod.Location = new System.Drawing.Point(940, 182);
            this.BtnEndingPeriod.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnEndingPeriod.Name = "BtnEndingPeriod";
            this.BtnEndingPeriod.Size = new System.Drawing.Size(81, 62);
            this.BtnEndingPeriod.TabIndex = 99;
            this.BtnEndingPeriod.Text = "Fine periodo";
            this.toolTip1.SetToolTip(this.BtnEndingPeriod, "Elimina allievo dalla classe ");
            this.BtnEndingPeriod.UseVisualStyleBackColor = false;
            this.BtnEndingPeriod.Click += new System.EventHandler(this.BtnEndingPeriod_Click);
            // 
            // TxtEmailGenerationPattern
            // 
            this.TxtEmailGenerationPattern.Location = new System.Drawing.Point(260, 309);
            this.TxtEmailGenerationPattern.Name = "TxtEmailGenerationPattern";
            this.TxtEmailGenerationPattern.Size = new System.Drawing.Size(652, 24);
            this.TxtEmailGenerationPattern.TabIndex = 155;
            this.TxtEmailGenerationPattern.Text = "<FirstName>.<LastName>.stud@ispascalcomandini.it";
            this.toolTip1.SetToolTip(this.TxtEmailGenerationPattern, "Fra parentesi angolare i nomi dei campi che vengono  sostituiti dai valori nel da" +
        "tabase ");
            this.TxtEmailGenerationPattern.TextChanged += new System.EventHandler(this.TxtEmailGenerationPattern_TextChanged);
            // 
            // BtnCreateEmailAddresses
            // 
            this.BtnCreateEmailAddresses.BackColor = System.Drawing.Color.Transparent;
            this.BtnCreateEmailAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateEmailAddresses.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnCreateEmailAddresses.Location = new System.Drawing.Point(921, 306);
            this.BtnCreateEmailAddresses.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnCreateEmailAddresses.Name = "BtnCreateEmailAddresses";
            this.BtnCreateEmailAddresses.Size = new System.Drawing.Size(114, 27);
            this.BtnCreateEmailAddresses.TabIndex = 156;
            this.BtnCreateEmailAddresses.Text = "indir.email";
            this.toolTip1.SetToolTip(this.BtnCreateEmailAddresses, "Genera email  con i nomi degli studenti");
            this.BtnCreateEmailAddresses.UseVisualStyleBackColor = false;
            this.BtnCreateEmailAddresses.Click += new System.EventHandler(this.BtnCreateEmailAddresses_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DarkBlue;
            this.button5.Location = new System.Drawing.Point(1029, 23);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 62);
            this.button5.TabIndex = 10;
            this.button5.Text = "Importa classe";
            this.toolTip1.SetToolTip(this.button5, "Importa nuova classe da file di testo, con il nome ora indicato  in \"Sigla classe" +
        "\"");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.BtnImportStudentsOfClass_Click);
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            this.TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(11, 38);
            this.TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            this.TxtOfficialSchoolAbbreviation.ReadOnly = true;
            this.TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            this.TxtOfficialSchoolAbbreviation.TabIndex = 13;
            this.TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Codice Scuola";
            // 
            // BtnImportStudentsOfClass
            // 
            this.BtnImportStudentsOfClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImportStudentsOfClass.BackColor = System.Drawing.Color.Transparent;
            this.BtnImportStudentsOfClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImportStudentsOfClass.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnImportStudentsOfClass.Location = new System.Drawing.Point(1029, 23);
            this.BtnImportStudentsOfClass.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnImportStudentsOfClass.Name = "BtnImportStudentsOfClass";
            this.BtnImportStudentsOfClass.Size = new System.Drawing.Size(81, 62);
            this.BtnImportStudentsOfClass.TabIndex = 10;
            this.BtnImportStudentsOfClass.Text = "Importa Classe";
            this.BtnImportStudentsOfClass.UseVisualStyleBackColor = false;
            this.BtnImportStudentsOfClass.Click += new System.EventHandler(this.BtnImportStudentsOfClass_Click);
            // 
            // BtnFileChoose
            // 
            this.BtnFileChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFileChoose.BackColor = System.Drawing.Color.Transparent;
            this.BtnFileChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFileChoose.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnFileChoose.Location = new System.Drawing.Point(824, 15);
            this.BtnFileChoose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnFileChoose.Name = "BtnFileChoose";
            this.BtnFileChoose.Size = new System.Drawing.Size(54, 40);
            this.BtnFileChoose.TabIndex = 6;
            this.BtnFileChoose.Text = "..";
            this.BtnFileChoose.UseVisualStyleBackColor = false;
            this.BtnFileChoose.Click += new System.EventHandler(this.BtnFileChoose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(165, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 82;
            this.label7.Text = "Anno scolastico";
            // 
            // CmbSchoolYear
            // 
            this.CmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(168, 37);
            this.CmbSchoolYear.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(89, 25);
            this.CmbSchoolYear.TabIndex = 1;
            this.CmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.CmbSchoolYear_SelectedIndexChanged);
            // 
            // BtnNewYear
            // 
            this.BtnNewYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNewYear.BackColor = System.Drawing.Color.Transparent;
            this.BtnNewYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnNewYear.Location = new System.Drawing.Point(1042, 182);
            this.BtnNewYear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnNewYear.Name = "BtnNewYear";
            this.BtnNewYear.Size = new System.Drawing.Size(81, 62);
            this.BtnNewYear.TabIndex = 15;
            this.BtnNewYear.Text = "Nuovo anno";
            this.BtnNewYear.UseVisualStyleBackColor = false;
            this.BtnNewYear.Click += new System.EventHandler(this.BtnNewYear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(287, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sigla Classe";
            // 
            // DgwStudents
            // 
            this.DgwStudents.AllowUserToAddRows = false;
            this.DgwStudents.AllowUserToDeleteRows = false;
            this.DgwStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgwStudents.Location = new System.Drawing.Point(11, 411);
            this.DgwStudents.Margin = new System.Windows.Forms.Padding(4);
            this.DgwStudents.MultiSelect = false;
            this.DgwStudents.Name = "DgwStudents";
            this.DgwStudents.RowTemplate.Height = 24;
            this.DgwStudents.Size = new System.Drawing.Size(1110, 275);
            this.DgwStudents.TabIndex = 87;
            this.DgwStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwStudents_CellClick);
            this.DgwStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwStudents_CellContentClick);
            this.DgwStudents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwStudents_CellDoubleClick);
            this.DgwStudents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwStudents_RowEnter);
            // 
            // BtnClassErase
            // 
            this.BtnClassErase.BackColor = System.Drawing.Color.Transparent;
            this.BtnClassErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClassErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnClassErase.Location = new System.Drawing.Point(521, 182);
            this.BtnClassErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnClassErase.Name = "BtnClassErase";
            this.BtnClassErase.Size = new System.Drawing.Size(81, 62);
            this.BtnClassErase.TabIndex = 14;
            this.BtnClassErase.Text = "Elimina Classe";
            this.BtnClassErase.UseVisualStyleBackColor = false;
            this.BtnClassErase.Click += new System.EventHandler(this.BtnClassErase_Click);
            // 
            // grpImportClasses
            // 
            this.grpImportClasses.Controls.Add(this.label8);
            this.grpImportClasses.Controls.Add(this.BtnFileChoose);
            this.grpImportClasses.Controls.Add(this.label3);
            this.grpImportClasses.Controls.Add(this.BtnPathImages);
            this.grpImportClasses.Controls.Add(this.TxtPathImages);
            this.grpImportClasses.Controls.Add(this.RdbPhotoAlreadyPresent);
            this.grpImportClasses.Controls.Add(this.RdbPhotoUserChoosen);
            this.grpImportClasses.Controls.Add(this.RdbPhotoNone);
            this.grpImportClasses.Controls.Add(this.BtnImportStudentsOfClass);
            this.grpImportClasses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpImportClasses.Location = new System.Drawing.Point(11, 70);
            this.grpImportClasses.Name = "grpImportClasses";
            this.grpImportClasses.Size = new System.Drawing.Size(1120, 106);
            this.grpImportClasses.TabIndex = 92;
            this.grpImportClasses.TabStop = false;
            this.grpImportClasses.Text = "Importazione classi da file ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(-3, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 18);
            this.label8.TabIndex = 94;
            this.label8.Text = "File dati da cui importare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(-3, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 93;
            this.label3.Text = "Cartella origine immagini";
            // 
            // BtnPathImages
            // 
            this.BtnPathImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPathImages.BackColor = System.Drawing.Color.Transparent;
            this.BtnPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnPathImages.Location = new System.Drawing.Point(824, 60);
            this.BtnPathImages.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnPathImages.Name = "BtnPathImages";
            this.BtnPathImages.Size = new System.Drawing.Size(54, 40);
            this.BtnPathImages.TabIndex = 7;
            this.BtnPathImages.Text = "..";
            this.BtnPathImages.UseVisualStyleBackColor = false;
            this.BtnPathImages.Click += new System.EventHandler(this.BtnPathImages_Click);
            // 
            // TxtPathImages
            // 
            this.TxtPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPathImages.Location = new System.Drawing.Point(173, 68);
            this.TxtPathImages.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPathImages.Name = "TxtPathImages";
            this.TxtPathImages.Size = new System.Drawing.Size(641, 24);
            this.TxtPathImages.TabIndex = 5;
            this.TxtPathImages.Text = "C:\\Develop\\Git\\ProgrammiScuola\\SchoolGrades\\SchoolGrades\\bin\\Release";
            // 
            // CmbClasses
            // 
            this.CmbClasses.FormattingEnabled = true;
            this.CmbClasses.Location = new System.Drawing.Point(290, 37);
            this.CmbClasses.Name = "CmbClasses";
            this.CmbClasses.Size = new System.Drawing.Size(102, 26);
            this.CmbClasses.TabIndex = 2;
            this.CmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            this.CmbClasses.TextChanged += new System.EventHandler(this.CmbClasses_TextChanged);
            // 
            // BtnStudentNew
            // 
            this.BtnStudentNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnStudentNew.Location = new System.Drawing.Point(13, 182);
            this.BtnStudentNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnStudentNew.Name = "BtnStudentNew";
            this.BtnStudentNew.Size = new System.Drawing.Size(81, 62);
            this.BtnStudentNew.TabIndex = 11;
            this.BtnStudentNew.Text = "Nuovo allievo";
            this.BtnStudentNew.UseVisualStyleBackColor = false;
            this.BtnStudentNew.Click += new System.EventHandler(this.BtnStudentNew_Click);
            // 
            // BtnPhotoChange
            // 
            this.BtnPhotoChange.BackColor = System.Drawing.Color.Transparent;
            this.BtnPhotoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPhotoChange.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnPhotoChange.Location = new System.Drawing.Point(262, 182);
            this.BtnPhotoChange.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnPhotoChange.Name = "BtnPhotoChange";
            this.BtnPhotoChange.Size = new System.Drawing.Size(81, 62);
            this.BtnPhotoChange.TabIndex = 13;
            this.BtnPhotoChange.Text = "Cambia foto allievo";
            this.BtnPhotoChange.UseVisualStyleBackColor = false;
            this.BtnPhotoChange.Click += new System.EventHandler(this.BtnPhotoChange_Click);
            // 
            // lblClassData
            // 
            this.lblClassData.AutoSize = true;
            this.lblClassData.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClassData.Location = new System.Drawing.Point(9, 318);
            this.lblClassData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassData.Name = "lblClassData";
            this.lblClassData.Size = new System.Drawing.Size(210, 18);
            this.lblClassData.TabIndex = 95;
            this.lblClassData.Text = "Dati classe (F2 per modificare)";
            this.lblClassData.Click += new System.EventHandler(this.lblClassData_Click);
            // 
            // BtnToggleDisableStudent
            // 
            this.BtnToggleDisableStudent.BackColor = System.Drawing.Color.Transparent;
            this.BtnToggleDisableStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnToggleDisableStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnToggleDisableStudent.Location = new System.Drawing.Point(432, 182);
            this.BtnToggleDisableStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnToggleDisableStudent.Name = "BtnToggleDisableStudent";
            this.BtnToggleDisableStudent.Size = new System.Drawing.Size(85, 62);
            this.BtnToggleDisableStudent.TabIndex = 97;
            this.BtnToggleDisableStudent.Text = "Cambia abilitaz. allievo";
            this.BtnToggleDisableStudent.UseVisualStyleBackColor = false;
            this.BtnToggleDisableStudent.Click += new System.EventHandler(this.BtnToggleDisableStudent_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(257, 291);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 18);
            this.label6.TabIndex = 95;
            this.label6.Text = "Pattern per generazione email";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // BtnPhotoErase
            // 
            this.BtnPhotoErase.BackColor = System.Drawing.Color.Transparent;
            this.BtnPhotoErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPhotoErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnPhotoErase.Location = new System.Drawing.Point(347, 182);
            this.BtnPhotoErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnPhotoErase.Name = "BtnPhotoErase";
            this.BtnPhotoErase.Size = new System.Drawing.Size(81, 62);
            this.BtnPhotoErase.TabIndex = 157;
            this.BtnPhotoErase.Text = "Elimina foto allievo";
            this.BtnPhotoErase.UseVisualStyleBackColor = false;
            this.BtnPhotoErase.Click += new System.EventHandler(this.BtnPhotoErase_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(1042, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 62);
            this.button1.TabIndex = 15;
            this.button1.Text = "Nuovo anno";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnNewYear_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.Location = new System.Drawing.Point(521, 182);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 62);
            this.button2.TabIndex = 14;
            this.button2.Text = "Elimina Classe";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BtnClassErase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtFileOfStudentsImport);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.TxtImagesOriginFolder);
            this.groupBox1.Controls.Add(this.rdbStudentsPhotosAlreadyPresent);
            this.groupBox1.Controls.Add(this.rdbChooseStudentsPhotoWhileImporting);
            this.groupBox1.Controls.Add(this.rdbDoNotImportPhotos);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(11, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1120, 106);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Importazione classi da file ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(-3, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 18);
            this.label5.TabIndex = 94;
            this.label5.Text = "File dati da cui importare";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkBlue;
            this.button3.Location = new System.Drawing.Point(824, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "..";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.BtnFileChoose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(-3, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 18);
            this.label9.TabIndex = 93;
            this.label9.Text = "Cartella origine immagini";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkBlue;
            this.button4.Location = new System.Drawing.Point(824, 60);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 40);
            this.button4.TabIndex = 7;
            this.button4.Text = "..";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.BtnPathImages_Click);
            // 
            // TxtImagesOriginFolder
            // 
            this.TxtImagesOriginFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImagesOriginFolder.Location = new System.Drawing.Point(173, 68);
            this.TxtImagesOriginFolder.Margin = new System.Windows.Forms.Padding(4);
            this.TxtImagesOriginFolder.Name = "TxtImagesOriginFolder";
            this.TxtImagesOriginFolder.Size = new System.Drawing.Size(641, 24);
            this.TxtImagesOriginFolder.TabIndex = 5;
            // 
            // rdbStudentsPhotosAlreadyPresent
            // 
            this.rdbStudentsPhotosAlreadyPresent.AutoSize = true;
            this.rdbStudentsPhotosAlreadyPresent.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbStudentsPhotosAlreadyPresent.Location = new System.Drawing.Point(888, 15);
            this.rdbStudentsPhotosAlreadyPresent.Margin = new System.Windows.Forms.Padding(4);
            this.rdbStudentsPhotosAlreadyPresent.Name = "rdbStudentsPhotosAlreadyPresent";
            this.rdbStudentsPhotosAlreadyPresent.Size = new System.Drawing.Size(136, 22);
            this.rdbStudentsPhotosAlreadyPresent.TabIndex = 7;
            this.rdbStudentsPhotosAlreadyPresent.Text = "Foto già presenti";
            this.rdbStudentsPhotosAlreadyPresent.UseVisualStyleBackColor = true;
            // 
            // rdbChooseStudentsPhotoWhileImporting
            // 
            this.rdbChooseStudentsPhotoWhileImporting.AutoSize = true;
            this.rdbChooseStudentsPhotoWhileImporting.Checked = true;
            this.rdbChooseStudentsPhotoWhileImporting.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbChooseStudentsPhotoWhileImporting.Location = new System.Drawing.Point(888, 46);
            this.rdbChooseStudentsPhotoWhileImporting.Margin = new System.Windows.Forms.Padding(4);
            this.rdbChooseStudentsPhotoWhileImporting.Name = "rdbChooseStudentsPhotoWhileImporting";
            this.rdbChooseStudentsPhotoWhileImporting.Size = new System.Drawing.Size(131, 22);
            this.rdbChooseStudentsPhotoWhileImporting.TabIndex = 8;
            this.rdbChooseStudentsPhotoWhileImporting.TabStop = true;
            this.rdbChooseStudentsPhotoWhileImporting.Text = "Scelta della foto";
            this.rdbChooseStudentsPhotoWhileImporting.UseVisualStyleBackColor = true;
            // 
            // rdbDoNotImportPhotos
            // 
            this.rdbDoNotImportPhotos.AutoSize = true;
            this.rdbDoNotImportPhotos.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbDoNotImportPhotos.Location = new System.Drawing.Point(888, 77);
            this.rdbDoNotImportPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDoNotImportPhotos.Name = "rdbDoNotImportPhotos";
            this.rdbDoNotImportPhotos.Size = new System.Drawing.Size(115, 22);
            this.rdbDoNotImportPhotos.TabIndex = 9;
            this.rdbDoNotImportPhotos.Text = "Nessuna foto";
            this.rdbDoNotImportPhotos.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.DarkBlue;
            this.button6.Location = new System.Drawing.Point(13, 182);
            this.button6.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 62);
            this.button6.TabIndex = 11;
            this.button6.Text = "Nuovo allievo";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.BtnStudentNew_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.DarkBlue;
            this.button7.Location = new System.Drawing.Point(96, 182);
            this.button7.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(81, 62);
            this.button7.TabIndex = 12;
            this.button7.Text = "Elimina allievo";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.BtnStudentErase_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.DarkBlue;
            this.button8.Location = new System.Drawing.Point(262, 182);
            this.button8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(81, 62);
            this.button8.TabIndex = 13;
            this.button8.Text = "Cambia foto allievo";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.BtnPhotoChange_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(9, 318);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 18);
            this.label10.TabIndex = 95;
            this.label10.Text = "Dati classe (F2 per modificare)";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.DarkBlue;
            this.button9.Location = new System.Drawing.Point(1040, 340);
            this.button9.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(81, 62);
            this.button9.TabIndex = 96;
            this.button9.Text = "Salva dati classe";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.BtnSaveClassData_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.DarkBlue;
            this.button10.Location = new System.Drawing.Point(432, 182);
            this.button10.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(85, 62);
            this.button10.TabIndex = 97;
            this.button10.Text = "Cambia abilitaz. allievo";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.BtnToggleDisableStudent_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.DarkBlue;
            this.button11.Location = new System.Drawing.Point(625, 182);
            this.button11.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(81, 62);
            this.button11.TabIndex = 98;
            this.button11.Text = "Modifica allievo";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.BtnModifyStudent_Click);
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.DarkBlue;
            this.button12.Location = new System.Drawing.Point(940, 182);
            this.button12.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(81, 62);
            this.button12.TabIndex = 99;
            this.button12.Text = "Fine periodo";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.BtnEndingPeriod_Click);
            // 
            // picStudent
            // 
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Location = new System.Drawing.Point(184, 182);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(67, 62);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStudent.TabIndex = 153;
            this.picStudent.TabStop = false;
            this.picStudent.Click += new System.EventHandler(this.picStudent_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(260, 309);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(652, 24);
            this.textBox3.TabIndex = 155;
            this.textBox3.Text = "<FirstName>.<LastName>.stud@ispascalcomandini.it";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(257, 291);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 18);
            this.label11.TabIndex = 95;
            this.label11.Text = "Pattern per generazione email";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.DarkBlue;
            this.button14.Location = new System.Drawing.Point(347, 182);
            this.button14.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(81, 62);
            this.button14.TabIndex = 157;
            this.button14.Text = "Elimina foto allievo";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.BtnPhotoErase_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(10, 262);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 18);
            this.label12.TabIndex = 160;
            this.label12.Text = "Cartella start links";
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.DarkBlue;
            this.button15.Location = new System.Drawing.Point(835, 250);
            this.button15.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(54, 40);
            this.button15.TabIndex = 159;
            this.button15.Text = "..";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // TxtStartLinksFolder
            // 
            this.TxtStartLinksFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStartLinksFolder.Location = new System.Drawing.Point(184, 259);
            this.TxtStartLinksFolder.Margin = new System.Windows.Forms.Padding(4);
            this.TxtStartLinksFolder.Name = "TxtStartLinksFolder";
            this.TxtStartLinksFolder.Size = new System.Drawing.Size(641, 24);
            this.TxtStartLinksFolder.TabIndex = 158;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 699);
            this.splitter1.TabIndex = 161;
            this.splitter1.TabStop = false;
            // 
            // btnStudentsInfoList
            // 
            this.btnStudentsInfoList.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentsInfoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentsInfoList.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStudentsInfoList.Location = new System.Drawing.Point(921, 259);
            this.btnStudentsInfoList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStudentsInfoList.Name = "btnStudentsInfoList";
            this.btnStudentsInfoList.Size = new System.Drawing.Size(114, 27);
            this.btnStudentsInfoList.TabIndex = 162;
            this.btnStudentsInfoList.Text = "elenco";
            this.toolTip1.SetToolTip(this.btnStudentsInfoList, "Genera un elenco degli allievi della classe");
            this.btnStudentsInfoList.UseVisualStyleBackColor = false;
            this.btnStudentsInfoList.Click += new System.EventHandler(this.btnStudentsInfoList_Click);
            // 
            // TxtFileOfStudentsImport
            // 
            this.TxtFileOfStudentsImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFileOfStudentsImport.Location = new System.Drawing.Point(173, 24);
            this.TxtFileOfStudentsImport.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFileOfStudentsImport.Name = "TxtFileOfStudentsImport";
            this.TxtFileOfStudentsImport.Size = new System.Drawing.Size(641, 24);
            this.TxtFileOfStudentsImport.TabIndex = 95;
            // 
            // FrmClassesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1136, 699);
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.btnStudentsInfoList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.TxtStartLinksFolder);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.BtnPhotoErase);
            this.Controls.Add(this.BtnCreateEmailAddresses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.TxtEmailGenerationPattern);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.BtnEndingPeriod);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.BtnModifyStudent);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.BtnToggleDisableStudent);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.BtnSaveClassData);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblClassData);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.BtnPhotoChange);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.BtnStudentErase);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.BtnStudentNew);
            this.Controls.Add(this.CmbClasses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grpImportClasses);
            this.Controls.Add(this.BtnClassErase);
            this.Controls.Add(this.DgwStudents);
            this.Controls.Add(this.DgwClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbSchoolYear);
            this.Controls.Add(this.BtnNewYear);
            this.Controls.Add(this.TxtOfficialSchoolAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtClassDescription);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmClassesManagement";
            this.Text = "      ";
            this.Load += new System.EventHandler(this.FrmClassesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).EndInit();
            this.grpImportClasses.ResumeLayout(false);
            this.grpImportClasses.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtClassDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RdbPhotoAlreadyPresent;
        private System.Windows.Forms.RadioButton RdbPhotoUserChoosen;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton RdbPhotoNone;
        private System.Windows.Forms.TextBox TxtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BtnImportStudentsOfClass;
        private System.Windows.Forms.Button BtnFileChoose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.Button BtnNewYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgwClass;
        private System.Windows.Forms.DataGridView DgwStudents;
        private System.Windows.Forms.Button BtnClassErase;
        private System.Windows.Forms.GroupBox grpImportClasses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnPathImages;
        private System.Windows.Forms.TextBox TxtPathImages;
        private System.Windows.Forms.ComboBox CmbClasses;
        private System.Windows.Forms.Button BtnStudentNew;
        private System.Windows.Forms.Button BtnStudentErase;
        private System.Windows.Forms.Button BtnPhotoChange;
        private System.Windows.Forms.Label lblClassData;
        private System.Windows.Forms.Button BtnSaveClassData;
        private System.Windows.Forms.Button BtnToggleDisableStudent;
        private System.Windows.Forms.Button BtnModifyStudent;
        private System.Windows.Forms.Button BtnEndingPeriod;
        private System.Windows.Forms.TextBox TxtEmailGenerationPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCreateEmailAddresses;
        private System.Windows.Forms.Button BtnPhotoErase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox TxtImagesOriginFolder;
        private System.Windows.Forms.RadioButton rdbStudentsPhotosAlreadyPresent;
        private System.Windows.Forms.RadioButton rdbChooseStudentsPhotoWhileImporting;
        private System.Windows.Forms.RadioButton rdbDoNotImportPhotos;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox TxtStartLinksFolder;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnStudentsInfoList;
        private System.Windows.Forms.TextBox TxtFileOfStudentsImport;
    }
}


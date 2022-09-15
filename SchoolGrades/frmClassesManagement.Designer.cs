namespace SchoolGrades
{
    partial class frmClassesManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassesManagement));
            this.txtClassDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DgwClass = new System.Windows.Forms.DataGridView();
            this.btnSaveClassData = new System.Windows.Forms.Button();
            this.BtnStudentErase = new System.Windows.Forms.Button();
            this.BtnModifyStudent = new System.Windows.Forms.Button();
            this.btnEndingPeriod = new System.Windows.Forms.Button();
            this.TxtEmailGenerationPattern = new System.Windows.Forms.TextBox();
            this.btnCreateEmailAddresses = new System.Windows.Forms.Button();
            this.btnImportStudentsOfClass = new System.Windows.Forms.Button();
            this.btnStudentsInfoList = new System.Windows.Forms.Button();
            this.btnPutNumbers = new System.Windows.Forms.Button();
            this.btnClassErase = new System.Windows.Forms.Button();
            this.rdbDoNotImportPhotos = new System.Windows.Forms.RadioButton();
            this.rdbStudentsPhotosAlreadyPresent = new System.Windows.Forms.RadioButton();
            this.rdbChooseStudentsPhotoWhileImporting = new System.Windows.Forms.RadioButton();
            this.TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.btnNewYear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DgwStudents = new System.Windows.Forms.DataGridView();
            this.CmbClasses = new System.Windows.Forms.ComboBox();
            this.btnStudentNew = new System.Windows.Forms.Button();
            this.BtnPhotoChange = new System.Windows.Forms.Button();
            this.lblClassData = new System.Windows.Forms.Label();
            this.btnToggleDisableStudent = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPhotoErase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFileChoose = new System.Windows.Forms.Button();
            this.TxtFileOfStudentsImport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPathImages = new System.Windows.Forms.Button();
            this.TxtImagesOriginFolder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSaveClassAndStudents = new System.Windows.Forms.Button();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtStartLinksFolder = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.DgwClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClassDescription
            // 
            this.txtClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClassDescription.Location = new System.Drawing.Point(399, 38);
            this.txtClassDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtClassDescription.Name = "txtClassDescription";
            this.txtClassDescription.ReadOnly = true;
            this.txtClassDescription.Size = new System.Drawing.Size(424, 24);
            this.txtClassDescription.TabIndex = 3;
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
            // btnSaveClassData
            // 
            this.btnSaveClassData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClassData.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveClassData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveClassData.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveClassData.Location = new System.Drawing.Point(1040, 340);
            this.btnSaveClassData.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSaveClassData.Name = "btnSaveClassData";
            this.btnSaveClassData.Size = new System.Drawing.Size(81, 62);
            this.btnSaveClassData.TabIndex = 96;
            this.btnSaveClassData.Text = "Salva dati classe";
            this.toolTip1.SetToolTip(this.btnSaveClassData, "Salva i dati sulla classe, qui accanto");
            this.btnSaveClassData.UseVisualStyleBackColor = false;
            this.btnSaveClassData.Click += new System.EventHandler(this.btnSaveClassAndStudents_Click);
            // 
            // BtnStudentErase
            // 
            this.BtnStudentErase.BackColor = System.Drawing.Color.Transparent;
            this.BtnStudentErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnStudentErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnStudentErase.Location = new System.Drawing.Point(96, 182);
            this.BtnStudentErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnStudentErase.Name = "BtnStudentErase";
            this.BtnStudentErase.Size = new System.Drawing.Size(81, 62);
            this.BtnStudentErase.TabIndex = 12;
            this.BtnStudentErase.Text = "Elimina allievo";
            this.toolTip1.SetToolTip(this.BtnStudentErase, "Elimina allievo dalla classe ");
            this.BtnStudentErase.UseVisualStyleBackColor = false;
            this.BtnStudentErase.Click += new System.EventHandler(this.btnStudentErase_Click);
            // 
            // BtnModifyStudent
            // 
            this.BtnModifyStudent.BackColor = System.Drawing.Color.Transparent;
            this.BtnModifyStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnModifyStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnModifyStudent.Location = new System.Drawing.Point(518, 182);
            this.BtnModifyStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BtnModifyStudent.Name = "BtnModifyStudent";
            this.BtnModifyStudent.Size = new System.Drawing.Size(81, 62);
            this.BtnModifyStudent.TabIndex = 98;
            this.BtnModifyStudent.Text = "Modifica allievo";
            this.toolTip1.SetToolTip(this.BtnModifyStudent, "Elimina allievo dalla classe ");
            this.BtnModifyStudent.UseVisualStyleBackColor = false;
            this.BtnModifyStudent.Click += new System.EventHandler(this.btnModifyStudent_Click);
            // 
            // btnEndingPeriod
            // 
            this.btnEndingPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndingPeriod.BackColor = System.Drawing.Color.Transparent;
            this.btnEndingPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEndingPeriod.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEndingPeriod.Location = new System.Drawing.Point(940, 182);
            this.btnEndingPeriod.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEndingPeriod.Name = "btnEndingPeriod";
            this.btnEndingPeriod.Size = new System.Drawing.Size(81, 62);
            this.btnEndingPeriod.TabIndex = 99;
            this.btnEndingPeriod.Text = "Fine periodo";
            this.toolTip1.SetToolTip(this.btnEndingPeriod, "Elimina allievo dalla classe ");
            this.btnEndingPeriod.UseVisualStyleBackColor = false;
            this.btnEndingPeriod.Click += new System.EventHandler(this.btnEndingPeriod_Click);
            // 
            // TxtEmailGenerationPattern
            // 
            this.TxtEmailGenerationPattern.Location = new System.Drawing.Point(260, 309);
            this.TxtEmailGenerationPattern.Name = "TxtEmailGenerationPattern";
            this.TxtEmailGenerationPattern.Size = new System.Drawing.Size(627, 24);
            this.TxtEmailGenerationPattern.TabIndex = 155;
            this.TxtEmailGenerationPattern.Text = "<FirstName>.<LastName>.stud@ispascalcomandini.it";
            this.toolTip1.SetToolTip(this.TxtEmailGenerationPattern, "Fra parentesi angolare i nomi dei campi che vengono  sostituiti dai valori nel da" +
        "tabase ");
            this.TxtEmailGenerationPattern.TextChanged += new System.EventHandler(this.TxtEmailGenerationPattern_TextChanged);
            // 
            // btnCreateEmailAddresses
            // 
            this.btnCreateEmailAddresses.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateEmailAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateEmailAddresses.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCreateEmailAddresses.Location = new System.Drawing.Point(921, 306);
            this.btnCreateEmailAddresses.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCreateEmailAddresses.Name = "btnCreateEmailAddresses";
            this.btnCreateEmailAddresses.Size = new System.Drawing.Size(114, 27);
            this.btnCreateEmailAddresses.TabIndex = 156;
            this.btnCreateEmailAddresses.Text = "indir.email";
            this.toolTip1.SetToolTip(this.btnCreateEmailAddresses, "Genera email  con i nomi degli studenti");
            this.btnCreateEmailAddresses.UseVisualStyleBackColor = false;
            this.btnCreateEmailAddresses.Click += new System.EventHandler(this.btnCreateEmailAddresses_Click);
            // 
            // btnImportStudentsOfClass
            // 
            this.btnImportStudentsOfClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportStudentsOfClass.BackColor = System.Drawing.Color.Transparent;
            this.btnImportStudentsOfClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportStudentsOfClass.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnImportStudentsOfClass.Location = new System.Drawing.Point(1029, 23);
            this.btnImportStudentsOfClass.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnImportStudentsOfClass.Name = "btnImportStudentsOfClass";
            this.btnImportStudentsOfClass.Size = new System.Drawing.Size(81, 62);
            this.btnImportStudentsOfClass.TabIndex = 10;
            this.btnImportStudentsOfClass.Text = "Importa classe";
            this.toolTip1.SetToolTip(this.btnImportStudentsOfClass, "Importa nuova classe da file di testo, con il nome ora indicato  in \"Sigla classe" +
        "\"");
            this.btnImportStudentsOfClass.UseVisualStyleBackColor = false;
            this.btnImportStudentsOfClass.Click += new System.EventHandler(this.btnImportStudentsOfClass_Click);
            // 
            // btnStudentsInfoList
            // 
            this.btnStudentsInfoList.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentsInfoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            // btnPutNumbers
            // 
            this.btnPutNumbers.BackColor = System.Drawing.Color.Transparent;
            this.btnPutNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPutNumbers.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPutNumbers.Location = new System.Drawing.Point(725, 182);
            this.btnPutNumbers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPutNumbers.Name = "btnPutNumbers";
            this.btnPutNumbers.Size = new System.Drawing.Size(81, 62);
            this.btnPutNumbers.TabIndex = 14;
            this.btnPutNumbers.Text = "Numeri registro";
            this.toolTip1.SetToolTip(this.btnPutNumbers, "Scrive numeri consecutivi nei campi numero di registro ");
            this.btnPutNumbers.UseVisualStyleBackColor = false;
            this.btnPutNumbers.Click += new System.EventHandler(this.btnPutNumbers_Click);
            // 
            // btnClassErase
            // 
            this.btnClassErase.BackColor = System.Drawing.Color.Transparent;
            this.btnClassErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClassErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnClassErase.Location = new System.Drawing.Point(807, 182);
            this.btnClassErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClassErase.Name = "btnClassErase";
            this.btnClassErase.Size = new System.Drawing.Size(81, 62);
            this.btnClassErase.TabIndex = 14;
            this.btnClassErase.Text = "Elimina Classe";
            this.toolTip1.SetToolTip(this.btnClassErase, "Elimina la classe dal database");
            this.btnClassErase.UseVisualStyleBackColor = false;
            this.btnClassErase.Click += new System.EventHandler(this.btnClassErase_Click);
            // 
            // rdbDoNotImportPhotos
            // 
            this.rdbDoNotImportPhotos.AutoSize = true;
            this.rdbDoNotImportPhotos.Checked = true;
            this.rdbDoNotImportPhotos.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbDoNotImportPhotos.Location = new System.Drawing.Point(888, 77);
            this.rdbDoNotImportPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDoNotImportPhotos.Name = "rdbDoNotImportPhotos";
            this.rdbDoNotImportPhotos.Size = new System.Drawing.Size(115, 22);
            this.rdbDoNotImportPhotos.TabIndex = 9;
            this.rdbDoNotImportPhotos.TabStop = true;
            this.rdbDoNotImportPhotos.Text = "Nessuna foto";
            this.toolTip1.SetToolTip(this.rdbDoNotImportPhotos, "Il programma usa solo i nomi dal file ");
            this.rdbDoNotImportPhotos.UseVisualStyleBackColor = true;
            // 
            // rdbStudentsPhotosAlreadyPresent
            // 
            this.rdbStudentsPhotosAlreadyPresent.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbStudentsPhotosAlreadyPresent.Location = new System.Drawing.Point(888, 20);
            this.rdbStudentsPhotosAlreadyPresent.Name = "rdbStudentsPhotosAlreadyPresent";
            this.rdbStudentsPhotosAlreadyPresent.Size = new System.Drawing.Size(132, 24);
            this.rdbStudentsPhotosAlreadyPresent.TabIndex = 96;
            this.rdbStudentsPhotosAlreadyPresent.Text = "Foto presenti";
            this.toolTip1.SetToolTip(this.rdbStudentsPhotosAlreadyPresent, "Foto già nella cartella giusta con il nome giusto");
            // 
            // rdbChooseStudentsPhotoWhileImporting
            // 
            this.rdbChooseStudentsPhotoWhileImporting.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdbChooseStudentsPhotoWhileImporting.Location = new System.Drawing.Point(888, 50);
            this.rdbChooseStudentsPhotoWhileImporting.Name = "rdbChooseStudentsPhotoWhileImporting";
            this.rdbChooseStudentsPhotoWhileImporting.Size = new System.Drawing.Size(132, 24);
            this.rdbChooseStudentsPhotoWhileImporting.TabIndex = 97;
            this.rdbChooseStudentsPhotoWhileImporting.Text = "Richiesta foto";
            this.toolTip1.SetToolTip(this.rdbChooseStudentsPhotoWhileImporting, "Il programma fa scegliere la foto per ciscuno degli allievi");
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            this.TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.CmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.CmbSchoolYear.FormattingEnabled = true;
            this.CmbSchoolYear.Location = new System.Drawing.Point(178, 37);
            this.CmbSchoolYear.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSchoolYear.Name = "CmbSchoolYear";
            this.CmbSchoolYear.Size = new System.Drawing.Size(89, 25);
            this.CmbSchoolYear.TabIndex = 1;
            this.CmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.CmbSchoolYear_SelectedIndexChanged);
            // 
            // btnNewYear
            // 
            this.btnNewYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewYear.BackColor = System.Drawing.Color.Transparent;
            this.btnNewYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNewYear.Location = new System.Drawing.Point(1042, 182);
            this.btnNewYear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNewYear.Name = "btnNewYear";
            this.btnNewYear.Size = new System.Drawing.Size(81, 62);
            this.btnNewYear.TabIndex = 15;
            this.btnNewYear.Text = "Nuovo anno";
            this.btnNewYear.UseVisualStyleBackColor = false;
            this.btnNewYear.Click += new System.EventHandler(this.btnNewYear_Click);
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
            // CmbClasses
            // 
            this.CmbClasses.FormattingEnabled = true;
            this.CmbClasses.Location = new System.Drawing.Point(281, 37);
            this.CmbClasses.Name = "CmbClasses";
            this.CmbClasses.Size = new System.Drawing.Size(102, 26);
            this.CmbClasses.TabIndex = 2;
            this.CmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            this.CmbClasses.TextChanged += new System.EventHandler(this.CmbClasses_TextChanged);
            // 
            // btnStudentNew
            // 
            this.btnStudentNew.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStudentNew.Location = new System.Drawing.Point(13, 182);
            this.btnStudentNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStudentNew.Name = "btnStudentNew";
            this.btnStudentNew.Size = new System.Drawing.Size(81, 62);
            this.btnStudentNew.TabIndex = 11;
            this.btnStudentNew.Text = "Nuovo allievo";
            this.btnStudentNew.UseVisualStyleBackColor = false;
            this.btnStudentNew.Click += new System.EventHandler(this.btnStudentNew_Click);
            // 
            // BtnPhotoChange
            // 
            this.BtnPhotoChange.BackColor = System.Drawing.Color.Transparent;
            this.BtnPhotoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            // btnToggleDisableStudent
            // 
            this.btnToggleDisableStudent.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleDisableStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleDisableStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnToggleDisableStudent.Location = new System.Drawing.Point(430, 182);
            this.btnToggleDisableStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnToggleDisableStudent.Name = "btnToggleDisableStudent";
            this.btnToggleDisableStudent.Size = new System.Drawing.Size(85, 62);
            this.btnToggleDisableStudent.TabIndex = 97;
            this.btnToggleDisableStudent.Text = "Cambia abilitaz. allievo";
            this.btnToggleDisableStudent.UseVisualStyleBackColor = false;
            this.btnToggleDisableStudent.Click += new System.EventHandler(this.btnToggleDisableStudent_Click);
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
            // btnPhotoErase
            // 
            this.btnPhotoErase.BackColor = System.Drawing.Color.Transparent;
            this.btnPhotoErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPhotoErase.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPhotoErase.Location = new System.Drawing.Point(346, 182);
            this.btnPhotoErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPhotoErase.Name = "btnPhotoErase";
            this.btnPhotoErase.Size = new System.Drawing.Size(81, 62);
            this.btnPhotoErase.TabIndex = 157;
            this.btnPhotoErase.Text = "Elimina foto allievo";
            this.btnPhotoErase.UseVisualStyleBackColor = false;
            this.btnPhotoErase.Click += new System.EventHandler(this.btnPhotoErase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileChoose);
            this.groupBox1.Controls.Add(this.rdbChooseStudentsPhotoWhileImporting);
            this.groupBox1.Controls.Add(this.TxtFileOfStudentsImport);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnPathImages);
            this.groupBox1.Controls.Add(this.TxtImagesOriginFolder);
            this.groupBox1.Controls.Add(this.rdbStudentsPhotosAlreadyPresent);
            this.groupBox1.Controls.Add(this.rdbDoNotImportPhotos);
            this.groupBox1.Controls.Add(this.btnImportStudentsOfClass);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(9, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1120, 106);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Importazione classi da file ";
            // 
            // btnFileChoose
            // 
            this.btnFileChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileChoose.BackColor = System.Drawing.Color.Transparent;
            this.btnFileChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFileChoose.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFileChoose.Location = new System.Drawing.Point(825, 16);
            this.btnFileChoose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnFileChoose.Name = "btnFileChoose";
            this.btnFileChoose.Size = new System.Drawing.Size(54, 40);
            this.btnFileChoose.TabIndex = 98;
            this.btnFileChoose.Text = "..";
            this.btnFileChoose.UseVisualStyleBackColor = false;
            this.btnFileChoose.Click += new System.EventHandler(this.btnFileChoose_Click);
            // 
            // TxtFileOfStudentsImport
            // 
            this.TxtFileOfStudentsImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtFileOfStudentsImport.Location = new System.Drawing.Point(173, 24);
            this.TxtFileOfStudentsImport.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFileOfStudentsImport.Name = "TxtFileOfStudentsImport";
            this.TxtFileOfStudentsImport.Size = new System.Drawing.Size(641, 24);
            this.TxtFileOfStudentsImport.TabIndex = 95;
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
            // btnPathImages
            // 
            this.btnPathImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathImages.BackColor = System.Drawing.Color.Transparent;
            this.btnPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPathImages.Location = new System.Drawing.Point(824, 60);
            this.btnPathImages.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathImages.Name = "btnPathImages";
            this.btnPathImages.Size = new System.Drawing.Size(54, 40);
            this.btnPathImages.TabIndex = 7;
            this.btnPathImages.Text = "..";
            this.btnPathImages.UseVisualStyleBackColor = false;
            this.btnPathImages.Click += new System.EventHandler(this.btnPathImages_Click);
            // 
            // TxtImagesOriginFolder
            // 
            this.TxtImagesOriginFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtImagesOriginFolder.Location = new System.Drawing.Point(173, 68);
            this.TxtImagesOriginFolder.Margin = new System.Windows.Forms.Padding(4);
            this.TxtImagesOriginFolder.Name = "TxtImagesOriginFolder";
            this.TxtImagesOriginFolder.Size = new System.Drawing.Size(641, 24);
            this.TxtImagesOriginFolder.TabIndex = 5;
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
            // 
            // btnSaveClassAndStudents
            // 
            this.btnSaveClassAndStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClassAndStudents.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveClassAndStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveClassAndStudents.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveClassAndStudents.Location = new System.Drawing.Point(1040, 340);
            this.btnSaveClassAndStudents.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSaveClassAndStudents.Name = "btnSaveClassAndStudents";
            this.btnSaveClassAndStudents.Size = new System.Drawing.Size(81, 62);
            this.btnSaveClassAndStudents.TabIndex = 96;
            this.btnSaveClassAndStudents.Text = "Salva classe e studenti";
            this.btnSaveClassAndStudents.UseVisualStyleBackColor = false;
            this.btnSaveClassAndStudents.Click += new System.EventHandler(this.btnSaveClassAndStudents_Click);
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
            // TxtStartLinksFolder
            // 
            this.TxtStartLinksFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            // frmClassesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1136, 699);
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.btnStudentsInfoList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TxtStartLinksFolder);
            this.Controls.Add(this.btnPhotoErase);
            this.Controls.Add(this.btnCreateEmailAddresses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtEmailGenerationPattern);
            this.Controls.Add(this.btnEndingPeriod);
            this.Controls.Add(this.BtnModifyStudent);
            this.Controls.Add(this.btnToggleDisableStudent);
            this.Controls.Add(this.btnSaveClassAndStudents);
            this.Controls.Add(this.btnSaveClassData);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblClassData);
            this.Controls.Add(this.BtnPhotoChange);
            this.Controls.Add(this.BtnStudentErase);
            this.Controls.Add(this.btnStudentNew);
            this.Controls.Add(this.CmbClasses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPutNumbers);
            this.Controls.Add(this.btnClassErase);
            this.Controls.Add(this.DgwStudents);
            this.Controls.Add(this.DgwClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbSchoolYear);
            this.Controls.Add(this.btnNewYear);
            this.Controls.Add(this.TxtOfficialSchoolAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClassDescription);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClassesManagement";
            this.Text = " Gestione classi";
            this.Load += new System.EventHandler(this.FrmClassesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwStudents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtClassDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RdbPhotoAlreadyPresent;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton RdbPhotoNone;
        private System.Windows.Forms.TextBox TxtOfficialSchoolAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnImportStudentsOfClass;
        private System.Windows.Forms.Button btnFileChoose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbSchoolYear;
        private System.Windows.Forms.Button btnNewYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgwClass;
        private System.Windows.Forms.DataGridView DgwStudents;
        private System.Windows.Forms.Button btnClassErase;
        private System.Windows.Forms.GroupBox grpImportClasses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPathImages;
        private System.Windows.Forms.TextBox TxtPathImages;
        private System.Windows.Forms.ComboBox CmbClasses;
        private System.Windows.Forms.Button btnStudentNew;
        private System.Windows.Forms.Button BtnStudentErase;
        private System.Windows.Forms.Button BtnPhotoChange;
        private System.Windows.Forms.Label lblClassData;
        private System.Windows.Forms.Button btnSaveClassData;
        private System.Windows.Forms.Button btnToggleDisableStudent;
        private System.Windows.Forms.Button BtnModifyStudent;
        private System.Windows.Forms.Button btnEndingPeriod;
        private System.Windows.Forms.TextBox TxtEmailGenerationPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreateEmailAddresses;
        private System.Windows.Forms.Button btnPhotoErase;
        private System.Windows.Forms.Button btnPutNumbers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnPathImages;
        private System.Windows.Forms.TextBox TxtImagesOriginFolder;
        private System.Windows.Forms.RadioButton rdbStudentsPhotosAlreadyPresent;
        private System.Windows.Forms.RadioButton rdbDoNotImportPhotos;
        private System.Windows.Forms.Button BtnImportStudentsOfClass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveClassAndStudents;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtStartLinksFolder;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnStudentsInfoList;
        private System.Windows.Forms.TextBox TxtFileOfStudentsImport;
        private System.Windows.Forms.RadioButton rdbChooseStudentsPhotoWhileImporting;
    }
}


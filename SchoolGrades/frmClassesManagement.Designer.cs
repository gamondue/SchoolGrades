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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassesManagement));
            txtClassDescription = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            DgwClass = new System.Windows.Forms.DataGridView();
            btnSaveClassData = new System.Windows.Forms.Button();
            BtnStudentErase = new System.Windows.Forms.Button();
            BtnModifyStudent = new System.Windows.Forms.Button();
            btnEndingPeriod = new System.Windows.Forms.Button();
            TxtEmailGenerationPattern = new System.Windows.Forms.TextBox();
            btnCreateEmailAddresses = new System.Windows.Forms.Button();
            btnImportStudentsOfClass = new System.Windows.Forms.Button();
            btnStudentsInfoList = new System.Windows.Forms.Button();
            btnPutNumbers = new System.Windows.Forms.Button();
            btnClassErase = new System.Windows.Forms.Button();
            rdbDoNotImportPhotos = new System.Windows.Forms.RadioButton();
            rdbStudentsPhotosAlreadyPresent = new System.Windows.Forms.RadioButton();
            rdbChooseStudentsPhotoWhileImporting = new System.Windows.Forms.RadioButton();
            TxtOfficialSchoolAbbreviation = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label7 = new System.Windows.Forms.Label();
            CmbSchoolYear = new System.Windows.Forms.ComboBox();
            btnNewYear = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            DgwStudents = new System.Windows.Forms.DataGridView();
            CmbClasses = new System.Windows.Forms.ComboBox();
            btnStudentNew = new System.Windows.Forms.Button();
            BtnPhotoChange = new System.Windows.Forms.Button();
            lblClassData = new System.Windows.Forms.Label();
            btnToggleDisableStudent = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            btnPhotoErase = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnFileChoose = new System.Windows.Forms.Button();
            TxtFileOfStudentsImport = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            btnPathImages = new System.Windows.Forms.Button();
            TxtImagesOriginFolder = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            btnSaveClassAndStudents = new System.Windows.Forms.Button();
            picStudent = new System.Windows.Forms.PictureBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            TxtStartLinksFolder = new System.Windows.Forms.TextBox();
            splitter1 = new System.Windows.Forms.Splitter();
            btnPathStartLinks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)DgwClass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgwStudents).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // txtClassDescription
            // 
            txtClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClassDescription.Location = new System.Drawing.Point(399, 38);
            txtClassDescription.Margin = new System.Windows.Forms.Padding(4);
            txtClassDescription.Name = "txtClassDescription";
            txtClassDescription.ReadOnly = true;
            txtClassDescription.Size = new System.Drawing.Size(424, 24);
            txtClassDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(397, 16);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(134, 18);
            label2.TabIndex = 6;
            label2.Text = "Descrizione classe";
            // 
            // DgwClass
            // 
            DgwClass.AllowUserToAddRows = false;
            DgwClass.AllowUserToDeleteRows = false;
            DgwClass.AllowUserToOrderColumns = true;
            DgwClass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgwClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DgwClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgwClass.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            DgwClass.Location = new System.Drawing.Point(11, 340);
            DgwClass.Margin = new System.Windows.Forms.Padding(4);
            DgwClass.MultiSelect = false;
            DgwClass.Name = "DgwClass";
            DgwClass.RowTemplate.Height = 24;
            DgwClass.Size = new System.Drawing.Size(1024, 62);
            DgwClass.TabIndex = 86;
            toolTip1.SetToolTip(DgwClass, "F2 per modificare");
            DgwClass.CellContentClick += DgwClass_CellContentClick;
            DgwClass.CellDoubleClick += DgwClass_CellDoubleClick;
            // 
            // btnSaveClassData
            // 
            btnSaveClassData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveClassData.BackColor = System.Drawing.Color.Transparent;
            btnSaveClassData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveClassData.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveClassData.Location = new System.Drawing.Point(1040, 340);
            btnSaveClassData.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnSaveClassData.Name = "btnSaveClassData";
            btnSaveClassData.Size = new System.Drawing.Size(81, 62);
            btnSaveClassData.TabIndex = 96;
            btnSaveClassData.Text = "Salva dati classe";
            toolTip1.SetToolTip(btnSaveClassData, "Salva i dati sulla classe, qui accanto");
            btnSaveClassData.UseVisualStyleBackColor = false;
            btnSaveClassData.Click += btnSaveClassAndStudents_Click;
            // 
            // BtnStudentErase
            // 
            BtnStudentErase.BackColor = System.Drawing.Color.Transparent;
            BtnStudentErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnStudentErase.ForeColor = System.Drawing.Color.DarkBlue;
            BtnStudentErase.Location = new System.Drawing.Point(96, 182);
            BtnStudentErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            BtnStudentErase.Name = "BtnStudentErase";
            BtnStudentErase.Size = new System.Drawing.Size(81, 62);
            BtnStudentErase.TabIndex = 12;
            BtnStudentErase.Text = "Elimina allievo";
            toolTip1.SetToolTip(BtnStudentErase, "Elimina allievo dalla classe ");
            BtnStudentErase.UseVisualStyleBackColor = false;
            BtnStudentErase.Click += btnStudentErase_Click;
            // 
            // BtnModifyStudent
            // 
            BtnModifyStudent.BackColor = System.Drawing.Color.Transparent;
            BtnModifyStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnModifyStudent.ForeColor = System.Drawing.Color.DarkBlue;
            BtnModifyStudent.Location = new System.Drawing.Point(518, 182);
            BtnModifyStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            BtnModifyStudent.Name = "BtnModifyStudent";
            BtnModifyStudent.Size = new System.Drawing.Size(81, 62);
            BtnModifyStudent.TabIndex = 98;
            BtnModifyStudent.Text = "Modifica allievo";
            toolTip1.SetToolTip(BtnModifyStudent, "Elimina allievo dalla classe ");
            BtnModifyStudent.UseVisualStyleBackColor = false;
            BtnModifyStudent.Click += btnModifyStudent_Click;
            // 
            // btnEndingPeriod
            // 
            btnEndingPeriod.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEndingPeriod.BackColor = System.Drawing.Color.Transparent;
            btnEndingPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEndingPeriod.ForeColor = System.Drawing.Color.DarkBlue;
            btnEndingPeriod.Location = new System.Drawing.Point(940, 182);
            btnEndingPeriod.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnEndingPeriod.Name = "btnEndingPeriod";
            btnEndingPeriod.Size = new System.Drawing.Size(81, 62);
            btnEndingPeriod.TabIndex = 99;
            btnEndingPeriod.Text = "Fine periodo";
            toolTip1.SetToolTip(btnEndingPeriod, "Elimina allievo dalla classe ");
            btnEndingPeriod.UseVisualStyleBackColor = false;
            btnEndingPeriod.Click += btnEndingPeriod_Click;
            // 
            // TxtEmailGenerationPattern
            // 
            TxtEmailGenerationPattern.Location = new System.Drawing.Point(260, 309);
            TxtEmailGenerationPattern.Name = "TxtEmailGenerationPattern";
            TxtEmailGenerationPattern.Size = new System.Drawing.Size(627, 24);
            TxtEmailGenerationPattern.TabIndex = 155;
            TxtEmailGenerationPattern.Text = "<FirstName>.<LastName>.stud@ispascalcomandini.it";
            toolTip1.SetToolTip(TxtEmailGenerationPattern, "Fra parentesi angolare i nomi dei campi che vengono  sostituiti dai valori nel database ");
            TxtEmailGenerationPattern.TextChanged += TxtEmailGenerationPattern_TextChanged;
            // 
            // btnCreateEmailAddresses
            // 
            btnCreateEmailAddresses.BackColor = System.Drawing.Color.Transparent;
            btnCreateEmailAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCreateEmailAddresses.ForeColor = System.Drawing.Color.DarkBlue;
            btnCreateEmailAddresses.Location = new System.Drawing.Point(921, 306);
            btnCreateEmailAddresses.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnCreateEmailAddresses.Name = "btnCreateEmailAddresses";
            btnCreateEmailAddresses.Size = new System.Drawing.Size(114, 27);
            btnCreateEmailAddresses.TabIndex = 156;
            btnCreateEmailAddresses.Text = "indir.email";
            toolTip1.SetToolTip(btnCreateEmailAddresses, "Genera email  con i nomi degli studenti");
            btnCreateEmailAddresses.UseVisualStyleBackColor = false;
            btnCreateEmailAddresses.Click += btnCreateEmailAddresses_Click;
            // 
            // btnImportStudentsOfClass
            // 
            btnImportStudentsOfClass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnImportStudentsOfClass.BackColor = System.Drawing.Color.Transparent;
            btnImportStudentsOfClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnImportStudentsOfClass.ForeColor = System.Drawing.Color.DarkBlue;
            btnImportStudentsOfClass.Location = new System.Drawing.Point(1029, 23);
            btnImportStudentsOfClass.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnImportStudentsOfClass.Name = "btnImportStudentsOfClass";
            btnImportStudentsOfClass.Size = new System.Drawing.Size(81, 62);
            btnImportStudentsOfClass.TabIndex = 10;
            btnImportStudentsOfClass.Text = "Importa classe";
            toolTip1.SetToolTip(btnImportStudentsOfClass, "Importa nuova classe da file di testo, con il nome ora indicato  in \"Sigla classe\"");
            btnImportStudentsOfClass.UseVisualStyleBackColor = false;
            btnImportStudentsOfClass.Click += btnImportStudentsOfClass_Click;
            // 
            // btnStudentsInfoList
            // 
            btnStudentsInfoList.BackColor = System.Drawing.Color.Transparent;
            btnStudentsInfoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStudentsInfoList.ForeColor = System.Drawing.Color.DarkBlue;
            btnStudentsInfoList.Location = new System.Drawing.Point(921, 259);
            btnStudentsInfoList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnStudentsInfoList.Name = "btnStudentsInfoList";
            btnStudentsInfoList.Size = new System.Drawing.Size(114, 27);
            btnStudentsInfoList.TabIndex = 162;
            btnStudentsInfoList.Text = "elenco";
            toolTip1.SetToolTip(btnStudentsInfoList, "Genera un elenco degli allievi della classe");
            btnStudentsInfoList.UseVisualStyleBackColor = false;
            btnStudentsInfoList.Click += btnStudentsInfoList_Click;
            // 
            // btnPutNumbers
            // 
            btnPutNumbers.BackColor = System.Drawing.Color.Transparent;
            btnPutNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPutNumbers.ForeColor = System.Drawing.Color.DarkBlue;
            btnPutNumbers.Location = new System.Drawing.Point(725, 182);
            btnPutNumbers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPutNumbers.Name = "btnPutNumbers";
            btnPutNumbers.Size = new System.Drawing.Size(81, 62);
            btnPutNumbers.TabIndex = 14;
            btnPutNumbers.Text = "Numeri registro";
            toolTip1.SetToolTip(btnPutNumbers, "Scrive numeri consecutivi nei campi numero di registro ");
            btnPutNumbers.UseVisualStyleBackColor = false;
            btnPutNumbers.Click += btnPutNumbers_Click;
            // 
            // btnClassErase
            // 
            btnClassErase.BackColor = System.Drawing.Color.Transparent;
            btnClassErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnClassErase.ForeColor = System.Drawing.Color.DarkBlue;
            btnClassErase.Location = new System.Drawing.Point(807, 182);
            btnClassErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnClassErase.Name = "btnClassErase";
            btnClassErase.Size = new System.Drawing.Size(81, 62);
            btnClassErase.TabIndex = 14;
            btnClassErase.Text = "Elimina Classe";
            toolTip1.SetToolTip(btnClassErase, "Elimina la classe dal database");
            btnClassErase.UseVisualStyleBackColor = false;
            btnClassErase.Click += btnClassErase_Click;
            // 
            // rdbDoNotImportPhotos
            // 
            rdbDoNotImportPhotos.AutoSize = true;
            rdbDoNotImportPhotos.Checked = true;
            rdbDoNotImportPhotos.ForeColor = System.Drawing.Color.DarkBlue;
            rdbDoNotImportPhotos.Location = new System.Drawing.Point(888, 77);
            rdbDoNotImportPhotos.Margin = new System.Windows.Forms.Padding(4);
            rdbDoNotImportPhotos.Name = "rdbDoNotImportPhotos";
            rdbDoNotImportPhotos.Size = new System.Drawing.Size(115, 22);
            rdbDoNotImportPhotos.TabIndex = 9;
            rdbDoNotImportPhotos.TabStop = true;
            rdbDoNotImportPhotos.Text = "Nessuna foto";
            toolTip1.SetToolTip(rdbDoNotImportPhotos, "Il programma usa solo i nomi dal file ");
            rdbDoNotImportPhotos.UseVisualStyleBackColor = true;
            // 
            // rdbStudentsPhotosAlreadyPresent
            // 
            rdbStudentsPhotosAlreadyPresent.ForeColor = System.Drawing.Color.DarkBlue;
            rdbStudentsPhotosAlreadyPresent.Location = new System.Drawing.Point(888, 20);
            rdbStudentsPhotosAlreadyPresent.Name = "rdbStudentsPhotosAlreadyPresent";
            rdbStudentsPhotosAlreadyPresent.Size = new System.Drawing.Size(132, 24);
            rdbStudentsPhotosAlreadyPresent.TabIndex = 96;
            rdbStudentsPhotosAlreadyPresent.Text = "Foto presenti";
            toolTip1.SetToolTip(rdbStudentsPhotosAlreadyPresent, "Foto già nella cartella giusta con il nome giusto");
            // 
            // rdbChooseStudentsPhotoWhileImporting
            // 
            rdbChooseStudentsPhotoWhileImporting.ForeColor = System.Drawing.Color.DarkBlue;
            rdbChooseStudentsPhotoWhileImporting.Location = new System.Drawing.Point(888, 50);
            rdbChooseStudentsPhotoWhileImporting.Name = "rdbChooseStudentsPhotoWhileImporting";
            rdbChooseStudentsPhotoWhileImporting.Size = new System.Drawing.Size(132, 24);
            rdbChooseStudentsPhotoWhileImporting.TabIndex = 97;
            rdbChooseStudentsPhotoWhileImporting.Text = "Richiesta foto";
            toolTip1.SetToolTip(rdbChooseStudentsPhotoWhileImporting, "Il programma fa scegliere la foto per ciscuno degli allievi");
            // 
            // TxtOfficialSchoolAbbreviation
            // 
            TxtOfficialSchoolAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtOfficialSchoolAbbreviation.Location = new System.Drawing.Point(11, 38);
            TxtOfficialSchoolAbbreviation.Margin = new System.Windows.Forms.Padding(4);
            TxtOfficialSchoolAbbreviation.Name = "TxtOfficialSchoolAbbreviation";
            TxtOfficialSchoolAbbreviation.ReadOnly = true;
            TxtOfficialSchoolAbbreviation.Size = new System.Drawing.Size(135, 24);
            TxtOfficialSchoolAbbreviation.TabIndex = 13;
            TxtOfficialSchoolAbbreviation.Text = "FOIS01100L";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(9, 16);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(105, 18);
            label4.TabIndex = 12;
            label4.Text = "Codice Scuola";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.DarkBlue;
            label7.Location = new System.Drawing.Point(165, 16);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(114, 18);
            label7.TabIndex = 82;
            label7.Text = "Anno scolastico";
            // 
            // CmbSchoolYear
            // 
            CmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CmbSchoolYear.ForeColor = System.Drawing.Color.DarkBlue;
            CmbSchoolYear.FormattingEnabled = true;
            CmbSchoolYear.Location = new System.Drawing.Point(178, 37);
            CmbSchoolYear.Margin = new System.Windows.Forms.Padding(4);
            CmbSchoolYear.Name = "CmbSchoolYear";
            CmbSchoolYear.Size = new System.Drawing.Size(89, 25);
            CmbSchoolYear.TabIndex = 1;
            CmbSchoolYear.SelectedIndexChanged += CmbSchoolYear_SelectedIndexChanged;
            // 
            // btnNewYear
            // 
            btnNewYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewYear.BackColor = System.Drawing.Color.Transparent;
            btnNewYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnNewYear.ForeColor = System.Drawing.Color.DarkBlue;
            btnNewYear.Location = new System.Drawing.Point(1042, 182);
            btnNewYear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnNewYear.Name = "btnNewYear";
            btnNewYear.Size = new System.Drawing.Size(81, 62);
            btnNewYear.TabIndex = 15;
            btnNewYear.Text = "Nuovo anno";
            btnNewYear.UseVisualStyleBackColor = false;
            btnNewYear.Click += btnNewYear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(287, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 18);
            label1.TabIndex = 3;
            label1.Text = "Sigla Classe";
            // 
            // DgwStudents
            // 
            DgwStudents.AllowUserToAddRows = false;
            DgwStudents.AllowUserToDeleteRows = false;
            DgwStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgwStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DgwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgwStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            DgwStudents.Location = new System.Drawing.Point(11, 411);
            DgwStudents.Margin = new System.Windows.Forms.Padding(4);
            DgwStudents.MultiSelect = false;
            DgwStudents.Name = "DgwStudents";
            DgwStudents.RowTemplate.Height = 24;
            DgwStudents.Size = new System.Drawing.Size(1110, 275);
            DgwStudents.TabIndex = 87;
            DgwStudents.CellClick += DgwStudents_CellClick;
            DgwStudents.CellContentClick += DgwStudents_CellContentClick;
            DgwStudents.CellDoubleClick += DgwStudents_CellDoubleClick;
            DgwStudents.RowEnter += DgwStudents_RowEnter;
            // 
            // CmbClasses
            // 
            CmbClasses.FormattingEnabled = true;
            CmbClasses.Location = new System.Drawing.Point(281, 37);
            CmbClasses.Name = "CmbClasses";
            CmbClasses.Size = new System.Drawing.Size(102, 26);
            CmbClasses.TabIndex = 2;
            CmbClasses.SelectedIndexChanged += CmbClasses_SelectedIndexChanged;
            CmbClasses.TextChanged += CmbClasses_TextChanged;
            // 
            // btnStudentNew
            // 
            btnStudentNew.BackColor = System.Drawing.Color.Transparent;
            btnStudentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStudentNew.ForeColor = System.Drawing.Color.DarkBlue;
            btnStudentNew.Location = new System.Drawing.Point(13, 182);
            btnStudentNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnStudentNew.Name = "btnStudentNew";
            btnStudentNew.Size = new System.Drawing.Size(81, 62);
            btnStudentNew.TabIndex = 11;
            btnStudentNew.Text = "Nuovo allievo";
            btnStudentNew.UseVisualStyleBackColor = false;
            btnStudentNew.Click += btnStudentNew_Click;
            // 
            // BtnPhotoChange
            // 
            BtnPhotoChange.BackColor = System.Drawing.Color.Transparent;
            BtnPhotoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BtnPhotoChange.ForeColor = System.Drawing.Color.DarkBlue;
            BtnPhotoChange.Location = new System.Drawing.Point(262, 182);
            BtnPhotoChange.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            BtnPhotoChange.Name = "BtnPhotoChange";
            BtnPhotoChange.Size = new System.Drawing.Size(81, 62);
            BtnPhotoChange.TabIndex = 13;
            BtnPhotoChange.Text = "Cambia foto allievo";
            BtnPhotoChange.UseVisualStyleBackColor = false;
            BtnPhotoChange.Click += BtnPhotoChange_Click;
            // 
            // lblClassData
            // 
            lblClassData.AutoSize = true;
            lblClassData.ForeColor = System.Drawing.Color.DarkBlue;
            lblClassData.Location = new System.Drawing.Point(9, 318);
            lblClassData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClassData.Name = "lblClassData";
            lblClassData.Size = new System.Drawing.Size(210, 18);
            lblClassData.TabIndex = 95;
            lblClassData.Text = "Dati classe (F2 per modificare)";
            lblClassData.Click += lblClassData_Click;
            // 
            // btnToggleDisableStudent
            // 
            btnToggleDisableStudent.BackColor = System.Drawing.Color.Transparent;
            btnToggleDisableStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnToggleDisableStudent.ForeColor = System.Drawing.Color.DarkBlue;
            btnToggleDisableStudent.Location = new System.Drawing.Point(430, 182);
            btnToggleDisableStudent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnToggleDisableStudent.Name = "btnToggleDisableStudent";
            btnToggleDisableStudent.Size = new System.Drawing.Size(85, 62);
            btnToggleDisableStudent.TabIndex = 97;
            btnToggleDisableStudent.Text = "Cambia abilitaz. allievo";
            btnToggleDisableStudent.UseVisualStyleBackColor = false;
            btnToggleDisableStudent.Click += btnToggleDisableStudent_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.DarkBlue;
            label6.Location = new System.Drawing.Point(257, 291);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(204, 18);
            label6.TabIndex = 95;
            label6.Text = "Pattern per generazione email";
            label6.Click += label6_Click;
            // 
            // btnPhotoErase
            // 
            btnPhotoErase.BackColor = System.Drawing.Color.Transparent;
            btnPhotoErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPhotoErase.ForeColor = System.Drawing.Color.DarkBlue;
            btnPhotoErase.Location = new System.Drawing.Point(346, 182);
            btnPhotoErase.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPhotoErase.Name = "btnPhotoErase";
            btnPhotoErase.Size = new System.Drawing.Size(81, 62);
            btnPhotoErase.TabIndex = 157;
            btnPhotoErase.Text = "Elimina foto allievo";
            btnPhotoErase.UseVisualStyleBackColor = false;
            btnPhotoErase.Click += btnPhotoErase_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnFileChoose);
            groupBox1.Controls.Add(rdbChooseStudentsPhotoWhileImporting);
            groupBox1.Controls.Add(TxtFileOfStudentsImport);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnPathImages);
            groupBox1.Controls.Add(TxtImagesOriginFolder);
            groupBox1.Controls.Add(rdbStudentsPhotosAlreadyPresent);
            groupBox1.Controls.Add(rdbDoNotImportPhotos);
            groupBox1.Controls.Add(btnImportStudentsOfClass);
            groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            groupBox1.Location = new System.Drawing.Point(9, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1120, 106);
            groupBox1.TabIndex = 92;
            groupBox1.TabStop = false;
            groupBox1.Text = "Importazione classi da file ";
            // 
            // btnFileChoose
            // 
            btnFileChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFileChoose.BackColor = System.Drawing.Color.Transparent;
            btnFileChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFileChoose.ForeColor = System.Drawing.Color.DarkBlue;
            btnFileChoose.Location = new System.Drawing.Point(825, 16);
            btnFileChoose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnFileChoose.Name = "btnFileChoose";
            btnFileChoose.Size = new System.Drawing.Size(54, 40);
            btnFileChoose.TabIndex = 98;
            btnFileChoose.Text = "..";
            btnFileChoose.UseVisualStyleBackColor = false;
            btnFileChoose.Click += btnFileChoose_Click;
            // 
            // TxtFileOfStudentsImport
            // 
            TxtFileOfStudentsImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtFileOfStudentsImport.Location = new System.Drawing.Point(173, 24);
            TxtFileOfStudentsImport.Margin = new System.Windows.Forms.Padding(4);
            TxtFileOfStudentsImport.Name = "TxtFileOfStudentsImport";
            TxtFileOfStudentsImport.Size = new System.Drawing.Size(641, 24);
            TxtFileOfStudentsImport.TabIndex = 95;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(-3, 26);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(168, 18);
            label5.TabIndex = 94;
            label5.Text = "File dati da cui importare";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.DarkBlue;
            label9.Location = new System.Drawing.Point(-3, 71);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(169, 18);
            label9.TabIndex = 93;
            label9.Text = "Cartella origine immagini";
            // 
            // btnPathImages
            // 
            btnPathImages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPathImages.BackColor = System.Drawing.Color.Transparent;
            btnPathImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathImages.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathImages.Location = new System.Drawing.Point(824, 60);
            btnPathImages.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathImages.Name = "btnPathImages";
            btnPathImages.Size = new System.Drawing.Size(54, 40);
            btnPathImages.TabIndex = 7;
            btnPathImages.Text = "..";
            btnPathImages.UseVisualStyleBackColor = false;
            btnPathImages.Click += btnPathImages_Click;
            // 
            // TxtImagesOriginFolder
            // 
            TxtImagesOriginFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtImagesOriginFolder.Location = new System.Drawing.Point(173, 68);
            TxtImagesOriginFolder.Margin = new System.Windows.Forms.Padding(4);
            TxtImagesOriginFolder.Name = "TxtImagesOriginFolder";
            TxtImagesOriginFolder.Size = new System.Drawing.Size(641, 24);
            TxtImagesOriginFolder.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.Color.DarkBlue;
            label10.Location = new System.Drawing.Point(9, 318);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(210, 18);
            label10.TabIndex = 95;
            label10.Text = "Dati classe (F2 per modificare)";
            // 
            // btnSaveClassAndStudents
            // 
            btnSaveClassAndStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveClassAndStudents.BackColor = System.Drawing.Color.Transparent;
            btnSaveClassAndStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveClassAndStudents.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveClassAndStudents.Location = new System.Drawing.Point(1040, 340);
            btnSaveClassAndStudents.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnSaveClassAndStudents.Name = "btnSaveClassAndStudents";
            btnSaveClassAndStudents.Size = new System.Drawing.Size(81, 62);
            btnSaveClassAndStudents.TabIndex = 96;
            btnSaveClassAndStudents.Text = "Salva classe e studenti";
            btnSaveClassAndStudents.UseVisualStyleBackColor = false;
            btnSaveClassAndStudents.Click += btnSaveClassAndStudents_Click;
            // 
            // picStudent
            // 
            picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picStudent.Location = new System.Drawing.Point(184, 182);
            picStudent.Name = "picStudent";
            picStudent.Size = new System.Drawing.Size(67, 62);
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 153;
            picStudent.TabStop = false;
            picStudent.Click += picStudent_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.Color.DarkBlue;
            label11.Location = new System.Drawing.Point(257, 291);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(204, 18);
            label11.TabIndex = 95;
            label11.Text = "Pattern per generazione email";
            label11.Click += label11_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = System.Drawing.Color.DarkBlue;
            label12.Location = new System.Drawing.Point(10, 262);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(125, 18);
            label12.TabIndex = 160;
            label12.Text = "Cartella start links";
            // 
            // TxtStartLinksFolder
            // 
            TxtStartLinksFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TxtStartLinksFolder.Location = new System.Drawing.Point(184, 259);
            TxtStartLinksFolder.Margin = new System.Windows.Forms.Padding(4);
            TxtStartLinksFolder.Name = "TxtStartLinksFolder";
            TxtStartLinksFolder.Size = new System.Drawing.Size(641, 24);
            TxtStartLinksFolder.TabIndex = 158;
            TxtStartLinksFolder.TextChanged += TxtStartLinksFolder_TextChanged;
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(3, 699);
            splitter1.TabIndex = 161;
            splitter1.TabStop = false;
            // 
            // btnPathStartLinks
            // 
            btnPathStartLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPathStartLinks.BackColor = System.Drawing.Color.Transparent;
            btnPathStartLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathStartLinks.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathStartLinks.Location = new System.Drawing.Point(833, 251);
            btnPathStartLinks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathStartLinks.Name = "btnPathStartLinks";
            btnPathStartLinks.Size = new System.Drawing.Size(54, 40);
            btnPathStartLinks.TabIndex = 99;
            btnPathStartLinks.Text = "..";
            btnPathStartLinks.UseVisualStyleBackColor = false;
            btnPathStartLinks.Click += btnPathStartLinks_Click;
            // 
            // frmClassesManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1136, 699);
            Controls.Add(btnPathStartLinks);
            Controls.Add(picStudent);
            Controls.Add(btnStudentsInfoList);
            Controls.Add(label12);
            Controls.Add(splitter1);
            Controls.Add(TxtStartLinksFolder);
            Controls.Add(btnPhotoErase);
            Controls.Add(btnCreateEmailAddresses);
            Controls.Add(label11);
            Controls.Add(label6);
            Controls.Add(TxtEmailGenerationPattern);
            Controls.Add(btnEndingPeriod);
            Controls.Add(BtnModifyStudent);
            Controls.Add(btnToggleDisableStudent);
            Controls.Add(btnSaveClassAndStudents);
            Controls.Add(btnSaveClassData);
            Controls.Add(label10);
            Controls.Add(lblClassData);
            Controls.Add(BtnPhotoChange);
            Controls.Add(BtnStudentErase);
            Controls.Add(btnStudentNew);
            Controls.Add(CmbClasses);
            Controls.Add(groupBox1);
            Controls.Add(btnPutNumbers);
            Controls.Add(btnClassErase);
            Controls.Add(DgwStudents);
            Controls.Add(DgwClass);
            Controls.Add(label7);
            Controls.Add(CmbSchoolYear);
            Controls.Add(btnNewYear);
            Controls.Add(TxtOfficialSchoolAbbreviation);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(txtClassDescription);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmClassesManagement";
            Text = " Gestione classi";
            Load += FrmClassesManagement_Load;
            ((System.ComponentModel.ISupportInitialize)DgwClass).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgwStudents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button btnPathStartLinks;
    }
}


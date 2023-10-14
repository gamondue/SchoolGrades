namespace SchoolGrades
{
    partial class frmQuestion
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestion));
            grpTags = new System.Windows.Forms.GroupBox();
            lstTags = new System.Windows.Forms.ListBox();
            btnRemoveTag = new System.Windows.Forms.Button();
            btnAddTag = new System.Windows.Forms.Button();
            txtQuestionText = new System.Windows.Forms.TextBox();
            lblQuestionText = new System.Windows.Forms.Label();
            grpTopic = new System.Windows.Forms.GroupBox();
            btnChooseByPeriod = new System.Windows.Forms.Button();
            btnChooseTopic = new System.Windows.Forms.Button();
            txtTopic = new System.Windows.Forms.TextBox();
            grpAnswers = new System.Windows.Forms.GroupBox();
            btnImportQuestions = new System.Windows.Forms.Button();
            btnAddAnswer = new System.Windows.Forms.Button();
            dgwAnswers = new System.Windows.Forms.DataGridView();
            grpQuestionImage = new System.Windows.Forms.GroupBox();
            btnChooseFileImage = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            txtQuestionImage = new System.Windows.Forms.TextBox();
            txtImagesPath = new System.Windows.Forms.TextBox();
            btnPathImportImage = new System.Windows.Forms.Button();
            picImage = new System.Windows.Forms.PictureBox();
            lblImageName = new System.Windows.Forms.Label();
            lblImagesPath = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtWeight = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtDuration = new System.Windows.Forms.TextBox();
            btnSaveQuestion = new System.Windows.Forms.Button();
            lblIdQuesion = new System.Windows.Forms.Label();
            txtIdQuestion = new System.Windows.Forms.TextBox();
            lblQuestionType = new System.Windows.Forms.Label();
            lblSchoolSubject = new System.Windows.Forms.Label();
            cmbQuestionType = new System.Windows.Forms.ComboBox();
            cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            lblDifficulty = new System.Windows.Forms.Label();
            txtDifficulty = new System.Windows.Forms.TextBox();
            btnNewQuestion = new System.Windows.Forms.Button();
            btnSaveAndChoose = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            grpTags.SuspendLayout();
            grpTopic.SuspendLayout();
            grpAnswers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAnswers).BeginInit();
            grpQuestionImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // grpTags
            // 
            grpTags.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpTags.Controls.Add(lstTags);
            grpTags.Controls.Add(btnRemoveTag);
            grpTags.Controls.Add(btnAddTag);
            grpTags.Location = new System.Drawing.Point(2, 370);
            grpTags.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTags.Name = "grpTags";
            grpTags.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTags.Size = new System.Drawing.Size(203, 310);
            grpTags.TabIndex = 0;
            grpTags.TabStop = false;
            grpTags.Text = "Tags";
            // 
            // lstTags
            // 
            lstTags.FormattingEnabled = true;
            lstTags.ItemHeight = 18;
            lstTags.Location = new System.Drawing.Point(6, 50);
            lstTags.Name = "lstTags";
            lstTags.Size = new System.Drawing.Size(191, 256);
            lstTags.TabIndex = 3;
            // 
            // btnRemoveTag
            // 
            btnRemoveTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveTag.Location = new System.Drawing.Point(165, 13);
            btnRemoveTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRemoveTag.Name = "btnRemoveTag";
            btnRemoveTag.Size = new System.Drawing.Size(37, 30);
            btnRemoveTag.TabIndex = 2;
            btnRemoveTag.Text = "-";
            btnRemoveTag.UseVisualStyleBackColor = true;
            btnRemoveTag.Click += btnRemoveTag_Click;
            // 
            // btnAddTag
            // 
            btnAddTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddTag.Location = new System.Drawing.Point(120, 14);
            btnAddTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddTag.Name = "btnAddTag";
            btnAddTag.Size = new System.Drawing.Size(39, 29);
            btnAddTag.TabIndex = 1;
            btnAddTag.Text = "+";
            btnAddTag.UseVisualStyleBackColor = true;
            btnAddTag.Click += btnAddTag_Click;
            // 
            // txtQuestionText
            // 
            txtQuestionText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtQuestionText.Location = new System.Drawing.Point(3, 31);
            txtQuestionText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtQuestionText.Multiline = true;
            txtQuestionText.Name = "txtQuestionText";
            txtQuestionText.Size = new System.Drawing.Size(908, 161);
            txtQuestionText.TabIndex = 1;
            txtQuestionText.TextChanged += txtQuestionText_TextChanged;
            // 
            // lblQuestionText
            // 
            lblQuestionText.AutoSize = true;
            lblQuestionText.Location = new System.Drawing.Point(3, 5);
            lblQuestionText.Name = "lblQuestionText";
            lblQuestionText.Size = new System.Drawing.Size(146, 18);
            lblQuestionText.TabIndex = 2;
            lblQuestionText.Text = "Testo della domanda";
            lblQuestionText.Click += lblQuestionText_Click;
            // 
            // grpTopic
            // 
            grpTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpTopic.Controls.Add(btnChooseByPeriod);
            grpTopic.Controls.Add(btnChooseTopic);
            grpTopic.Controls.Add(txtTopic);
            grpTopic.Location = new System.Drawing.Point(211, 370);
            grpTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTopic.Name = "grpTopic";
            grpTopic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpTopic.Size = new System.Drawing.Size(781, 70);
            grpTopic.TabIndex = 2;
            grpTopic.TabStop = false;
            grpTopic.Text = "Argomento";
            // 
            // btnChooseByPeriod
            // 
            btnChooseByPeriod.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChooseByPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnChooseByPeriod.Location = new System.Drawing.Point(741, 20);
            btnChooseByPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnChooseByPeriod.Name = "btnChooseByPeriod";
            btnChooseByPeriod.Size = new System.Drawing.Size(34, 34);
            btnChooseByPeriod.TabIndex = 112;
            btnChooseByPeriod.Text = "Per.";
            toolTip1.SetToolTip(btnChooseByPeriod, "Argomenti fatti in un periodo");
            btnChooseByPeriod.UseVisualStyleBackColor = true;
            btnChooseByPeriod.Click += btnChooseByPeriod_Click;
            // 
            // btnChooseTopic
            // 
            btnChooseTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChooseTopic.Location = new System.Drawing.Point(705, 20);
            btnChooseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnChooseTopic.Name = "btnChooseTopic";
            btnChooseTopic.Size = new System.Drawing.Size(34, 34);
            btnChooseTopic.TabIndex = 1;
            btnChooseTopic.Text = "..";
            btnChooseTopic.UseVisualStyleBackColor = true;
            btnChooseTopic.Click += btnChooseTopic_Click;
            // 
            // txtTopic
            // 
            txtTopic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTopic.Location = new System.Drawing.Point(6, 25);
            txtTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTopic.Name = "txtTopic";
            txtTopic.ReadOnly = true;
            txtTopic.Size = new System.Drawing.Size(693, 24);
            txtTopic.TabIndex = 0;
            txtTopic.TextChanged += txtTopic_TextChanged;
            // 
            // grpAnswers
            // 
            grpAnswers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpAnswers.Controls.Add(btnImportQuestions);
            grpAnswers.Controls.Add(btnAddAnswer);
            grpAnswers.Controls.Add(dgwAnswers);
            grpAnswers.Location = new System.Drawing.Point(211, 448);
            grpAnswers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpAnswers.Name = "grpAnswers";
            grpAnswers.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpAnswers.Size = new System.Drawing.Size(775, 227);
            grpAnswers.TabIndex = 4;
            grpAnswers.TabStop = false;
            grpAnswers.Text = "Risposte";
            // 
            // btnImportQuestions
            // 
            btnImportQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnImportQuestions.Enabled = false;
            btnImportQuestions.Location = new System.Drawing.Point(546, 0);
            btnImportQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnImportQuestions.Name = "btnImportQuestions";
            btnImportQuestions.Size = new System.Drawing.Size(229, 26);
            btnImportQuestions.TabIndex = 106;
            btnImportQuestions.Text = "Importa domande da file";
            btnImportQuestions.UseVisualStyleBackColor = true;
            btnImportQuestions.Click += btnImportQuestions_Click;
            // 
            // btnAddAnswer
            // 
            btnAddAnswer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddAnswer.Location = new System.Drawing.Point(77, 0);
            btnAddAnswer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddAnswer.Name = "btnAddAnswer";
            btnAddAnswer.Size = new System.Drawing.Size(55, 26);
            btnAddAnswer.TabIndex = 2;
            btnAddAnswer.Text = "+";
            btnAddAnswer.UseVisualStyleBackColor = true;
            btnAddAnswer.Click += btnAddAnswer_Click;
            // 
            // dgwAnswers
            // 
            dgwAnswers.AllowUserToAddRows = false;
            dgwAnswers.AllowUserToDeleteRows = false;
            dgwAnswers.AllowUserToOrderColumns = true;
            dgwAnswers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgwAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgwAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAnswers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgwAnswers.Location = new System.Drawing.Point(2, 34);
            dgwAnswers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgwAnswers.Name = "dgwAnswers";
            dgwAnswers.RowTemplate.Height = 24;
            dgwAnswers.Size = new System.Drawing.Size(767, 190);
            dgwAnswers.TabIndex = 0;
            dgwAnswers.CellContentClick += dgwAnswers_CellContentClick;
            dgwAnswers.CellDoubleClick += dgwAnswers_CellDoubleClick;
            // 
            // grpQuestionImage
            // 
            grpQuestionImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpQuestionImage.Controls.Add(btnChooseFileImage);
            grpQuestionImage.Controls.Add(button1);
            grpQuestionImage.Controls.Add(txtQuestionImage);
            grpQuestionImage.Controls.Add(txtImagesPath);
            grpQuestionImage.Controls.Add(btnPathImportImage);
            grpQuestionImage.Controls.Add(picImage);
            grpQuestionImage.Controls.Add(lblImageName);
            grpQuestionImage.Controls.Add(lblImagesPath);
            grpQuestionImage.Controls.Add(label2);
            grpQuestionImage.Enabled = false;
            grpQuestionImage.Location = new System.Drawing.Point(1, 255);
            grpQuestionImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpQuestionImage.Name = "grpQuestionImage";
            grpQuestionImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpQuestionImage.Size = new System.Drawing.Size(991, 107);
            grpQuestionImage.TabIndex = 2;
            grpQuestionImage.TabStop = false;
            grpQuestionImage.Text = "Immagine della domanda";
            // 
            // btnChooseFileImage
            // 
            btnChooseFileImage.BackColor = System.Drawing.Color.Transparent;
            btnChooseFileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnChooseFileImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnChooseFileImage.Location = new System.Drawing.Point(719, 58);
            btnChooseFileImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnChooseFileImage.Name = "btnChooseFileImage";
            btnChooseFileImage.Size = new System.Drawing.Size(33, 26);
            btnChooseFileImage.TabIndex = 156;
            btnChooseFileImage.Text = "..";
            btnChooseFileImage.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(756, 33);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(66, 51);
            button1.TabIndex = 114;
            button1.Text = "Imm. lezione";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtQuestionImage
            // 
            txtQuestionImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtQuestionImage.Location = new System.Drawing.Point(164, 60);
            txtQuestionImage.Margin = new System.Windows.Forms.Padding(4);
            txtQuestionImage.Name = "txtQuestionImage";
            txtQuestionImage.Size = new System.Drawing.Size(549, 24);
            txtQuestionImage.TabIndex = 153;
            // 
            // txtImagesPath
            // 
            txtImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtImagesPath.Location = new System.Drawing.Point(164, 30);
            txtImagesPath.Margin = new System.Windows.Forms.Padding(4);
            txtImagesPath.Name = "txtImagesPath";
            txtImagesPath.Size = new System.Drawing.Size(549, 24);
            txtImagesPath.TabIndex = 154;
            // 
            // btnPathImportImage
            // 
            btnPathImportImage.BackColor = System.Drawing.Color.Transparent;
            btnPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPathImportImage.ForeColor = System.Drawing.Color.DarkBlue;
            btnPathImportImage.Location = new System.Drawing.Point(719, 28);
            btnPathImportImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            btnPathImportImage.Name = "btnPathImportImage";
            btnPathImportImage.Size = new System.Drawing.Size(33, 27);
            btnPathImportImage.TabIndex = 155;
            btnPathImportImage.Text = "..";
            btnPathImportImage.UseVisualStyleBackColor = false;
            // 
            // picImage
            // 
            picImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picImage.Location = new System.Drawing.Point(830, 13);
            picImage.Name = "picImage";
            picImage.Size = new System.Drawing.Size(155, 88);
            picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 134;
            picImage.TabStop = false;
            // 
            // lblImageName
            // 
            lblImageName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblImageName.AutoSize = true;
            lblImageName.Enabled = false;
            lblImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblImageName.ForeColor = System.Drawing.Color.DarkBlue;
            lblImageName.Location = new System.Drawing.Point(10, 64);
            lblImageName.Name = "lblImageName";
            lblImageName.Size = new System.Drawing.Size(147, 20);
            lblImageName.TabIndex = 107;
            lblImageName.Text = "Nome file immagine";
            // 
            // lblImagesPath
            // 
            lblImagesPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblImagesPath.AutoSize = true;
            lblImagesPath.Enabled = false;
            lblImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblImagesPath.ForeColor = System.Drawing.Color.DarkBlue;
            lblImagesPath.Location = new System.Drawing.Point(10, 31);
            lblImagesPath.Name = "lblImagesPath";
            lblImagesPath.Size = new System.Drawing.Size(138, 20);
            lblImagesPath.TabIndex = 106;
            lblImagesPath.Text = "Percorso immagini";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(929, -49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 15);
            label2.TabIndex = 101;
            label2.Text = "Durata";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(917, 10);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 15);
            label4.TabIndex = 97;
            label4.Text = "Peso [%]";
            // 
            // txtWeight
            // 
            txtWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtWeight.Location = new System.Drawing.Point(917, 31);
            txtWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new System.Drawing.Size(77, 37);
            txtWeight.TabIndex = 96;
            txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtWeight.TextChanged += txtWeight_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(917, 73);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 99;
            label1.Text = "Durata [s]";
            // 
            // txtDuration
            // 
            txtDuration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtDuration.Location = new System.Drawing.Point(917, 93);
            txtDuration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new System.Drawing.Size(77, 37);
            txtDuration.TabIndex = 98;
            txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDuration.TextChanged += txtDuration_TextChanged;
            // 
            // btnSaveQuestion
            // 
            btnSaveQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveQuestion.Location = new System.Drawing.Point(856, 196);
            btnSaveQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSaveQuestion.Name = "btnSaveQuestion";
            btnSaveQuestion.Size = new System.Drawing.Size(66, 51);
            btnSaveQuestion.TabIndex = 2;
            btnSaveQuestion.Text = "Salva";
            btnSaveQuestion.UseVisualStyleBackColor = true;
            btnSaveQuestion.Click += btnSaveQuestion_Click;
            // 
            // lblIdQuesion
            // 
            lblIdQuesion.AutoSize = true;
            lblIdQuesion.Location = new System.Drawing.Point(643, 209);
            lblIdQuesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblIdQuesion.Name = "lblIdQuesion";
            lblIdQuesion.Size = new System.Drawing.Size(55, 18);
            lblIdQuesion.TabIndex = 105;
            lblIdQuesion.Text = "Codice";
            // 
            // txtIdQuestion
            // 
            txtIdQuestion.Location = new System.Drawing.Point(702, 206);
            txtIdQuestion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtIdQuestion.Name = "txtIdQuestion";
            txtIdQuestion.ReadOnly = true;
            txtIdQuestion.Size = new System.Drawing.Size(75, 24);
            txtIdQuestion.TabIndex = 104;
            txtIdQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblQuestionType
            // 
            lblQuestionType.AutoSize = true;
            lblQuestionType.Location = new System.Drawing.Point(319, 207);
            lblQuestionType.Name = "lblQuestionType";
            lblQuestionType.Size = new System.Drawing.Size(103, 18);
            lblQuestionType.TabIndex = 108;
            lblQuestionType.Text = "Tipo domanda";
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Location = new System.Drawing.Point(3, 207);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            lblSchoolSubject.TabIndex = 107;
            lblSchoolSubject.Text = "Materia";
            // 
            // cmbQuestionType
            // 
            cmbQuestionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbQuestionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbQuestionType.FormattingEnabled = true;
            cmbQuestionType.Location = new System.Drawing.Point(425, 204);
            cmbQuestionType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbQuestionType.Name = "cmbQuestionType";
            cmbQuestionType.Size = new System.Drawing.Size(209, 26);
            cmbQuestionType.TabIndex = 109;
            cmbQuestionType.SelectedIndexChanged += cmbQuestionType_SelectedIndexChanged;
            // 
            // cmbSchoolSubject
            // 
            cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchoolSubject.FormattingEnabled = true;
            cmbSchoolSubject.Location = new System.Drawing.Point(80, 204);
            cmbSchoolSubject.Name = "cmbSchoolSubject";
            cmbSchoolSubject.Size = new System.Drawing.Size(233, 26);
            cmbSchoolSubject.TabIndex = 106;
            cmbSchoolSubject.SelectedIndexChanged += cmbSchoolSubject_SelectedIndexChanged;
            // 
            // lblDifficulty
            // 
            lblDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblDifficulty.AutoSize = true;
            lblDifficulty.Enabled = false;
            lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDifficulty.ForeColor = System.Drawing.Color.DarkBlue;
            lblDifficulty.Location = new System.Drawing.Point(917, 136);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new System.Drawing.Size(64, 15);
            lblDifficulty.TabIndex = 111;
            lblDifficulty.Text = "Difficoltà";
            // 
            // txtDifficulty
            // 
            txtDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtDifficulty.Location = new System.Drawing.Point(917, 155);
            txtDifficulty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDifficulty.Name = "txtDifficulty";
            txtDifficulty.Size = new System.Drawing.Size(77, 37);
            txtDifficulty.TabIndex = 110;
            txtDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDifficulty.TextChanged += txtDifficulty_TextChanged;
            // 
            // btnNewQuestion
            // 
            btnNewQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewQuestion.Location = new System.Drawing.Point(784, 196);
            btnNewQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnNewQuestion.Name = "btnNewQuestion";
            btnNewQuestion.Size = new System.Drawing.Size(66, 51);
            btnNewQuestion.TabIndex = 112;
            btnNewQuestion.Text = "Nuova";
            btnNewQuestion.UseVisualStyleBackColor = true;
            btnNewQuestion.Click += btnNewQuestion_Click;
            // 
            // btnSaveAndChoose
            // 
            btnSaveAndChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveAndChoose.Location = new System.Drawing.Point(928, 196);
            btnSaveAndChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSaveAndChoose.Name = "btnSaveAndChoose";
            btnSaveAndChoose.Size = new System.Drawing.Size(66, 51);
            btnSaveAndChoose.TabIndex = 113;
            btnSaveAndChoose.Text = "Salva e scegli ";
            btnSaveAndChoose.UseVisualStyleBackColor = true;
            btnSaveAndChoose.Click += btnSaveAndChoose_Click;
            // 
            // frmQuestion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1000, 682);
            Controls.Add(btnSaveAndChoose);
            Controls.Add(btnNewQuestion);
            Controls.Add(lblDifficulty);
            Controls.Add(txtDifficulty);
            Controls.Add(lblQuestionType);
            Controls.Add(lblSchoolSubject);
            Controls.Add(cmbQuestionType);
            Controls.Add(cmbSchoolSubject);
            Controls.Add(lblIdQuesion);
            Controls.Add(txtIdQuestion);
            Controls.Add(btnSaveQuestion);
            Controls.Add(label1);
            Controls.Add(txtDuration);
            Controls.Add(label4);
            Controls.Add(txtWeight);
            Controls.Add(grpQuestionImage);
            Controls.Add(grpAnswers);
            Controls.Add(grpTopic);
            Controls.Add(lblQuestionText);
            Controls.Add(txtQuestionText);
            Controls.Add(grpTags);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DarkBlue;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmQuestion";
            Text = "Domanda";
            Load += frmQuestion_Load;
            grpTags.ResumeLayout(false);
            grpTopic.ResumeLayout(false);
            grpTopic.PerformLayout();
            grpAnswers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwAnswers).EndInit();
            grpQuestionImage.ResumeLayout(false);
            grpQuestionImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpTags;
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.GroupBox grpTopic;
        private System.Windows.Forms.Button btnChooseTopic;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.GroupBox grpAnswers;
        private System.Windows.Forms.DataGridView dgwAnswers;
        private System.Windows.Forms.GroupBox grpQuestionImage;
        private System.Windows.Forms.Button btnAddAnswer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.Label lblIdQuesion;
        private System.Windows.Forms.TextBox txtIdQuestion;
        private System.Windows.Forms.Button btnImportQuestions;
        private System.Windows.Forms.Label lblImagesPath;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Label lblQuestionType;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.ComboBox cmbQuestionType;
        private System.Windows.Forms.ComboBox cmbSchoolSubject;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.TextBox txtDifficulty;
        private System.Windows.Forms.Button btnChooseByPeriod;
        private System.Windows.Forms.Button btnNewQuestion;
        private System.Windows.Forms.Button btnSaveAndChoose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnChooseFileImage;
        private System.Windows.Forms.TextBox txtQuestionImage;
        private System.Windows.Forms.TextBox txtImagesPath;
        private System.Windows.Forms.Button btnPathImportImage;
    }
}
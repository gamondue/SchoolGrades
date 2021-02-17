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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestion));
            this.grpTags = new System.Windows.Forms.GroupBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.grpTopic = new System.Windows.Forms.GroupBox();
            this.btnChooseByPeriod = new System.Windows.Forms.Button();
            this.btnChooseTopic = new System.Windows.Forms.Button();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.grpAnswers = new System.Windows.Forms.GroupBox();
            this.btnImportQuestions = new System.Windows.Forms.Button();
            this.btnAddAnswer = new System.Windows.Forms.Button();
            this.dgwAnswers = new System.Windows.Forms.DataGridView();
            this.grpQuestionImage = new System.Windows.Forms.GroupBox();
            this.btnChooseFileImage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtQuestionImage = new System.Windows.Forms.TextBox();
            this.txtImagesPath = new System.Windows.Forms.TextBox();
            this.btnPathImportImage = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblImageName = new System.Windows.Forms.Label();
            this.lblImagesPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnSaveQuestion = new System.Windows.Forms.Button();
            this.lblIdQuesion = new System.Windows.Forms.Label();
            this.txtIdQuestion = new System.Windows.Forms.TextBox();
            this.lblQuestionType = new System.Windows.Forms.Label();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.cmbQuestionType = new System.Windows.Forms.ComboBox();
            this.cmbSchoolSubject = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.txtDifficulty = new System.Windows.Forms.TextBox();
            this.btnNewQuestion = new System.Windows.Forms.Button();
            this.btnSaveAndChoose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpTags.SuspendLayout();
            this.grpTopic.SuspendLayout();
            this.grpAnswers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).BeginInit();
            this.grpQuestionImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTags
            // 
            this.grpTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTags.Controls.Add(this.lstTags);
            this.grpTags.Controls.Add(this.btnRemoveTag);
            this.grpTags.Controls.Add(this.btnAddTag);
            this.grpTags.Location = new System.Drawing.Point(2, 370);
            this.grpTags.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTags.Name = "grpTags";
            this.grpTags.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTags.Size = new System.Drawing.Size(203, 310);
            this.grpTags.TabIndex = 0;
            this.grpTags.TabStop = false;
            this.grpTags.Text = "Tags";
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 18;
            this.lstTags.Location = new System.Drawing.Point(6, 50);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(191, 256);
            this.lstTags.TabIndex = 3;
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTag.Location = new System.Drawing.Point(165, 13);
            this.btnRemoveTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(37, 30);
            this.btnRemoveTag.TabIndex = 2;
            this.btnRemoveTag.Text = "-";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTag.Location = new System.Drawing.Point(120, 14);
            this.btnAddTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(39, 29);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestionText.Location = new System.Drawing.Point(3, 31);
            this.txtQuestionText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(908, 161);
            this.txtQuestionText.TabIndex = 1;
            this.txtQuestionText.TextChanged += new System.EventHandler(this.txtQuestionText_TextChanged);
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Location = new System.Drawing.Point(3, 5);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(146, 18);
            this.lblQuestionText.TabIndex = 2;
            this.lblQuestionText.Text = "Testo della domanda";
            // 
            // grpTopic
            // 
            this.grpTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTopic.Controls.Add(this.btnChooseByPeriod);
            this.grpTopic.Controls.Add(this.btnChooseTopic);
            this.grpTopic.Controls.Add(this.txtTopic);
            this.grpTopic.Location = new System.Drawing.Point(211, 370);
            this.grpTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTopic.Name = "grpTopic";
            this.grpTopic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTopic.Size = new System.Drawing.Size(781, 70);
            this.grpTopic.TabIndex = 2;
            this.grpTopic.TabStop = false;
            this.grpTopic.Text = "Argomento";
            // 
            // btnChooseByPeriod
            // 
            this.btnChooseByPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseByPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseByPeriod.Location = new System.Drawing.Point(741, 20);
            this.btnChooseByPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseByPeriod.Name = "btnChooseByPeriod";
            this.btnChooseByPeriod.Size = new System.Drawing.Size(34, 34);
            this.btnChooseByPeriod.TabIndex = 112;
            this.btnChooseByPeriod.Text = "Per.";
            this.toolTip1.SetToolTip(this.btnChooseByPeriod, "Argomenti fatti in un periodo");
            this.btnChooseByPeriod.UseVisualStyleBackColor = true;
            this.btnChooseByPeriod.Click += new System.EventHandler(this.btnChooseByPeriod_Click);
            // 
            // btnChooseTopic
            // 
            this.btnChooseTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseTopic.Location = new System.Drawing.Point(705, 20);
            this.btnChooseTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseTopic.Name = "btnChooseTopic";
            this.btnChooseTopic.Size = new System.Drawing.Size(34, 34);
            this.btnChooseTopic.TabIndex = 1;
            this.btnChooseTopic.Text = "..";
            this.btnChooseTopic.UseVisualStyleBackColor = true;
            this.btnChooseTopic.Click += new System.EventHandler(this.btnChooseTopic_Click);
            // 
            // txtTopic
            // 
            this.txtTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopic.Location = new System.Drawing.Point(6, 25);
            this.txtTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.ReadOnly = true;
            this.txtTopic.Size = new System.Drawing.Size(693, 24);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // grpAnswers
            // 
            this.grpAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnswers.Controls.Add(this.btnImportQuestions);
            this.grpAnswers.Controls.Add(this.btnAddAnswer);
            this.grpAnswers.Controls.Add(this.dgwAnswers);
            this.grpAnswers.Location = new System.Drawing.Point(211, 448);
            this.grpAnswers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAnswers.Name = "grpAnswers";
            this.grpAnswers.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAnswers.Size = new System.Drawing.Size(775, 227);
            this.grpAnswers.TabIndex = 4;
            this.grpAnswers.TabStop = false;
            this.grpAnswers.Text = "Risposte";
            // 
            // btnImportQuestions
            // 
            this.btnImportQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportQuestions.Enabled = false;
            this.btnImportQuestions.Location = new System.Drawing.Point(546, 0);
            this.btnImportQuestions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImportQuestions.Name = "btnImportQuestions";
            this.btnImportQuestions.Size = new System.Drawing.Size(229, 26);
            this.btnImportQuestions.TabIndex = 106;
            this.btnImportQuestions.Text = "Importa domande da file";
            this.btnImportQuestions.UseVisualStyleBackColor = true;
            this.btnImportQuestions.Click += new System.EventHandler(this.btnImportQuestions_Click);
            // 
            // btnAddAnswer
            // 
            this.btnAddAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAnswer.Location = new System.Drawing.Point(77, 0);
            this.btnAddAnswer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddAnswer.Name = "btnAddAnswer";
            this.btnAddAnswer.Size = new System.Drawing.Size(55, 26);
            this.btnAddAnswer.TabIndex = 2;
            this.btnAddAnswer.Text = "+";
            this.btnAddAnswer.UseVisualStyleBackColor = true;
            this.btnAddAnswer.Click += new System.EventHandler(this.btnAddAnswer_Click);
            // 
            // dgwAnswers
            // 
            this.dgwAnswers.AllowUserToAddRows = false;
            this.dgwAnswers.AllowUserToDeleteRows = false;
            this.dgwAnswers.AllowUserToOrderColumns = true;
            this.dgwAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgwAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAnswers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwAnswers.Location = new System.Drawing.Point(2, 34);
            this.dgwAnswers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwAnswers.Name = "dgwAnswers";
            this.dgwAnswers.RowTemplate.Height = 24;
            this.dgwAnswers.Size = new System.Drawing.Size(767, 190);
            this.dgwAnswers.TabIndex = 0;
            this.dgwAnswers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnswers_CellContentClick);
            this.dgwAnswers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnswers_CellDoubleClick);
            // 
            // grpQuestionImage
            // 
            this.grpQuestionImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQuestionImage.Controls.Add(this.btnChooseFileImage);
            this.grpQuestionImage.Controls.Add(this.button1);
            this.grpQuestionImage.Controls.Add(this.txtQuestionImage);
            this.grpQuestionImage.Controls.Add(this.txtImagesPath);
            this.grpQuestionImage.Controls.Add(this.btnPathImportImage);
            this.grpQuestionImage.Controls.Add(this.picImage);
            this.grpQuestionImage.Controls.Add(this.lblImageName);
            this.grpQuestionImage.Controls.Add(this.lblImagesPath);
            this.grpQuestionImage.Controls.Add(this.label2);
            this.grpQuestionImage.Enabled = false;
            this.grpQuestionImage.Location = new System.Drawing.Point(1, 255);
            this.grpQuestionImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpQuestionImage.Name = "grpQuestionImage";
            this.grpQuestionImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpQuestionImage.Size = new System.Drawing.Size(991, 107);
            this.grpQuestionImage.TabIndex = 2;
            this.grpQuestionImage.TabStop = false;
            this.grpQuestionImage.Text = "Immagine della domanda";
            // 
            // btnChooseFileImage
            // 
            this.btnChooseFileImage.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseFileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFileImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnChooseFileImage.Location = new System.Drawing.Point(719, 58);
            this.btnChooseFileImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChooseFileImage.Name = "btnChooseFileImage";
            this.btnChooseFileImage.Size = new System.Drawing.Size(33, 26);
            this.btnChooseFileImage.TabIndex = 156;
            this.btnChooseFileImage.Text = "..";
            this.btnChooseFileImage.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(756, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 51);
            this.button1.TabIndex = 114;
            this.button1.Text = "Imm. lezione";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtQuestionImage
            // 
            this.txtQuestionImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestionImage.Location = new System.Drawing.Point(164, 60);
            this.txtQuestionImage.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuestionImage.Name = "txtQuestionImage";
            this.txtQuestionImage.Size = new System.Drawing.Size(549, 24);
            this.txtQuestionImage.TabIndex = 153;
            // 
            // txtImagesPath
            // 
            this.txtImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagesPath.Location = new System.Drawing.Point(164, 30);
            this.txtImagesPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtImagesPath.Name = "txtImagesPath";
            this.txtImagesPath.Size = new System.Drawing.Size(549, 24);
            this.txtImagesPath.TabIndex = 154;
            // 
            // btnPathImportImage
            // 
            this.btnPathImportImage.BackColor = System.Drawing.Color.Transparent;
            this.btnPathImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathImportImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPathImportImage.Location = new System.Drawing.Point(719, 28);
            this.btnPathImportImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathImportImage.Name = "btnPathImportImage";
            this.btnPathImportImage.Size = new System.Drawing.Size(33, 27);
            this.btnPathImportImage.TabIndex = 155;
            this.btnPathImportImage.Text = "..";
            this.btnPathImportImage.UseVisualStyleBackColor = false;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(830, 13);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(155, 88);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 134;
            this.picImage.TabStop = false;
            // 
            // lblImageName
            // 
            this.lblImageName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageName.AutoSize = true;
            this.lblImageName.Enabled = false;
            this.lblImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblImageName.Location = new System.Drawing.Point(10, 64);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(147, 20);
            this.lblImageName.TabIndex = 107;
            this.lblImageName.Text = "Nome file immagine";
            // 
            // lblImagesPath
            // 
            this.lblImagesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImagesPath.AutoSize = true;
            this.lblImagesPath.Enabled = false;
            this.lblImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagesPath.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblImagesPath.Location = new System.Drawing.Point(10, 31);
            this.lblImagesPath.Name = "lblImagesPath";
            this.lblImagesPath.Size = new System.Drawing.Size(138, 20);
            this.lblImagesPath.TabIndex = 106;
            this.lblImagesPath.Text = "Percorso immagini";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(929, -49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Durata";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(917, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "Peso [%]";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(917, 31);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(77, 37);
            this.txtWeight.TabIndex = 96;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(917, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 99;
            this.label1.Text = "Durata [s]";
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(917, 93);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(77, 37);
            this.txtDuration.TabIndex = 98;
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // btnSaveQuestion
            // 
            this.btnSaveQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveQuestion.Location = new System.Drawing.Point(856, 196);
            this.btnSaveQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveQuestion.Name = "btnSaveQuestion";
            this.btnSaveQuestion.Size = new System.Drawing.Size(66, 51);
            this.btnSaveQuestion.TabIndex = 2;
            this.btnSaveQuestion.Text = "Salva";
            this.btnSaveQuestion.UseVisualStyleBackColor = true;
            this.btnSaveQuestion.Click += new System.EventHandler(this.btnSaveQuestion_Click);
            // 
            // lblIdQuesion
            // 
            this.lblIdQuesion.AutoSize = true;
            this.lblIdQuesion.Location = new System.Drawing.Point(643, 209);
            this.lblIdQuesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdQuesion.Name = "lblIdQuesion";
            this.lblIdQuesion.Size = new System.Drawing.Size(55, 18);
            this.lblIdQuesion.TabIndex = 105;
            this.lblIdQuesion.Text = "Codice";
            // 
            // txtIdQuestion
            // 
            this.txtIdQuestion.Location = new System.Drawing.Point(702, 206);
            this.txtIdQuestion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdQuestion.Name = "txtIdQuestion";
            this.txtIdQuestion.ReadOnly = true;
            this.txtIdQuestion.Size = new System.Drawing.Size(75, 24);
            this.txtIdQuestion.TabIndex = 104;
            this.txtIdQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblQuestionType
            // 
            this.lblQuestionType.AutoSize = true;
            this.lblQuestionType.Location = new System.Drawing.Point(319, 207);
            this.lblQuestionType.Name = "lblQuestionType";
            this.lblQuestionType.Size = new System.Drawing.Size(103, 18);
            this.lblQuestionType.TabIndex = 108;
            this.lblQuestionType.Text = "Tipo domanda";
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Location = new System.Drawing.Point(3, 207);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(57, 18);
            this.lblSchoolSubject.TabIndex = 107;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // cmbQuestionType
            // 
            this.cmbQuestionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQuestionType.FormattingEnabled = true;
            this.cmbQuestionType.Location = new System.Drawing.Point(425, 204);
            this.cmbQuestionType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbQuestionType.Name = "cmbQuestionType";
            this.cmbQuestionType.Size = new System.Drawing.Size(209, 26);
            this.cmbQuestionType.TabIndex = 109;
            this.cmbQuestionType.SelectedIndexChanged += new System.EventHandler(this.cmbQuestionType_SelectedIndexChanged);
            // 
            // cmbSchoolSubject
            // 
            this.cmbSchoolSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSubject.FormattingEnabled = true;
            this.cmbSchoolSubject.Location = new System.Drawing.Point(80, 204);
            this.cmbSchoolSubject.Name = "cmbSchoolSubject";
            this.cmbSchoolSubject.Size = new System.Drawing.Size(233, 26);
            this.cmbSchoolSubject.TabIndex = 106;
            this.cmbSchoolSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSubject_SelectedIndexChanged);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Enabled = false;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDifficulty.Location = new System.Drawing.Point(917, 136);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(64, 15);
            this.lblDifficulty.TabIndex = 111;
            this.lblDifficulty.Text = "Difficoltà";
            // 
            // txtDifficulty
            // 
            this.txtDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifficulty.Location = new System.Drawing.Point(917, 155);
            this.txtDifficulty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDifficulty.Name = "txtDifficulty";
            this.txtDifficulty.Size = new System.Drawing.Size(77, 37);
            this.txtDifficulty.TabIndex = 110;
            this.txtDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDifficulty.TextChanged += new System.EventHandler(this.txtDifficulty_TextChanged);
            // 
            // btnNewQuestion
            // 
            this.btnNewQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewQuestion.Location = new System.Drawing.Point(784, 196);
            this.btnNewQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewQuestion.Name = "btnNewQuestion";
            this.btnNewQuestion.Size = new System.Drawing.Size(66, 51);
            this.btnNewQuestion.TabIndex = 112;
            this.btnNewQuestion.Text = "Nuova";
            this.btnNewQuestion.UseVisualStyleBackColor = true;
            this.btnNewQuestion.Click += new System.EventHandler(this.btnNewQuestion_Click);
            // 
            // btnSaveAndChoose
            // 
            this.btnSaveAndChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndChoose.Location = new System.Drawing.Point(928, 196);
            this.btnSaveAndChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAndChoose.Name = "btnSaveAndChoose";
            this.btnSaveAndChoose.Size = new System.Drawing.Size(66, 51);
            this.btnSaveAndChoose.TabIndex = 113;
            this.btnSaveAndChoose.Text = "Salva e scegli ";
            this.btnSaveAndChoose.UseVisualStyleBackColor = true;
            this.btnSaveAndChoose.Click += new System.EventHandler(this.btnSaveAndChoose_Click);
            // 
            // frmQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1000, 682);
            this.Controls.Add(this.btnSaveAndChoose);
            this.Controls.Add(this.btnNewQuestion);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.txtDifficulty);
            this.Controls.Add(this.lblQuestionType);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.cmbQuestionType);
            this.Controls.Add(this.cmbSchoolSubject);
            this.Controls.Add(this.lblIdQuesion);
            this.Controls.Add(this.txtIdQuestion);
            this.Controls.Add(this.btnSaveQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.grpQuestionImage);
            this.Controls.Add(this.grpAnswers);
            this.Controls.Add(this.grpTopic);
            this.Controls.Add(this.lblQuestionText);
            this.Controls.Add(this.txtQuestionText);
            this.Controls.Add(this.grpTags);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuestion";
            this.Text = "Domanda";
            this.Load += new System.EventHandler(this.frmQuestion_Load);
            this.grpTags.ResumeLayout(false);
            this.grpTopic.ResumeLayout(false);
            this.grpTopic.PerformLayout();
            this.grpAnswers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).EndInit();
            this.grpQuestionImage.ResumeLayout(false);
            this.grpQuestionImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
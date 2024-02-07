namespace SchoolGrades
{
    partial class frmMicroAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMicroAssessment));
            txtMicroGrade = new System.Windows.Forms.TextBox();
            trkbGrade = new System.Windows.Forms.TrackBar();
            trkbWeight = new System.Windows.Forms.TrackBar();
            lblGrade = new System.Windows.Forms.Label();
            lblWeight = new System.Windows.Forms.Label();
            btnSaveMicroGrade = new System.Windows.Forms.Button();
            txtMicroGradeWeight = new System.Windows.Forms.TextBox();
            txtAverageMicroQuestions = new System.Windows.Forms.TextBox();
            btnNewMacroGrade = new System.Windows.Forms.Button();
            btnSaveMacroGrade = new System.Windows.Forms.Button();
            txtWeightsSum = new System.Windows.Forms.TextBox();
            lblAverageMicroQuestions = new System.Windows.Forms.Label();
            lblWeightsSum = new System.Windows.Forms.Label();
            txtIdMacroGrade = new System.Windows.Forms.TextBox();
            lblStudent = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            TxtQuestionText = new System.Windows.Forms.TextBox();
            btnQuestionChoose = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            txtMacroGradeWeight = new System.Windows.Forms.TextBox();
            txtGradeType = new System.Windows.Forms.TextBox();
            txtGradeTypeParent = new System.Windows.Forms.TextBox();
            lblGradeType = new System.Windows.Forms.Label();
            lblGradeTypeParent = new System.Windows.Forms.Label();
            lblSchoolSubject = new System.Windows.Forms.Label();
            txtSchoolSubject = new System.Windows.Forms.TextBox();
            btnEraseMicroGrade = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            btnFlushQuestion = new System.Windows.Forms.Button();
            btnSaveMicrogradeFromGrid = new System.Windows.Forms.Button();
            TxtIdStudent = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            DgwQuestions = new System.Windows.Forms.DataGridView();
            LessonTimer = new System.Windows.Forms.Timer(components);
            lblLessonTime = new System.Windows.Forms.Label();
            picStudent = new System.Windows.Forms.PictureBox();
            chkHasSpecialNeeds = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)trkbGrade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkbWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgwQuestions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // txtMicroGrade
            // 
            txtMicroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtMicroGrade.Location = new System.Drawing.Point(927, 295);
            txtMicroGrade.Margin = new System.Windows.Forms.Padding(4);
            txtMicroGrade.Name = "txtMicroGrade";
            txtMicroGrade.Size = new System.Drawing.Size(124, 37);
            txtMicroGrade.TabIndex = 2;
            txtMicroGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtMicroGrade, "Valutazione del microvoto corrente");
            txtMicroGrade.TextChanged += txtGrade_TextChanged;
            // 
            // trkbGrade
            // 
            trkbGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trkbGrade.LargeChange = 10;
            trkbGrade.Location = new System.Drawing.Point(71, 270);
            trkbGrade.Margin = new System.Windows.Forms.Padding(4);
            trkbGrade.Maximum = 100;
            trkbGrade.Name = "trkbGrade";
            trkbGrade.Size = new System.Drawing.Size(851, 45);
            trkbGrade.SmallChange = 5;
            trkbGrade.TabIndex = 5;
            trkbGrade.Value = 10;
            trkbGrade.Scroll += trkbGrade_Scroll;
            // 
            // trkbWeight
            // 
            trkbWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trkbWeight.LargeChange = 10;
            trkbWeight.Location = new System.Drawing.Point(71, 217);
            trkbWeight.Margin = new System.Windows.Forms.Padding(4);
            trkbWeight.Maximum = 100;
            trkbWeight.Name = "trkbWeight";
            trkbWeight.Size = new System.Drawing.Size(851, 45);
            trkbWeight.SmallChange = 5;
            trkbWeight.TabIndex = 4;
            trkbWeight.Value = 20;
            trkbWeight.Scroll += trkbWeight_Scroll;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Enabled = false;
            lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblGrade.ForeColor = System.Drawing.Color.DarkBlue;
            lblGrade.Location = new System.Drawing.Point(10, 270);
            lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new System.Drawing.Size(35, 15);
            lblGrade.TabIndex = 74;
            lblGrade.Text = "Voto";
            toolTip1.SetToolTip(lblGrade, "Valutazione del microvoto corrente");
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Enabled = false;
            lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblWeight.ForeColor = System.Drawing.Color.DarkBlue;
            lblWeight.Location = new System.Drawing.Point(10, 217);
            lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new System.Drawing.Size(39, 15);
            lblWeight.TabIndex = 73;
            lblWeight.Text = "Peso";
            toolTip1.SetToolTip(lblWeight, "Peso del microvoto corrente");
            // 
            // btnSaveMicroGrade
            // 
            btnSaveMicroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveMicroGrade.BackColor = System.Drawing.Color.Transparent;
            btnSaveMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveMicroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveMicroGrade.Location = new System.Drawing.Point(944, 151);
            btnSaveMicroGrade.Margin = new System.Windows.Forms.Padding(6);
            btnSaveMicroGrade.Name = "btnSaveMicroGrade";
            btnSaveMicroGrade.Size = new System.Drawing.Size(95, 58);
            btnSaveMicroGrade.TabIndex = 3;
            btnSaveMicroGrade.Text = "Nuova micro valutazione";
            toolTip1.SetToolTip(btnSaveMicroGrade, "Salva un nuovo microvoto che contribuisce alla media pesata sul voto \"padre\"");
            btnSaveMicroGrade.UseVisualStyleBackColor = false;
            btnSaveMicroGrade.Click += btnSaveMicroGradeFromGrid_Click;
            // 
            // txtMicroGradeWeight
            // 
            txtMicroGradeWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtMicroGradeWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtMicroGradeWeight.Location = new System.Drawing.Point(927, 235);
            txtMicroGradeWeight.Margin = new System.Windows.Forms.Padding(4);
            txtMicroGradeWeight.Name = "txtMicroGradeWeight";
            txtMicroGradeWeight.Size = new System.Drawing.Size(124, 37);
            txtMicroGradeWeight.TabIndex = 1;
            txtMicroGradeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtMicroGradeWeight, "Peso del microvoto corrente");
            txtMicroGradeWeight.TextChanged += txtWeight_TextChanged;
            // 
            // txtAverageMicroQuestions
            // 
            txtAverageMicroQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtAverageMicroQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtAverageMicroQuestions.Location = new System.Drawing.Point(927, 414);
            txtAverageMicroQuestions.Margin = new System.Windows.Forms.Padding(4);
            txtAverageMicroQuestions.Name = "txtAverageMicroQuestions";
            txtAverageMicroQuestions.Size = new System.Drawing.Size(124, 37);
            txtAverageMicroQuestions.TabIndex = 6;
            txtAverageMicroQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtAverageMicroQuestions, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si può modificare. ");
            // 
            // btnNewMacroGrade
            // 
            btnNewMacroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewMacroGrade.BackColor = System.Drawing.Color.Transparent;
            btnNewMacroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnNewMacroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnNewMacroGrade.Location = new System.Drawing.Point(944, 647);
            btnNewMacroGrade.Margin = new System.Windows.Forms.Padding(6);
            btnNewMacroGrade.Name = "btnNewMacroGrade";
            btnNewMacroGrade.Size = new System.Drawing.Size(95, 57);
            btnNewMacroGrade.TabIndex = 10;
            btnNewMacroGrade.Text = "Nuovo voto sint.";
            toolTip1.SetToolTip(btnNewMacroGrade, "Genera il codice di un nuovo voto \"padre\" sotto il quele staranno i prossimi  microvoti");
            btnNewMacroGrade.UseVisualStyleBackColor = false;
            btnNewMacroGrade.Click += btnNewMacroGrade_Click;
            // 
            // btnSaveMacroGrade
            // 
            btnSaveMacroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveMacroGrade.BackColor = System.Drawing.Color.Transparent;
            btnSaveMacroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveMacroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveMacroGrade.Location = new System.Drawing.Point(944, 581);
            btnSaveMacroGrade.Margin = new System.Windows.Forms.Padding(6);
            btnSaveMacroGrade.Name = "btnSaveMacroGrade";
            btnSaveMacroGrade.Size = new System.Drawing.Size(95, 59);
            btnSaveMacroGrade.TabIndex = 9;
            btnSaveMacroGrade.Text = "Salva voto di sintesi";
            toolTip1.SetToolTip(btnSaveMacroGrade, "Chiude le microvalutazioni salvando \"voto complessivo\" come voto \"padre\" ");
            btnSaveMacroGrade.UseVisualStyleBackColor = false;
            btnSaveMacroGrade.Click += btnSaveMacroGrade_Click;
            // 
            // txtWeightsSum
            // 
            txtWeightsSum.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtWeightsSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtWeightsSum.Location = new System.Drawing.Point(927, 474);
            txtWeightsSum.Margin = new System.Windows.Forms.Padding(4);
            txtWeightsSum.Name = "txtWeightsSum";
            txtWeightsSum.ReadOnly = true;
            txtWeightsSum.Size = new System.Drawing.Size(124, 37);
            txtWeightsSum.TabIndex = 7;
            txtWeightsSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtWeightsSum, "Somma dei pesi dei microvoti visualizzati");
            // 
            // lblAverageMicroQuestions
            // 
            lblAverageMicroQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblAverageMicroQuestions.AutoSize = true;
            lblAverageMicroQuestions.Enabled = false;
            lblAverageMicroQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAverageMicroQuestions.ForeColor = System.Drawing.Color.DarkBlue;
            lblAverageMicroQuestions.Location = new System.Drawing.Point(941, 395);
            lblAverageMicroQuestions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAverageMicroQuestions.Name = "lblAverageMicroQuestions";
            lblAverageMicroQuestions.Size = new System.Drawing.Size(97, 15);
            lblAverageMicroQuestions.TabIndex = 86;
            lblAverageMicroQuestions.Text = "Voto di sintesi";
            toolTip1.SetToolTip(lblAverageMicroQuestions, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si può modificare. ");
            // 
            // lblWeightsSum
            // 
            lblWeightsSum.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblWeightsSum.AutoSize = true;
            lblWeightsSum.Enabled = false;
            lblWeightsSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblWeightsSum.ForeColor = System.Drawing.Color.DarkBlue;
            lblWeightsSum.Location = new System.Drawing.Point(914, 455);
            lblWeightsSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWeightsSum.Name = "lblWeightsSum";
            lblWeightsSum.Size = new System.Drawing.Size(151, 15);
            lblWeightsSum.TabIndex = 87;
            lblWeightsSum.Text = "Somma pesi domande";
            toolTip1.SetToolTip(lblWeightsSum, "Somma dei pesi dei microvoti visualizzati");
            // 
            // txtIdMacroGrade
            // 
            txtIdMacroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtIdMacroGrade.Location = new System.Drawing.Point(927, 364);
            txtIdMacroGrade.Margin = new System.Windows.Forms.Padding(4);
            txtIdMacroGrade.Name = "txtIdMacroGrade";
            txtIdMacroGrade.ReadOnly = true;
            txtIdMacroGrade.Size = new System.Drawing.Size(124, 24);
            txtIdMacroGrade.TabIndex = 88;
            txtIdMacroGrade.TabStop = false;
            txtIdMacroGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtIdMacroGrade, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // lblStudent
            // 
            lblStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStudent.BackColor = System.Drawing.Color.Transparent;
            lblStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudent.ForeColor = System.Drawing.Color.DarkBlue;
            lblStudent.Location = new System.Drawing.Point(89, 12);
            lblStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new System.Drawing.Size(743, 59);
            lblStudent.TabIndex = 89;
            lblStudent.Text = "Allievo";
            lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.DarkBlue;
            label3.Location = new System.Drawing.Point(925, 345);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(128, 15);
            label3.TabIndex = 90;
            label3.Text = "Cod. voto di sintesi";
            toolTip1.SetToolTip(label3, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // TxtQuestionText
            // 
            TxtQuestionText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TxtQuestionText.Location = new System.Drawing.Point(10, 77);
            TxtQuestionText.Margin = new System.Windows.Forms.Padding(4);
            TxtQuestionText.Multiline = true;
            TxtQuestionText.Name = "TxtQuestionText";
            TxtQuestionText.ReadOnly = true;
            TxtQuestionText.Size = new System.Drawing.Size(903, 64);
            TxtQuestionText.TabIndex = 91;
            TxtQuestionText.DoubleClick += TxtQuestionText_DoubleClick;
            // 
            // btnQuestionChoose
            // 
            btnQuestionChoose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQuestionChoose.BackColor = System.Drawing.Color.Transparent;
            btnQuestionChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnQuestionChoose.ForeColor = System.Drawing.Color.DarkBlue;
            btnQuestionChoose.Location = new System.Drawing.Point(972, 83);
            btnQuestionChoose.Margin = new System.Windows.Forms.Padding(6);
            btnQuestionChoose.Name = "btnQuestionChoose";
            btnQuestionChoose.Size = new System.Drawing.Size(95, 56);
            btnQuestionChoose.TabIndex = 92;
            btnQuestionChoose.Text = "Scelta domanda";
            toolTip1.SetToolTip(btnQuestionChoose, "Apre la finestra che fa scegliere una domanda");
            btnQuestionChoose.UseVisualStyleBackColor = false;
            btnQuestionChoose.Click += btnQuestionChoose_Click;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.DarkBlue;
            label4.Location = new System.Drawing.Point(924, 515);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(131, 15);
            label4.TabIndex = 95;
            label4.Text = "Peso voto di sintesi";
            toolTip1.SetToolTip(label4, "Peso che verrà assegnato al voto \"padre\" quando  si salverà il voto complessivo");
            // 
            // txtMacroGradeWeight
            // 
            txtMacroGradeWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtMacroGradeWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtMacroGradeWeight.Location = new System.Drawing.Point(927, 534);
            txtMacroGradeWeight.Margin = new System.Windows.Forms.Padding(4);
            txtMacroGradeWeight.Name = "txtMacroGradeWeight";
            txtMacroGradeWeight.Size = new System.Drawing.Size(124, 37);
            txtMacroGradeWeight.TabIndex = 8;
            txtMacroGradeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtMacroGradeWeight, "Peso che verrà assegnato al voto \"padre\" quando  si salverà il voto complessivo");
            // 
            // txtGradeType
            // 
            txtGradeType.Location = new System.Drawing.Point(10, 172);
            txtGradeType.Margin = new System.Windows.Forms.Padding(4);
            txtGradeType.Multiline = true;
            txtGradeType.Name = "txtGradeType";
            txtGradeType.ReadOnly = true;
            txtGradeType.Size = new System.Drawing.Size(454, 37);
            txtGradeType.TabIndex = 96;
            // 
            // txtGradeTypeParent
            // 
            txtGradeTypeParent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtGradeTypeParent.Location = new System.Drawing.Point(471, 172);
            txtGradeTypeParent.Margin = new System.Windows.Forms.Padding(4);
            txtGradeTypeParent.Multiline = true;
            txtGradeTypeParent.Name = "txtGradeTypeParent";
            txtGradeTypeParent.ReadOnly = true;
            txtGradeTypeParent.Size = new System.Drawing.Size(442, 37);
            txtGradeTypeParent.TabIndex = 97;
            // 
            // lblGradeType
            // 
            lblGradeType.AutoSize = true;
            lblGradeType.Enabled = false;
            lblGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            lblGradeType.Location = new System.Drawing.Point(7, 153);
            lblGradeType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGradeType.Name = "lblGradeType";
            lblGradeType.Size = new System.Drawing.Size(295, 15);
            lblGradeType.TabIndex = 98;
            lblGradeType.Text = "Tipo di voto componente (micro valutazione) ";
            // 
            // lblGradeTypeParent
            // 
            lblGradeTypeParent.AutoSize = true;
            lblGradeTypeParent.Enabled = false;
            lblGradeTypeParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblGradeTypeParent.ForeColor = System.Drawing.Color.DarkBlue;
            lblGradeTypeParent.Location = new System.Drawing.Point(471, 153);
            lblGradeTypeParent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGradeTypeParent.Name = "lblGradeTypeParent";
            lblGradeTypeParent.Size = new System.Drawing.Size(259, 15);
            lblGradeTypeParent.TabIndex = 99;
            lblGradeTypeParent.Text = "Tipo del voto complessivo (di riepilogo)";
            // 
            // lblSchoolSubject
            // 
            lblSchoolSubject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSchoolSubject.AutoSize = true;
            lblSchoolSubject.Enabled = false;
            lblSchoolSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            lblSchoolSubject.Location = new System.Drawing.Point(910, 6);
            lblSchoolSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchoolSubject.Name = "lblSchoolSubject";
            lblSchoolSubject.Size = new System.Drawing.Size(56, 15);
            lblSchoolSubject.TabIndex = 110;
            lblSchoolSubject.Text = "Materia";
            // 
            // txtSchoolSubject
            // 
            txtSchoolSubject.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSchoolSubject.Location = new System.Drawing.Point(915, 24);
            txtSchoolSubject.Name = "txtSchoolSubject";
            txtSchoolSubject.ReadOnly = true;
            txtSchoolSubject.Size = new System.Drawing.Size(152, 24);
            txtSchoolSubject.TabIndex = 111;
            txtSchoolSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtSchoolSubject, "Materia di questa valutazione");
            // 
            // btnEraseMicroGrade
            // 
            btnEraseMicroGrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEraseMicroGrade.BackColor = System.Drawing.Color.Transparent;
            btnEraseMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEraseMicroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            btnEraseMicroGrade.Location = new System.Drawing.Point(863, 318);
            btnEraseMicroGrade.Margin = new System.Windows.Forms.Padding(6);
            btnEraseMicroGrade.Name = "btnEraseMicroGrade";
            btnEraseMicroGrade.Size = new System.Drawing.Size(50, 37);
            btnEraseMicroGrade.TabIndex = 112;
            btnEraseMicroGrade.Text = "-";
            toolTip1.SetToolTip(btnEraseMicroGrade, "Elimina la valutazione selezionata nella tabella");
            btnEraseMicroGrade.UseVisualStyleBackColor = false;
            btnEraseMicroGrade.Click += btnEraseMicroGrade_Click;
            // 
            // btnFlushQuestion
            // 
            btnFlushQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFlushQuestion.BackColor = System.Drawing.Color.Transparent;
            btnFlushQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFlushQuestion.ForeColor = System.Drawing.Color.DarkBlue;
            btnFlushQuestion.Location = new System.Drawing.Point(929, 83);
            btnFlushQuestion.Margin = new System.Windows.Forms.Padding(6);
            btnFlushQuestion.Name = "btnFlushQuestion";
            btnFlushQuestion.Size = new System.Drawing.Size(37, 56);
            btnFlushQuestion.TabIndex = 113;
            btnFlushQuestion.Text = "-";
            toolTip1.SetToolTip(btnFlushQuestion, "Elimina la domanda scelta");
            btnFlushQuestion.UseVisualStyleBackColor = false;
            btnFlushQuestion.Click += btnFlushQuestion_Click;
            // 
            // btnSaveMicrogradeFromGrid
            // 
            btnSaveMicrogradeFromGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveMicrogradeFromGrid.BackColor = System.Drawing.Color.Transparent;
            btnSaveMicrogradeFromGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveMicrogradeFromGrid.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveMicrogradeFromGrid.Location = new System.Drawing.Point(863, 367);
            btnSaveMicrogradeFromGrid.Margin = new System.Windows.Forms.Padding(6);
            btnSaveMicrogradeFromGrid.Name = "btnSaveMicrogradeFromGrid";
            btnSaveMicrogradeFromGrid.Size = new System.Drawing.Size(50, 37);
            btnSaveMicrogradeFromGrid.TabIndex = 144;
            btnSaveMicrogradeFromGrid.Text = "Salva";
            toolTip1.SetToolTip(btnSaveMicrogradeFromGrid, "Salva la valutazione selezionata nella tabella");
            btnSaveMicrogradeFromGrid.UseVisualStyleBackColor = false;
            btnSaveMicrogradeFromGrid.Click += btnSaveMicroGradeFromGrid_Click;
            // 
            // TxtIdStudent
            // 
            TxtIdStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            TxtIdStudent.Location = new System.Drawing.Point(836, 24);
            TxtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            TxtIdStudent.Name = "TxtIdStudent";
            TxtIdStudent.ReadOnly = true;
            TxtIdStudent.Size = new System.Drawing.Size(77, 24);
            TxtIdStudent.TabIndex = 147;
            TxtIdStudent.TabStop = false;
            TxtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(TxtIdStudent, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.DarkBlue;
            label1.Location = new System.Drawing.Point(833, 6);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 148;
            label1.Text = "Id allievo";
            toolTip1.SetToolTip(label1, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si può modificare. ");
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.DarkBlue;
            label2.Location = new System.Drawing.Point(938, 216);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 15);
            label2.TabIndex = 150;
            label2.Text = "Peso domanda";
            toolTip1.SetToolTip(label2, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.DarkBlue;
            label5.Location = new System.Drawing.Point(940, 276);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(99, 15);
            label5.TabIndex = 151;
            label5.Text = "Voto domanda";
            toolTip1.SetToolTip(label5, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // DgwQuestions
            // 
            DgwQuestions.AllowUserToAddRows = false;
            DgwQuestions.AllowUserToDeleteRows = false;
            DgwQuestions.AllowUserToOrderColumns = true;
            DgwQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgwQuestions.Location = new System.Drawing.Point(10, 318);
            DgwQuestions.Name = "DgwQuestions";
            DgwQuestions.Size = new System.Drawing.Size(852, 386);
            DgwQuestions.TabIndex = 114;
            DgwQuestions.CellClick += DgwQuestions_CellClick;
            DgwQuestions.CellContentClick += DgwQuestions_CellContentClick;
            DgwQuestions.CellContentDoubleClick += DgwQuestions_CellDoubleClick;
            // 
            // LessonTimer
            // 
            LessonTimer.Enabled = true;
            LessonTimer.Tick += LessonTimer_Tick;
            // 
            // lblLessonTime
            // 
            lblLessonTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblLessonTime.BackColor = System.Drawing.Color.Transparent;
            lblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblLessonTime.Enabled = false;
            lblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            lblLessonTime.Location = new System.Drawing.Point(990, 57);
            lblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLessonTime.Name = "lblLessonTime";
            lblLessonTime.Size = new System.Drawing.Size(77, 15);
            lblLessonTime.TabIndex = 143;
            lblLessonTime.Text = "      ";
            // 
            // picStudent
            // 
            picStudent.Location = new System.Drawing.Point(10, 1);
            picStudent.Name = "picStudent";
            picStudent.Size = new System.Drawing.Size(78, 76);
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 145;
            picStudent.TabStop = false;
            // 
            // chkHasSpecialNeeds
            // 
            chkHasSpecialNeeds.AutoSize = true;
            chkHasSpecialNeeds.ForeColor = System.Drawing.Color.DarkBlue;
            chkHasSpecialNeeds.Location = new System.Drawing.Point(836, 55);
            chkHasSpecialNeeds.Name = "chkHasSpecialNeeds";
            chkHasSpecialNeeds.Size = new System.Drawing.Size(69, 22);
            chkHasSpecialNeeds.TabIndex = 149;
            chkHasSpecialNeeds.Text = "BES ..";
            chkHasSpecialNeeds.UseVisualStyleBackColor = true;
            // 
            // frmMicroAssessment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PowderBlue;
            ClientSize = new System.Drawing.Size(1070, 715);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(chkHasSpecialNeeds);
            Controls.Add(label1);
            Controls.Add(TxtIdStudent);
            Controls.Add(picStudent);
            Controls.Add(btnSaveMicrogradeFromGrid);
            Controls.Add(lblLessonTime);
            Controls.Add(DgwQuestions);
            Controls.Add(btnFlushQuestion);
            Controls.Add(btnEraseMicroGrade);
            Controls.Add(txtSchoolSubject);
            Controls.Add(lblSchoolSubject);
            Controls.Add(lblGradeTypeParent);
            Controls.Add(lblGradeType);
            Controls.Add(txtGradeTypeParent);
            Controls.Add(txtGradeType);
            Controls.Add(label4);
            Controls.Add(txtMacroGradeWeight);
            Controls.Add(btnQuestionChoose);
            Controls.Add(TxtQuestionText);
            Controls.Add(label3);
            Controls.Add(lblStudent);
            Controls.Add(txtIdMacroGrade);
            Controls.Add(lblWeightsSum);
            Controls.Add(lblAverageMicroQuestions);
            Controls.Add(txtWeightsSum);
            Controls.Add(btnSaveMacroGrade);
            Controls.Add(txtAverageMicroQuestions);
            Controls.Add(btnNewMacroGrade);
            Controls.Add(btnSaveMicroGrade);
            Controls.Add(txtMicroGrade);
            Controls.Add(txtMicroGradeWeight);
            Controls.Add(trkbGrade);
            Controls.Add(trkbWeight);
            Controls.Add(lblGrade);
            Controls.Add(lblWeight);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmMicroAssessment";
            Text = "Micro voti";
            FormClosing += frmMicroAssessment_FormClosing;
            Load += frmMicroAssessment_Load;
            ((System.ComponentModel.ISupportInitialize)trkbGrade).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkbWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgwQuestions).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtMicroGrade;
        private System.Windows.Forms.TrackBar trkbGrade;
        private System.Windows.Forms.TrackBar trkbWeight;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Button btnSaveMicroGrade;
        private System.Windows.Forms.TextBox txtMicroGradeWeight;
        private System.Windows.Forms.TextBox txtAverageMicroQuestions;
        private System.Windows.Forms.Button btnNewMacroGrade;
        private System.Windows.Forms.Button btnSaveMacroGrade;
        private System.Windows.Forms.TextBox txtWeightsSum;
        private System.Windows.Forms.Label lblAverageMicroQuestions;
        private System.Windows.Forms.Label lblWeightsSum;
        private System.Windows.Forms.TextBox txtIdMacroGrade;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtQuestionText;
        private System.Windows.Forms.Button btnQuestionChoose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMacroGradeWeight;
        private System.Windows.Forms.TextBox txtGradeType;
        private System.Windows.Forms.TextBox txtGradeTypeParent;
        private System.Windows.Forms.Label lblGradeType;
        private System.Windows.Forms.Label lblGradeTypeParent;
        private System.Windows.Forms.Label lblSchoolSubject;
        private System.Windows.Forms.TextBox txtSchoolSubject;
        private System.Windows.Forms.Button btnEraseMicroGrade;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFlushQuestion;
        private System.Windows.Forms.DataGridView DgwQuestions;
        private System.Windows.Forms.Timer LessonTimer;
        private System.Windows.Forms.Label lblLessonTime;
        private System.Windows.Forms.Button btnSaveMicrogradeFromGrid;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.TextBox TxtIdStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHasSpecialNeeds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMicroAssessment));
            this.txtMicroGrade = new System.Windows.Forms.TextBox();
            this.trkbGrade = new System.Windows.Forms.TrackBar();
            this.trkbWeight = new System.Windows.Forms.TrackBar();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.btnSaveMicroGrade = new System.Windows.Forms.Button();
            this.txtMicroGradeWeight = new System.Windows.Forms.TextBox();
            this.txtAverageMicroQuestions = new System.Windows.Forms.TextBox();
            this.btnNewMacroGrade = new System.Windows.Forms.Button();
            this.btnSaveMacroGrade = new System.Windows.Forms.Button();
            this.txtWeightsSum = new System.Windows.Forms.TextBox();
            this.lblAverageMicroQuestions = new System.Windows.Forms.Label();
            this.lblWeightsSum = new System.Windows.Forms.Label();
            this.txtIdMacroGrade = new System.Windows.Forms.TextBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtQuestionText = new System.Windows.Forms.TextBox();
            this.btnQuestionChoose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMacroGradeWeight = new System.Windows.Forms.TextBox();
            this.txtGradeType = new System.Windows.Forms.TextBox();
            this.txtGradeTypeParent = new System.Windows.Forms.TextBox();
            this.lblGradeType = new System.Windows.Forms.Label();
            this.lblGradeTypeParent = new System.Windows.Forms.Label();
            this.lblSchoolSubject = new System.Windows.Forms.Label();
            this.txtSchoolSubject = new System.Windows.Forms.TextBox();
            this.btnEraseMicroGrade = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFlushQuestion = new System.Windows.Forms.Button();
            this.BtnSaveGrid = new System.Windows.Forms.Button();
            this.TxtIdStudent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgwQuestions = new System.Windows.Forms.DataGridView();
            this.LessonTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLessonTime = new System.Windows.Forms.Label();
            this.picStudent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkbGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMicroGrade
            // 
            this.txtMicroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMicroGrade.Location = new System.Drawing.Point(929, 270);
            this.txtMicroGrade.Margin = new System.Windows.Forms.Padding(4);
            this.txtMicroGrade.Name = "txtMicroGrade";
            this.txtMicroGrade.Size = new System.Drawing.Size(124, 37);
            this.txtMicroGrade.TabIndex = 2;
            this.txtMicroGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMicroGrade, "Valutazione del microvoto corrente");
            this.txtMicroGrade.TextChanged += new System.EventHandler(this.txtGrade_TextChanged);
            // 
            // trkbGrade
            // 
            this.trkbGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkbGrade.LargeChange = 10;
            this.trkbGrade.Location = new System.Drawing.Point(71, 270);
            this.trkbGrade.Margin = new System.Windows.Forms.Padding(4);
            this.trkbGrade.Maximum = 100;
            this.trkbGrade.Name = "trkbGrade";
            this.trkbGrade.Size = new System.Drawing.Size(851, 45);
            this.trkbGrade.SmallChange = 5;
            this.trkbGrade.TabIndex = 5;
            this.trkbGrade.Value = 10;
            this.trkbGrade.Scroll += new System.EventHandler(this.trkbGrade_Scroll);
            // 
            // trkbWeight
            // 
            this.trkbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkbWeight.LargeChange = 10;
            this.trkbWeight.Location = new System.Drawing.Point(71, 217);
            this.trkbWeight.Margin = new System.Windows.Forms.Padding(4);
            this.trkbWeight.Maximum = 100;
            this.trkbWeight.Name = "trkbWeight";
            this.trkbWeight.Size = new System.Drawing.Size(851, 45);
            this.trkbWeight.SmallChange = 5;
            this.trkbWeight.TabIndex = 4;
            this.trkbWeight.Value = 20;
            this.trkbWeight.Scroll += new System.EventHandler(this.trkbWeight_Scroll);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Enabled = false;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGrade.Location = new System.Drawing.Point(10, 270);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(35, 15);
            this.lblGrade.TabIndex = 74;
            this.lblGrade.Text = "Voto";
            this.toolTip1.SetToolTip(this.lblGrade, "Valutazione del microvoto corrente");
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Enabled = false;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeight.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblWeight.Location = new System.Drawing.Point(10, 217);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(39, 15);
            this.lblWeight.TabIndex = 73;
            this.lblWeight.Text = "Peso";
            this.toolTip1.SetToolTip(this.lblWeight, "Peso del microvoto corrente");
            // 
            // btnSaveMicroGrade
            // 
            this.btnSaveMicroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMicroGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveMicroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveMicroGrade.Location = new System.Drawing.Point(944, 151);
            this.btnSaveMicroGrade.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveMicroGrade.Name = "btnSaveMicroGrade";
            this.btnSaveMicroGrade.Size = new System.Drawing.Size(95, 58);
            this.btnSaveMicroGrade.TabIndex = 3;
            this.btnSaveMicroGrade.Text = "Nuova micro valutazione";
            this.toolTip1.SetToolTip(this.btnSaveMicroGrade, "Salva un nuovo microvoto che contribuisce alla media pesata sul voto \"padre\"");
            this.btnSaveMicroGrade.UseVisualStyleBackColor = false;
            this.btnSaveMicroGrade.Click += new System.EventHandler(this.btnSaveMicroGrade_Click);
            // 
            // txtMicroGradeWeight
            // 
            this.txtMicroGradeWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMicroGradeWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMicroGradeWeight.Location = new System.Drawing.Point(929, 217);
            this.txtMicroGradeWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtMicroGradeWeight.Name = "txtMicroGradeWeight";
            this.txtMicroGradeWeight.Size = new System.Drawing.Size(124, 37);
            this.txtMicroGradeWeight.TabIndex = 1;
            this.txtMicroGradeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMicroGradeWeight, "Peso del microvoto corrente");
            this.txtMicroGradeWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // txtAverageMicroQuestions
            // 
            this.txtAverageMicroQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAverageMicroQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAverageMicroQuestions.Location = new System.Drawing.Point(929, 387);
            this.txtAverageMicroQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.txtAverageMicroQuestions.Name = "txtAverageMicroQuestions";
            this.txtAverageMicroQuestions.Size = new System.Drawing.Size(124, 37);
            this.txtAverageMicroQuestions.TabIndex = 6;
            this.txtAverageMicroQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtAverageMicroQuestions, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si " +
        "può modificare. ");
            // 
            // btnNewMacroGrade
            // 
            this.btnNewMacroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewMacroGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnNewMacroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewMacroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNewMacroGrade.Location = new System.Drawing.Point(944, 647);
            this.btnNewMacroGrade.Margin = new System.Windows.Forms.Padding(6);
            this.btnNewMacroGrade.Name = "btnNewMacroGrade";
            this.btnNewMacroGrade.Size = new System.Drawing.Size(95, 57);
            this.btnNewMacroGrade.TabIndex = 10;
            this.btnNewMacroGrade.Text = "Nuovo voto sint.";
            this.toolTip1.SetToolTip(this.btnNewMacroGrade, "Genera il codice di un nuovo voto \"padre\" sotto il quele staranno i prossimi  mic" +
        "rovoti");
            this.btnNewMacroGrade.UseVisualStyleBackColor = false;
            this.btnNewMacroGrade.Click += new System.EventHandler(this.btnNewMacroGrade_Click);
            // 
            // btnSaveMacroGrade
            // 
            this.btnSaveMacroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMacroGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveMacroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveMacroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveMacroGrade.Location = new System.Drawing.Point(944, 576);
            this.btnSaveMacroGrade.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveMacroGrade.Name = "btnSaveMacroGrade";
            this.btnSaveMacroGrade.Size = new System.Drawing.Size(95, 59);
            this.btnSaveMacroGrade.TabIndex = 9;
            this.btnSaveMacroGrade.Text = "Salva voto di sintesi";
            this.toolTip1.SetToolTip(this.btnSaveMacroGrade, "Chiude le microvalutazioni salvando \"voto complessivo\" come voto \"padre\" ");
            this.btnSaveMacroGrade.UseVisualStyleBackColor = false;
            this.btnSaveMacroGrade.Click += new System.EventHandler(this.btnSaveMacroGrade_Click);
            // 
            // txtWeightsSum
            // 
            this.txtWeightsSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeightsSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtWeightsSum.Location = new System.Drawing.Point(929, 447);
            this.txtWeightsSum.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeightsSum.Name = "txtWeightsSum";
            this.txtWeightsSum.ReadOnly = true;
            this.txtWeightsSum.Size = new System.Drawing.Size(124, 37);
            this.txtWeightsSum.TabIndex = 7;
            this.txtWeightsSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtWeightsSum, "Somma dei pesi dei microvoti visualizzati");
            // 
            // lblAverageMicroQuestions
            // 
            this.lblAverageMicroQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAverageMicroQuestions.AutoSize = true;
            this.lblAverageMicroQuestions.Enabled = false;
            this.lblAverageMicroQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAverageMicroQuestions.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAverageMicroQuestions.Location = new System.Drawing.Point(927, 368);
            this.lblAverageMicroQuestions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageMicroQuestions.Name = "lblAverageMicroQuestions";
            this.lblAverageMicroQuestions.Size = new System.Drawing.Size(97, 15);
            this.lblAverageMicroQuestions.TabIndex = 86;
            this.lblAverageMicroQuestions.Text = "Voto di sintesi";
            this.toolTip1.SetToolTip(this.lblAverageMicroQuestions, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si " +
        "può modificare. ");
            // 
            // lblWeightsSum
            // 
            this.lblWeightsSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeightsSum.AutoSize = true;
            this.lblWeightsSum.Enabled = false;
            this.lblWeightsSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeightsSum.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblWeightsSum.Location = new System.Drawing.Point(927, 428);
            this.lblWeightsSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeightsSum.Name = "lblWeightsSum";
            this.lblWeightsSum.Size = new System.Drawing.Size(136, 15);
            this.lblWeightsSum.TabIndex = 87;
            this.lblWeightsSum.Text = "Somma pesi voticini";
            this.toolTip1.SetToolTip(this.lblWeightsSum, "Somma dei pesi dei microvoti visualizzati");
            // 
            // txtIdMacroGrade
            // 
            this.txtIdMacroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdMacroGrade.Location = new System.Drawing.Point(929, 337);
            this.txtIdMacroGrade.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdMacroGrade.Name = "txtIdMacroGrade";
            this.txtIdMacroGrade.ReadOnly = true;
            this.txtIdMacroGrade.Size = new System.Drawing.Size(124, 24);
            this.txtIdMacroGrade.TabIndex = 88;
            this.txtIdMacroGrade.TabStop = false;
            this.txtIdMacroGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtIdMacroGrade, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            this.txtIdMacroGrade.TextChanged += new System.EventHandler(this.txtIdMacroGrade_TextChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblStudent.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStudent.Location = new System.Drawing.Point(89, 12);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(824, 59);
            this.lblStudent.TabIndex = 89;
            this.lblStudent.Text = "Allievo";
            this.lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(927, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.label3.TabIndex = 90;
            this.label3.Text = "Cod. voto di sintesi";
            this.toolTip1.SetToolTip(this.label3, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // TxtQuestionText
            // 
            this.TxtQuestionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtQuestionText.Location = new System.Drawing.Point(10, 77);
            this.TxtQuestionText.Margin = new System.Windows.Forms.Padding(4);
            this.TxtQuestionText.Multiline = true;
            this.TxtQuestionText.Name = "TxtQuestionText";
            this.TxtQuestionText.ReadOnly = true;
            this.TxtQuestionText.Size = new System.Drawing.Size(903, 64);
            this.TxtQuestionText.TabIndex = 91;
            this.TxtQuestionText.TextChanged += new System.EventHandler(this.TxtQuestionText_TextChanged);
            this.TxtQuestionText.DoubleClick += new System.EventHandler(this.TxtQuestionText_DoubleClick);
            // 
            // btnQuestionChoose
            // 
            this.btnQuestionChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestionChoose.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestionChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuestionChoose.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnQuestionChoose.Location = new System.Drawing.Point(972, 83);
            this.btnQuestionChoose.Margin = new System.Windows.Forms.Padding(6);
            this.btnQuestionChoose.Name = "btnQuestionChoose";
            this.btnQuestionChoose.Size = new System.Drawing.Size(95, 56);
            this.btnQuestionChoose.TabIndex = 92;
            this.btnQuestionChoose.Text = "Scelta domanda";
            this.toolTip1.SetToolTip(this.btnQuestionChoose, "Apre la finestra che fa scegliere una domanda");
            this.btnQuestionChoose.UseVisualStyleBackColor = false;
            this.btnQuestionChoose.Click += new System.EventHandler(this.btnQuestionChoose_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(927, 488);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 95;
            this.label4.Text = "Peso voto di sintesi";
            this.toolTip1.SetToolTip(this.label4, "Peso che verrà assegnato al voto \"padre\" quando  si salverà il voto complessivo");
            // 
            // txtMacroGradeWeight
            // 
            this.txtMacroGradeWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacroGradeWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMacroGradeWeight.Location = new System.Drawing.Point(929, 507);
            this.txtMacroGradeWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtMacroGradeWeight.Name = "txtMacroGradeWeight";
            this.txtMacroGradeWeight.Size = new System.Drawing.Size(124, 37);
            this.txtMacroGradeWeight.TabIndex = 8;
            this.txtMacroGradeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtMacroGradeWeight, "Peso che verrà assegnato al voto \"padre\" quando  si salverà il voto complessivo");
            // 
            // txtGradeType
            // 
            this.txtGradeType.Location = new System.Drawing.Point(10, 172);
            this.txtGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.txtGradeType.Multiline = true;
            this.txtGradeType.Name = "txtGradeType";
            this.txtGradeType.ReadOnly = true;
            this.txtGradeType.Size = new System.Drawing.Size(454, 37);
            this.txtGradeType.TabIndex = 96;
            // 
            // txtGradeTypeParent
            // 
            this.txtGradeTypeParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGradeTypeParent.Location = new System.Drawing.Point(471, 172);
            this.txtGradeTypeParent.Margin = new System.Windows.Forms.Padding(4);
            this.txtGradeTypeParent.Multiline = true;
            this.txtGradeTypeParent.Name = "txtGradeTypeParent";
            this.txtGradeTypeParent.ReadOnly = true;
            this.txtGradeTypeParent.Size = new System.Drawing.Size(442, 37);
            this.txtGradeTypeParent.TabIndex = 97;
            // 
            // lblGradeType
            // 
            this.lblGradeType.AutoSize = true;
            this.lblGradeType.Enabled = false;
            this.lblGradeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGradeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGradeType.Location = new System.Drawing.Point(7, 153);
            this.lblGradeType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradeType.Name = "lblGradeType";
            this.lblGradeType.Size = new System.Drawing.Size(295, 15);
            this.lblGradeType.TabIndex = 98;
            this.lblGradeType.Text = "Tipo di voto componente (micro valutazione) ";
            // 
            // lblGradeTypeParent
            // 
            this.lblGradeTypeParent.AutoSize = true;
            this.lblGradeTypeParent.Enabled = false;
            this.lblGradeTypeParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGradeTypeParent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGradeTypeParent.Location = new System.Drawing.Point(471, 153);
            this.lblGradeTypeParent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradeTypeParent.Name = "lblGradeTypeParent";
            this.lblGradeTypeParent.Size = new System.Drawing.Size(259, 15);
            this.lblGradeTypeParent.TabIndex = 99;
            this.lblGradeTypeParent.Text = "Tipo del voto complessivo (di riepilogo)";
            // 
            // lblSchoolSubject
            // 
            this.lblSchoolSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchoolSubject.AutoSize = true;
            this.lblSchoolSubject.Enabled = false;
            this.lblSchoolSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSchoolSubject.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSchoolSubject.Location = new System.Drawing.Point(910, 16);
            this.lblSchoolSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolSubject.Name = "lblSchoolSubject";
            this.lblSchoolSubject.Size = new System.Drawing.Size(56, 15);
            this.lblSchoolSubject.TabIndex = 110;
            this.lblSchoolSubject.Text = "Materia";
            // 
            // txtSchoolSubject
            // 
            this.txtSchoolSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchoolSubject.Location = new System.Drawing.Point(915, 34);
            this.txtSchoolSubject.Name = "txtSchoolSubject";
            this.txtSchoolSubject.ReadOnly = true;
            this.txtSchoolSubject.Size = new System.Drawing.Size(152, 24);
            this.txtSchoolSubject.TabIndex = 111;
            this.txtSchoolSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtSchoolSubject, "Materia di questa valutazione");
            // 
            // btnEraseMicroGrade
            // 
            this.btnEraseMicroGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEraseMicroGrade.BackColor = System.Drawing.Color.Transparent;
            this.btnEraseMicroGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEraseMicroGrade.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEraseMicroGrade.Location = new System.Drawing.Point(863, 318);
            this.btnEraseMicroGrade.Margin = new System.Windows.Forms.Padding(6);
            this.btnEraseMicroGrade.Name = "btnEraseMicroGrade";
            this.btnEraseMicroGrade.Size = new System.Drawing.Size(50, 37);
            this.btnEraseMicroGrade.TabIndex = 112;
            this.btnEraseMicroGrade.Text = "-";
            this.toolTip1.SetToolTip(this.btnEraseMicroGrade, "Elimina la valutazione selezionata nella tabella");
            this.btnEraseMicroGrade.UseVisualStyleBackColor = false;
            this.btnEraseMicroGrade.Click += new System.EventHandler(this.btnEraseMicroGrade_Click);
            // 
            // btnFlushQuestion
            // 
            this.btnFlushQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlushQuestion.BackColor = System.Drawing.Color.Transparent;
            this.btnFlushQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFlushQuestion.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFlushQuestion.Location = new System.Drawing.Point(929, 83);
            this.btnFlushQuestion.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlushQuestion.Name = "btnFlushQuestion";
            this.btnFlushQuestion.Size = new System.Drawing.Size(37, 56);
            this.btnFlushQuestion.TabIndex = 113;
            this.btnFlushQuestion.Text = "-";
            this.toolTip1.SetToolTip(this.btnFlushQuestion, "Elimina la domanda scelta");
            this.btnFlushQuestion.UseVisualStyleBackColor = false;
            this.btnFlushQuestion.Click += new System.EventHandler(this.btnFlushQuestion_Click);
            // 
            // BtnSaveGrid
            // 
            this.BtnSaveGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveGrid.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveGrid.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnSaveGrid.Location = new System.Drawing.Point(863, 367);
            this.BtnSaveGrid.Margin = new System.Windows.Forms.Padding(6);
            this.BtnSaveGrid.Name = "BtnSaveGrid";
            this.BtnSaveGrid.Size = new System.Drawing.Size(50, 37);
            this.BtnSaveGrid.TabIndex = 144;
            this.BtnSaveGrid.Text = "Salva";
            this.toolTip1.SetToolTip(this.BtnSaveGrid, "Salva la valutazione selezionata nella tabella");
            this.BtnSaveGrid.UseVisualStyleBackColor = false;
            this.BtnSaveGrid.Click += new System.EventHandler(this.BtnSaveGrade);
            // 
            // TxtIdStudent
            // 
            this.TxtIdStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIdStudent.Location = new System.Drawing.Point(836, 34);
            this.TxtIdStudent.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdStudent.Name = "TxtIdStudent";
            this.TxtIdStudent.ReadOnly = true;
            this.TxtIdStudent.Size = new System.Drawing.Size(77, 24);
            this.TxtIdStudent.TabIndex = 147;
            this.TxtIdStudent.TabStop = false;
            this.TxtIdStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TxtIdStudent, "Codice del voto \"padre\", sotto il quale stanno tuttu queste microvalutazioni ");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(833, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 148;
            this.label1.Text = "Id allievo";
            this.toolTip1.SetToolTip(this.label1, "Media pesata di tutti i microvoti visualizzati. Salvata nel voto complessivo. Si " +
        "può modificare. ");
            // 
            // DgwQuestions
            // 
            this.DgwQuestions.AllowUserToAddRows = false;
            this.DgwQuestions.AllowUserToDeleteRows = false;
            this.DgwQuestions.AllowUserToOrderColumns = true;
            this.DgwQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgwQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwQuestions.Location = new System.Drawing.Point(10, 318);
            this.DgwQuestions.Name = "DgwQuestions";
            this.DgwQuestions.Size = new System.Drawing.Size(852, 386);
            this.DgwQuestions.TabIndex = 114;
            this.DgwQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellClick);
            this.DgwQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellContentClick);
            this.DgwQuestions.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwQuestions_CellDoubleClick);
            // 
            // LessonTimer
            // 
            this.LessonTimer.Enabled = true;
            this.LessonTimer.Tick += new System.EventHandler(this.LessonTimer_Tick);
            // 
            // lblLessonTime
            // 
            this.lblLessonTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLessonTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLessonTime.Enabled = false;
            this.lblLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLessonTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLessonTime.Location = new System.Drawing.Point(836, 60);
            this.lblLessonTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLessonTime.Name = "lblLessonTime";
            this.lblLessonTime.Size = new System.Drawing.Size(77, 15);
            this.lblLessonTime.TabIndex = 143;
            this.lblLessonTime.Text = "      ";
            // 
            // picStudent
            // 
            this.picStudent.Location = new System.Drawing.Point(10, 1);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(78, 76);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStudent.TabIndex = 145;
            this.picStudent.TabStop = false;
            // 
            // frmMicroAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1070, 715);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtIdStudent);
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.BtnSaveGrid);
            this.Controls.Add(this.lblLessonTime);
            this.Controls.Add(this.DgwQuestions);
            this.Controls.Add(this.btnFlushQuestion);
            this.Controls.Add(this.btnEraseMicroGrade);
            this.Controls.Add(this.txtSchoolSubject);
            this.Controls.Add(this.lblSchoolSubject);
            this.Controls.Add(this.lblGradeTypeParent);
            this.Controls.Add(this.lblGradeType);
            this.Controls.Add(this.txtGradeTypeParent);
            this.Controls.Add(this.txtGradeType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMacroGradeWeight);
            this.Controls.Add(this.btnQuestionChoose);
            this.Controls.Add(this.TxtQuestionText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.txtIdMacroGrade);
            this.Controls.Add(this.lblWeightsSum);
            this.Controls.Add(this.lblAverageMicroQuestions);
            this.Controls.Add(this.txtWeightsSum);
            this.Controls.Add(this.btnSaveMacroGrade);
            this.Controls.Add(this.txtAverageMicroQuestions);
            this.Controls.Add(this.btnNewMacroGrade);
            this.Controls.Add(this.btnSaveMicroGrade);
            this.Controls.Add(this.txtMicroGrade);
            this.Controls.Add(this.txtMicroGradeWeight);
            this.Controls.Add(this.trkbGrade);
            this.Controls.Add(this.trkbWeight);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblWeight);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMicroAssessment";
            this.Text = "Micro voti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMicroAssessment_FormClosing);
            this.Load += new System.EventHandler(this.frmMicroAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkbGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgwQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button BtnSaveGrid;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.TextBox TxtIdStudent;
        private System.Windows.Forms.Label label1;
    }
}
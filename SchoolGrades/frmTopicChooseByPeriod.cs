using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTopicChooseByPeriod : Form
    {
        DbAndBusiness db;
        private Class currentClass;
        private SchoolSubject currentSubject;

        internal Topic TopicChosen { get; private set; }

        List<Topic> topicsDone;

        public enum TopicChooseFormType
        {
            ChooseTopicOnExit,
            OpenTopicOnExit,
        }
        TopicChooseFormType formType;

        public frmTopicChooseByPeriod(TopicChooseFormType FormType, 
            Class Class, SchoolSubject Subject)
        {
            InitializeComponent();
            db = new DbAndBusiness(Commons.PathAndFileDatabase);

            currentClass = Class;
            currentSubject = Subject;
            formType = FormType;
            TopicChosen = new Topic(); 
            TopicChosen.Id = 0; 
        }

        private void frmTopicChooseByPeriod_Load(object sender, EventArgs e)
        {
            if (currentSubject != null)
            {
                dtpEndPeriod.Value = DateTime.Now;
                dtpStartPeriod.Value = dtpEndPeriod.Value.AddDays(-7);
                txtSchoolSubject.Text = currentSubject.IdSchoolSubject;
                txtClass.Text = currentClass.Abbreviation;
                txtSchoolYear.Text = currentClass.SchoolYear;
            }
            else
            {

            }
            cmbStandardPeriod.SelectedIndex = 4; // !! year !! TODO read previuos value 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateFrom;
            if (cmbStandardPeriod.Text == "")
                dateFrom = Commons.DateNull;
            else
                dateFrom = dtpStartPeriod.Value; 
            topicsDone = db.GetTopicsDoneInPeriod(currentClass, currentSubject,
                dateFrom, dtpEndPeriod.Value);

            dgwTopics.DataSource = topicsDone;
            //if (chkVisualizePath.Checked)
            //    dgwTopics.Columns[0].Visible = true;
            //else
            //    dgwTopics.Columns[0].Visible = false;

            dgwTopics.Columns[0].Visible = true;
            dgwTopics.Columns[1].Visible = false;
            dgwTopics.Columns[2].Visible = false;
            dgwTopics.Columns[3].Visible = false;
            dgwTopics.Columns[4].Visible = false;
            dgwTopics.Columns[5].Visible = false;
            dgwTopics.Columns[6].Visible = true;
            dgwTopics.Columns[7].Visible = true;
            dgwTopics.Columns[8].Visible = false;
            dgwTopics.Columns[9].Visible = false;
            dgwTopics.Columns[10].Visible = false;
            dgwTopics.Columns[11].Visible = false;
            dgwTopics.Columns[12].Visible = false;
        }

        private void dgwTopics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwTopics_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow value = dgwTopics.Rows[e.RowIndex];
                switch (formType)
                {
                    case (TopicChooseFormType.ChooseTopicOnExit):
                        {
                            if (value != null)
                            {
                                TopicChosen = topicsDone[e.RowIndex];
                                this.Close();
                            }
                            break;
                        }
                    case (TopicChooseFormType.OpenTopicOnExit):
                        {
                            List<Topic> oneItemList = new List<Topic>();
                            oneItemList.Add(topicsDone[e.RowIndex]);
                            frmTopics t = new frmTopics(frmTopics.TopicsFormType.NormalDialog,
                                oneItemList, currentClass, currentSubject);
                            t.ShowDialog(); 
                            t.Dispose();
                            break;
                        }
                }
            }
        }

        private void btnRandomTopic_Click(object sender, EventArgs e)
        {
            if (topicsDone == null)
            {
                topicsDone = db.GetTopicsDoneInPeriod(currentClass, currentSubject,
                    dtpStartPeriod.Value, dtpEndPeriod.Value);
            }
            if (topicsDone.Count > 0)
            {
                Random r = new Random();
                int index = r.Next(topicsDone.Count);
                TopicChosen = topicsDone[index];
                this.Close();
            }
            Console.Beep(); 
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgwTopics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Scegliere un argomento nella griglia");
                return; 
            }
            int rowIndex = dgwTopics.SelectedRows[0].Index;
            //DataRow row = ((DataTable)(dgwTopics.DataSource)).Rows[rowIndex];
            DataGridViewRow value = dgwTopics.Rows[rowIndex];
            switch (formType)
            {
                case (TopicChooseFormType.ChooseTopicOnExit):
                    {
                        if (value != null)
                        {
                            TopicChosen = topicsDone[rowIndex];
                            this.Close();
                        }
                        break;
                    }
                case (TopicChooseFormType.OpenTopicOnExit):
                    {
                        List<Topic> oneItemList = new List<Topic>();
                        oneItemList.Add(topicsDone[rowIndex]);
                        frmTopics t = new frmTopics(frmTopics.TopicsFormType.NormalDialog,
                            oneItemList, currentClass, currentSubject);
                        t.ShowDialog();
                        t.Dispose();
                        break;
                    }
            }
        }

        private void rdbWeek_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartPeriod.Value = dtpEndPeriod.Value.AddDays(-7);
        }

        private void rdbMonth_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartPeriod.Value = dtpEndPeriod.Value.AddMonths(-1);
        }

        private void rdbSchoolYear_CheckedChanged(object sender, EventArgs e)
        {
            // TODO calculate automatically the beginning of the school year 
            // TODO and put in dtpStartPeriod
            dtpStartPeriod.Value = new DateTime(2018, 09, 15);
        }

        private void cmbStandardPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbStandardPeriod.SelectedIndex)
            {
                case 0:
                    { // week
                        dtpStartPeriod.Value = Commons.DateNull;
                        break;
                    }
                case 1:
                    { // week
                        dtpStartPeriod.Value = dtpEndPeriod.Value.AddDays(-7);
                        break;
                    }
                case 2:
                    {  // month
                        dtpStartPeriod.Value = dtpEndPeriod.Value.AddMonths(-1);
                        break;
                    }
                case 3:
                    {   // school year
                        // TODO calculate automatically the beginning of the school year 
                        // TODO and put in dtpStartPeriod
                        dtpStartPeriod.Value = new DateTime(2018, 09, 1);
                        break;
                    }
                case 4:
                    {   // from the beginning of the solar year. 
                        // TODO use the periods stores in SchoolPeriods table 
                        dtpStartPeriod.Value = new DateTime(2019, 01, 01);
                        break;
                    }
            }
        }

        private void dgwTopics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwTopics.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}

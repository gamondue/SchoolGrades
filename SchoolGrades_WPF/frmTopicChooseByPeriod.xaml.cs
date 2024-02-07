using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmTopicChooseByPeriod.xaml
    /// </summary>
    public partial class frmTopicChooseByPeriod : Window
    {
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
        private SchoolPeriod currentSchoolPeriod;
        public frmTopicChooseByPeriod(TopicChooseFormType FormType,
            Class Class, SchoolSubject Subject)
        {
            InitializeComponent();
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
                dtpEndPeriod.SelectedDate = DateTime.Now;
                dtpStartPeriod.SelectedDate = dtpEndPeriod.SelectedDate.Value.AddDays(-7);
                txtSchoolSubject.Text = currentSubject.IdSchoolSubject;
                txtClass.Text = currentClass.Abbreviation;
                txtSchoolYear.Text = currentClass.SchoolYear;
            }
            else
            {

            }
            List<SchoolPeriod> listPeriods = Commons.bl.GetSchoolPeriods(currentClass.SchoolYear);
            cmbSchoolPeriod.ItemsSource = listPeriods;
            // select the combo item of the partial period of the DateTime.Now
            foreach (SchoolPeriod sp in listPeriods)
            {
                if (sp.DateFinish > DateTime.Now && sp.DateStart < DateTime.Now
                    && sp.IdSchoolPeriodType == "P")
                {
                    cmbSchoolPeriod.SelectedItem = sp;
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateFrom;
            if (cmbSchoolPeriod.Text == "")
                dateFrom = Commons.DateNull;
            else
                dateFrom = dtpStartPeriod.SelectedDate.Value;
            topicsDone = Commons.bl.GetTopicsDoneInPeriod(currentClass, currentSubject,
                dateFrom, dtpEndPeriod.SelectedDate.Value);

            dgwTopics.ItemsSource = topicsDone;
            //if (chkVisualizePath.IsChecked)
            //    dgwTopics.Columns[0].Visibility = Visibility.Visible;
            //else
            //    dgwTopics.Columns[0].Visibility = Visibility.Hidden;

            dgwTopics.Columns[0].Visibility = Visibility.Visible;
            dgwTopics.Columns[1].Visibility = Visibility.Hidden;
            dgwTopics.Columns[2].Visibility = Visibility.Hidden;
            dgwTopics.Columns[3].Visibility = Visibility.Hidden;
            dgwTopics.Columns[4].Visibility = Visibility.Hidden;
            dgwTopics.Columns[5].Visibility = Visibility.Hidden;
            dgwTopics.Columns[6].Visibility = Visibility.Visible;
            dgwTopics.Columns[7].Visibility = Visibility.Visible;
            dgwTopics.Columns[8].Visibility = Visibility.Hidden;
            dgwTopics.Columns[9].Visibility = Visibility.Hidden;
            dgwTopics.Columns[10].Visibility = Visibility.Hidden;
            dgwTopics.Columns[11].Visibility = Visibility.Hidden;
            dgwTopics.Columns[12].Visibility = Visibility.Hidden;
        }
        private void dgwTopics_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void dgwTopics_CellContentDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                DataGridRow value = (DataGridRow)dgwTopics.Items[RowIndex];
                switch (formType)
                {
                    case (TopicChooseFormType.ChooseTopicOnExit):
                        {
                            if (value != null)
                            {
                                TopicChosen = topicsDone[RowIndex];
                                this.Close();
                            }
                            break;
                        }
                    case (TopicChooseFormType.OpenTopicOnExit):
                        {
                            List<Topic> oneItemList = new List<Topic>();
                            oneItemList.Add(topicsDone[RowIndex]);
                            frmTopics t = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                                currentClass, currentSubject, null, oneItemList);
                            t.ShowDialog();
                            //t.Dispose();
                            break;
                        }
                }
            }
        }
        private void btnRandomTopic_Click(object sender, EventArgs e)
        {
            if (topicsDone == null)
            {
                topicsDone = Commons.bl.GetTopicsDoneInPeriod(currentClass, currentSubject,
                    dtpStartPeriod.SelectedDate.Value, dtpEndPeriod.SelectedDate.Value);
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
            if (dgwTopics.SelectedItems.Count == 0)
            {
                MessageBox.Show("Scegliere un argomento nella griglia");
                return;
            }
            int rowIndex = dgwTopics.SelectedIndex;
            //DataGridRow value = dgwTopics.Items[rowIndex];
            DataGridRow value = (DataGridRow)dgwTopics.Items[rowIndex];
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
                        frmTopics t = new frmTopics(frmTopics.TopicsFormType.HighlightTopics,
                            currentClass, currentSubject, null, oneItemList);
                        t.ShowDialog();
                        //t.Dispose();
                        break;
                    }
            }
        }
        private void cmbStandardPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSchoolPeriod = (SchoolPeriod)(cmbSchoolPeriod.SelectedValue);
            if (currentSchoolPeriod.IdSchoolPeriodType != "N")
            {
                dtpStartPeriod.SelectedDate = (DateTime)currentSchoolPeriod.DateStart;
                dtpEndPeriod.SelectedDate = (DateTime)currentSchoolPeriod.DateFinish;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "month")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddMonths(-1);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "week")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddDays(-7);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
            else if (currentSchoolPeriod.IdSchoolPeriod == "year")
            {
                dtpStartPeriod.SelectedDate = DateTime.Now.AddYears(-1);
                dtpEndPeriod.SelectedDate = DateTime.Now;
            }
        }
        private void dgwTopics_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                //////////dgwTopics.Items[RowIndex].Selected = true;
            }
        }
    }
}

using System;
using System.Windows.Forms;
using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;

namespace SchoolGrades
{
    public partial class frmSchoolYearAndPeriodsManagement : Form
    {
        SchoolPeriod currentSchoolPeriod = new SchoolPeriod();
        public frmSchoolYearAndPeriodsManagement()
        {
            InitializeComponent();
            LocalizeForm();
        }
        public frmSchoolYearAndPeriodsManagement(string ClassAbbreviation)
        {
            InitializeComponent();
            txtSchoolYear.Text = ClassAbbreviation;
        }
        private void frmSchoolPeriodsManagement_Load(object sender, EventArgs e)
        {
            RefreshGrid();

            cmbSchoolPeriodTypes.DisplayMember = "Desc";
            cmbSchoolPeriodTypes.ValueMember = "IdSchoolPeriodType";
            cmbSchoolPeriodTypes.DataSource = Commons.bl.GetSchoolPeriodTypes();
            cmbSchoolPeriodTypes.SelectedValue = "P";
        }
        private void btnNewPeriod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da fare!");
            RefreshGrid();
            return;
        }
        private void btnDeletePeriod_Click(object sender, EventArgs e)
        {
            ReadFromUi(); 
            if (currentSchoolPeriod == null || currentSchoolPeriod.IdSchoolPeriod == null || currentSchoolPeriod.IdSchoolPeriod == "")
            {
                MessageBox.Show(Loc.Get("SchoolPeriods_SelectToDelete"));
                return;
            }
            if (MessageBox.Show(string.Format(Loc.Get("SchoolPeriods_ConfirmDelete"),
                currentSchoolPeriod.IdSchoolPeriod, currentSchoolPeriod.Desc),
                "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return; 
            }
            Commons.bl.DeleteSchoolPeriod(currentSchoolPeriod.IdSchoolPeriod);  
            RefreshGrid();
            return;
        }
        private void dgwSchoolPeriods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwSchoolPeriods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgwSchoolPeriods.Rows[e.RowIndex].Selected = true;
                WriteToUi(); 
            }
        }
        private void btnSaveSchoolPeriod_Click(object sender, EventArgs e)
        {
            ReadFromUi();
            Commons.bl.SaveSchoolPeriod(currentSchoolPeriod);
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dgwSchoolPeriods.DataSource = Commons.bl.GetSchoolPeriods(null);
        }
        private void ReadFromUi()
        {
            currentSchoolPeriod.IdSchoolPeriod = txtIdSchoolPeriod.Text;
            currentSchoolPeriod.IdSchoolYear = txtSchoolYear.Text;
            currentSchoolPeriod.DateStart = dtpStartPeriod.Value;
            currentSchoolPeriod.DateFinish = dtpEndPeriod.Value;
            currentSchoolPeriod.Name = txtName.Text;
            currentSchoolPeriod.Desc = txtDescription.Text;
            currentSchoolPeriod.IdSchoolPeriodType = ((SchoolPeriodType)cmbSchoolPeriodTypes.SelectedItem).IdSchoolPeriodType;
        }
        private void WriteToUi()
        {
            DataGridViewRow row = dgwSchoolPeriods.SelectedRows[0];
            txtIdSchoolPeriod.Text = row.Cells["IdSchoolPeriod"].Value.ToString();
            txtSchoolYear.Text = row.Cells["IdSchoolYear"].Value.ToString();
            if (row.Cells["DateStart"].Value != null)
                dtpStartPeriod.Value = (DateTime)row.Cells["DateStart"].Value;
            if (row.Cells["DateFinish"].Value != null)
                dtpEndPeriod.Value = (DateTime)row.Cells["DateFinish"].Value;
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtDescription.Text = row.Cells["Desc"].Value.ToString();
            cmbSchoolPeriodTypes.SelectedValue = row.Cells["IdSchoolPeriodType"].Value.ToString();
        }
        private void btnNewYear_Click(object sender, EventArgs e)
        {
            if (txtSchoolYear.Text == "")
            {
                MessageBox.Show(Loc.Get("SchoolPeriods_EnterYearCode"));
                return;
            }
            //string nextYear = Commons.IncreaseIntegersInString(txtSchoolYear.Text); 
            if (rdbQuadrimester.Checked)
            { 
                Commons.bl.CreateNewQuadrimesterPeriods(txtSchoolYear.Text);
            }
            else
            { 
                Commons.bl.CreateNewTrimesterPeriods(txtSchoolYear.Text);
            }
            RefreshGrid();
        }
        private void LocalizeForm()
        {
            try
            {
                // Title
                this.Text = Loc.Get("SchoolPeriods_Title");

                // GroupBox
                grpPeriodOfQuestionsTopics.Text = Loc.Get("SchoolPeriods_PeriodDates");

                // Labels
                label1.Text = Loc.Get("SchoolPeriods_Code");
                lblSchoolYear.Text = Loc.Get("SchoolPeriods_Year");
                lblStart.Text = Loc.Get("SchoolPeriods_Start");
                lblEnd.Text = Loc.Get("SchoolPeriods_End");
                label2.Text = Loc.Get("SchoolPeriods_ShortDescription");
                label4.Text = Loc.Get("SchoolPeriods_Type");
                label3.Text = Loc.Get("SchoolPeriods_Description");

                // Buttons
                btnNewYear.Text = Loc.Get("SchoolPeriods_YearPeriods");
                btnSaveSchoolPeriod.Text = Loc.Get("SchoolPeriods_SaveSinglePeriod");
                btnNewPeriod.Text = Loc.Get("SchoolPeriods_Add");
                btnDeletePeriod.Text = Loc.Get("SchoolPeriods_Remove");

                // RadioButtons
                rdbQuadrimester.Text = Loc.Get("SchoolPeriods_Quadrimesters");
                rdbTrimester.Text = Loc.Get("SchoolPeriods_Trimesters");

                // Tooltips
                toolTip1.SetToolTip(btnNewYear, Loc.Get("SchoolPeriods_Tooltip_YearPeriods"));
                toolTip1.SetToolTip(btnSaveSchoolPeriod, Loc.Get("SchoolPeriods_Tooltip_SaveSinglePeriod"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmSchoolYearAndPeriodsManagement.LocalizeForm: {ex.Message}");
            }
        }
    }
}

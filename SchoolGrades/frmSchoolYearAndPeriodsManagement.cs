using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmSchoolYearAndPeriodsManagement : Form
    {
        SchoolPeriod currentSchoolPeriod = new SchoolPeriod();
        public frmSchoolYearAndPeriodsManagement()
        {
            InitializeComponent();
        }
        public frmSchoolYearAndPeriodsManagement(string NewAbbreviation)
        {
            InitializeComponent();
            Text = NewAbbreviation;
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
                MessageBox.Show("Selezionare un periodo da cancellare"); 
                return;
            }
            if (MessageBox.Show("E' sicuro di cancellare il periodo " + currentSchoolPeriod.IdSchoolPeriod + 
                " | " + currentSchoolPeriod.Desc + "?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
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
                MessageBox.Show("Scrivere il codice dell'anno precedente nella casella 'Anno'"); 
                return;
            }
            string nextYear = Commons.IncreaseIntegersInString(txtSchoolYear.Text); 
            if (rdbQuadrimester.Checked)
            { 
                Commons.bl.CreateNewQuadrimesterPeriods(nextYear);
            }
            else
            { 
                Commons.bl.CreateNewTrimesterPeriods(nextYear);
            }
            RefreshGrid();
        }
        private void cmbSchoolPeriodTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

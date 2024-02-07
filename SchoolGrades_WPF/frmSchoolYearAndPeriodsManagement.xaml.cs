using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per wpfSchoolYearAndPeriodsManagement.xaml
    /// </summary>
    public partial class frmSchoolYearAndPeriodsManagement : Window
    {
        SchoolPeriod currentSchoolPeriod = new SchoolPeriod();

        public string Text { get; }

        public frmSchoolYearAndPeriodsManagement()
        {
            InitializeComponent();
        }

        public frmSchoolYearAndPeriodsManagement(string NewAbbreviation)
        {
            InitializeComponent();
            Text = NewAbbreviation;
        }
        private void frmSchoolPeriodsManagement_Load(object sender, RoutedEventArgs e)
        {
            RefreshGrid();

            cmbSchoolPeriodTypes.DisplayMemberPath = "Desc";
            cmbSchoolPeriodTypes.DisplayMemberPath = "IdSchoolPeriodType";
            cmbSchoolPeriodTypes.ItemsSource = Commons.bl.GetSchoolPeriodTypes();
            cmbSchoolPeriodTypes.SelectedValue = "P";
        }



        private void btnNewPeriod_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da fare!");
            RefreshGrid();
            return;
        }

        private void btnDeletePeriod_Click(object sender, RoutedEventArgs e)
        {
            ReadFromUi();
            if (currentSchoolPeriod == null || currentSchoolPeriod.IdSchoolPeriod == null || currentSchoolPeriod.IdSchoolPeriod == "")
            {
                MessageBox.Show("Selezionare un periodo da cancellare");
                return;
            }
            if (MessageBox.Show("E' sicuro di cancellare il periodo " + currentSchoolPeriod.IdSchoolPeriod +
                " | " + currentSchoolPeriod.Desc + "?", "", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }
            Commons.bl.DeleteSchoolPeriod(currentSchoolPeriod.IdSchoolPeriod);
            RefreshGrid();
            return;
        }



        //private void dgwSchoolPeriods_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //                DataGrid grid = (DataGrid)sender;
        //int RowIndex = grid.SelectedIndex;
        //    if (RowIndex > -1)
        //    {
        //        dgwSchoolPeriods.Items[RowIndex].Selected = true;
        //        WriteToUi();
        //    }
        //}

        private void btnSaveSchoolPeriod_Click(object sender, RoutedEventArgs e)
        {
            ReadFromUi();
            Commons.bl.SaveSchoolPeriod(currentSchoolPeriod);
            RefreshGrid();
        }

        private void btnNewYear_Click(object sender, RoutedEventArgs e)
        {
            if (txtSchoolYear.Text == "")
            {
                MessageBox.Show("Scrivere il codice dell'anno precedente nella casella 'Anno'");
                return;
            }
            string nextYear = Commons.IncreaseIntegersInString(txtSchoolYear.Text);
            if ((bool)rdbQuadrimester.IsChecked)
            {
                Commons.bl.CreateNewQuadrimesterPeriods(nextYear);
            }
            else
            {
                Commons.bl.CreateNewTrimesterPeriods(nextYear);
            }
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dgwSchoolPeriods.ItemsSource = Commons.bl.GetSchoolPeriods(null);
        }

        private void ReadFromUi()
        {
            currentSchoolPeriod.IdSchoolPeriod = txtIdSchoolPeriod.Text;
            currentSchoolPeriod.IdSchoolYear = txtSchoolYear.Text;
            currentSchoolPeriod.DateStart = dtpStartPeriod.DisplayDate;
            currentSchoolPeriod.DateFinish = dtpEndPeriod.DisplayDate;
            currentSchoolPeriod.Name = txtName.Text;
            currentSchoolPeriod.Desc = (string)txtDescription.Content;
            currentSchoolPeriod.IdSchoolPeriodType = ((SchoolPeriodType)cmbSchoolPeriodTypes.SelectedItem).IdSchoolPeriodType;
        }

        private void txtIdSchoolPeriod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSchoolYear_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgwSchoolPeriods_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void dgwSchoolPeriods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgwSchoolPeriods_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }


        //private void WriteToUi()
        //{
        //    DataGridRow row = dgwSchoo;
        //    txtIdSchoolPeriod.Text = row.Cells["IdSchoolPeriod"].Value.ToString();
        //    txtSchoolYear.Text = row.Cells["IdSchoolYear"].Value.ToString();
        //    if (row.Cells["DateStart"].Value != null)
        //        dtpStartPeriod.Value = (DateTime)row.Cells["DateStart"].Value;
        //    if (row.Cells["DateFinish"].Value != null)
        //        dtpEndPeriod.Value = (DateTime)row.Cells["DateFinish"].Value;
        //    txtName.Text = row.Cells["Name"].Value.ToString();
        //    txtDescription.Text = row.Cells["Desc"].Value.ToString();
        //    cmbSchoolPeriodTypes.SelectedValue = row.Cells["IdSchoolPeriodType"].Value.ToString();
        //}


    }
}

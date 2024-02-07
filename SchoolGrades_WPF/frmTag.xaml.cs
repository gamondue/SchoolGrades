using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmTag.xaml
    /// </summary>
    public partial class frmTag : Window
    {
        List<Tag> listTags;
        internal Tag currentTag = new Tag();
        bool isDialog;
        public bool haveChosen = false;

        public frmTag(bool IsDialog)
        {
            InitializeComponent();

            isDialog = IsDialog;
            if (isDialog)
            {
                btnChoose.Visibility = Visibility.Visible;
            }
            else
            {
                btnChoose.Visibility = Visibility.Hidden;
            }
        }
        private void frmTag_Load(object sender, EventArgs e)
        {
            listTags = new List<Tag>();
            if (txtIdTag.Text == "")
            {
                btnSave.IsEnabled = false;
                btnChoose.IsEnabled = false;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtTag.Text = txtSearch.Text;
            if (txtSearch.Text.Length > 0)
            {
                listTags = Commons.bl.GetTagsContaining(txtSearch.Text);
                dgwExistingTags.ItemsSource = listTags;
                dgwExistingTags.Columns[0].Visibility = Visibility.Hidden;
                dgwExistingTags.Columns[2].Visibility = Visibility.Hidden;
                //dgwExistingTags.Refresh();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Commons.bl.SaveTag(currentTag);
            btnChoose.IsEnabled = true;
        }
        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            currentTag.TagName = txtTag.Text;
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            currentTag.Desc = txtDesc.Text;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtIdTag.Text = Commons.bl.CreateNewTag(currentTag).ToString();
            btnChoose.IsEnabled = false;
            btnSave.IsEnabled = true;
        }
        private void dgwExistingTags_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            Tag t = listTags[RowIndex];
            currentTag = t;
            txtDesc.Text = t.Desc;
            txtIdTag.Text = t.IdTag.ToString();
            txtTag.Text = t.TagName;
            btnChoose.IsEnabled = true;
            btnSave.IsEnabled = true;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            haveChosen = true;
            this.Close();
        }
    }
}

using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmTag : Form
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
                btnChoose.Visible = true;
            }
            else {
                btnChoose.Visible = false;
            }
        }

        private void frmTag_Load(object sender, EventArgs e)
        {
            listTags = new List<Tag>(); 
            if (txtIdTag.Text  == "")
            {
                btnSave.Enabled = false;
                btnChoose.Enabled = false;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtTag.Text = txtSearch.Text;
            if (txtSearch.Text.Length > 0)
            {
                listTags = Commons.bl.GetTagsContaining(txtSearch.Text);
                dgwExistingTags.DataSource = listTags;
                dgwExistingTags.Columns[0].Visible = false;
                dgwExistingTags.Columns[2].Visible = false;
                dgwExistingTags.Refresh(); 
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Commons.bl.SaveTag(currentTag);
            btnChoose.Enabled = true; 
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
            btnChoose.Enabled = false;
            btnSave.Enabled = true; 
        }

        private void dgwExistingTags_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tag t = listTags[e.RowIndex];
            currentTag = t; 
            txtDesc.Text = t.Desc;
            txtIdTag.Text = t.IdTag.ToString();
            txtTag.Text = t.TagName;
            btnChoose.Enabled = true;
            btnSave.Enabled = true; 
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            haveChosen = true; 
            this.Close(); 
        }
    }
}

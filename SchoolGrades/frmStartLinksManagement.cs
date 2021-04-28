using SchoolGrades.DbClasses;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmStartLinksManagement : Form
    {
        // TODO management of year and classes of year with combo.  

        DbAndBusiness db;
        BusinessLayer bl;

        string year;
        private int? currentIdStartLink;
        private Class currentClass; 

        public frmStartLinksManagement(Class CurrentClass)
        {
            InitializeComponent();

            db = new DbAndBusiness(Commons.PathAndFileDatabase);
            bl = new BusinessLayer(Commons.PathAndFileDatabase);

            currentClass = CurrentClass; 
        }

        private void frmStartLinksManagement_Load(object sender, EventArgs e)
        {
            int anno = 2009;
            for (; anno <= DateTime.Now.Year; anno++)
            {
                CmbSchoolYear.Items.Add((anno - 2000).ToString("00") + ((anno + 1) - 2000).ToString("00"));
            }
            int nAnni = CmbSchoolYear.Items.Count;
            if (DateTime.Now.Month >= 9)
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 1];
            else
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 2];

                CmbClasses.DataSource = bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text,
                CmbSchoolYear.SelectedItem.ToString());

            refreshGrid();
            // TxtPathStartLink.Text = Commons.PathStartLinks;
            TxtPathStartLink.Text = currentClass.PathRestrictedApplication; 
        }

        private void txtSchoolYear_TextChanged(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void refreshGrid()
        {
            DgwLinks.DataSource = db.GetAllStartLinks(CmbSchoolYear.Text.ToString()
                ,currentClass.IdClass);
        }

        private void DgwLinks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgwLinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DgwLinks.Rows[e.RowIndex].Selected = true;  
            }
        }

        private void DgwLinks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRow row = ((DataTable)(DgwLinks.DataSource)).Rows[e.RowIndex];
                CmbClasses.SelectedItem = (string)row["abbreviation"];
                currentClass.Abbreviation = (string)row["abbreviation"];
                TxtStartLink.Text = SafeDb.SafeString(row["startLink"]);

                TxtLinkDescription.Text = SafeDb.SafeString(row["desc"]);
                currentIdStartLink = (int)row["idStartLink"];
                currentClass.IdClass = (int)row["idClass"];
            }
        }

        private void DgwLinks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try { 
                    DataRow row = ((DataTable)(DgwLinks.DataSource)).Rows[e.RowIndex];
                    string link = (string)row["startLink"];
                    Class clickedClass = db.GetClassById((int)row["idClass"]); 
                    if (link.Substring(0, 4) == "http" || link.Contains(".exe"))
                        Commons.ProcessStartLink(link);
                    else
                        Commons.ProcessStartLink(clickedClass.PathRestrictedApplication + "\\" + link);
                }
                catch (Exception ex)
                {
                    Console.Beep();
                }
            }
        }

        private void btnSaveLinks_Click(object sender, EventArgs e)
        {
            db.SaveStartLink(currentIdStartLink, currentClass.IdClass, 
                CmbSchoolYear.Text, TxtStartLink.Text, TxtLinkDescription.Text);
            refreshGrid();
        }

        private void btnAddLink_Click(object sender, EventArgs e)
        {
            if (currentClass.IdClass > 0)
                //currentIdStartLink = db.CreateNewVoidStartLink(currentClass.IdClass);
                currentIdStartLink = db.SaveStartLink(null, currentClass.IdClass, 
                    CmbSchoolYear.Text,TxtStartLink.Text, TxtLinkDescription.Text);
                    else
                        MessageBox.Show("Scegliere una classe");
            refreshGrid();
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (currentClass.IdClass > 0)
                db.DeleteStartLink(currentIdStartLink);
            else
                MessageBox.Show("Scegliere un link da cancellare");
            refreshGrid();
        }

        private void txtStartLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStartLink_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (TxtStartLink.Text.Substring(0, 4) == "http")
                    Commons.ProcessStartLink(TxtStartLink.Text);
                else
                    Commons.ProcessStartLink(currentClass.PathRestrictedApplication + "\\" + TxtStartLink.Text);
            }
            catch
            {
                Console.Beep();
            }
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class tempClass = db.GetClass(TxtOfficialSchoolAbbreviation.Text, 
                CmbSchoolYear.Text, CmbClasses.SelectedItem.ToString());
            if (tempClass.IdClass != null && tempClass.IdClass != 0)
            {
                currentClass = tempClass;
                TxtPathStartLink.Text = currentClass.PathRestrictedApplication;
                refreshGrid();
            }
            else
            {
                DgwLinks.DataSource = null;
            }
        }

        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshGrid();
            CmbClasses.DataSource = bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text,
                    CmbSchoolYear.SelectedItem.ToString());
            // TxtPathStartLink.Text = Commons.PathStartLinks;
            TxtPathStartLink.Text = currentClass.PathRestrictedApplication;
        }

        private void TxtPathStartLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPathStartLink_DoubleClick(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(TxtPathStartLink.Text);
        }

        private void BtnPathRetrictedApplication_Click(object sender, EventArgs e)
        {
            // !!!! TODO: add a new field to Classes record that contains the start link folder and separate if 
            // !!!! from the RestrictedAccessPath, that is another thing! (even if in most cases the two 
            // !!!! paths will be equal). When the database will be changed adding a PathStartLink, then
            // !!!! update this method changing TxtPathStartLink.Text with a new textbox. 
            // !!!! Keep BtnPathRetrictedApplication button non visible until then.

            // !!!! code currently non executed
            folderBrowserDialog1.SelectedPath = TxtPathStartLink.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("Si deve cambiare la cartella dei link?\n(i link a documenti già presenti non funzioneranno più!)", 
                    "Attenzione!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                { 
                    TxtPathStartLink.Text = folderBrowserDialog1.SelectedPath;
                    db.UpdatePathStartLinkOfClass(currentClass, TxtPathStartLink.Text); 
                }
            } 
        }

        private void BtnFileToLaunch_Click(object sender, EventArgs e)
        {
            string folderStartLinks = TxtPathStartLink.Text; 
            openFileDialog.InitialDirectory = folderStartLinks;
            DialogResult r = openFileDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtStartLink.Text = openFileDialog.FileName.Replace(folderStartLinks,"").Substring(1);
            }
        }

        private void TxtLinkedFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

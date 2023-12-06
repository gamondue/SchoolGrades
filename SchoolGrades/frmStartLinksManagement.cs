using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmStartLinksManagement : Form
    {
        private int? currentIdStartLink;
        private Class currentClass;
        private StartLink currentLink;
        private bool loading;

        public frmStartLinksManagement(Class CurrentClass)
        {
            InitializeComponent();

            currentClass = CurrentClass; 
        }
        private void frmStartLinksManagement_Load(object sender, EventArgs e)
        {
            loading = true;
            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            CmbSchoolYear.DataSource = ly;
            if (ly.Count > 0)
                CmbSchoolYear.SelectedItem = ly[ly.Count - 1];
            //TxtPathStartLink.Text = currentClass.PathRestrictedApplication;
            loading = false; 
        }
        private void txtSchoolYear_TextChanged(object sender, EventArgs e)
        {
            refreshGrid();
        }
        private void refreshGrid()
        {
            if (!loading)
            {
                DgwLinks.DataSource = null;
                DgwLinks.DataSource = Commons.bl.GetStartLinksOfClass(currentClass);
            }
        }
        private void DgwLinks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwLinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DgwLinks.Rows[e.RowIndex].Selected = true;
                currentLink = ((List<StartLink>)DgwLinks.DataSource)[e.RowIndex]; 
            }
        }
        private void DgwLinks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                List<StartLink> l = (List<StartLink>)DgwLinks.DataSource; 

                TxtStartLink.Text = Safe.String(l[e.RowIndex].Link);

                TxtLinkDescription.Text = Safe.String(l[e.RowIndex].Desc);
                currentIdStartLink = Safe.Int(l[e.RowIndex].IdStartLink);
                currentClass.IdClass = Safe.Int(l[e.RowIndex].IdClass);
            }
        }
        private void DgwLinks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try {
                    StartLink row = ((List<StartLink>)(DgwLinks.DataSource))[e.RowIndex];
                    Class clickedClass = Commons.bl.GetClassById((int)row.IdClass); 
                    if (row.Link.Substring(0, 4) == "http" || row.Link.Contains(".exe"))
                        Commons.ProcessStartLink(row.Link);
                    else
                        Commons.ProcessStartLink(Path.Combine(clickedClass.PathRestrictedApplication, row.Link));
                }
                catch (Exception ex)
                {
                    Console.Beep();
                }
            }
        }
        private void btnSaveLinks_Click(object sender, EventArgs e)
        {
            Commons.bl.SaveStartLink(currentIdStartLink, currentClass.IdClass, 
                CmbSchoolYear.Text, TxtStartLink.Text, TxtLinkDescription.Text);
            refreshGrid();
        }
        private void btnAddLink_Click(object sender, EventArgs e)
        {
            if (currentClass.IdClass > 0)
                currentIdStartLink = Commons.bl.SaveStartLink(null, currentClass.IdClass, 
                    CmbSchoolYear.Text, TxtStartLink.Text, TxtLinkDescription.Text);
            else
                MessageBox.Show("Scegliere una classe");
            refreshGrid();
        }
        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (currentLink.IdStartLink > 0)
                Commons.bl.DeleteStartLink(currentLink.IdStartLink);
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
                    Commons.ProcessStartLink(Path.Combine(currentClass.PathRestrictedApplication, TxtStartLink.Text));
            }
            catch
            {
                Console.Beep();
            }
        }
        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                Class tempClass = Commons.bl.GetClass(TxtOfficialSchoolAbbreviation.Text,
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
        }
        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text,
                    CmbSchoolYear.SelectedItem.ToString());
            if (!loading)
            { 
                refreshGrid();
                TxtPathStartLink.Text = currentClass.PathRestrictedApplication;
            }
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
            // !!!! TODO: add a new field to Classes record that contains the start link folder and separate it
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
                    Commons.bl.UpdatePathStartLinkOfClass(currentClass, TxtPathStartLink.Text); 
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

using Microsoft.Win32;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for StartLinksManagement.xaml
    /// </summary>
    public partial class frmStartLinksManagement : Window
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
            CmbSchoolYear.ItemsSource = ly;
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
                DgwLinks.ItemsSource = null;
                DgwLinks.ItemsSource = Commons.bl.GetStartLinksOfClass(currentClass);
            }
        }
        private void DgwLinks_CellContentClick(object sender, RoutedEvent e)
        {

        }
        private void DgwLinks_CellClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                //////////DgwLinks.Items[RowIndex].Selected= true;
                currentLink = ((List<StartLink>)DgwLinks.ItemsSource)[RowIndex];
            }
        }
        private void DgwLinks_RowEnter(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                List<StartLink> l = (List<StartLink>)DgwLinks.ItemsSource;

                TxtStartLink.Text = Safe.String(l[RowIndex].Link);

                TxtLinkDescription.Text = Safe.String(l[RowIndex].Desc);
                currentIdStartLink = Safe.Int(l[RowIndex].IdStartLink);
                currentClass.IdClass = Safe.Int(l[RowIndex].IdClass);
            }
        }
        private void DgwLinks_CellDoubleClick(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                try
                {
                    StartLink row = ((List<StartLink>)(DgwLinks.ItemsSource))[RowIndex];
                    Class clickedClass = Commons.bl.GetClassById((int)row.IdClass);
                    if (row.Link.Substring(0, 4) == "http" || row.Link.Contains(".exe"))
                        Commons.ProcessStartLink(row.Link);
                    else
                        Commons.ProcessStartLink(System.IO.Path.Combine(clickedClass.PathRestrictedApplication, row.Link));
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
                    Commons.ProcessStartLink(System.IO.Path.Combine(currentClass.PathRestrictedApplication, TxtStartLink.Text));
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
                    DgwLinks.ItemsSource = null;
                }
            }
        }
        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbClasses.ItemsSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text,
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
            OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
            folderBrowserDialog1.InitialDirectory = TxtPathStartLink.Text;
            bool? r = folderBrowserDialog1.ShowDialog();
            if (r == true)
            {
                if (MessageBox.Show("Si deve cambiare la cartella dei link?\n(i link a documenti già presenti non funzioneranno più!)",
                    "Attenzione!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    TxtPathStartLink.Text = Path.GetFullPath(folderBrowserDialog1.FileName);
                    Commons.bl.UpdatePathStartLinkOfClass(currentClass, TxtPathStartLink.Text);
                }
            }
        }
        private void BtnFileToLaunch_Click(object sender, EventArgs e)
        {
            string folderStartLinks = TxtPathStartLink.Text;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = folderStartLinks;
            bool? chosen = ofd.ShowDialog();
            if (chosen == true)
            {
                TxtStartLink.Text = ofd.FileName.Replace(folderStartLinks, "").Substring(1);
            }
        }
        private void TxtLinkedFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

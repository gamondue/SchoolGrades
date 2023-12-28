using Microsoft.Win32;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Path = System.IO.Path;
//using Image = System

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmImages.xaml
    /// </summary>
    public partial class frmImages : Window
    {
        // TODO manage an order of the images of the lesson (database and code) 

        List<SchoolGrades.BusinessObjects.Image> listImages;
        private Lesson currentLesson;
        private Class currentClass;
        private SchoolGrades.BusinessObjects.Image currentImage;
        private SchoolSubject currentSubject;
        private bool imageChanged = false;

        ImagesFormType type;
        private string lessonImagesPath;
        private int currentIndexInImages;
        private SchoolPeriod currentSchoolPeriod;
        private string oldImage;

        public enum ImagesFormType
        {
            NormalManagement,
            ShowImage,
        }
        public frmImages(ImagesFormType Type, Lesson Lesson, Class Class,
            List<SchoolGrades.BusinessObjects.Image> Images, SchoolSubject Subject)
        {
            InitializeComponent();

            listImages = Images;
            currentLesson = Lesson;
            currentClass = Class;
            currentSubject = Subject;

            type = Type;
            lessonImagesPath = currentClass.SchoolYear +
                currentClass.Abbreviation + "\\Lessons" +
                "\\" + currentLesson.IdSchoolSubject;
        }
        private void frmImages_Load(object sender, EventArgs e)
        {
            txtLessonDate.Text = currentLesson.Date.ToString();
            txtSchoolYear.Text = currentClass.SchoolYear;
            txtClass.Text = currentClass.Abbreviation;

            txtSchoolSubject.Text = currentLesson.IdSchoolSubject;
            txtLessonCode.Text = currentLesson.IdLesson.ToString(); ;
            txtLessonDesc.Text = currentLesson.Note;

            refreshUi(currentIndexInImages);

            if (type == ImagesFormType.ShowImage)
            {
                //////////picImage.Location = new System.Drawing.Point(0, 0);
                //////////picImage.Size = this.Size;
                currentImage = listImages[0];
                loadCurrentImage();
                //picImage.Load(Commons.PathImages + "\\"+ listImages[0].RelativePathAndFilename);
            }
            else if (type == ImagesFormType.NormalManagement)
            {
                dgwLessonsImages.ItemsSource = listImages;
            }
            if (listImages.Count > 0)
            {
                currentImage = listImages[0];
                loadCurrentImage();
            }
            else
            {
                currentImage = new SchoolGrades.BusinessObjects.Image();
            }

            if (currentSubject != null)
            {
                Color col = CommonsWpf.ColorFromNumber(currentSubject);
                this.Background = CommonsWpf.BrushFromColor(col);
                rdbAutoRename_CheckedChanged(null, null);
            }
        }
        private void loadCurrentImage()
        {
            try
            {
                CommonsWpf.loadPicture(picImage, System.IO.Path.Combine(Commons.PathImages, currentImage.RelativePathAndFilename));
                txtCaption.Text = currentImage.Caption;
            }
            catch
            {
                Console.Beep();
            };
        }
        private void txtPathImportImage_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPathImportImage_DoubleClick(object sender, EventArgs e)
        {
            if (txtPathImportImage.Text != "")
                Commons.ProcessStartLink(txtPathImportImage.Text);
        }
        private void btnPathImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new();
            bool? result = fileBrowser.ShowDialog();
            if (result == true)
            {
                txtPathImportImage.Text = fileBrowser.FileName; ;
            }
        }
        private void btnChooseFileImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = "";
            dialog.InitialDirectory = txtPathImportImage.Text;
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                txtFileImportImage.Text = Path.GetFileName(dialog.FileName);
                txtPathImportImage.Text = Path.GetDirectoryName(dialog.FileName);
            }
            if (dialog.FileName != "")
            {
                try
                {
                    CommonsWpf.loadPicture(picImage, dialog.FileName);
                    List<string> captions = Commons.bl.GetCaptionsOfThisImage(txtFileImportImage.Text);
                    if (captions.Count > 0)
                        // this SHOULD take the last caption that this image has had
                        // (but if it doesn't it doesn't matter much)
                        txtCaption.Text = captions[captions.Count - 1];
                    else
                        txtCaption.Text = "";
                    string currentImage = Path.Combine(txtPathImportImage.Text, txtFileImportImage.Text);
                    if (currentImage != oldImage)
                    {
                        imageChanged = true;
                    }
                    oldImage = currentImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Immagine non caricata.\nFormato non supportato?");
                }
            }
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (txtFileImportImage.Text != "")
            {
                string sourcePathAndFileName = txtPathImportImage.Text + "\\" +
                    txtFileImportImage.Text;
                string lessonImagesPath = Path.Combine(Commons.PathImages, txtSubFolderStorage.Text);
                string extension = Path.GetExtension(sourcePathAndFileName);
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {   // save an image
                    currentImage.Caption = txtCaption.Text;
                    Commons.bl.AddImageToLesson(sourcePathAndFileName, lessonImagesPath, txtSubFolderStorage.Text,
                        currentLesson, currentClass, currentImage, (bool)rdbAutoRename.IsChecked,
                        (bool)chkMantainOldFileName.IsChecked);
                    try
                    {
                        CommonsWpf.loadPicture(picImage, sourcePathAndFileName);
                    }
                    catch
                    {
                        Console.Beep();
                    };
                    // goto the last in the grid (the one just added) 
                    currentIndexInImages = dgwLessonsImages.Items.Count;
                    if (currentIndexInImages < 0)
                        currentIndexInImages = 0;
                    refreshUi(currentIndexInImages);
                    // load data from the last 
                    currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[dgwLessonsImages.Items.Count - 1];
                    loadCurrentImage();
                }
                else
                {   // save a document 

                }
            }
        }
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            // values before 
            int oldIndex = currentIndexInImages;

            if (dgwLessonsImages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selezionare nella griglia un'immagine da cancellare");
                return;
            }
            CommonsWpf.loadPicture(picImage, "");
            // read from grid the data of the image to delete
            currentImage = (SchoolGrades.BusinessObjects.Image)dgwLessonsImages.SelectedItem;
            MessageBoxResult r = MessageBox.Show(" (Sì) Cancella anche il FILE dell'immagine '" + currentImage.Caption + "';" +
                "\n (No) Cancella il solo collegamento a questa lezione; " +
                "\n (Annulla) Non cancella nulla.",
                "Cancellazione Immagine", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                Commons.bl.RemoveImageFromLesson(currentLesson, currentImage, true);
            }
            else if (r == MessageBoxResult.No)
                Commons.bl.RemoveImageFromLesson(currentLesson, currentImage, false);
            else
                return;

            if (currentIndexInImages > 0)
                currentIndexInImages = oldIndex - 1;
            try
            {
                currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[currentIndexInImages];
            }
            catch { }
            loadCurrentImage();
            refreshUi(currentIndexInImages);
        }
        private void btnSubFolderStorage_Click(object sender, EventArgs e)
        {
            OpenFolderDialog dialog = new();
            dialog.Multiselect = false;
            dialog.Title = "Scegli una cartella";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {   // recupera la path completa della cartella selezionata dall'utente
                string fullPathToFolder = dialog.FolderName;
                // prende solo il nome della cartella selezionata, senza il resto della Path 
                string folderNameOnly = dialog.SafeFolderName;
                string subPath = dialog.FolderName;
                subPath = subPath.Remove(0, Commons.PathImages.Length + 1);
                txtSubFolderStorage.Text = subPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgwLessonsImages.SelectedItems != null)
            {
                try
                {
                    int localIndex = dgwLessonsImages.SelectedIndex = 0;
                    currentImage.Caption = txtCaption.Text;
                    if (imageChanged)
                    {
                        string currentFile = Path.Combine(txtPathImportImage.Text, txtFileImportImage.Text);
                        currentImage.RelativePathAndFilename = currentFile.Remove(0, Commons.PathImages.Length + 1);
                    }
                    Commons.bl.SaveImage(currentImage);
                    imageChanged = false;
                    currentIndexInImages = localIndex;
                    refreshUi(currentIndexInImages);
                    currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[localIndex];
                    loadCurrentImage();
                    //txtCaption.Text = currentImage.Caption;
                    //DgwLessonsImages.Items[localIndex].Selected = false;
                    //DgwLessonsImages.Items[localIndex].Selected = true;                    
                }
                catch (Exception ex)
                {
                    Console.Beep();
                }
            }
        }
        private void picImage_Click(object sender, EventArgs e)
        {

        }
        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(Path.Combine(Commons.PathImages,
                currentImage.RelativePathAndFilename));
        }
        private void rdbAutoRename_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)rdbAutoRename.IsChecked)
            {
                lblSubFolderStorage.Visibility = Visibility.Visible;
                txtSubFolderStorage.Visibility = Visibility.Visible;
                btnSubFolderStorage.Visibility = Visibility.Visible;
                chkMantainOldFileName.Visibility = Visibility.Visible;
                //////////this.Size = new System.Drawing.Size(1240, 768);
                txtSubFolderStorage.Text = lessonImagesPath;
            }
        }
        private void rdbManualRename_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)rdbManualRename.IsChecked)
            {
                lblSubFolderStorage.Visibility = Visibility.Hidden;
                txtSubFolderStorage.Visibility = Visibility.Hidden;
                btnSubFolderStorage.Visibility = Visibility.Hidden;
                chkMantainOldFileName.Visibility = Visibility.Hidden;
                //////////this.Size = new System.Drawing.Size(724, 768);
            }
        }
        private void txtSubFolderStorage_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSubFolderStorage_DoubleClick(object sender, EventArgs e)
        {
            string directory = Path.Combine(Commons.PathImages, txtSubFolderStorage.Text);
            if (txtSubFolderStorage.Text != "" && Directory.Exists(directory))
                Commons.ProcessStartLink(directory);
            else
                Console.Beep();
        }
        private void refreshUi(int IndexInImages)
        {
            // refresh images in grid
            List<SchoolGrades.BusinessObjects.Image> l = Commons.bl.GetListLessonsImages(currentLesson);
            dgwLessonsImages.ItemsSource = l;
            if (l.Count > 0)
            {
                try
                {
                    dgwLessonsImages.SelectedIndex = IndexInImages;
                }
                catch
                {

                }
            }
            else
            {
                CommonsWpf.loadPicture(picImage, "");
                txtCaption.Text = "";
            }
            txtFileImportImage.Text = "";
        }
        private void frmImages_KeyDown(object sender, KeyEventArgs e)
        {
            ////////////////DataGrid grid = (DataGrid)sender;
            ////////////////int RowIndex = grid.SelectedIndex;
            ////////////////if (RowIndex > -1)
            //////{
            //////    //////////{
            //////    //////////    this.WindowState = FormWindowState.Normal;
            //////    //////////    this.TopMost = false;
            //////    //////////    this.FormBorderStyle = FormBorderStyle.Sizable;
            //////    //////////}
            //////    ///}
            //////}
        }
        private void previousImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedItem = null;
                if (currentIndexInImages == 0)
                    currentIndexInImages = listImages.Count;
                currentIndexInImages--;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[currentIndexInImages];
                loadCurrentImage();
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
            }
        }
        private void nextImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
                currentIndexInImages = ++currentIndexInImages % listImages.Count;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[currentIndexInImages];
                loadCurrentImage();
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
            }
        }
        private void lastImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
                currentIndexInImages = listImages.Count - 1;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[currentIndexInImages];
                loadCurrentImage();
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
            }
        }
        private void firstImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
                currentIndexInImages = 0;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[currentIndexInImages];
                loadCurrentImage();
                dgwLessonsImages.SelectedIndex = currentIndexInImages;
            }
        }
        private void grpPeriodOfQuestionsTopics_Enter(object sender, EventArgs e) { }
        private void dgwLessonsImages_CellContentClick(object sender, RoutedEvent e) { }
        private void dgwLessonsImages_CellClick(object sender, RoutedEvent e)
        {
            //DataGrid grid = (DataGrid)sender;
            //int RowIndex = grid.SelectedIndex;
            //if (RowIndex > -1)
            //{
            //    //{
            //    //    DgwLessonsImages.Items[RowIndex].Selected = true;
            //    //    currentIndexInImages = RowIndex;
            //    //    currentImage = ((List<DbClasses.Image>)DgwLessonsImages.ItemsSource)[RowIndex];
            //    //    LoadImage();
            //    //}
            //}
        }
        private void dgwLessonsImages_RowEnter(object sender, RoutedEvent e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                {
                    dgwLessonsImages.SelectedIndex = RowIndex;
                    currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[RowIndex];
                    currentIndexInImages = RowIndex;
                    loadCurrentImage();
                }
            }
        }
        private void dgwLessonsImages_CellDoubleClick(object sender, RoutedEvent e)
        {
            string RelativePath = System.IO.Path.GetDirectoryName(currentImage.RelativePathAndFilename);
            Commons.ProcessStartLink(System.IO.Path.Combine(Commons.PathImages, RelativePath));
        }
        private void btnNextImage_Click(object sender, EventArgs e)
        {
            nextImage();
        }
        private void btnPreviousImage_Click(object sender, EventArgs e)
        {
            previousImage();
        }
        private void btnFirstImage_Click(object sender, EventArgs e)
        {
            firstImage();
        }
        private void btnLastImage_Click(object sender, EventArgs e)
        {
            lastImage();
        }
    }
}

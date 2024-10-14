using Microsoft.Win32;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.Forms.MessageBox;
using WpfColor = System.Windows.Media.Color;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Interaction logic for frmImages.xaml
    /// </summary>
    public partial class frmImages : Window
    {
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
            // TODO: the following path should be better. Fix the program to Re-use this path (should also change old paths)
            //////lessonImagesPath = Path.Combine(currentClass.SchoolYear,
            //////    currentClass.Abbreviation, "Lessons",
            //////    currentLesson.IdSchoolSubject);
        }
        private void frmImages_Load(object sender, RoutedEventArgs e)
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
                //picImage.Location = new System.Drawing.Point(0, 0);
                //picImage.Size = this.Size;
                //currentImage = listImages[0];
                //loadCurrentImage();
                picImage.Margin = new Thickness(0, 0, 0, 0);
                picImage.Width = this.ActualWidth;
                picImage.Height = this.ActualHeight;
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
                WpfColor BackColor = Commons.ColorFromNumber(currentSubject.Color);
                SolidColorBrush br = new SolidColorBrush(WpfColor.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
                this.Background = br;
                rdbAutoRename_CheckedChanged(null, null);
            }
        }
        private void loadCurrentImage()
        {
            try
            {
                string imagePath = Path.Combine(Commons.PathImages, currentImage.RelativePathAndFilename);
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                picImage.Source = bitmap;
                txtCaption.Text = currentImage.Caption;
            }
            catch
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void txtPathImportImage_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPathImportImage_DoubleClick(object sender, EventArgs e)
        {
            if (txtPathImportImage.Text != "")
                Commons.ProcessStartLink(txtPathImportImage.Text);
        }
        //private void btnPathImportImage_Click(object sender, EventArgs e)
        //{
        //    folderBrowserDialog1.SelectedPath = txtPathImportImage.Text;
        //    DialogResult r = folderBrowserDialog1.ShowDialog();
        //    if (r == System.Windows.Forms.DialogResult.OK)
        //    {
        //        txtPathImportImage.Text = folderBrowserDialog1.SelectedPath;
        //    }
        //}
        private void btnPathImportImage_Click(object sender, RoutedEventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = txtPathImportImage.Text;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    txtPathImportImage.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
        private void btnChooseFileImage_Click(object sender, EventArgs e)
        {
            //openFileDialog1.FileName = "";
            //openFileDialog1.InitialDirectory = txtPathImportImage.Text;
            //DialogResult r = openFileDialog1.ShowDialog();
            //if (r == System.Windows.Forms.DialogResult.OK)
            //{
            //    txtFileImportImage.Text = Path.GetFileName(openFileDialog1.FileName);
            //    txtPathImportImage.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            //}
            //if (openFileDialog1.FileName != "")
            //{
            //    try
            //    {
            //        string imagePath = Path.Combine(Commons.PathImages, openFileDialog1.FileName);
            //        BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
            //        picImage.Source = bitmap;
            //        //picImage.Load(openFileDialog1.FileName);
            //        List<string> captions = Commons.bl.GetCaptionsOfThisImage(txtFileImportImage.Text);
            //        if (captions.Count > 0)
            //            // this SHOULD take the last caption that this image has had
            //            // (but if it doesn't it doesn't matter much)
            //            txtCaption.Text = captions[captions.Count - 1];
            //        else
            //            txtCaption.Text = "";
            //        string currentImage = Path.Combine(txtPathImportImage.Text, txtFileImportImage.Text);
            //        if (currentImage != oldImage)
            //        {
            //            imageChanged = true;
            //        }
            //        oldImage = currentImage;
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show("Immagine non caricata.\nFormato non supportato?");
            //    }
            //}
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = txtPathImportImage.Text;
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                txtFileImportImage.Text = Path.GetFileName(openFileDialog.FileName);
                txtPathImportImage.Text = Path.GetDirectoryName(openFileDialog.FileName);
            }
            if (openFileDialog.FileName != "")
            {
                try
                {
                    string imagePath = Path.Combine(Commons.PathImages, openFileDialog.FileName);
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    picImage.Source = bitmap;
                    //picImage.Load(openFileDialog1.FileName);
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
                        currentLesson, currentClass, currentImage, 
                        (bool)rdbAutoRename.IsChecked, (bool)chkMantainOldFileName.IsChecked);
                    try
                    {
                        string imagePath = Path.Combine(Commons.PathImages, sourcePathAndFileName);
                        BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                        picImage.Source = bitmap;
                    }
                    catch
                    {
                        Console.Beep();
                    };
                    // goto the last in the grid (the one just added) 
                    List<Image> l = ((List<Image>)(dgwLessonsImages.ItemsSource));
                    currentIndexInImages = l.Count;
                    if (currentIndexInImages < 0)
                        currentIndexInImages = 0;
                    refreshUi(currentIndexInImages);
                    // load data from the last 
                    currentImage = l[l.Count - 1];
                    loadCurrentImage();
                }
                else
                {   // save a document 

                }
            }
        }
        private void btnRemoveImage_Click(object sender, RoutedEventArgs e)
        {
            ////////////// values before 
            ////////////int oldIndex = currentIndexInImages;
            ////////////if (dgwLessonsImages.SelectedItems.Count == 0)
            ////////////{
            ////////////    MessageBox.Show("Selezionare nella griglia un'immagine da cancellare");
            ////////////    return;
            ////////////}
            ////////////picImage.Source = null;
            ////////////// read from grid the data of the image to delete
            ////////////currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[dgwLessonsImages.SelectedIndex];
            //////////////MessageBoxResult r = MessageBox.Show(" (Sì) Cancella anche il FILE dell'immagine '" + currentImage.Caption + "';" +
            //////////////    "\n (No) Cancella il solo collegamento a questa lezione; " +
            //////////////    "\n (Annulla) Non cancella nulla.",
            //////////////    "Cancellazione Immagine",
            //////////////    MessageBoxButton.YesNoCancel, MessageBoxImage.Question,
            //////////////currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[dgwLessonsImages.SelectedIndex];
            ////////////DialogResult r = MessageBox.Show(" (Sì) Cancella anche il FILE dell'immagine '" + currentImage.Caption + "';" +
            ////////////    "\n (No) Cancella il solo collegamento a questa lezione; " +
            ////////////    "\n (Annulla) Non cancella nulla.",
            ////////////    "Cancellazione Immagine",
            ////////////    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
            ////////////    MessageBoxDefaultButton.Button2);
            ////////////if (r == DialogResult.)
            ////////////{
            ////////////    Commons.bl.RemoveImageFromLesson(currentLesson, currentImage, true);
            ////////////}
            ////////////else if (r == MessageBoxResult.No)
            ////////////    Commons.bl.RemoveImageFromLesson(currentLesson, currentImage, false);
            ////////////else
            ////////////    return;

            ////////////if (currentIndexInImages > 0)
            ////////////    currentIndexInImages = oldIndex - 1;
            ////////////try
            ////////////{
            ////////////    currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[currentIndexInImages];
            ////////////}
            ////////////catch { }
            ////////////loadCurrentImage();
            ////////////refreshUi(currentIndexInImages);
        }
        private void btnSubFolderStorage_Click(object sender, RoutedEventArgs e)
        {
            using (var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = Path.Combine(Path.Combine(Commons.PathImages, txtSubFolderStorage.Text));
                System.Windows.Forms.DialogResult r = folderBrowserDialog.ShowDialog();
                if (r == System.Windows.Forms.DialogResult.OK)
                {
                    string subPath = folderBrowserDialog.SelectedPath;
                    subPath = subPath.Remove(0, Commons.PathImages.Length + 1);
                    txtSubFolderStorage.Text = subPath;
                }
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgwLessonsImages.SelectedItems != null)
            {
                try
                {
                    int localIndex = dgwLessonsImages.SelectedIndex;
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
                    //DgwLessonsImages.Rows[localIndex].Selected = false;
                    //DgwLessonsImages.Rows[localIndex].Selected = true;                    
                }
                catch (Exception ex)
                {
                    Console.Beep();
                }
            }
        }
        private void picImage_Click(object sender, RoutedEventArgs e)
        {

        }
        private void picImage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Commons.ProcessStartLink(Path.Combine(Commons.PathImages,
                currentImage.RelativePathAndFilename));
        }
        private void rdbAutoRename_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbAutoRename.IsChecked == true)
            {
                lblSubFolderStorage.Visibility = Visibility.Visible;
                txtSubFolderStorage.Visibility = Visibility.Visible;
                btnSubFolderStorage.Visibility = Visibility.Visible;
                chkMantainOldFileName.Visibility = Visibility.Visible;
                this.Width = 1240;
                this.Height = 768;
                txtSubFolderStorage.Text = lessonImagesPath;
            }
        }
        private void rdbManualRename_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbManualRename.IsChecked == true)
            {
                lblSubFolderStorage.Visibility = Visibility.Hidden;
                txtSubFolderStorage.Visibility = Visibility.Hidden;
                btnSubFolderStorage.Visibility = Visibility.Hidden;
                chkMantainOldFileName.Visibility = Visibility.Hidden;
                this.Width = 724;
                this.Height = 768;
            }
        }
        private void txtSubFolderStorage_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void txtSubFolderStorage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                picImage.Source = null;
                txtCaption.Text = "";
            }
            txtFileImportImage.Text = "";
        }
        private void previousImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = (currentIndexInImages == 0) ? listImages.Count - 1 : currentIndexInImages - 1;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[dgwLessonsImages.SelectedIndex];
                loadCurrentImage();
            }
        }
        private void nextImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = (currentIndexInImages + 1) % listImages.Count;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[dgwLessonsImages.SelectedIndex];
                loadCurrentImage();
            }
        }
        private void lastImage()
        {
            if (listImages.Count > 0)
            {
                dgwLessonsImages.SelectedIndex = listImages.Count - 1;
                currentImage = (SchoolGrades.BusinessObjects.Image)listImages[dgwLessonsImages.SelectedIndex];
                loadCurrentImage();
            }
        }
        private void firstImage()
        {
            if (listImages.Count > 0)
                if (listImages.Count > 0)
                {
                    //dgwLessonsImages.Rows[currentIndexInImages].Selected = false;
                    currentIndexInImages = 0;
                    currentImage = (SchoolGrades.BusinessObjects.Image)listImages[currentIndexInImages];
                    loadCurrentImage();
                    //dgwLessonsImages.Rows[currentIndexInImages].Selected = true;
                }
        }
        private void grpPeriodOfQuestionsTopics_Enter(object sender, EventArgs e) { }
        //private void dgwLessonsImages_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        //dgwLessonsImages.Rows[e.RowIndex].Selected = true;
        //        currentImage = ((List<SchoolGrades.BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[e.RowIndex];
        //        currentIndexInImages = e.RowIndex;
        //        loadCurrentImage();
        //    }
        //}
        //private void dgwLessonsImages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string RelativePath = Path.GetDirectoryName(currentImage.RelativePathAndFilename);
        //    Commons.ProcessStartLink(Path.Combine(Commons.PathImages, RelativePath));
        //}
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
        private void picImage_DoubleClick(object sender, MouseButtonEventArgs e)
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
                ////////this.Size = new System.Drawing.Size(1240, 768);
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
                ////////this.Size = new System.Drawing.Size(724, 768);
            }
        }
        //private void txtSubFolderStorage_TextChanged(object sender, EventArgs e)
        //{

        //}
        private void txtSubFolderStorage_DoubleClick(object sender, EventArgs e)
        {
            string directory = Path.Combine(Commons.PathImages, txtSubFolderStorage.Text);
            if (txtSubFolderStorage.Text != "" && Directory.Exists(directory))
                Commons.ProcessStartLink(directory);
            else
                Console.Beep();
        }
        //private void frmImages_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //        this.TopMost = false;
        //        this.FormBorderStyle = FormBorderStyle.Sizable;
        //    }
        //}
        //private void previousImage()
        //{
        //    if (listImages.Count > 0)
        //    {
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = false;
        //        if (currentIndexInImages == 0)
        //            currentIndexInImages = listImages.Count;
        //        currentIndexInImages--;
        //        currentImage = (BusinessObjects.Image)listImages[currentIndexInImages];
        //        loadCurrentImage();
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = true;
        //    }
        //}
        //private void nextImage()
        //{
        //    if (listImages.Count > 0)
        //    {
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = false;
        //        currentIndexInImages = ++currentIndexInImages % listImages.Count;
        //        currentImage = (BusinessObjects.Image)listImages[currentIndexInImages];
        //        loadCurrentImage();
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = true;
        //    }
        //}
        //private void lastImage()
        //{
        //    if (listImages.Count > 0)
        //    {
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = false;
        //        currentIndexInImages = listImages.Count - 1;
        //        currentImage = (BusinessObjects.Image)listImages[currentIndexInImages];
        //        loadCurrentImage();
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = true;
        //    }
        //}
        //private void firstImage()
        //{
        //    if (listImages.Count > 0)
        //    {
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = false;
        //        currentIndexInImages = 0;
        //        currentImage = (BusinessObjects.Image)listImages[currentIndexInImages];
        //        loadCurrentImage();
        //        dgwLessonsImages.Rows[currentIndexInImages].Selected = true;
        //    }
        //}
        //private void grpPeriodOfQuestionsTopics_Enter(object sender, EventArgs e) { }
        private void dgwLessonsImages_CellClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            int RowIndex = grid.SelectedIndex;
            if (RowIndex > -1)
            {
                List<Image> l = ((List<Image>)(dgwLessonsImages.ItemsSource));
                //DgwLessonsImages.Rows[e.RowIndex].Selected = true;
                currentIndexInImages = RowIndex;
                currentImage = (Image)l[RowIndex];
            }
            refreshUi(currentIndexInImages);
        }
        private void dgwLessonsImages_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    dgwLessonsImages.Rows[e.RowIndex].Selected = true;
            //    currentImage = ((List<BusinessObjects.Image>)dgwLessonsImages.ItemsSource)[e.RowIndex];
            //    currentIndexInImages = e.RowIndex;
            //    loadCurrentImage();
            //}
        }
        private void dgwLessonsImages_CellDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string RelativePath = Path.GetDirectoryName(currentImage.RelativePathAndFilename);
            Commons.ProcessStartLink(Path.Combine(Commons.PathImages, RelativePath));
        }
        //private void btnNextImage_Click(object sender, EventArgs e)
        //{
        //    nextImage();
        //}
        //private void btnPreviousImage_Click(object sender, EventArgs e)
        //{
        //    previousImage();
        //}
        //private void btnFirstImage_Click(object sender, EventArgs e)
        //{
        //    firstImage();
        //}
        //private void btnLastImage_Click(object sender, EventArgs e)
        //{
        //    lastImage();
        //}
    }
}

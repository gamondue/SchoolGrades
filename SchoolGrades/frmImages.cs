using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmImages : Form
    {
        // TODO avoid to copy the files when they are already into 
        // the images folder. In that case just link the lesson to the file 

        // TODO manage an order of the images of the lesson (database and code) 

        // TODO complete management of the images (modifications, deletion) 

        List<DbClasses.Image> listImages;
        private Lesson currentLesson;
        private Class currentClass;
        private DbClasses.Image currentImage; 
        private SchoolSubject currentSubject;
        DbAndBusiness db; 

        ImagesFormType type;
        private string lessonImagesPath;
        private int indexImages;

        public enum ImagesFormType
        {
            NormalManagement,
            ShowImage,
        }

        public frmImages(ImagesFormType Type, Lesson Lesson, Class Class, 
            List<SchoolGrades.DbClasses.Image> Images, SchoolSubject Subject)
        {
            InitializeComponent();
            db = new DbAndBusiness(Commons.PathAndFileDatabase);

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

            DgwLessonsImages.DataSource = listImages;

            if (type == ImagesFormType.ShowImage)
            {
                picImage.Location = new System.Drawing.Point(0, 0);
                picImage.Size = this.Size;
                currentImage = listImages[0];
                LoadImage();
                //picImage.Load(Commons.PathImages + "\\"+ listImages[0].RelativePathAndFilename);
            }
            else if (type == ImagesFormType.NormalManagement)
            {
                DgwLessonsImages.DataSource = listImages;
            }
            if (listImages.Count > 0)
            {
                currentImage = listImages[0];
                LoadImage();
            }
            else
            {
                currentImage = new DbClasses.Image();
            }

            if (currentSubject != null)
            {
                int col = (int)currentSubject.Color;
                this.BackColor = Commons.ColorFromNumber(currentSubject);
                rdbAutoRename_CheckedChanged(null, null);
            }
        }


        private void LoadImage()
        {
            try
            {
                picImage.Load(Commons.PathImages + "\\" + currentImage.RelativePathAndFilename);
            }
            catch {
                Console.Beep(); 
            }; 
            //db.GetLessonsImages(currentLesson);
            //txtCaption.Text = currentImage.Caption; 
        }

        private void txtPathImportImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPathImportImage_DoubleClick(object sender, EventArgs e)
        {
            if(txtPathImportImage.Text != "")
                Commons.ProcessStartLink(txtPathImportImage.Text);

        }

        private void btnPathImportImage_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPathImportImage.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtPathImportImage.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnChooseFileImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ""; 
            openFileDialog1.InitialDirectory = txtPathImportImage.Text;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                txtFileImportImage.Text = Path.GetFileName(openFileDialog1.FileName);
                txtPathImportImage.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
            if (openFileDialog1.FileName != "")
            {
                try
                {
                    picImage.Load(openFileDialog1.FileName);
                    List<string> captions = db.GetCaptionsOfThisImage(txtFileImportImage.Text);
                    if (captions.Count > 0)
                        txtCaption.Text = captions[captions.Count - 1];
                    else
                        txtCaption.Text = "";
                }
                catch
                {
                    MessageBox.Show("Immagine non caricata.\nFormato non supportato?"); 
                }
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (txtFileImportImage.Text != "")
            {
                string caption = txtCaption.Text;
                string sourcePathAndFileName = txtPathImportImage.Text + "\\" +
                    txtFileImportImage.Text;
                // if the chosen file is already in the image path, the program
                // will avoid copying it under the image path and will link to the 
                // existing file instead 
                if (txtPathImportImage.Text.Contains(Commons.PathImages))
                {
                    // chosen file is inside the images path 
                    // does not copy and rename the file
                    // this spares HDD space on teachers' machine 
                    justLinkFileToLesson(sourcePathAndFileName);
                }
                else
                {
                    // chosen file is outside the images path 
                    copyFileToImagesAndLinkToLessons(sourcePathAndFileName);
                }
                // goto the last (the one just added) 
                indexImages = DgwLessonsImages.Rows.Count - 1;
                try
                {
                    picImage.Load(sourcePathAndFileName);
                }
                catch
                {
                    Console.Beep();
                };
                DgwLessonsImages.Rows[indexImages].Selected = false;
                DgwLessonsImages.Rows[indexImages].Selected = true;
                txtCaption.Text = caption;
            }
        }

        private void justLinkFileToLesson(string sourcePathAndFileName)
        {
            DbClasses.Image currentImage = db.FindImageWithGivenFile(sourcePathAndFileName);
            // if the image that reference to the file isn't anymore in the database 
            // create a new image that references to this file 
            // (eg. if the lesson has been deleted from the database together with its images, but 
            // the file is (somehow) still there) 
            if (currentImage == null)
            {
                currentImage = new DbClasses.Image();
                currentImage.IdImage = 0;
                currentImage.RelativePathAndFilename = sourcePathAndFileName.Remove(0,Commons.PathImages.Length + 1);
                currentImage.Caption = txtCaption.Text; 
            }
            else
            {
                LoadImage(); 
            }
            db.LinkOneImage(currentImage, currentLesson);
            // refresh images in grid
            DgwLessonsImages.DataSource = db.GetLessonsImagesList(currentLesson);
        }

        private void copyFileToImagesAndLinkToLessons(string sourcePathAndFileName)
        {
            string ext = Path.GetExtension(sourcePathAndFileName);
            if (rdbAutoRename.Checked)
                lessonImagesPath = txtSubFolderStorage.Text + "\\"; // + currentLesson.IdSchoolSubject;
            string destinationFileName = "";
            string destinationPathAndFileName = "";

            if (rdbAutoRename.Checked)
            {
                string tempFileName;
                if (chkMantainOldFileName.Checked)
                    tempFileName = ((DateTime)currentLesson.Date).ToString("yyyy-MM-dd") + "_" +
                        currentLesson.IdSchoolSubject + "-xggR" +
                        "_" + txtFileImportImage.Text;
                else
                {
                    tempFileName = ((DateTime)currentLesson.Date).ToString("yyyy-MM-dd") + "_L_" +
                    currentClass.Abbreviation + currentClass.SchoolYear +
                    currentLesson.IdSchoolSubject + "-xggR";
                    tempFileName += ext;
                }
                int i = 1;
                do
                {
                    destinationPathAndFileName = Commons.PathImages + "\\" +
                        lessonImagesPath + 
                        tempFileName.Replace("xggR", (i++).ToString("00"));
                } while (File.Exists(destinationPathAndFileName));
                destinationFileName = tempFileName.Replace("xggR", (--i).ToString("00"));
                currentImage.RelativePathAndFilename = lessonImagesPath +  destinationFileName;
            }
            else if (rdbManualRename.Checked)
            {
                destinationFileName = txtFileImportImage.Text;
                destinationPathAndFileName = Commons.PathImages + "\\" +
                    lessonImagesPath +  destinationFileName;
                if (File.Exists(destinationPathAndFileName))
                {
                    MessageBox.Show("Il file " + destinationPathAndFileName + " esiste già.");
                    return;
                }
                currentImage.RelativePathAndFilename = lessonImagesPath +  destinationFileName;
            }

            if (!File.Exists(sourcePathAndFileName))
            {
                MessageBox.Show("Il file " + sourcePathAndFileName + " non esiste!");
                return;
            }
            // if it doesn't exist, create the folder of the images of the lessons of the class
            if (!Directory.Exists(Commons.PathImages + "\\" + lessonImagesPath))
            {
                Directory.CreateDirectory(Commons.PathImages + "\\" + lessonImagesPath);
            }
            File.Copy(sourcePathAndFileName, destinationPathAndFileName);
            //currentImage.IdImage = int.MaxValue; 
            currentImage.Caption = txtCaption.Text;
            currentImage.IdImage = 0; // to force creation of a new record
            db.LinkOneImage(currentImage, currentLesson);
            // refresh images in grid
            DgwLessonsImages.DataSource = db.GetLessonsImagesList(currentLesson);
        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            Commons.ProcessStartLink(Commons.PathImages + "\\" + 
                currentImage.RelativePathAndFilename);
        }

        private void rdbAutoRename_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAutoRename.Checked)
            {
                lblSubFolderStorage.Visible = true;
                txtSubFolderStorage.Visible = true;
                btnSubFolderStorage.Visible = true;
                chkMantainOldFileName.Visible = true;
                this.Size = new System.Drawing.Size(1240, 768);
                txtSubFolderStorage.Text = lessonImagesPath;
            }
        }

        private void rdbManualRename_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManualRename.Checked)
            {
                lblSubFolderStorage.Visible = false;
                txtSubFolderStorage.Visible = false;
                btnSubFolderStorage.Visible = false;
                chkMantainOldFileName.Visible = false;
                this.Size = new System.Drawing.Size(724, 768);
            }
        }

        private void txtSubFolderStorage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubFolderStorage_DoubleClick(object sender, EventArgs e)
        {
            string directory = Commons.PathImages + "\\" + txtSubFolderStorage.Text;
            if (txtSubFolderStorage.Text != "" && Directory.Exists(directory))
                Commons.ProcessStartLink(directory);
            else
                Console.Beep(); 
        }

        private void btnSubFolderStorage_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Commons.PathImages + "\\" + txtSubFolderStorage.Text;
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                string subPath = folderBrowserDialog1.SelectedPath;
                subPath = subPath.Remove(0, Commons.PathImages.Length + 1); 
                txtSubFolderStorage.Text = subPath;
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (DgwLessonsImages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare nella griglia un'immagine da cancellare");
                return;
            }
            picImage.Image=null; 

            currentImage = ((List<DbClasses.Image>)DgwLessonsImages.DataSource)[DgwLessonsImages.SelectedRows[0].Index];
            if (MessageBox.Show("Vuole cancellare il file dell'immagine (Sì) o solo il collegamento a questa lezione (No)?",
                "Cancellazione Immagine", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                db.RemoveImageFromLesson(currentLesson, currentImage, true);
            }
            else
                db.RemoveImageFromLesson(currentLesson, currentImage, false);
            DgwLessonsImages.DataSource = db.GetLessonsImagesList(currentLesson);
            try
            {
                currentImage = ((List<DbClasses.Image>)DgwLessonsImages.DataSource)[0];
            }catch { }
            LoadImage(); 
        }

        private void frmImages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Normal;
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int localIndex = DgwLessonsImages.SelectedRows[0].Index;
            currentImage.Caption = txtCaption.Text;
            db.SaveImage(currentImage);
            // refresh images in grid
            DgwLessonsImages.DataSource = db.GetLessonsImagesList(currentLesson);
            indexImages = localIndex;
            currentImage = ((List<DbClasses.Image>)DgwLessonsImages.DataSource)[localIndex];
            LoadImage();
            txtCaption.Text = currentImage.Caption; 
            DgwLessonsImages.Rows[localIndex].Selected = false;
            DgwLessonsImages.Rows[localIndex].Selected = true;
        }
        private void PreviousImage()
        {
            if (listImages.Count > 0)
            {
                DgwLessonsImages.Rows[indexImages].Selected = false;
                if (indexImages == 0)
                    indexImages = listImages.Count;
                indexImages--;
                currentImage = (DbClasses.Image)listImages[indexImages];
                LoadImage();
                DgwLessonsImages.Rows[indexImages].Selected = true;
            }
        }

        private void NextImage()
        {
            if (listImages.Count > 0)
            {
                DgwLessonsImages.Rows[indexImages].Selected = false;
                indexImages = ++indexImages % listImages.Count;
                currentImage = (DbClasses.Image)listImages[indexImages];
                LoadImage();
                DgwLessonsImages.Rows[indexImages].Selected = true;
            }
        }

        private void LastImage()
        {
            if (listImages.Count > 0)
            {
                DgwLessonsImages.Rows[indexImages].Selected = false;
                indexImages = listImages.Count - 1;
                currentImage = (DbClasses.Image)listImages[indexImages];
                LoadImage();
                DgwLessonsImages.Rows[indexImages].Selected = true;
            }
        }
        private void FirstImage()
        {
            if (listImages.Count > 0)
            {
                DgwLessonsImages.Rows[indexImages].Selected = false;
                indexImages = 0;
                currentImage = (DbClasses.Image)listImages[indexImages];
                LoadImage();
                DgwLessonsImages.Rows[indexImages].Selected = true;
            }
        }
        
        private void grpPeriodOfQuestionsTopics_Enter(object sender, EventArgs e)
        {

        }

        private void DgwLessonsImages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwLessonsImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //DgwLessonsImages.Rows[e.RowIndex].Selected = true;
                //currentImage = ((List<DbClasses.Image>)DgwLessonsImages.DataSource)[e.RowIndex];
                //LoadImage();
                //txtCaption.Text = currentImage.Caption;
                ////indexImages = e.RowIndex;
            }
        }

        private void DgwLessonsImages_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DgwLessonsImages.Rows[e.RowIndex].Selected = true;
            currentImage = ((List<DbClasses.Image>)DgwLessonsImages.DataSource)[e.RowIndex];
            LoadImage();
            txtCaption.Text = currentImage.Caption;
            //indexImages = e.RowIndex;
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            NextImage(); 
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            PreviousImage(); 
        }

        private void BtnFirstImage_Click(object sender, EventArgs e)
        {
            FirstImage();
        }

        private void BtnLastImage_Click(object sender, EventArgs e)
        {
            LastImage(); 
        }
    }
}

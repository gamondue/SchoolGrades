using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolGrades
{
    public partial class frmMosaic : Form
    {
        Class currentClass; 
        List<Student> currentStudents;
        List<PictureBox> currentPictures = new List<PictureBox>(); 

        public frmMosaic(SchoolGrades.BusinessObjects.Class Class)
        {
            InitializeComponent();

            currentClass = Class;
            currentStudents = Commons.bl.GetStudentsOfClassList(Commons.IdSchool,
                currentClass.SchoolYear, currentClass.Abbreviation, false);
        }

        private void frmMosaic_Load(object sender, EventArgs e)
        {
            // creation of pictures 
            foreach (Student s in currentStudents)
            {
                PictureBox pic =new PictureBox();
                pic.BorderStyle = BorderStyle.FixedSingle; 
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Tag = s.LastName + " " + s.FirstName;

                loadPicture(s, currentClass.SchoolYear, pic); 
                currentPictures.Add(pic); 
                this.Controls.Add(pic); 
            }
            ResizePictures(); 
        }

        private void ResizePictures()
        {
            int xNumPictures = 7;
            int yNumPictures = (int)(Math.Ceiling((double)currentStudents.Count / xNumPictures));
            int xStep = this.ClientRectangle.Width / xNumPictures;
            int yStep =  this.ClientRectangle.Height / yNumPictures;
            int nRow = 0, nCol = 0;
            foreach (PictureBox pic in currentPictures)
            {
                pic.Location = new Point(nCol * xStep, nRow * yStep);
                pic.Size = new Size(xStep, yStep);
                pic.MouseDown += new System.Windows.Forms.MouseEventHandler(pictures_MouseDown);
                pic.MouseUp += new System.Windows.Forms.MouseEventHandler(pictures_MouseUp);
                nCol++;
                if (nCol == xNumPictures)
                {
                    nRow++;
                    nCol = 0;
                }
            }
            this.Refresh();
        }

        private void pictures_MouseUp(object sender, EventArgs e)
        {
            txtStudentsName.Visible = false;
        }

        private void pictures_MouseDown(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender; 
            txtStudentsName.Text = pic.Tag.ToString();
            txtStudentsName.Location = new Point(pic.Location.X, pic.Location.Y + pic.Height / 2); 
            txtStudentsName.Visible = true; 
        }

        private void loadPicture(Student ShowingStudent, string SchoolYear, PictureBox PictureContainer)
        {
            try
            {
                PictureContainer.Image = System.Drawing.Image.FromFile(Commons.PathImages + "\\" +
                    Commons.bl.GetFilePhoto(ShowingStudent.IdStudent, SchoolYear));
            }
            catch
            {
                PictureContainer.Image = null;
                Console.Beep();
            }
        }
        private void frmMosaic_Resize(object sender, EventArgs e)
        {
            ResizePictures(); 
        }
    }
}

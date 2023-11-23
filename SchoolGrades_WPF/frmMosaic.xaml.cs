using System;
using System.Collections.Generic;
using System.Windows;
using SchoolGrades.BusinessObjects;
using SchoolGrades;
using SGImage = SchoolGrades.BusinessObjects.Image;
using WPFImage = System.Windows.Controls.Image;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;

namespace SchoolGrades_WPF
{
    /// <summary>
    /// Logica di interazione per frmMosaic.xaml
    /// </summary>
    public partial class frmMosaic : Window
    {
        Class currentClass;
        List<Student> currentStudents;
        List<WPFImage> currentPictures = new List<WPFImage>();

        public frmMosaic(SchoolGrades.BusinessObjects.Class Class)
        {
            InitializeComponent();

            currentClass = Class;
            currentStudents = Commons.bl.GetStudentsOfClassList(Commons.IdSchool,
                currentClass.SchoolYear, currentClass.Abbreviation, false);

            // with a grid of seven colums, we set the number of rows,
            // given the number of students
            int nGridRows = currentStudents.Count / 7; 
            for (int row = 0; row < nGridRows; row++) {
                PictureGrid.RowDefinitions.Add(new RowDefinition());
            }
            // creation of pictures 
            int i = 0; 
            foreach (Student s in currentStudents)
            {
                WPFImage pic = new WPFImage();
                BitmapImage bitmapImage = new BitmapImage();
                //pic.BorderStyle = BorderStyle.FixedSingle;
                //pic.SizeMode = ImageSizeMode.Zoom;
                pic.Tag = s.LastName + " " + s.FirstName;
                PictureGrid.Children.Add(pic);
                pic.Stretch = System.Windows.Media.Stretch.Uniform; 
                int row = i / 7;
                int column = i % 7;
                Grid.SetRow(pic, row);
                Grid.SetColumn(pic, column);
                loadPicture(s, currentClass.SchoolYear, pic);
                PictureGrid.Children.Add(pic);

                //currentPictures.Add(pic);
                //this.Controls.Add(pic);
                i++; 
            }
            ResizePictures();
        }
        private void ResizePictures()
        {
            //int xNumPictures = 7;
            //int yNumPictures = (int)(Math.Ceiling((double)currentStudents.Count / xNumPictures));
            //int xStep = this.ClientRectangle.Width / xNumPictures;
            //int yStep = this.ClientRectangle.Height / yNumPictures;
            //int nRow = 0, nCol = 0;
            //foreach (WPFImage pic in currentPictures)
            //{
            //    pic.Location = new Point(nCol * xStep, nRow * yStep);
            //    pic.Size = new Size(xStep, yStep);
            //    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(pictures_MouseDown);
            //    pic.MouseUp += new System.Windows.Forms.MouseEventHandler(pictures_MouseUp);
            //    nCol++;
            //    if (nCol == xNumPictures)
            //    {
            //        nRow++;
            //        nCol = 0;
            //    }
            //}
            //this.Refresh();
        }
        private void pictures_MouseUp(object sender, EventArgs e)
        {
            txtStudentsName.Visibility = Visibility.Hidden;
        }
        private void pictures_MouseDown(object sender, EventArgs e)
        {
            WPFImage pic = (WPFImage)sender;
            txtStudentsName.Text = pic.Tag.ToString();
            //txtStudentsName.Location = new Point(pic.Location.X, pic.Location.Y + pic.Height / 2);
            txtStudentsName.Visibility = Visibility.Visible; 
        }
        private void loadPicture(Student ShowingStudent, string SchoolYear, WPFImage PictureContainer)
        {
            try
            {
                Uri fileUri = new Uri(Path.Combine(Commons.PathImages,
                Commons.bl.GetFilePhoto(ShowingStudent.IdStudent, SchoolYear)));
                PictureContainer.Source = new BitmapImage(fileUri);
            }
            catch
            {
                PictureContainer.Source = null;
                Console.Beep();
            }
        }
        private void frmMosaic_Resize(object sender, EventArgs e)
        {
            ResizePictures();
        }
    }
}

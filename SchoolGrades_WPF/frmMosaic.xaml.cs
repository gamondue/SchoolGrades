using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPFImage = System.Windows.Controls.Image;

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
            int nGridRows = currentStudents.Count / 7 + 1;
            int nGridCols = 7;
            // adding the rows in the Grid
            for (int row = 0; row < nGridRows; row++)
            {
                PictureGrid.RowDefinitions.Add(new RowDefinition());
            }
            // creation of pictures 
            int i = 0, rowIndex = 0, columnIndex = 0;
            foreach (Student s in currentStudents)
            {
                rowIndex = i / 7;
                columnIndex = i % 7;
                WPFImage image = null;
                try
                {
                    Uri fileUri = new Uri(Path.Combine(Commons.PathImages,
                    Commons.bl.GetFilePhoto(s.IdStudent, s.SchoolYear)));
                    //image = new WPFImage { Source = imageSource };
                    image = new WPFImage();
                    image.Source = new BitmapImage(fileUri);
                    PictureGrid.Children.Add(image);

                    Grid.SetRow(image, rowIndex);
                    Grid.SetColumn(image, columnIndex);
                }
                catch
                {
                    image = null;
                    Console.Beep();
                }
                i++;
            }
        }
        private void pictures_MouseUp(object sender, RoutedEventArgs e)
        {
            txtStudentsName.Visibility = Visibility.Hidden;
        }
        private void pictures_MouseDown(object sender, RoutedEventArgs e)
        {
            WPFImage pic = (WPFImage)sender;
            txtStudentsName.Text = pic.Tag.ToString();
            //txtStudentsName.Location = new Point(pic.Location.X, pic.Location.Y + pic.Height / 2);
            txtStudentsName.Visibility = Visibility.Visible;
        }
    }
}

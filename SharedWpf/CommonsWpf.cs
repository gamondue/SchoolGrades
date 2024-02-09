using gamon;
using gamon.TreeMptt;
using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rectangle = System.Windows.Shapes.Rectangle;
using WinFormsColor = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

namespace Shared
{
    internal class CommonsWpf
    {
        internal static Rectangle globalPicLed;
        internal static TreeMptt SaveTreeMptt;
        internal static WpfColor ColorNoSubject = Colors.PowderBlue;

        internal static void SaveCurrentValuesOfAllControls(Control ParentControl, ref string PathAndFile)
        {
            //////////string fileContent = "";
            //////////if (ParentControl.Controls.Count > 0)
            //////////{
            //////////    SaveControlsValuesOfLevel(ParentControl, ref fileContent);
            //////////}
            //////////TextFile.StringToFile(PathAndFile, fileContent, false);
        }
        private static void SaveControlsValuesOfLevel(Control ParentControl, ref string NamesAndValues)
        {
            //////////// recursive function! 
            //////////foreach (Control c in ParentControl.Controls)
            //////////{
            //////////    try
            //////////    {
            //////////        // we don't save the values of the types of controls that we don't want to save
            //////////        if (
            //////////            // ADD here specific controls that you don't want to be saved
            //////////            // make THE SAME in RestoreControlsValues()                            
            //////////            c.Name != ""
            //////////            && !(c is Label)
            //////////            && !(c is Button)
            //////////            && !(c is GroupBox)
            //////////            && !(c is Image)
            //////////            && !(c is DataGrid)
            //////////        )
            //////////        {
            //////////            NamesAndValues += c.Name + "\t";
            //////////            if (c is TextBox)
            //////////                NamesAndValues += ((TextBox)c).Text;
            //////////            else if (c is RadioButton)
            //////////                NamesAndValues += ((RadioButton)c).IsChecked.ToString();
            //////////            else if (c is CheckBox)
            //////////                NamesAndValues += ((CheckBox)c).IsChecked.ToString();
            //////////            else
            //////////                ////////////NamesAndValues += c.Text;
            //////////                //if (c is DataGrid)
            //////////                //    SaveTableContent((DataGrid)c);
            //////////                NamesAndValues += "\n";
            //////////        }
            //////////    }
            //////////    catch (Exception ex)
            //////////    {
            //////////        Console.Beep(200, 300);
            //////////    }
            //////////    SaveControlsValuesOfLevel(c, ref NamesAndValues);
            //////////}
        }
        internal static void RestoreCurrentValuesOfAllControls(Control ParentControl, string PathAndFile)
        {
            try
            {
                string[,] NamesAndValues = TextFile.FileToMatrix(PathAndFile, '\t');
                int index = 0;
                //RestoreControlsValuesOfLevel(ParentControl, NamesAndValues, ref index);
                RestoreControlsValuesOfLevel(ParentControl, NamesAndValues);
            }
            catch (Exception ex)
            {
                Console.Beep(200, 300);
            }
        }
        //private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues, ref int Index)
        private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues)
        {
            //////////// recursive function! 
            //////////// !!!! to fix !!!! reads only a few of the controls !!!! 
            //////////foreach (Control c in ParentControl.Controls)
            //////////{
            //////////    for (int Index = 0; Index < NamesAndValues.GetLength(1); Index++)
            //////////    {
            //////////        // we don't restore the values of the types of controls that were not saved
            //////////        if (
            //////////            // ADD here specific controls that you don't want to be saved
            //////////            c.Name != ""
            //////////            && !(c is Label)
            //////////            && !(c is Button)
            //////////            && !(c is GroupBox)
            //////////            && !(c is System.Windows.Controls.Image)
            //////////            && !(c is DataGrid)
            //////////        )
            //////////        {
            //////////            // if the name of the control is different from the one that has been saved,
            //////////            // then the catch statement has fired when saving, so we skip this control
            //////////            // by doing nothing 
            //////////            if (NamesAndValues[Index, 0] != c.Name)
            //////////            {

            //////////            }
            //////////            else
            //////////            {
            //////////                //if (c is DataGrid)
            //////////                //    RestoreTableContent((DataGrid)c);
            //////////                if (c is TextBox)
            //////////                    ((TextBox)c).Text = NamesAndValues[Index, 1];
            //////////                else if (c is RadioButton)
            //////////                    ((RadioButton)c).IsChecked = bool.Parse(NamesAndValues[Index, 1]);
            //////////                else if (c is CheckBox)
            //////////                    ((CheckBox)c).IsChecked = bool.Parse(NamesAndValues[Index, 1]);
            //////////                else
            //////////                ////////////c.Text = NamesAndValues[Index, 1];
            //////////                // if something went wrong 
            //////////                // (e.g. something has changed in the U.I, controls since last execution)
            //////////                // the Index could overflow the matrix
            //////////                if (Index == NamesAndValues.Length)
            //////////                    break; // exits the loop 
            //////////            }
            //////////            // RestoreControlsValuesOfLevel(c, NamesAndValues, ref Index);
            //////////            RestoreControlsValuesOfLevel(c, NamesAndValues);
            //////////        }
            //////////    }
            //////////}
        }
        private static void RestoreTableContent(DataGrid grid)
        {
            //string fileIni = grid.Name + ".ini";
            //DataSet ds = new DataSet("DataSet_" + grid.Name);
            //ds.ReadXml(Comuni.PathFileConfigurazione + fileIni);
            //DataTable dt = ds.Tables[0];
            //grid.ItemsSource = dt;

            ////////string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            ////////DataSet ds = new DataSet("DataSet_" + grid.Name);
            ////////ds.ReadXml(ComuniZ.PathFileConfigurazione + fileIni);
            ////////DataTable dt = ds.Tables[0];

            ////////int j = 0;
            ////////foreach (DataRow riga in dt.Items)
            ////////{
            ////////    grid.Items.Add();
            ////////    for (int i = 0; i < riga.ItemArray.Length; i++)
            ////////    {
            ////////        grid.Items[j].Cells[i].Value = riga.ItemArray[i];
            ////////    }
            ////////    j++;
            ////////}
        }
        private static void SaveTableContent(DataGrid grid)
        {
            //string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            //int j = 0;
            //DataSet ds = new DataSet();
            //// tabella
            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn column in grid.Columns)
            //{
            //    dt.Columns.Add(grid.Items[0].Cells[j].ToString());
            //    j++;
            //}
            //object[] cellValues = new object[grid.Columns.Count];
            //// valori
            //foreach (DataGridRow rigaGrid in grid.Items)
            //{
            //    for (int i = 0; i < rigaGrid.Cells.Count; i++)
            //    {
            //        //dt.Items[j].ItemArray = rigaGrid.Cells[i].Value;
            //        cellValues[i] = rigaGrid.Cells[i].Value;
            //    }
            //    dt.Items.Add(cellValues);
            //}
            //ds.Tables.Add(dt);
            //ds.WriteXml(ComuniZ.PathFileConfigurazione + fileIni);
        }
        internal static bool CheckIfTypeOfAssessmentChosen(GradeType GradeType)
        {
            if (GradeType == null)
            {
                MessageBox.Show("Scegliere un tipo di valutazione", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfSubjectChosen(SchoolSubject SchoolSubject)
        {
            if (SchoolSubject == null)
            //if (cmbSchoolSubject.SelectedItem == null || cmbSchoolSubject.Text == "")
            {
                MessageBox.Show("Scegliere una materia", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfClassChosen(Class CurrentClass)
        {
            // Commons.CurrentClass 
            if (CurrentClass == null)
            {
                MessageBox.Show("Scegliere una classe", "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                MessageBox.Show("Scegliere un allievo"
                    , "Operazione non possibile");
                return false;
            }
            return true;
        }
        internal static void RestoreCurrentValuesOfAllControls(Window window, string file)
        {
            throw new NotImplementedException();
        }
        internal static void SwitchPicLed(bool IsLedLit)
        {
            // lights on or off the Rectangle used as an Activity LED 

            //////////globalPicLed.Invoke(new Action(() =>
            //////////{
            //////////    if (IsLedLit)
            //////////        globalPicLed.Fill = Brushes.Red;           // LED lit
            //////////    else
            //////////        globalPicLed.Fill = Brushes.DarkGray;      // LED off
            //////////}));
        }
        internal static bool ReadConfigData()
        {
            string[] dati = null;
            try
            {
#if DEBUG
                dati = TextFile.FileToArray(Commons.PathAndFileConfig + "_DEBUG");
#else
                dati = TextFile.FileToArray(Commons.PathAndFileConfig);
#endif
                if (dati != null)
                {
                    if (Commons.PathAndFileDatabase == null)
                    {
                        Commons.DatabaseFileName_Current = dati[0];
                        Commons.PathImages = dati[1];
                        // position 2 was held by PathStartLinks 
                        //Commons.PathStartLinks = dati[2]; 
                        Commons.PathDatabase = dati[3];
                        Commons.PathAndFileDatabase = System.IO.Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
                        Commons.PathDocuments = dati[4];
                    }
                    else
                    {
                        Commons.DatabaseFileName_Current = dati[0];
                        Commons.PathImages = dati[1];
                        // position 2 was held by PathStartLinks 
                        //Commons.PathStartLinks = dati[2]; 
                        Commons.PathDatabase = dati[3];
                        Commons.PathAndFileDatabase = System.IO.Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
                        Commons.PathDocuments = dati[4];
                    }
                    // we try the next to avoid stopping the program when we have a new config file, 
                    // with another field will show up. You have to add some data in.config file. 
                    try
                    {
                        Commons.SaveBackupWhenExiting = bool.Parse(dati[5]);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            catch
            {
                // if error do nothing. the rest of the code will generate the default data
                return false;
            }
            return false;
        }
        internal static void WriteConfigData()
        {
            string[] dati = new string[6];
            try
            {
                if (!Directory.Exists(Commons.PathConfig))
                    Directory.CreateDirectory(Commons.PathConfig);
                if (!Directory.Exists(Commons.PathLogs))
                    Directory.CreateDirectory(Commons.PathLogs);
                if (!Directory.Exists(Commons.PathImages))
                    Directory.CreateDirectory(Commons.PathImages);
                //if (!Directory.Exists(Commons.PathStartLinks))
                //    Directory.CreateDirectory(Commons.PathStartLinks);
                if (!Directory.Exists(Commons.PathDatabase))
                    Directory.CreateDirectory(Commons.PathDatabase);
                if (!Directory.Exists(Commons.PathDocuments))
                {
                    if (Commons.PathDocuments != "")
                        Directory.CreateDirectory(Commons.PathDocuments);
                    else
                        Commons.PathDocuments = ".";
                }
                dati[0] = Commons.PathAndFileDatabase;
                dati[1] = Commons.PathImages;
                //dati[2] = Commons.PathStartLinks;
                dati[3] = Commons.PathDatabase;
                dati[4] = Commons.PathDocuments;
                dati[5] = Commons.SaveBackupWhenExiting.ToString();
#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif
                MessageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig);
            }
            catch (Exception e)
            {
                string err = @"[Error in program's directories] \r\n" + e.Message;
                Commons.ErrorLog(err);
                throw new FileNotFoundException(err);
                //return;
            }
        }
        internal static WpfColor ColorFromNumber(int? ColorNumber)
        {
            if (ColorNumber == null || ColorNumber == null)
                return ColorNoSubject;
            // extract the color components from the RGB number
            byte red = (byte)((ColorNumber & 0xFF0000) >> 16);
            byte green = (byte)((ColorNumber & 0xFF00) >> 8);
            byte blue = (byte)(ColorNumber & 0xFF);
            System.Windows.Media.Color bgColor = System.Windows.Media.Color.FromRgb(red, green, blue);
            return bgColor;
        }
        internal static SolidColorBrush BrushFromColor(WpfColor Color)
        {
            return new SolidColorBrush(Color);
        }
        internal static void loadPicture(System.Windows.Controls.Image ImageControl, string PicturePathAndFile)
        {
            try
            {
                var uriSource = new Uri(PicturePathAndFile, UriKind.Absolute);
                ImageControl.Source = new BitmapImage(uriSource);
            }
            catch
            {
                ImageControl.Source = null;
                Console.Beep();
            }
        }
        internal static WinFormsColor WpfToWinFormsColor(WpfColor color) => WinFormsColor.FromArgb(color.A, color.R, color.G, color.B);
        internal static WpfColor WinFormsToWpfColor(WinFormsColor color) => WpfColor.FromArgb(color.A, color.R, color.G, color.B);
        internal static Brush WinFormsToWpfBrush(WinFormsColor winFormsColor)
        {
            return new SolidColorBrush(WinFormsToWpfColor(winFormsColor));
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using gamon;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Drawing;
using SchoolGrades.DbClasses;
using gamon.TreeMptt;
using System.Diagnostics;

namespace SchoolGrades
{
    public static class Commons
    {
        // program's default path and files. Overridden by the config file "schgrd.cfg", when it exists
        public static string PathUser = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static string PathAndFileExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8);
        //public static string PathExe = System.IO.Path.GetDirectoryName(PathAndFileExe);
        public static string PathExe = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName); 


        public static string PathConfig = PathUser + "\\SchoolGrades\\Config";
        public static string PathAndFileConfig = PathConfig + "\\schgrd.cfg";
        public static string CompanyPrefix = "gamon-";
        public static string PathLogs = PathUser + "\\SchoolGrades\\Logs";
        public static string PathAndFileLogText = PathLogs + "\\" + CompanyPrefix + "Errori.txt";

        public static string FileDatabase = "SchoolGrades.sqlite";
        //public static string PathDatabase = PathUser + "\\SchoolGrades\\Data";
        public static string PathDatabase = PathExe + "\\Data";
        public static string PathAndFileDatabase; // read with Commons.ReadConfigFile()! 

        //public static string PathStartLink = PathUser + "\\SchoolGrades\\";
        public static string PathStartLinks = PathExe; 
        //public static string PathImages = PathUser + "\\SchoolGrades\\Images";
        //public static string PathImages = PathExe + "\\SchoolGrades\\Images";
        
        public static string PathImages = PathExe + "\\Images";

        //public static string PathDocuments = PathExe + "\\SchoolGrades\\Docs";
        public static string PathDocuments = PathExe + "\\Docs";

        // wait time before saving 
        //public static int BackgroundThreadSleepSeconds = 20; // 
        //public static int BackgroundThreadSleepSeconds = 60 * 60 * 24; // 1 day: Mpttsaving is effectiveley TEMPORARILY excluded 
        public static int BackgroundThreadSleepSeconds = 5 * 60;
        // enable Mptt backgroud saving of Left anf Right pointers 
        public static bool BackgroundCanStillSaveTopicsTree = true;
        // Tree object for concurrent saving 
        internal static TreeMptt SaveTreeMptt;
        // Thread that concurrently saves the Topics tree
        internal static Thread BackgroundSaveThread; 

        public static bool SaveBackupWhenExiting; 

        public static string IdSchool = "FOIS01100L";

        // variables to remember something between forms (Global) 
        // remember what was the last Topic chosen
        internal static Topic LastTopicChosen;
        // remember which were the last Tags chosen
        internal static List<Tag> LastTagsChosen;

        internal static bool isLogging = true;
        internal static DateTime DateNull = new DateTime(1800,1,1);

        internal static List<Question> QuestionsAlreadyMadeThisTime = new List<Question>();

        private static Color ColorNoSubject = Color.PowderBlue;

        public static bool IsTimerLessonActive { get; internal set; }

        internal static PictureBox globalPicLed;
        internal static void SwitchPicLedOn(bool SetLedLit)
        {
            // lights on or off the PictureBox used as an Activity LED 
            globalPicLed.Invoke(new Action(() =>
            {
                if (SetLedLit)
                    globalPicLed.BackColor = Color.Red;           // LED lit
                else
                    globalPicLed.BackColor = Color.DarkGray;      // LED off
            }));
        }
        internal static string CalculateSHA1(string File)
        {
            try
            {
                byte[] buff = null;
                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(File).Length;
                buff = br.ReadBytes((int)numBytes);

                SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buff)).Replace("-", "");
                buff = null;
                GC.Collect(); // lancia il garbage collector, per liberare subito la memoria usata
                return hash;
            }
            catch (Exception ex)
            {
                return ErrorLog("ERRORE in calcolo SHA1: " + ex.Message, false);
            }
        }
        internal static string ErrorLog(string Error, bool UseMessageBox)
        {
            if (isLogging)
            {
                try
                {
                    // append dell'errore nel file di logging
                    using (StreamWriter sw = File.AppendText(PathAndFileLogText))
                    {
                        sw.WriteLine(DateTime.Now + " " + Error);
                    }
                }
                catch (Exception e)
                {
                    if (e.HResult == -2147024893)
                    {
                        // if directory doesn't exist: make it
                        Directory.CreateDirectory(Path.GetDirectoryName(PathAndFileLogText));
                        // append dell'errore nel file di logging
                        using (StreamWriter sw = File.AppendText(PathAndFileLogText))
                        {
                            sw.WriteLine(DateTime.Now + " " + Error);
                        }
                        return Error;
                    }
                    Console.WriteLine(DateTime.Now + " Errore nella memorizzazione del file di log. \r\n" + e.Message);
                }
            }
            if (UseMessageBox)
            {
                MessageBox.Show(Error, "Errore");
            }
            Console.Beep();

            return Error;
        }
        internal static string ConvertStringToFilename(string SubmittedName, bool SubstituteSpaces)
        {
            string s = SubmittedName;
            s = s.Replace('<', '-');
            s = s.Replace('>', '-');
            s = s.Replace(':', '-');
            s = s.Replace('"', '-');
            s = s.Replace('/', '-');
            s = s.Replace('\\', '-');
            s = s.Replace('|', '-');
            s = s.Replace('?', '-');
            s = s.Replace('*', '-');

            if (SubstituteSpaces)
                s = s.Replace(' ', '-');
            return s;
        }
        internal static DateTime NextWeekSameDay(DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
        internal static void ReadConfigFile()
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
                    Commons.FileDatabase = dati[0];
                    Commons.PathImages = dati[1];
                    Commons.PathStartLinks = dati[2]; // not longer used; left for compatibility of configuration file
                    Commons.PathDatabase = dati[3];
                    Commons.PathAndFileDatabase = Commons.PathDatabase + "\\" + Commons.FileDatabase;
                    Commons.PathDocuments = dati[4];
                    
                    // we try the next to avoid stopping the program whe a new config file, 
                    // with another field will show up. You have to add some data in.config file. 
                    try
                    {
                        Commons.SaveBackupWhenExiting = bool.Parse(dati[5]);
                    }
                    catch { }
                }
            }
            catch
            {
                // if error do nothing. the rest of the code will generate the default data
            }
        }
        public static object CloneObject(object o)
        {
            // from https://stackoverflow.com/questions/4544657/duplicate-group-box
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();

            Object p = t.InvokeMember("", System.Reflection.
                BindingFlags.CreateInstance, null, o, null);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o, null), null);
                }
            }
            return p;
        }
        internal static void ShuffleList(List<Student> List)
        {
            Random r = new Random();
            for (int p = 0; p < List.Count - 1; p++)
            {
                // item to exchange with the first
                int num = r.Next(List.Count - p) + p;
                // exchange
                Student tmp = List[p];
                List[p] = List[num];
                List[num] = tmp;
            }
            // once again
            for (int p = 0; p < List.Count - 1; p++)
            {
                int num = r.Next(List.Count - p) + p;
                Student tmp = List[p];
                List[p] = List[num];
                List[num] = tmp;
            }
        }
        internal static void ShuffleListWithDifferentProbabilities(List<Student> List)
        {
            // shuffles the list with a probability of going in the first place proportional 
            // to the property SortOrDrawCriterion
            Random r = new Random();
            for (int p = 0; p < List.Count - 1; p++)
            {
                // sum all the probalities of the elements of the list that
                // haven't been swapped with the "first" yet
                double sum = sumAllProbabilities(p, List);
                // determine the item to exchange with the first
                // draw a random number less than the sum
                double drawn = r.NextDouble() * sum;
                int num = findIndexOfItemtoSwapWithFirst(drawn, p, List); 
                // exchange
                Student tmp = List[p];
                List[p] = List[num];
                
                List[num] = tmp;
            }
            // once again
            for (int p = 0; p < List.Count - 1; p++)
            {
                int num = r.Next(List.Count - p) + p;
                Student tmp = List[p];
                List[p] = List[num];
                List[num] = tmp;
            }
        }
        internal static void ShuffleListOfStrings(ref List<string> List)
        {
            // shuffles the list 
            Random r = new Random();
            for (int p = 0; p < List.Count - 1; p++)
            {
                int drawn = r.Next(p + 1, List.Count);
                // exchange
                string tmp = List[drawn];
                List[drawn] = List[p];
                List[p] = tmp;
            }
        }

        private static int findIndexOfItemtoSwapWithFirst(double drawn, 
            int IndexBeginFrom, List<Student> List)
        {
            double sumTillHere = 0;
            int p = IndexBeginFrom; 
            for (; p < List.Count; p++)
            {
                sumTillHere += (double)List[p].SortOrDrawCriterion;
                if (drawn <= sumTillHere)
                    break; 
            }
            return p;
        }

        private static double sumAllProbabilities(int IndexBeginFrom, List<Student> List)
        {
            double sum = 0; 
            for (int p = IndexBeginFrom; p < List.Count; p++)
            {
                sum += (double)List[p].SortOrDrawCriterion; 
            }
            return sum;
        }
        internal static void StartLinks(Class Class, List<string> LinksOfClass)
        {
            foreach (string link in LinksOfClass)
            {
                try
                {
                    string startLink;
                    if (link.Substring(0, 4) == "http" || link.Contains(".exe"))
                        startLink = link;
                    else
                        startLink = Class.PathRestrictedApplication + "\\" + link;
                    Commons.ProcessStartLink(startLink); 
                }
                catch
                {
                    Console.Beep();
                }
            }
        }
        internal static void ProcessStartLink(string Link)
        {
            try
            {
                new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(Link)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            catch (Exception ex)
            {
                Console.Beep(); 
            }
        }
        internal static void SaveCurrentValuesOfAllControls(Control ParentControl, ref string PathAndFile)
        {
            string fileContent = ""; 
            if (ParentControl.Controls.Count > 0)
            {
                SaveControlsValuesOfLevel(ParentControl, ref fileContent);
            }
            TextFile.StringToFile(PathAndFile, fileContent, false);
        }
        private static void SaveControlsValuesOfLevel(Control ParentControl, ref string NamesAndValues)
        {
            // recursive function! 
            foreach (Control c in ParentControl.Controls)
            {
                try
                {
                    // we don't save the values of the types of controls that we don't want to save
                    if (
                        // ADD here specific controls that you don't want to be saved
                        // make THE SAME in RestoreControlsValues()                            
                        c.Name != ""
                        && !(c is Label) 
                        && !(c is Button)
                        && !(c is GroupBox) 
                        && !(c is PictureBox)
                    )
                    {
                        NamesAndValues += c.Name + "\t";
                        if (c is TextBox)
                            NamesAndValues += ((TextBox)c).Text;
                        else if (c is RadioButton)
                            NamesAndValues += ((RadioButton)c).Checked.ToString();
                        else if (c is CheckBox)
                            NamesAndValues += ((CheckBox)c).Checked.ToString();
                        else
                            NamesAndValues += c.Text;
                        //if (c is DataGridView)
                        //    SaveTableContent((DataGridView)c);
                        NamesAndValues += "\n"; 
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep(200, 300);
                }
                SaveControlsValuesOfLevel(c, ref  NamesAndValues);
            }
        }

        internal static void RestoreCurrentValuesOfAllControls(Control ParentControl, string PathAndFile)
        {
            try 
            { 
                string[,] NamesAndValues = TextFile.FileToMatrix(PathAndFile, '\t');
                int index = 0; 
                RestoreControlsValuesOfLevel(ParentControl, NamesAndValues, ref index); 
            }
            catch (Exception ex)
            {
                Console.Beep(200, 300); 
            }
        }
        private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues, ref int Index)
        { 
            // recursive function! 
            // !!!! to fix !!!! reads only a few of the controls !!!! 
            foreach (Control c in ParentControl.Controls)
            {
                // we don't restore the values of the types of controls that were not saved
                if (
                    // ADD here specific controls that you don't want to be saved
                    c.Name != ""
                    && !(c is Label)
                    && !(c is Button)
                    && !(c is GroupBox)
                    && !(c is PictureBox)
                )
                {
                    // if the name of the control is different from the one that has been saved,
                    // then the catch statement has fired when saving, so we skip this control
                    // by doing nothing 
                    if (NamesAndValues[Index, 0] != c.Name)
                    {
                        
                    }
                    else
                    {
                        //if (c is DataGridView)
                        //    RestoreTableContent((DataGridView)c);
                        if (c is TextBox)
                            ((TextBox)c).Text = NamesAndValues[Index, 1];
                        else if (c is RadioButton)
                            ((RadioButton)c).Checked = bool.Parse(NamesAndValues[Index, 1]);
                        else if (c is CheckBox)
                            ((CheckBox)c).Checked = bool.Parse(NamesAndValues[Index, 1]);
                        else
                            c.Text = NamesAndValues[Index, 1];
                        Index++;
                        // if something went wrong 
                        // (e.g. something has changed in the U.I, controls since last execution)
                        // the Index could overflow the matrix
                        if (Index == NamesAndValues.Length)
                            break; // exits the loop 
                    }
                    RestoreControlsValuesOfLevel(c, NamesAndValues, ref Index);
                }
            }
        }

        private static void RestoreTableContent(DataGridView grid)
        {
            //string fileIni = grid.Name + ".ini";
            //DataSet ds = new DataSet("DataSet_" + grid.Name);
            //ds.ReadXml(Comuni.PathFileConfigurazione + fileIni);
            //DataTable dt = ds.Tables[0];
            //grid.DataSource = dt;

            ////////string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            ////////DataSet ds = new DataSet("DataSet_" + grid.Name);
            ////////ds.ReadXml(ComuniZ.PathFileConfigurazione + fileIni);
            ////////DataTable dt = ds.Tables[0];

            ////////int j = 0;
            ////////foreach (DataRow riga in dt.Rows)
            ////////{
            ////////    grid.Rows.Add();
            ////////    for (int i = 0; i < riga.ItemArray.Length; i++)
            ////////    {
            ////////        grid.Rows[j].Cells[i].Value = riga.ItemArray[i];
            ////////    }
            ////////    j++;
            ////////}
        }

        private static void SaveTableContent(DataGridView grid)
        {
            //string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            //int j = 0;
            //DataSet ds = new DataSet();
            //// tabella
            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn column in grid.Columns)
            //{
            //    dt.Columns.Add(grid.Rows[0].Cells[j].ToString());
            //    j++;
            //}
            //object[] cellValues = new object[grid.Columns.Count];
            //// valori
            //foreach (DataGridViewRow rigaGrid in grid.Rows)
            //{
            //    for (int i = 0; i < rigaGrid.Cells.Count; i++)
            //    {
            //        //dt.Rows[j].ItemArray = rigaGrid.Cells[i].Value;
            //        cellValues[i] = rigaGrid.Cells[i].Value;
            //    }
            //    dt.Rows.Add(cellValues);
            //}
            //ds.Tables.Add(dt);
            //ds.WriteXml(ComuniZ.PathFileConfigurazione + fileIni);
        }

        internal static void SortListBySortOrDrawCriterionDescending(List<Student> List)
        {
            for (int i = 0; i < List.Count - 1; i++)
            {
                Student max = List[i];
                int indexMax = i;
                for (int j = i + 1 ; j < List.Count; j++)
                {
                    if (List[j].SortOrDrawCriterion > max.SortOrDrawCriterion)
                    {
                        indexMax = j;
                        max = List[j];
                    }
                }
                // swap list elements
                Student dummy = List[i];
                List[i] = List[indexMax];
                List[indexMax] = dummy; 
            }
        }

        internal static bool CheckIfTypeOfAssessmentChosen(GradeType GradeType)
        {
            if (GradeType == null)
            {
                MessageBox.Show("Scegliere un tipo di valutazione", "Operazione non possibile",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        internal static bool CheckIfSubjectChosen(SchoolSubject SchoolSubject)
        {
            if (SchoolSubject == null)
            //if (cmbSchoolSubject.SelectedItem == null || cmbSchoolSubject.Text == "")
            {
                MessageBox.Show("Scegliere una materia", "Operazione non possibile",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        internal static bool CheckIfClassChosen(Class CurrentClass)
        {
            // Commons.CurrentClass 
            if (CurrentClass == null)
            {
                MessageBox.Show("Scegliere una classe", "Operazione non possibile",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                MessageBox.Show("Scegliere un allievo"
                    , "Operazione non possibile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static Color ColorFromNumber(SchoolSubject Subject)
        {
            if (Subject == null || Subject.Color == null || Subject.Color == 0)
                return Commons.ColorNoSubject;
            // extract the color components from the RGB number
            Color bgColor = Color.FromArgb((int)(Subject.Color & 0xFF0000) >> 16,
                (int)(Subject.Color & 0xFF00) >> 8,
                (int)Subject.Color & 0xFF);
            return bgColor;
        }
    }
}

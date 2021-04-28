using System;
using System.IO;
using System.Security.Cryptography;
using gamon;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using SchoolGrades.DbClasses;
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

        public static string FileDatabase = "SchoolGrades_DEMO.sqlite";
        //public static string PathDatabase = PathUser + "\\SchoolGrades\\Data";
        public static string PathDatabase = PathExe + "\\Data";
        public static string PathAndFileDatabase = PathDatabase + "\\" + FileDatabase; // if will be read with Commons.ReadConfigFile()! 

        //public static string PathStartLink = PathUser + "\\SchoolGrades\\";
        public static string PathStartLinks = PathExe; 
        //public static string PathImages = PathUser + "\\SchoolGrades\\Images";
        //public static string PathImages = PathExe + "\\SchoolGrades\\Images";
        
        public static string PathImages = PathExe + "\\Images";

        //public static string PathDocuments = PathExe + "\\SchoolGrades\\Docs";
        public static string PathDocuments = PathExe + "\\Docs";

        // variables to remember something between forms (Global) 
        // remember what was the last Topic chosen
        internal static Topic LastTopicChosen;
        // remember which were the last Tags chosen
        internal static List<Tag> LastTagsChosen;

        internal static bool isLogging = true;
        internal static DateTime DateNull = new DateTime(1800,1,1);

        internal static List<Question> QuestionsAlreadyMadeThisTime = new List<Question>();

        private static Color ColorNoSubject = Color.PowderBlue;

        public static string IdSchool = "FOIS01100L";

        public static bool IsTimerLessonActive { get; internal set; }

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
                return ErrorLog("ERRORE in calcolo SHA1: " + ex.Message); 
            }
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
        internal static bool ReadConfigFile()
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
                    // we try the next to avoid stopping the program whem we have a new config file, 
                    // with another field will show up. You have to add some data in.config file. 
                    try
                    {
#if WINFORMS
                        SharedWinForms.CommonsWinForms.SaveBackupWhenExiting = bool.Parse(dati[5]);
#endif
                        return true;
                    }
                    catch 
                    {
                        return false; 
                    }
                }
            }
            catch
            {
                // if error do nothing. the rest of the code will generate the default data
                return false;
            }
            return false; 
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
        internal static DateTime DateCompiled()
        // Assumes that in AssemblyInfo.cs,
        // the version is specified as 1.0.* or the like,
        // with only 2 numbers specified;
        // the next two are generated from the date.
        // This routine decodes them.
        {

            System.Version v =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // v.Build is days since Jan. 1, 2000
            // v.Revision*2 is seconds since local midnight
            // (NEVER daylight saving time)

            //DateTime t = new DateTime(
            //    v.Build * TimeSpan.TicksPerDay +
            //    v.Revision * TimeSpan.TicksPerSecond * 2
            //).AddYears(1999);

            DateTime t = new DateTime(
                v.Build * TimeSpan.TicksPerDay).AddYears(1999);
            return t;
        }
        internal static string ErrorLog(string Error)
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
            ////////if (UseMessageBox)
            ////////{
            ////////    MessageBox.Show(Error, "Errore");
            ////////}
            Console.Beep();

            return Error;
        }
    }
}

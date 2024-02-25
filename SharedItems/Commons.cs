//using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;

namespace SchoolGrades
{
    public static class Commons
    {
        internal static BusinessLayer bl;
        //internal static DataLayer dl;
        // program's default path and files. Overridden by the config file "schgrd.cfg", when it exists
        internal static string PathUser = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        internal static string PathAndFileExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8);
        internal static string PathExe = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        internal static string PathConfig = Path.Combine(PathUser, "SchoolGrades", "Config");
        internal static string PathAndFileConfig = Path.Combine(PathConfig, "schgrd.cfg");
        internal static string CompanyPrefix = "gamon-";
        internal static string PathLogs = Path.Combine(PathUser, "SchoolGrades", "Logs");
        internal static string PathAndFileLogText = Path.Combine(PathLogs, CompanyPrefix + "Errori.txt");

        internal static string DatabaseFileName_Teacher = "SchoolGrades.sqlite";
        internal static string DatabaseFileName_Demo = "SchoolGrades_DEMO.sqlite";
        internal static string DatabaseFileName_Current = "";
        internal static string PathDatabase = Path.Combine(PathExe, "Data");
        private static string pathAndFileDatabase;
        internal static string PathImages = Path.Combine(PathExe, "Images");
        internal static string PathDocuments = Path.Combine(PathExe, "Docs");

        // !!!! TODO use DbInfo !!!!
        //internal static DatabaseInfo DbInfo = new();
        //DatabaseInfo.
        //    . = "SchoolGrades.sqlite";
        //DbInfo.Name_Demo = "SchoolGrades_DEMO.sqlite";
        //DbInfo.Name_Current = "";

        // variables to remember something between forms (Global) 
        // remember what was the last Topic chosen
        internal static Topic LastTopicChosen;
        // remember which were the last Tags chosen
        internal static List<Tag> LastTagsChosen;

        internal static bool isLogging = true;
        internal static DateTime DateNull = new DateTime(1800, 1, 1);

        internal static List<Question> QuestionsAlreadyMadeThisTime = new List<Question>();

        private static Color ColorNoSubject = Color.PowderBlue;

        internal static string IdSchool = "FOIS01100L";
        internal static bool IsTimerLessonActive { get; set; }
        internal static string PathAndFileDatabase { get => pathAndFileDatabase; set => pathAndFileDatabase = value; }

        // wait time before saving 
        public static int BackgroundThreadSleepSeconds = 60;
        // enable Mptt backgroud saving of Left anf Right pointers 
        public static bool BackgroundSavingEnabled = true;
        // exit the background task 
        public static bool BackgroundTaskClose = false;
        public static bool BackgroundTaskIsSaving = false;

        // lock variable for serialization of access to BackgroundSavingEnabled and BackgroundSavingSafeStatus
        public static object LockSavingCriticalSections = new object();
        public static object LockBackgroundSavingVariables = new object();
        // Thread that concurrently saves the Topics tree
        internal static Thread BackgroundSaveThread;
        // Tree object for concurrent saving 

        public static bool SaveBackupWhenExiting;

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
        internal static DateTime GetValidDateFromString(string input)
        {
            if (DateTime.TryParse(input, out DateTime date))
            {
                // The string is a valid date, and 'date' now contains the parsed value.
                return date;
            }
            else
            {
                // The string is not a valid date.
                return DateTime.MinValue;
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
        internal static void ListShuffleRandom<T>(IList<T> List)
        {
            Random r = new Random();
            int n = List.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                T value = List[k];
                List[k] = List[n];
                List[n] = value;
            }
            // once again
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                T value = List[k];
                List[k] = List[n];
                List[n] = value;
            }
        }
        internal static void ListShuffleWithDifferentProbabilities(List<Student> List)
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
        internal static void StartLinks(Class Class, List<StartLink> LinksOfClass)
        {
            foreach (StartLink link in LinksOfClass)
            {
                try
                {
                    string startLink;
                    if (link.Link.Substring(0, 4) == "http" || link.Link.Contains(".exe"))
                        startLink = link.Link;
                    else
                        startLink = Path.Combine(Class.PathRestrictedApplication, link.Link);
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
                for (int j = i + 1; j < List.Count; j++)
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

            System.Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // DataBaseName.Build is days since Jan. 1, 2000
            // DataBaseName.Revision*2 is seconds since local midnight
            // (NEVER daylight saving time)

            //DateTime t = new DateTime(
            //    DataBaseName.Build * TimeSpan.TicksPerDay +
            //    DataBaseName.Revision * TimeSpan.TicksPerSecond * 2
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
            Console.Beep();

            return Error;
        }
        enum State
        {
            SeekingFirstDigit,
            ReadingNumber
        }
        internal static string IncreaseIntegersInString(string StringWithNumbersInside)
        {
            // increase (add one to) the integer numbers contained into a string, leaving the rest untouched 

            // finite state machine that recognizes numbers 
            string outputString = "";
            string partialString = "";
            int currentIndex = 0;
            State state = State.SeekingFirstDigit;
            while (currentIndex < StringWithNumbersInside.Length)
            {
                char currentChar = StringWithNumbersInside[currentIndex];
                switch (state)
                {
                    case State.SeekingFirstDigit:
                        {
                            if (char.IsDigit(currentChar))
                            {
                                state = State.ReadingNumber;
                                outputString += partialString;
                                partialString = "";
                            }
                            partialString += currentChar.ToString();
                            break;
                        }
                    case State.ReadingNumber:
                        {
                            if (char.IsDigit(currentChar))
                            {
                                partialString += currentChar.ToString();
                            }
                            else
                            {
                                state = State.SeekingFirstDigit;
                                int number = int.Parse(partialString);
                                outputString += (++number).ToString() + currentChar.ToString();
                                partialString = "";
                            }
                            break;
                        }
                }
                currentIndex++;
            }
            if (state == State.ReadingNumber)
            {
                int number = int.Parse(partialString);
                outputString += (++number).ToString();
            }
            else
                outputString += partialString;

            return outputString;
        }
        internal static bool ProcessingCanContinue()
        {
            // if the foreground task is running, we will NOT EVER interrupt it 
            if (!BackgroundTaskIsSaving) return true;
            // if the background is disabled, processing proceed only if enabled 
            return BackgroundSavingEnabled;

        }
        internal static void CreatePaths()
        {
            if (!Directory.Exists(Commons.PathConfig))
                Directory.CreateDirectory(Commons.PathConfig);
            if (!Directory.Exists(Commons.PathLogs))
                Directory.CreateDirectory(Commons.PathLogs);
            if (!Directory.Exists(Commons.PathImages))
                Directory.CreateDirectory(Commons.PathImages);
            if (!Directory.Exists(Commons.PathDatabase))
                Directory.CreateDirectory(Commons.PathDatabase);
            if (!Directory.Exists(Commons.PathDocuments))
            {
                if (Commons.PathDocuments != "")
                    Directory.CreateDirectory(Commons.PathDocuments);
                else
                    Commons.PathDocuments = ".";
            }
        }
        internal static string GetNewestAmongFilesWithDateInName(string DatabasePath)
        {
            if (!Directory.Exists(DatabasePath))
            {
                return null;
            }
            string[] files = Directory.GetFiles(DatabasePath);
            DateTime newestFileDate = DateTime.MinValue;
            string newestFileNameAndPath = "";
            foreach (string file in files)
            {
                DateTime thisFileDate = Commons.GetValidDateFromString(Path.GetFileName(file).Substring(0, 10));
                if (thisFileDate > newestFileDate)
                {
                    newestFileDate = thisFileDate;
                    newestFileNameAndPath = file;
                }
            }
            return newestFileNameAndPath;
        }
        internal static DataLayer SetDataLayer(string DataBaseName)
        {
#if SQL_SERVER
            DataLayer dlNew = new SqlServer_DataLayer(DataBaseName);
#else
            SqLite_DataLayer dlNew = new SqLite_DataLayer(DataBaseName);
#endif
            return dlNew;
        }
    }
}

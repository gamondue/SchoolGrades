using gamon;
using SchoolGrades.BusinessObjects;
using SchoolGrades_BlazorWasm.Shared;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolGrades
{
    internal static partial class Commons
    {
        private static string ColorNoSubject = "#B0E0E6"; // Hex for PowderBlue

        internal static void SaveCurrentValuesOfAllControls(object ParentControl, ref string PathAndFile)
        {
            // Implementation for Blazor (if needed)
        }
        internal static void RestoreCurrentValuesOfAllControls(object ParentControl, string PathAndFile)
        {
            // Implementation for Blazor (if needed)
        }
        internal static event Action<string>? OnShowMessage;
        
        /// <summary>
        /// Validates if the current configuration is complete and valid
        /// </summary>
        internal static bool IsConfigurationValid()
        {
            return !string.IsNullOrEmpty(PathDatabase) &&
                   !string.IsNullOrEmpty(DatabaseFileName_Current) &&
                   !string.IsNullOrEmpty(PathImages) &&
                   !string.IsNullOrEmpty(PathDocuments) &&
                   !string.IsNullOrEmpty(PathAndFileDatabase);
        }

        /// <summary>
        /// Creates default configuration directories if they don't exist
        /// </summary>
        internal static void EnsureDirectoriesExist()
        {
            try
            {
                if (!Directory.Exists(PathConfig))
                    Directory.CreateDirectory(PathConfig);
                if (!Directory.Exists(PathLogs))
                    Directory.CreateDirectory(PathLogs);
                if (!string.IsNullOrEmpty(PathImages) && !Directory.Exists(PathImages))
                    Directory.CreateDirectory(PathImages);
                if (!string.IsNullOrEmpty(PathDatabase) && !Directory.Exists(PathDatabase))
                    Directory.CreateDirectory(PathDatabase);
                if (!string.IsNullOrEmpty(PathDocuments) && !Directory.Exists(PathDocuments))
                    Directory.CreateDirectory(PathDocuments);
            }
            catch (Exception ex)
            {
                ErrorLog($"Errore nella creazione delle directory: {ex.Message}");
            }
        }

        /// <summary>
        /// Writes configuration data for Blazor Setup page
        /// </summary>
        internal static void WriteConfigDataBlazor(string pathDatabase, string fileDatabase, 
            string pathImages, string pathDocuments, bool saveBackup)
        {
            string[] dati = new string[6];
            try
            {
                // Update Commons properties
                PathDatabase = pathDatabase;
                DatabaseFileName_Current = fileDatabase;
                PathImages = pathImages;
                PathDocuments = pathDocuments;
                SaveBackupWhenExiting = saveBackup;
                PathAndFileDatabase = Path.Combine(pathDatabase, fileDatabase);

                // Ensure directories exist
                EnsureDirectoriesExist();

                // Prepare data array
                dati[0] = DatabaseFileName_Current;
                dati[1] = PathImages;
                // position 2 was held by PathStartLinks (not used anymore)
                dati[3] = PathDatabase;
                dati[4] = PathDocuments;
                dati[5] = SaveBackupWhenExiting.ToString();

#if DEBUG
                TextFile.ArrayToFile(PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(PathAndFileConfig, dati, false);
#endif
            }
            catch (Exception e)
            {
                string err = "WriteConfigDataBlazor(): " + e.Message;
                ErrorLog(err);
                throw new Exception(err);
            }
        }

        internal static bool CheckIfTypeOfAssessmentChosen(GradeType GradeType)
        {
            if (GradeType == null)
            {
                OnShowMessage?.Invoke("Scegliere un tipo di valutazione");
                return false;
            }
            return true;
        }
        internal static bool CheckIfSubjectChosen(SchoolSubject SchoolSubject)
        {
            if (SchoolSubject == null)
            {
                OnShowMessage?.Invoke("Scegliere una materia");
                return false;
            }
            return true;
        }
        internal static bool CheckIfClassChosen(Class CurrentClass)
        {
            if (CurrentClass == null)
            {
                OnShowMessage?.Invoke("Scegliere una classe");
                return false;
            }
            return true;
        }

        public static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                OnShowMessage?.Invoke("Scegliere un allievo");
                return false;
            }
            return true;
        }
        internal static void SwitchPicLed(bool IsLedLit)
        {
            //try
            //{
            //    // lights on or off the PictureBox used as an Activity LED 
            //    globalPicLed.Invoke(new Action(() =>
            //    {
            //        if (IsLedLit)
            //            globalPicLed.BackColor = Color.Red;     // LED lit
            //        else
            //            globalPicLed.BackColor = Color.DarkGray; // LED off
            //    }));
            //    Application.DoEvents();
            //}
            //catch { }
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
                        Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
                        Commons.PathDocuments = dati[4];
                    }
                    else
                    {
                        Commons.DatabaseFileName_Current = dati[0];
                        Commons.PathImages = dati[1];
                        // position 2 was held by PathStartLinks 
                        //Commons.PathStartLinks = dati[2]; 
                        Commons.PathDatabase = dati[3];
                        Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
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
                OnShowMessage?.Invoke("File di configurazione salvato in " + Commons.PathAndFileConfig);
            }
            catch (Exception e)
            {
                string err = @"[Error in program's directories] \r\n" + e.Message;
                Commons.ErrorLog(err);
                throw new FileNotFoundException(err);
                //return;
            }
        }
        internal static string ColorFromNumber(SchoolSubject Subject)
        {
            if (Subject == null || Subject.Color == null || Subject.Color == 0)
                return ColorNoSubject;

            // extract the color components from the RGB number
            return string.Format("#{0:X2}{1:X2}{2:X2}",
                (Subject.Color & 0xFF0000) >> 16,
                (Subject.Color & 0xFF00) >> 8,
                Subject.Color & 0xFF);
        }
    }
}
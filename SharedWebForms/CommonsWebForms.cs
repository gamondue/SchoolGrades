using gamon;
using SchoolGrades;
using SchoolGrades_WebForms;
using System;
using System.IO;
using System.Web.UI; 

namespace SharedWebForms
{
    internal static class CommonsWebForms
    {
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
        internal static void WriteConfigFile()
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
                if (!Directory.Exists(Commons.PathStartLinks))
                    Directory.CreateDirectory(Commons.PathStartLinks);
                if (!Directory.Exists(Commons.PathDatabase))
                    Directory.CreateDirectory(Commons.PathDatabase);
                if (!Directory.Exists(Commons.PathDocuments))
                {
                    if (Commons.PathDocuments != "")
                        Directory.CreateDirectory(Commons.PathDocuments);
                    else
                        Commons.PathDocuments = ".";
                }
                dati[0] = Commons.FileDatabase;
                dati[1] = Commons.PathImages;
                dati[2] = Commons.PathStartLinks;
                dati[3] = Commons.PathDatabase;
                dati[4] = Commons.PathDocuments;
                MessageBox messageBox = new MessageBox();
                messageBox.Show("File di configurazione salvato in " + Commons.PathAndFileConfig, 
                    "SchoolGrades prompt");
#if DEBUG
                TextFile.ArrayToFile(Commons.PathAndFileConfig + "_DEBUG", dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif
            }
            catch (Exception e)
            {
                string err = @"[Error in program's directories] \r\n" + e.Message;
                Commons.ErrorLog(err);
                throw new FileNotFoundException(err);
                //return;
            }
        }
    }
}

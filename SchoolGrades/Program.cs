using gamon;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolGrades
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // read configuration file or run configuration 
            if (!Commons.ReadConfigFile())
            {
                // config file is unexistent or broken 
                if (Commons.PathAndFileDatabase.Contains("DEMO") && File.Exists(Commons.PathAndFileDatabase))
                {
                    // if demo database exists, save the configuration program with demo file 
                    WriteConfigFile();
                }
                else
                {
                    // we don't want the demo file or it doesn't exist. Let's ask the user 
                    MessageBox.Show("Configurazione del programma.\r\nSistemare le cartelle con il percorso dei file (in particolare la cartella che contiene il database), " +
                        "poi scegliere il file di dati .sqlite e premere 'Salva configurazione'", "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmSetup f = new FrmSetup();
                    f.ShowDialog();
                    if (!File.Exists(Commons.PathAndFileDatabase))
                    {
                        MessageBox.Show("Configurare il programma!", "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                // config file has been read 
                // di nothing
            }

            //Application.Run(new frmLogin());
            Application.Run(new frmMain());
        }
        private static void WriteConfigFile()
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
                dati[5] = CommonsWinForms.SaveBackupWhenExiting.ToString();
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
    }
}

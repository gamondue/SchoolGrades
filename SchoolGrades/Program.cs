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
            if (!CommonsWinForms.ReadConfigFile())
            {
                // config file is unexistent or broken 
                if (Commons.PathAndFileDatabase.Contains("DEMO") && File.Exists(Commons.PathAndFileDatabase))
                {
                    // if demo database exists, save the configuration program with demo file 
                    CommonsWinForms.WriteConfigFile();
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
                // do nothing
            }

            //Application.Run(new frmLogin());
            Application.Run(new frmMain());
        }
    }
}

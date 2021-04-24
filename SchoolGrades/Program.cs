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

            // read configuration file or run configuration form 
            Commons.ReadConfigFile();
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                MessageBox.Show("Configurazione del programma.\r\nSistemare le cartelle con il percorso dei file (in particalore la cartella che contiene il database), " +
                    "poi scegliere il file di dati .sqlite e premere 'Salva configurazione'", "SchoolGrades", MessageBoxButtons.OK,MessageBoxIcon.Information);
                FrmSetup f = new FrmSetup();
                f.ShowDialog();
                if (!File.Exists(Commons.PathAndFileDatabase))
                {
                    MessageBox.Show("Configurare il programma!", "SchoolGrades", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
            }
            //Application.Run(new frmLogin());
            Application.Run(new frmMain());
        }
    }
}

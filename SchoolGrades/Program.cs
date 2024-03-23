using System;
using System.Windows.Forms;

namespace SchoolGrades
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //string database = @"C:\OneDriveScuola\OneDrive - ispascalcomandini.gov.it\SchoolGrades\Data\SchoolGrades.sqlite";
            //if (args.Length > 0)
            //    database = args[0];
            //else
            //    database = null;

            //Application.Run(new frmLogin());
            //Application.Run(new frmMain(database));
            Application.Run(new frmMain());
        }
        // devo faer il commit e la pull request 
        // questi sono dommenti solo per fare dei cambiamenti senza rompere il codice.
    }
}

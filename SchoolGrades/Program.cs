using gamon;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string database;
            database = @"C:\OneDriveScuola\OneDrive - ispascalcomandini.gov.it\SchoolGrades\Data\SchoolGrades-Bardock-75.sqlite";
            //if (args.Length > 0)
            //    database = args[0];
            //else
            //    database = null;

            //Application.Run(new frmLogin());
            Application.Run(new frmMain(database));
        }
   }
}

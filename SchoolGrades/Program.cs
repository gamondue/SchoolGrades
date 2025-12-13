using System;
using System.Threading;
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
            // Gestione globale delle eccezioni non gestite
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                LogFatalException("Application.Run", ex);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogFatalException("ThreadException", e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogFatalException("UnhandledException", ex);
            }
            else
            {
                Commons.ErrorLog($"UnhandledException (non-Exception): {e.ExceptionObject}");
            }
        }

        private static void LogFatalException(string source, Exception ex)
        {
            string message = $"[{source}] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}";
            
            // Log to file
            try
            {
                Commons.ErrorLog(message);
            }
            catch
            {
                // Ignore logging errors
            }
            
            // Show to user
            try
            {
                MessageBox.Show(
                    $"Si è verificato un errore critico:\n\n{ex.Message}\n\nL'errore è stato registrato nel log.",
                    "Errore Critico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                // If we can't show the message box, just continue
            }
        }
    }
}

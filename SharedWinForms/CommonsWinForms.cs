using gamon;
using gamon.TreeMptt;
using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolGrades
{
    internal static partial class Commons
    {
        internal static PictureBox globalPicLed;

        private static Color ColorNoSubject = Color.PowderBlue;

        internal static void SaveCurrentValuesOfAllControls(Control ParentControl, ref string PathAndFile)
        {
            string fileContent = "";
            if (ParentControl.Controls.Count > 0)
            {
                SaveControlsValuesOfLevel(ParentControl, ref fileContent);
            }
            TextFile.StringToFile(PathAndFile, fileContent, false);
        }
        private static void SaveControlsValuesOfLevel(Control ParentControl, ref string NamesAndValues)
        {
            // recursive function! 
            foreach (Control c in ParentControl.Controls)
            {
                try
                {
                    // we don't save the values of the types of controls that we don't want to save
                    if (
                        // ADD here specific controls that you don't want to be saved
                        // make THE SAME in RestoreControlsValues()                            
                        c.Name != ""
                        && !(c is Label)
                        && !(c is Button)
                        && !(c is GroupBox)
                        && !(c is PictureBox)
                        && !(c is DataGridView)
                    )
                    {
                        NamesAndValues += c.Name + "\t";
                        if (c is TextBox)
                            NamesAndValues += ((TextBox)c).Text;
                        else if (c is RadioButton)
                            NamesAndValues += ((RadioButton)c).Checked.ToString();
                        else if (c is CheckBox)
                            NamesAndValues += ((CheckBox)c).Checked.ToString();
                        else
                            NamesAndValues += c.Text;
                        //if (c is DataGridView)
                        //    SaveTableContent((DataGridView)c);
                        NamesAndValues += "\n";
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep(200, 300);
                }
                SaveControlsValuesOfLevel(c, ref NamesAndValues);
            }
        }
        internal static void RestoreCurrentValuesOfAllControls(Control ParentControl, string PathAndFile)
        {
            try
            {
                string[,] NamesAndValues = TextFile.FileToMatrix(PathAndFile, '\t');
                int index = 0;
                //RestoreControlsValuesOfLevel(ParentControl, NamesAndValues, ref index);
                RestoreControlsValuesOfLevel(ParentControl, NamesAndValues);
            }
            catch (Exception ex)
            {
                Console.Beep(200, 300);
            }
        }
        //private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues, ref int Index)
        private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues)
        {
            // recursive function! 
            // !!!! to fix !!!! reads only a few of the controls !!!! 
            foreach (Control c in ParentControl.Controls)
            {
                for (int Index = 0; Index < NamesAndValues.GetLength(1); Index++)
                {
                    // we don't restore the values of the types of controls that were not saved
                    if (
                        // ADD here specific controls that you don't want to be saved
                        c.Name != ""
                        && !(c is Label)
                        && !(c is Button)
                        && !(c is GroupBox)
                        && !(c is PictureBox)
                        && !(c is DataGridView)
                    )
                    {
                        // if the name of the control is different from the one that has been saved,
                        // then the catch statement has fired when saving, so we skip this control
                        // by doing nothing 
                        if (NamesAndValues[Index, 0] != c.Name)
                        {

                        }
                        else
                        {
                            //if (c is DataGridView)
                            //    RestoreTableContent((DataGridView)c);
                            if (c is TextBox)
                                ((TextBox)c).Text = NamesAndValues[Index, 1];
                            else if (c is RadioButton)
                                ((RadioButton)c).Checked = bool.Parse(NamesAndValues[Index, 1]);
                            else if (c is CheckBox)
                                ((CheckBox)c).Checked = bool.Parse(NamesAndValues[Index, 1]);
                            else
                                c.Text = NamesAndValues[Index, 1];
                            // if something went wrong 
                            // (e.g. something has changed in the U.I, controls since last execution)
                            // the Index could overflow the matrix
                            if (Index == NamesAndValues.Length)
                                break; // exits the loop 
                        }
                        // RestoreControlsValuesOfLevel(c, NamesAndValues, ref Index);
                        RestoreControlsValuesOfLevel(c, NamesAndValues);
                    }
                }
            }
        }
        private static void RestoreTableContent(DataGridView grid)
        {
            //string fileIni = grid.Name + ".ini";
            //DataSet ds = new DataSet("DataSet_" + grid.Name);
            //ds.ReadXml(Comuni.PathFileConfigurazione + fileIni);
            //DataTable dt = ds.Tables[0];
            //grid.DataSource = dt;

            ////////string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            ////////DataSet ds = new DataSet("DataSet_" + grid.Name);
            ////////ds.ReadXml(ComuniZ.PathFileConfigurazione + fileIni);
            ////////DataTable dt = ds.Tables[0];

            ////////int j = 0;
            ////////foreach (DataRow riga in dt.Rows)
            ////////{
            ////////    grid.Rows.Add();
            ////////    for (int i = 0; i < riga.ItemArray.Length; i++)
            ////////    {
            ////////        grid.Rows[j].Cells[i].Value = riga.ItemArray[i];
            ////////    }
            ////////    j++;
            ////////}
        }
        private static void SaveTableContent(DataGridView grid)
        {
            //string fileIni = ComuniZ.PrefissoAzienda + grid.Name + ".ini";

            //int j = 0;
            //DataSet ds = new DataSet();
            //// tabella
            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn column in grid.Columns)
            //{
            //    dt.Columns.Add(grid.Rows[0].Cells[j].ToString());
            //    j++;
            //}
            //object[] cellValues = new object[grid.Columns.Count];
            //// valori
            //foreach (DataGridViewRow rigaGrid in grid.Rows)
            //{
            //    for (int i = 0; i < rigaGrid.Cells.Count; i++)
            //    {
            //        //dt.Rows[j].ItemArray = rigaGrid.Cells[i].Value;
            //        cellValues[i] = rigaGrid.Cells[i].Value;
            //    }
            //    dt.Rows.Add(cellValues);
            //}
            //ds.Tables.Add(dt);
            //ds.WriteXml(ComuniZ.PathFileConfigurazione + fileIni);
        }
        internal static bool CheckIfTypeOfAssessmentChosen(GradeType GradeType)
        {
            if (GradeType == null)
            {
                MessageBox.Show(Loc.Get("Commons_SelectGradeType"), Loc.Get("Commons_OperationNotPossible"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static bool CheckIfSubjectChosen(SchoolSubject SchoolSubject)
        {
            if (SchoolSubject == null)
            //if (cmbSchoolSubject.SelectedItem == null || cmbSchoolSubject.Text == "")
            {
                MessageBox.Show(Loc.Get("Commons_SelectSubject"), Loc.Get("Commons_OperationNotPossible"),
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static bool CheckIfClassChosen(Class CurrentClass)
        {
            // Commons.CurrentClass 
            if (CurrentClass == null)
            {
                MessageBox.Show(Loc.Get("Commons_SelectClass"), Loc.Get("Commons_OperationNotPossible"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        public static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                MessageBox.Show(Loc.Get("Commons_SelectStudent")
                    , Loc.Get("Commons_OperationNotPossible"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static void SwitchPicLed(bool IsLedLit)
        {
            try
            {
                // Verify that globalPicLed is valid
                if (globalPicLed == null || globalPicLed.IsDisposed)
                {
                    Commons.ErrorLog("[SwitchPicLed] globalPicLed is null or disposed");
                    return;
                }

                // If the calling thread is not the UI thread, marshal the update to the UI thread
                if (globalPicLed.InvokeRequired)
                {
                    // Called from a background thread - use BeginInvoke to avoid deadlocks
                    globalPicLed.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            if (globalPicLed != null && !globalPicLed.IsDisposed)
                            {
                                if (IsLedLit)
                                    globalPicLed.BackColor = Color.Red;     // LED lit
                                else
                                    globalPicLed.BackColor = Color.DarkGray; // LED off
                            }
                        }
                        catch (Exception ex)
                        {
                            Commons.ErrorLog($"[SwitchPicLed] Error in BeginInvoke: {ex.Message}");
                        }
                    }));
                }
                else
                {
                    // Already on UI thread - update directly
                    if (IsLedLit)
                        globalPicLed.BackColor = Color.Red;
                    else
                        globalPicLed.BackColor = Color.DarkGray;
                }

                // DO NOT use Application.DoEvents() - it is dangerous
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"[SwitchPicLed] Unexpected error: {ex.Message}\n{ex.StackTrace}");
            }

        }
        internal static bool ReadConfigData()
        {
            string[] dati = null;
            try
            {
                dati = TextFile.FileToArray(Commons.PathAndFileConfig);
                if (dati != null)
                {
                    if (Commons.PathAndFileDatabase == null)
                    {
                        if (((string)dati[0]) != "")
                            Commons.DatabaseFileName = dati[0];
                        if (((string)dati[1]) != "")
                            Commons.PathImages = dati[1];
                        // position 2 was held by PathStartLinks 
                        //Commons.PathStartLinks = dati[2]; 
                        if (((string)dati[3]) != "")
                            Commons.PathDatabase = dati[3];
                        Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName);
                        if (((string)dati[4]) != "")
                            Commons.PathDocuments = dati[4];
                    }
                    else
                    {
                        Commons.DatabaseFileName = dati[0];
                        Commons.PathImages = dati[1];
                        // position 2 was held by PathStartLinks 
                        //Commons.PathStartLinks = dati[2]; 
                        Commons.PathDatabase = dati[3];
                        Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName);
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
                TextFile.ArrayToFile(Commons.PathAndFileConfigDebug, dati, false);
#else
                TextFile.ArrayToFile(Commons.PathAndFileConfig, dati, false);
#endif
                MessageBox.Show(Loc.Get("Commons_ConfigSaved") + Commons.PathAndFileConfig);
            }
            catch (Exception e)
            {
                string err = @"[Error in program's directories] \r\n" + e.Message;
                Commons.ErrorLog(err);
                throw new FileNotFoundException(err);
                //return;
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
        // the following must stay in this file, because it is uses the TreeMptt class
        // that is dependant from the UI technology used (WinForms, WPF, etc.)  
    }
}

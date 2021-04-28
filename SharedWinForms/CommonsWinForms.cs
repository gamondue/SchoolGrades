using System;
using gamon.TreeMptt;
using gamon;
using SchoolGrades.DbClasses;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SharedWinForms
{
    public static class CommonsWinForms
    {
        internal static PictureBox globalPicLed;

        // wait time before saving 
        public static int BackgroundThreadSleepSeconds = 5 * 60;
        // enable Mptt backgroud saving of Left anf Right pointers 
        public static bool BackgroundCanStillSaveTopicsTree = true;
        public static object LockBackgroundCanStillSaveTopicsTree = new object();
        // Tree object for concurrent saving 
        internal static TreeMptt SaveTreeMptt;
        // Thread that concurrently saves the Topics tree
        internal static Thread BackgroundSaveThread;

        public static bool SaveBackupWhenExiting;

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
                RestoreControlsValuesOfLevel(ParentControl, NamesAndValues, ref index);
            }
            catch (Exception ex)
            {
                Console.Beep(200, 300);
            }
        }
        private static void RestoreControlsValuesOfLevel(Control ParentControl, string[,] NamesAndValues, ref int Index)
        {
            // recursive function! 
            // !!!! to fix !!!! reads only a few of the controls !!!! 
            foreach (Control c in ParentControl.Controls)
            {
                // we don't restore the values of the types of controls that were not saved
                if (
                    // ADD here specific controls that you don't want to be saved
                    c.Name != ""
                    && !(c is Label)
                    && !(c is Button)
                    && !(c is GroupBox)
                    && !(c is PictureBox)
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
                        Index++;
                        // if something went wrong 
                        // (e.g. something has changed in the U.I, controls since last execution)
                        // the Index could overflow the matrix
                        if (Index == NamesAndValues.Length)
                            break; // exits the loop 
                    }
                    RestoreControlsValuesOfLevel(c, NamesAndValues, ref Index);
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
                MessageBox.Show("Scegliere un tipo di valutazione", "Operazione non possibile",
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
                MessageBox.Show("Scegliere una materia", "Operazione non possibile",
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
                MessageBox.Show("Scegliere una classe", "Operazione non possibile",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static bool CheckIfStudentChosen(Student CurrentStudent)
        {
            if (CurrentStudent == null)
            {
                MessageBox.Show("Scegliere un allievo"
                    , "Operazione non possibile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        internal static void SwitchPicLedOn(bool SetLedLit)
        {
            // lights on or off the PictureBox used as an Activity LED 
            globalPicLed.Invoke(new Action(() =>
            {
                if (SetLedLit)
                    globalPicLed.BackColor = Color.Red;           // LED lit
                else
                    globalPicLed.BackColor = Color.DarkGray;      // LED off
            }));
        }
    }
}

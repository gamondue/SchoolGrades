using gamon;
using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SchoolGrades.Localization;


namespace SchoolGrades
{
    public partial class frmClassesManagement : Form
    {
        // TODO !!!! put an option for separator in import files 

        DataTable dtClass;

        School currentSchool;
        Class currentClass;
        List<Student> studentsList;
        string idSchoolYear;
        bool isLoading = true;
        bool newYear = true;
        Class passedClass;
        public frmClassesManagement(Class Class = null)
        {
            InitializeComponent();
            passedClass = Class;
        }
        private void FrmClassesManagement_Load(object sender, EventArgs e)
        {
            isLoading = true;
            // currentSchool data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);
            CmbSchoolYear.DisplayMember = "IdSchoolYear";
            CmbSchoolYear.ValueMember = "IdSchoolYear";
            CmbClasses.DisplayMember = "Abbreviation";
            CmbClasses.ValueMember = "Abbreviation";
            List<SchoolYear> ly = Commons.bl.GetAllSchoolYears();
            CmbSchoolYear.DataSource = ly;
            if (ly.Count > 0)
            {
                if (passedClass != null)
                {
                    // take the year of the class that has been passed
                    CmbSchoolYear.SelectedValue = passedClass.SchoolYear;
                    CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, passedClass.SchoolYear);
                    // take the class of the year that has been passed
                    // load it automatically
                    isLoading = false;
                    CmbClasses.SelectedValue = passedClass.Abbreviation;
                }
                else
                {
                    // take the last year in the list of the years
                    CmbSchoolYear.SelectedItem = ly[ly.Count - 1];
                    if (CmbSchoolYear.SelectedItem != null)
                    {
                        idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
                        CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
                    }
                }
                isLoading = false;
                newYear = false;
            }

            LocalizeForm();
        }
        private void btnImportStudentsOfClass_Click(object sender, EventArgs e)
        {
            // give warning to avoid modifying existing class instead of making a new one
            if (Commons.bl.GetClass(currentSchool.IdSchool, idSchoolYear, CmbClasses.Text).Abbreviation != null)
            {
                MessageBox.Show(
                    string.Format(Loc.Get("ClassMgmt_Msg_ClassExists"), CmbClasses.Text),
                    Loc.Get("ClassMgmt_Msg_Warning"),
                    MessageBoxButtons.OK);
                return;
            }
            if (CmbClasses.Text.Contains(" "))
            {
                DialogResult d = MessageBox.Show(
                    Loc.Get("ClassMgmt_Msg_NoSpaces"),
                    Loc.Get("Common_Information"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (d != DialogResult.Yes) return;
            }
            if (!File.Exists(TxtFileOfStudentsImport.Text) ||
                TxtFileOfStudentsImport.Text.Substring(TxtFileOfStudentsImport.Text.Length - 1, 1) == "\\")
            {
                MessageBox.Show(
                    string.Format(Loc.Get("ClassMgmt_Msg_FileNotExists"), TxtFileOfStudentsImport.Text),
                    Loc.Get("Common_Warning"),
                    MessageBoxButtons.OK);
                return;
            }
            string[,] studentsData = TextFile.FileToMatrix(TxtFileOfStudentsImport.Text, '\t');

            int idClass;
            Class newClass = new Class(0, CmbClasses.Text, CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);

            if (!rdbChooseStudentsPhotoWhileImporting.Checked)
            {
                newClass.IdClass = Commons.bl.CreateClassAndStudents(studentsData, CmbClasses.Text, txtClassDescription.Text,
                CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text, rdbStudentsPhotosAlreadyPresent.Checked);
            }
            else
            {
                // make a new class from data taken from the UI
                idClass = Commons.bl.CreateClassIfNotExists(CmbClasses.Text, txtClassDescription.Text,
                    CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
                for (int row = 1; row < studentsData.GetLength(0); row++)
                {
                    Student s = CheckIfStudentIsMultipleAndChooseWhat(studentsData, row);
                    Commons.bl.PutStudentInClass(s, idClass);
                    if (rdbChooseStudentsPhotoWhileImporting.Checked)
                    {
                        using (OpenFileDialog dlg = new OpenFileDialog())
                        {
                            dlg.Title = string.Format(Loc.Get("ClassMgmt_Msg_ChoosePhoto"),
                                studentsData[row, 1], studentsData[row, 2], CmbClasses.Text, CmbSchoolYear.Text);
                            dlg.Filter = "jpg files (*.jpg)|*.jpg";
                            dlg.InitialDirectory = TxtImagesOriginFolder.Text;
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                Student s1 = new Student();
                                s1.IdStudent = s.IdStudent;
                                s1.LastName = studentsData[row, 1];
                                s1.FirstName = studentsData[row, 2];
                                Commons.bl.CopyAndLinkOnePhoto(s1, newClass, dlg.FileName);
                            }
                        }
                    }
                }
            }
            MessageBox.Show(Loc.Get("ClassMgmt_Msg_ImportDone"));
            this.Close();
        }
        private Student CheckIfStudentIsMultipleAndChooseWhat(string[,] studentsData, int row)
        {
            Student s = Commons.bl.CreateNewStudentFromFileRow(studentsData, row);
            List<Student> ls = Commons.bl.GetStudentsHomonyms(s);
            if (ls.Count > 0)
            {
                // found students with the same name; user will decide what to do
                int iValue;
                do
                {
                    string MessagePrompt = Loc.Get("ClassMgmt_Msg_FoundHomonym");
                        MessagePrompt += "\n" + string.Format(Loc.Get("ClassMgmt_Msg_AddNewStudent"),
                        s.LastName, s.FirstName, s.ClassAbbreviation, s.SchoolYear);
                    // add to MessagePrompt names and classes of the homonym students,
                    // prefixed by the number of student in the list
                    for (int iLs = 0; iLs < ls.Count; iLs++)
                    {
                        MessagePrompt += "\n" + (iLs + 1).ToString("00") + " - " + ls[iLs].LastName + " " +
                            ls[iLs].FirstName + " " + ls[iLs].ClassAbbreviation + " " +
                            ls[iLs].SchoolYear;
                    }
                    string value = "0";
                    frmInputBox ib = new frmInputBox(Loc.Get("ClassMgmt_Msg_ChooseStudent"), MessagePrompt, value);

                    DialogResult dr = ib.ShowDialog();
                    iValue = -1;
                    if (dr != DialogResult.Cancel)
                    {
                        int.TryParse(ib.Value, out iValue);
                    }
                } while (iValue < 0 || iValue > ls.Count);
                // if user has chosen a name, change the current student to the student chosen by user 
                if (iValue > 0)
                    s = ls[iValue - 1];
            }
            else
            {   // found no students with the same name
                // no need to do anything, the new student's data is already in s
            }
            return s;
        }
        private void btnFileChoose_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(TxtFileOfStudentsImport.Text + "\\");
            DialogResult r = openFileDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtFileOfStudentsImport.Text = openFileDialog.FileName;
            }
        }
        private void btnPathImages_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtImagesOriginFolder.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtImagesOriginFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                newYear = true;

                DetachData();

                idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
                CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
                newYear = false;
            }
        }
        private void DetachData()
        {
            DgwClass.DataSource = null;
            DgwStudents.DataSource = null;
            txtClassDescription.Text = "";
            currentClass = null;
            TxtStartLinksFolder.Text = "";
        }
        private void btnClassErase_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_ChooseClass"));
                return;
            }
            DialogResult res = MessageBox.Show(
                string.Format(Loc.Get("ClassMgmt_Msg_DeleteClassConfirm"), CmbClasses.Text, CmbSchoolYear.Text),
                Loc.Get("Common_Warning"),
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (res == DialogResult.Cancel)
                return;
            if (res == DialogResult.No)
            {
                // eliminazione degli studenti della classe
                Commons.bl.EraseAllStudentsOfAClass(currentClass);
            }
            // eliminazione della classe 
            Commons.bl.EraseClassFromClasses(currentClass);

            this.Close();
        }
        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!newYear)
            {
                Class c = (Class)CmbClasses.SelectedItem;
                if (c != null)
                {
                    FillClassData(c);
                }
            }
        }
        private void CmbClasses_TextChanged(object sender, EventArgs e)
        {
            // !!!! written by the user. It should be fired only when the text part of the combo is manually modified for the first time 
            txtClassDescription.Text = currentSchool.Name + " " + CmbSchoolYear.Text +
                " " + CmbClasses.Text;
        }
        private void FillClassData(Class Class)
        {
            if (Class != null)
            {
                dtClass = Commons.bl.GetClassTable(Class.IdClass);
                DgwClass.DataSource = dtClass;

                studentsList = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, true);
                DgwStudents.DataSource = studentsList;
                txtClassDescription.Text = Safe.String(DgwClass.Rows[DgwClass.CurrentRow.Index].Cells["desc"].Value);
                currentClass = (Class)CmbClasses.SelectedItem;
                TxtStartLinksFolder.Text = currentClass.PathRestrictedApplication;
            }
        }
        private void BtnPhotoChange_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedCells.Count > -1)
            {
                studentsList = (List<Student>)DgwStudents.DataSource;
                Student s = studentsList[DgwStudents.SelectedCells[0].RowIndex];
                DialogResult dr = openFileDialog.ShowDialog();
                string newPhotoFullName = openFileDialog.FileName;
                if (newPhotoFullName != "" && !(dr == DialogResult.Cancel))
                {
                    if (picStudent.Image != null)
                    {
                        picStudent.Image.Dispose();
                        picStudent.Image = null;
                    }
                    s.SchoolYear = CmbSchoolYear.Text;
                    try
                    {
                        Commons.bl.CopyAndLinkOnePhoto(s, currentClass, newPhotoFullName);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Loc.Get("ClassMgmt_Msg_FileLocked"));
                        return;
                    }
                    // loads the new photo in the picture box avoiding the locking of the origin file
                    using (var newImage = System.Drawing.Image.FromFile(newPhotoFullName))
                    {
                        picStudent.Image = (System.Drawing.Image)newImage.Clone();
                    }
                    //LoadPicture(s);
                }
            }
            else
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectForPhoto"));
            }
        }
        private void LoadPicture(Student StudentToLoad)
        {
            try
            {
                string filePathAndName = Path.Combine(Commons.PathImages,
                    Commons.bl.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear));

                picStudent.Image = System.Drawing.Image.FromFile(filePathAndName);
                picStudent.Visible = true;
            }
            catch (Exception ex)
            {
                picStudent.Image = null;
                Console.Beep();
            }
        }
        private void btnStudentNew_Click(object sender, EventArgs e)
        {
            if (CmbClasses.Text == "")
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectClass"));
                return;
            }
            frmStudent sf = new frmStudent(null, true);
            sf.ShowDialog();
            if (sf.UserHasChosen)
            {
                Commons.bl.PutStudentInClass(sf.CurrentStudent,
                    ((Class)(CmbClasses.SelectedItem)).IdClass);
                DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, false);
            }
            else
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_StudentNotAdded"));
            }
        }
        private void btnStudentErase_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectStudentInGrid"));
                return;
            }
            string deletingStudent = (string)DgwStudents.SelectedRows[0].Cells["LastName"].Value +
                " " + (string)DgwStudents.SelectedRows[0].Cells["FirstName"].Value;
            if (MessageBox.Show(
                string.Format(Loc.Get("ClassMgmt_Msg_DeleteStudentConfirm"), deletingStudent),
                Loc.Get("Common_Confirm"),
                MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;
            int IdDeletingStudent = (int)DgwStudents.SelectedRows[0].Cells["IdStudent"].Value;
            Commons.bl.DeleteOneStudentFromClass(IdDeletingStudent,
                ((Class)(CmbClasses.SelectedItem)).IdClass);
            DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, false);
        }
        private void btnSaveClassAndStudents_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = DgwClass.Rows[0];
            int? idClass = ((Class)CmbClasses.SelectedItem).IdClass;
            Class c = new Class(idClass, CmbClasses.Text, CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
            c.Description = Safe.String(dgr.Cells["desc"].Value);
            //c.Description = TxtClassDescription.Text;  
            c.UriWebApp = Safe.String(dgr.Cells["uriWebApp"].Value);
            //c.PathRestrictedApplication = Safe.String(dgr.Cells["pathRestrictedApplication"].Value);
            c.PathRestrictedApplication = TxtStartLinksFolder.Text;

            Commons.bl.SaveClass(c);
            Commons.bl.SaveStudentsOfList((List<Student>)DgwStudents.DataSource, null);

            FillClassData(c);
        }
        private void btnToggleDisableStudent_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectForToggle"));
                return;
            }
            Student disablingStudent = studentsList[DgwStudents.SelectedCells[0].RowIndex];
            Commons.bl.ToggleDisabledFlagOneStudent(disablingStudent, currentClass);
            DgwStudents.DataSource = null;
            DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, true);
            string prompt = "Commutato lo stato di abilitazione dell'allievo " + disablingStudent;
            // !!!! dire in che stato è ora 
            // prompt += ".\nStato attuale: "
            MessageBox.Show(string.Format(Loc.Get("ClassMgmt_Msg_StatusToggled"), disablingStudent));
        }
        private void btnModifyStudent_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count < 1)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectToModify"));
                return;
            }
            Student s = (Student)DgwStudents.SelectedRows[0].DataBoundItem;
            s.SchoolYear = currentClass.SchoolYear;

            frmStudent fs = new frmStudent(s, true);
            fs.ShowDialog();

            Class c = (Class)CmbClasses.SelectedItem;
            FillClassData(c);
        }
        private void btnEndingPeriod_Click(object sender, EventArgs e)
        {
            // make a csv file with all grades and averages 
            MessageBox.Show(Loc.Get("ClassMgmt_Msg_Todo"));
        }
        private void btnCreateEmailAddresses_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectForEmails"));
                return;
            }
            List<Student> list = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, false);
            string file = "";
            string pattern = TxtEmailGenerationPattern.Text;
            string email = "";
            foreach (Student s in list)
            {
                email = pattern;
                foreach (PropertyInfo prop in s.GetType().GetProperties())
                {
                    if (pattern.Contains(prop.Name))
                    {
                        // the name of the field is in the pattern, then we have to put
                        // the value of the field il the email 
                        email = email.Replace("<" + prop.Name + ">", ((string)prop.GetValue(s)).ToLower().Trim());
                    }
                }
                file += email + "\r\n";
            }
            string nomeFile = Commons.PathDatabase + "\\" + CmbSchoolYear.Text + "_" +
                CmbClasses.SelectedItem.ToString() + "_emails.txt";
            TextFile.StringToFile(nomeFile, file, false);

            MessageBox.Show(string.Format(Loc.Get("ClassMgmt_Msg_FileGenerated"), nomeFile));
        }
        private void DgwStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwStudents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell c = DgwStudents.Rows[e.RowIndex].Cells["IdStudent"];
                Student s = Commons.bl.GetStudent((int)c.Value);
                s.SchoolYear = CmbSchoolYear.Text;
                LoadPicture(s);
            }
        }
        private void DgwStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DgwStudents.Rows[e.RowIndex].Selected = true;
            }
        }
        private void DgwStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                List<Student> ls = (List<Student>)(DgwStudents.DataSource);
                Student s = ls[e.RowIndex];
                EditStudentsData(s);
            }
        }
        private void EditStudentsData(Student Student)
        {
            Student.SchoolYear = currentClass.SchoolYear;

            frmStudent fs = new frmStudent(Student, true);
            fs.ShowDialog();

            Class c = (Class)CmbClasses.SelectedItem;
            FillClassData(c);
        }
        private void DgwClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgwClass_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 6) // column of the path; opens the folder with that path 
                {
                    Commons.ProcessStartLink(DgwClass.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }
        private void btnPhotoErase_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectForDeletePhoto"));
                return;
            }
            DataGridViewCell c = DgwStudents.SelectedRows[0].Cells["IdStudent"];
            Student s = Commons.bl.GetStudent((int)c.Value);
            Commons.bl.EraseStudentsPhoto((int)c.Value, CmbSchoolYear.Text);
            picStudent.Image = null;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtImagesOriginFolder.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtImagesOriginFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtEmailGenerationPattern_TextChanged(object sender, EventArgs e)
        {

        }
        private void lblClassData_Click(object sender, EventArgs e)
        {

        }
        private void btnStudentsInfoList_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show(Loc.Get("ClassMgmt_Msg_SelectForList"));
                return;
            }
            List<Student> list = Commons.bl.GetStudentsOfClassList((Class)CmbClasses.SelectedItem, false);
            string file = "N.registro\tCognome\tNome\tData di nascita\tLuogo di nascita\temail\tComune residenza\tIdSchoolGrades\r\n";
            foreach (Student s in list)
            {
                file += s.RegisterNumber + "\t" + s.LastName + "\t" + s.FirstName + "\t" + s.BirthDate
                    + "\t" + s.BirthPlace + "\t" + s.Email
                    + "\t" + s.City + "\t" + s.IdStudent + "\r\n";
            }
            string nomeFile = Commons.PathDatabase + "\\" + CmbSchoolYear.Text + "_" +
                CmbClasses.SelectedItem.ToString() + "_elenco.csv";
            TextFile.StringToFile(nomeFile, file, false);

            MessageBox.Show(string.Format(Loc.Get("ClassMgmt_Msg_ListGenerated"), nomeFile));
        }
        private void picStudent_Click(object sender, EventArgs e)
        {

        }
        private void btnPutNumbers_Click(object sender, EventArgs e)
        {
            int i = 1;
            foreach (Student s in (List<Student>)DgwStudents.DataSource)
            {
                if (s.Disabled != true)
                {
                    s.RegisterNumber = i.ToString();
                    i++;
                }
            }
            DgwStudents.Refresh();
        }
        private void TxtStartLinksFolder_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnPathStartLinks_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtStartLinksFolder.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtStartLinksFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void btnImportStudentsOfSomeClasses_Click(object sender, EventArgs e)
        {
            //var res = MessageBox.Show("Should we import several classes from single file " +
            //    TxtFileOfStudentsImport.Text + "?", "ATTENZIONE!",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            //if (res == DialogResult.No)
            var res = MessageBox.Show(
                string.Format(Loc.Get("ClassMgmt_Msg_ImportManyConfirm"), TxtFileOfStudentsImport.Text),
                Loc.Get("Common_Warning"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (res == DialogResult.No)
            {
                return;
            }
            if (!File.Exists(TxtFileOfStudentsImport.Text) ||
                TxtFileOfStudentsImport.Text.Substring(TxtFileOfStudentsImport.Text.Length - 1, 1) == "\\")
            {
                MessageBox.Show(
                    string.Format(Loc.Get("ClassMgmt_Msg_FileNotExists"), TxtFileOfStudentsImport.Text),
                    Loc.Get("Common_Warning"),
                    MessageBoxButtons.OK);
                return;
            }
            string[,] studentsData = TextFile.FileToMatrix(TxtFileOfStudentsImport.Text, '\t');

            string currentYear = "";
            string currentClass = "";
            string currentSchool = "";
            int idClass = 0;
            for (int iStudent = 1; iStudent < studentsData.GetLength(0); iStudent++)
            {
                if (currentYear != studentsData[iStudent, 0] || currentClass != studentsData[iStudent, 1]
                    || currentSchool != studentsData[iStudent, 16])
                {   // new class 
                    currentYear = studentsData[iStudent, 0];
                    Commons.bl.AddSchoolYearIfNotExists(new SchoolYear(currentYear));
                    currentClass = studentsData[iStudent, 1];
                    currentSchool = studentsData[iStudent, 16];
                    string classDescription = currentSchool + " " + currentYear + " " + currentClass;
                    idClass = Commons.bl.CreateClassIfNotExists(currentClass, classDescription,
                        currentYear, TxtOfficialSchoolAbbreviation.Text);
                }
                Student s = CheckIfStudentIsMultipleAndChooseWhat(studentsData, iStudent);
                s.IdClass = idClass;
                if (s.IdStudent == null)
                {
                    Commons.bl.CreateStudent(s);
                }
                Commons.bl.PutStudentInClass(s, idClass);
            }
            MessageBox.Show(Loc.Get("ClassMgmt_Msg_ImportDone"));
            this.Close();
        }
        private void btnCreateNewClass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                string.Format(Loc.Get("ClassMgmt_Msg_CreateClassConfirm"), CmbClasses.Text, CmbSchoolYear.Text),
                Loc.Get("Common_Confirm"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                != DialogResult.Yes)
            {
                return;
            }
            // check if the year exists, if it doesn't create it
            if (!Commons.bl.SchoolYearExists(CmbSchoolYear.Text))
            {
                DialogResult d = MessageBox.Show(
                        string.Format(Loc.Get("ClassMgmt_Msg_YearNotExists"), CmbSchoolYear.Text),
                        Loc.Get("Common_Information"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (d != DialogResult.Yes) return;
                SchoolYear s = new SchoolYear();
                s.IdSchoolYear = CmbSchoolYear.Text;
                s.ShortDescription = "A.S. " + CmbSchoolYear.Text;
                s.Notes = "Anno scolastico " + CmbSchoolYear.Text;
                Commons.bl.AddSchoolYearIfNotExists(s);
            }
            // give warning to avoid modifying existing class instead of making a new one
            if (Commons.bl.GetClass(currentSchool.IdSchool, idSchoolYear, CmbClasses.Text).Abbreviation != null)
            {
                MessageBox.Show(
                    string.Format(Loc.Get("ClassMgmt_Msg_ClassExists"), CmbClasses.Text),
                    Loc.Get("Common_Warning"),
                    MessageBoxButtons.OK);
                return;
            }
            if (CmbClasses.Text == "")
            {
                DialogResult d = MessageBox.Show(
                    Loc.Get("ClassMgmt_Msg_AbbrevRequired"),
                    Loc.Get("Common_Information"));
                return;
            }
            if (CmbClasses.Text.Contains(" "))
            {
                DialogResult d = MessageBox.Show(
                    Loc.Get("ClassMgmt_Msg_NoSpaces"),
                    Loc.Get("Common_Information"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (d != DialogResult.Yes) return;
            }
            Commons.bl.CreateClassIfNotExists(CmbClasses.Text, txtClassDescription.Text,
                CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, CmbSchoolYear.Text);
        }
        private void btnMosaic_Click(object sender, EventArgs e)
        {
            if (currentClass == null || currentClass.IdClass == null)
                return;
            frmMosaic f = new frmMosaic(currentClass);
            f.Show();
        }
        private void btnPeriodsManagement_Click(object sender, EventArgs e)
        {
            frmNewYear f = new frmNewYear(CmbSchoolYear.Text);
            f.ShowDialog();
            CmbClasses.DataSource = null;
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void LocalizeForm()
        {
            try
            {
                // Form Title
                this.Text = Loc.Get("ClassMgmt_Title");

                // Labels
                label4.Text = Loc.Get("ClassMgmt_SchoolCode");
                label7.Text = Loc.Get("ClassMgmt_SchoolYear");
                label1.Text = Loc.Get("ClassMgmt_ClassAbbreviation");
                label2.Text = Loc.Get("ClassMgmt_ClassDescription");
                lblClassData.Text = Loc.Get("ClassMgmt_ClassData");
                label12.Text = Loc.Get("ClassMgmt_StartLinksFolder");
                label6.Text = Loc.Get("ClassMgmt_EmailPattern");
                label11.Text = Loc.Get("ClassMgmt_EmailPattern");

                // GroupBox
                groupBox1.Text = Loc.Get("ClassMgmt_ImportGroup");
                label5.Text = Loc.Get("ClassMgmt_ImportFile");
                label9.Text = Loc.Get("ClassMgmt_PhotosFolder");

                // RadioButtons
                rdbDoNotImportPhotos.Text = Loc.Get("ClassMgmt_NoPhotos");
                rdbStudentsPhotosAlreadyPresent.Text = Loc.Get("ClassMgmt_PhotosPresent");
                rdbChooseStudentsPhotoWhileImporting.Text = Loc.Get("ClassMgmt_AskPhotos");

                // Buttons - Gestione Classe
                btnCreateNewClass.Text = Loc.Get("ClassMgmt_CreateClass");
                btnImportStudentsOfOneClass.Text = Loc.Get("ClassMgmt_ImportOneClass");
                btnImportStudentsOfSomeClasses.Text = Loc.Get("ClassMgmt_ImportManyClasses");
                btnClassErase.Text = Loc.Get("ClassMgmt_DeleteClass");
                btnPeriodsManagement.Text = Loc.Get("ClassMgmt_ManageYears");

                // Buttons - Gestione Studenti
                btnStudentNew.Text = Loc.Get("ClassMgmt_NewStudent");
                BtnStudentErase.Text = Loc.Get("ClassMgmt_DeleteStudent");
                BtnModifyStudent.Text = Loc.Get("ClassMgmt_ModifyStudent");
                btnToggleDisableStudent.Text = Loc.Get("ClassMgmt_ToggleStudent");

                // Buttons - Gestione Foto
                BtnPhotoChange.Text = Loc.Get("ClassMgmt_ChangePhoto");
                btnPhotoErase.Text = Loc.Get("ClassMgmt_DeletePhoto");
                btnChoseAmogPastPhotos.Text = Loc.Get("ClassMgmt_FindOldPhotos");

                // Buttons - Utilità
                btnPutNumbers.Text = Loc.Get("ClassMgmt_PutNumbers");
                btnMosaic.Text = Loc.Get("ClassMgmt_Mosaic");
                btnEndingPeriod.Text = Loc.Get("ClassMgmt_EndPeriod");

                // Buttons - Salvataggio
                btnSaveClassData.Text = Loc.Get("ClassMgmt_SaveClassData");
                btnSaveClassAndStudents.Text = Loc.Get("ClassMgmt_SaveAll");

                // Buttons - Report
                btnStudentsInfoList.Text = Loc.Get("ClassMgmt_StudentsList");
                btnCreateEmailAddresses.Text = Loc.Get("ClassMgmt_GenerateEmails");

                // Buttons - File Browser (mantengono "..")
                // btnFileChoose, btnPathImages, btnPathStartLinks - non necessitano localizzazione

                // ToolTips
                toolTip1.SetToolTip(DgwClass, Loc.Get("ClassMgmt_Tip_EditF2"));
                toolTip1.SetToolTip(btnSaveClassData, Loc.Get("ClassMgmt_Tip_SaveClassData"));
                toolTip1.SetToolTip(BtnStudentErase, Loc.Get("ClassMgmt_Tip_DeleteStudent"));
                toolTip1.SetToolTip(BtnModifyStudent, Loc.Get("ClassMgmt_Tip_ModifyStudent"));
                toolTip1.SetToolTip(btnEndingPeriod, Loc.Get("ClassMgmt_Tip_EndPeriod"));
                toolTip1.SetToolTip(TxtEmailGenerationPattern, Loc.Get("ClassMgmt_Tip_EmailPattern"));
                toolTip1.SetToolTip(btnCreateEmailAddresses, Loc.Get("ClassMgmt_Tip_GenerateEmails"));
                toolTip1.SetToolTip(btnImportStudentsOfOneClass, Loc.Get("ClassMgmt_Tip_ImportOne"));
                toolTip1.SetToolTip(btnStudentsInfoList, Loc.Get("ClassMgmt_Tip_StudentsList"));
                toolTip1.SetToolTip(btnPutNumbers, Loc.Get("ClassMgmt_Tip_PutNumbers"));
                toolTip1.SetToolTip(btnClassErase, Loc.Get("ClassMgmt_Tip_DeleteClass"));
                toolTip1.SetToolTip(rdbDoNotImportPhotos, Loc.Get("ClassMgmt_Tip_NoPhotos"));
                toolTip1.SetToolTip(rdbStudentsPhotosAlreadyPresent, Loc.Get("ClassMgmt_Tip_PhotosPresent"));
                toolTip1.SetToolTip(rdbChooseStudentsPhotoWhileImporting, Loc.Get("ClassMgmt_Tip_AskPhotos"));
                toolTip1.SetToolTip(btnImportStudentsOfSomeClasses, Loc.Get("ClassMgmt_Tip_ImportMany"));
                toolTip1.SetToolTip(btnCreateNewClass, Loc.Get("ClassMgmt_Tip_CreateClass"));
                toolTip1.SetToolTip(BtnPhotoChange, Loc.Get("ClassMgmt_Tip_ChangePhoto"));
                toolTip1.SetToolTip(btnPhotoErase, Loc.Get("ClassMgmt_Tip_DeletePhoto"));
                toolTip1.SetToolTip(btnChoseAmogPastPhotos, Loc.Get("ClassMgmt_Tip_FindOldPhotos"));
                toolTip1.SetToolTip(btnMosaic, Loc.Get("ClassMgmt_Tip_Mosaic"));
                toolTip1.SetToolTip(DgwStudents, Loc.Get("ClassMgmt_Tip_DoubleClick"));
                toolTip1.SetToolTip(TxtFileOfStudentsImport, Loc.Get("ClassMgmt_Tip_ImportFile"));
                toolTip1.SetToolTip(TxtImagesOriginFolder, Loc.Get("ClassMgmt_Tip_PhotosFolder"));
                toolTip1.SetToolTip(btnPeriodsManagement, Loc.Get("ClassMgmt_Tip_ManageYears"));
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmClassesManagement.LocalizeForm: {ex.Message}");
            }
        }
    }
}

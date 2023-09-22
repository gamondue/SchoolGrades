using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

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

        public frmClassesManagement()
        {
            InitializeComponent();
        }
        private void FrmClassesManagement_Load(object sender, EventArgs e)
        {
            isLoading = true;
            // school data
            currentSchool = Commons.bl.GetSchool(TxtOfficialSchoolAbbreviation.Text);

            List<SchoolYear> ly = Commons.bl.GetSchoolYearsThatHaveClasses();
            CmbSchoolYear.DataSource = ly;
            if (ly.Count > 0)
                CmbSchoolYear.SelectedItem = ly[ly.Count - 1];

            if (CmbSchoolYear.SelectedItem != null)
            {
                idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
                CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
            }
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);

            isLoading = false;
        }
        private void btnImportStudentsOfClass_Click(object sender, EventArgs e)
        {
            // give warning to avoid modifying existing class instead of making a new one
            if (Commons.bl.GetClass(currentSchool.IdSchool, idSchoolYear, CmbClasses.Text).Abbreviation != null)
            {
                MessageBox.Show("Esiste già una classe con il nome \"" + CmbClasses.Text + "\" in questa scuola ed in questo anno!", "Avviso",
                    MessageBoxButtons.OK);
                return;
            }
            if (CmbClasses.Text.Contains(" "))
            {
                DialogResult d = MessageBox.Show("E' meglio non mettere spazi nella sigla della classe." +
                    "\r\nDevo metterli lo stesso?",
                    "Informazione", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (d != DialogResult.Yes) return;
            }
            if (!File.Exists(TxtFileOfStudentsImport.Text) ||
                TxtFileOfStudentsImport.Text.Substring(TxtFileOfStudentsImport.Text.Length - 1, 1) == "\\")
            {
                MessageBox.Show("Il file \"" + TxtFileOfStudentsImport.Text + "\" non esiste!", "Avviso",
                    MessageBoxButtons.OK);
                return;
            }
            string[,] datiAllievi = TextFile.FileToMatrix(TxtFileOfStudentsImport.Text, '\t');

            int idClass;
            Class newClass = new Class(0, CmbClasses.Text, CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);

            if (!rdbChooseStudentsPhotoWhileImporting.Checked)
            {
                newClass.IdClass = Commons.bl.CreateClassAndStudents(datiAllievi, CmbClasses.Text, txtClassDescription.Text,
                CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text, rdbStudentsPhotosAlreadyPresent.Checked);
            }
            else
            {
                idClass = Commons.bl.CreateClass(CmbClasses.Text, txtClassDescription.Text,
                    CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
                for (int riga = 1; riga < datiAllievi.GetLength(0); riga++)
                {
                    Student s = Commons.bl.CreateStudentFromStringMatrix(datiAllievi, riga);
                    if (s.IdStudent > 0)
                    {
                        Commons.bl.PutStudentInClass(s.IdStudent, idClass);
                        if (rdbChooseStudentsPhotoWhileImporting.Checked)
                        {
                            using (OpenFileDialog dlg = new OpenFileDialog())
                            {
                                dlg.Title = "Scegli una foto dello studente " + datiAllievi[riga, 1] + " " +
                                    datiAllievi[riga, 2] + ", " + CmbClasses.Text + " " + CmbSchoolYear.Text;
                                dlg.Filter = "jpg files (*.jpg)|*.jpg";
                                dlg.InitialDirectory = TxtImagesOriginFolder.Text;
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    Student s1 = new Student();
                                    s1.IdStudent = s.IdStudent;
                                    s1.LastName = datiAllievi[riga, 1];
                                    s1.FirstName = datiAllievi[riga, 2];
                                    Commons.bl.CopyAndLinkOnePhoto(s1, newClass, dlg.FileName);
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Importazione terminata");
            this.Close();
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
            idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }
        private void btnClassErase_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere in 'Sigla classe' una classe da cancellare");
                return;
            }
            DialogResult res = MessageBox.Show("ATTENZIONE: eliminazione della classe " + CmbClasses.Text
                + " dell'anno " + CmbSchoolYear.Text
                + ". \r\nDevo eliminare solo la classe (Sì) o anche gli studenti (No)?\r\nScegliere 'Annulla' per non eliminare", "ATTENZIONE!",
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
            if (!isLoading)
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

                studentsList = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                    idSchoolYear, CmbClasses.Text, true);
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
                        picStudent.Image.Dispose();
                    Application.DoEvents();
                    Thread.Sleep(1500);

                    System.Drawing.Image newImage = System.Drawing.Image.FromFile(newPhotoFullName);
                    picStudent.Image = newImage;

                    Application.DoEvents();
                    Thread.Sleep(1500);
                    //picStudent.Image = null;

                    ////picStudent.Image.Dispose();

                    //Application.DoEvents();
                    //if (picStudent.InitialImage != null)
                    //    picStudent.InitialImage.Dispose();
                    //picStudent.InitialImage = null;
                    //picStudent.Update();
                    //Application.DoEvents();
                    //picStudent.Refresh();
                    //Thread.Sleep(1500);

                    Commons.bl.CopyAndLinkOnePhoto(s, currentClass, newPhotoFullName);
                    s.SchoolYear = CmbSchoolYear.Text;
                    LoadPicture(s);
                }
            }
            else
            {
                MessageBox.Show("Scegliere un allievo cui cambiare la foto");
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
        private void btnNewYear_Click(object sender, EventArgs e)
        {
            frmNewYear f = new frmNewYear(idSchoolYear);
            f.ShowDialog();
            CmbClasses.DataSource = null;
            CmbClasses.DataSource = Commons.bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }
        private void btnStudentNew_Click(object sender, EventArgs e)
        {
            if (CmbClasses.Text == "")
            {
                MessageBox.Show("Scegliere una classe");
                return;
            }
            frmStudent sf = new frmStudent(null, true);
            sf.ShowDialog();
            if (sf.UserHasChosen)
            {
                Commons.bl.PutStudentInClass(sf.CurrentStudent.IdStudent,
                    ((Class)(CmbClasses.SelectedItem)).IdClass);
                DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                    idSchoolYear, CmbClasses.Text, false);
            }
            else
            {
                MessageBox.Show("Studente non aggiunto alla classe \n(premere 'Scegli' nella finestra appena chiusa)");
            }
        }
        private void btnStudentErase_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare nella griglia un allievo da cancellare");
                return;
            }
            string deletingStudent = (string)DgwStudents.SelectedRows[0].Cells["LastName"].Value +
                " " + (string)DgwStudents.SelectedRows[0].Cells["FirstName"].Value;
            if (MessageBox.Show("Devo eliminare l'allievo " + deletingStudent + "?" +
                "\r\nL'allievo verrà solo eliminato dalla classe e mantenuto nel database",
                "Conferma", MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;
            int IdDeletingStudent = (int)DgwStudents.SelectedRows[0].Cells["IdStudent"].Value;
            Commons.bl.DeleteOneStudentFromClass(IdDeletingStudent,
                ((Class)(CmbClasses.SelectedItem)).IdClass);
            DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                idSchoolYear, CmbClasses.Text, false);
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
                MessageBox.Show("Selezionare nella griglia un allievo di cui cambiare lo stato di attivazione");
                return;
            }
            Student disablingStudent = studentsList[DgwStudents.SelectedCells[0].RowIndex];
            Commons.bl.ToggleDisabledFlagOneStudent(disablingStudent);
            DgwStudents.DataSource = null;
            DgwStudents.DataSource = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text,
                idSchoolYear, CmbClasses.Text, true);
            string prompt = "Commutato lo stato di abilitazione dell'allievo " + disablingStudent;
            // !!!! dire in che stato è ora 
            // prompt += ".\nStato attuale: "
            MessageBox.Show(prompt);
        }
        private void btnModifyStudent_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count < 1)
            {
                MessageBox.Show("Selezionare lo studente da modificare");
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
            MessageBox.Show("TO DO!");
        }
        private void btnCreateEmailAddresses_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe per cui generare gli indirizzi email");
                return;
            }
            List<Student> list = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, CmbSchoolYear.Text,
                CmbClasses.SelectedItem.ToString(), false);
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

            MessageBox.Show("Ho generato il file " + nomeFile);
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
                MessageBox.Show("Selezionere l'allievo del quale eliminare la foto");
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
                MessageBox.Show("Scegliere la classe per cui generare l'elenco su file");
                return;
            }
            List<Student> list = Commons.bl.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, CmbSchoolYear.Text,
                CmbClasses.SelectedItem.ToString(), false);
            string file = "N.registro\tCognome\tNome\tData di nascita\tLuogo di nascita\temail\tComune residenza\tIdSchoolGrades\r\n";
            foreach (Student s in list)
            {
                file += s.RegisterNumber + "\t" + s.LastName + "\t" + s.FirstName + "\t" + s.BirthDate
                    + "\t" + s.BirthPlace + "\t" + s.Email
                    + "\t" + s.Residence + "\t" + s.IdStudent + "\r\n";
            }
            string nomeFile = Commons.PathDatabase + "\\" + CmbSchoolYear.Text + "_" +
                CmbClasses.SelectedItem.ToString() + "_elenco.csv";
            TextFile.StringToFile(nomeFile, file, false);

            MessageBox.Show("Ho generato il file " + nomeFile);
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
    }
}

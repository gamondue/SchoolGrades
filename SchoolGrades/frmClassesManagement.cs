using gamon;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class FrmClassesManagement : Form
    {
    	// TODO !!!! put an option for separator in import files 
        DbAndBusiness db;
        BusinessLayer bl; 

        DataSet dsClass;
        DataTable dtClass;

        School currentSchool; 
        Class currentClass;
        string idSchoolYear; 

        public FrmClassesManagement()
        {
            InitializeComponent();

            db = new DbAndBusiness(Commons.PathAndFileDatabase);
            bl = new BusinessLayer(Commons.PathAndFileDatabase);
        }

        private void FrmClassesManagement_Load(object sender, EventArgs e)
        {
            // school data
            currentSchool = db.GetSchool(TxtOfficialSchoolAbbreviation.Text);
            // primo anno di default del combo con gli anni
            int anno = 2009;

            for (; anno <= DateTime.Now.Year; anno++)
            {
                CmbSchoolYear.Items.Add((anno - 2000).ToString("00") + ((anno + 1) - 2000).ToString("00"));
            }
            int nAnni = CmbSchoolYear.Items.Count;
            if (DateTime.Now.Month >= 9)
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 1];
            else
                CmbSchoolYear.SelectedItem = CmbSchoolYear.Items[nAnni - 2];
            idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
            CmbClasses.DataSource = bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }

        private void BtnImportStudentsOfClass_Click(object sender, EventArgs e)
        {
            // give warning to avoid modifying existing class instead of making a new one
            if (db.GetClass(currentSchool.IdSchool, idSchoolYear, CmbClasses.Text).Abbreviation != null)
            {
                MessageBox.Show("Esiste già una classe con il nome \"" + CmbClasses.Text + "\" in questo anno!", "Avviso", 
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

            if (!RdbPhotoUserChoosen.Checked)
            {
                newClass.IdClass = db.CreateClassAndStudents(datiAllievi, CmbClasses.Text, TxtClassDescription.Text,
                CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text,RdbPhotoAlreadyPresent.Checked);
            }
            else
            {
                idClass = db.CreateClass(CmbClasses.Text, TxtClassDescription.Text,
                    CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
                for (int riga = 1; riga < datiAllievi.GetLength(0); riga++)
                {
                    int codiceStudente = db.CreateStudentFromStringMatrix(datiAllievi, riga);
                    if (codiceStudente > 0)
                    {
                        db.PutStudentInClass(codiceStudente, idClass);
                        if (rdbChooseStudentsPhotoWhileImporting.Checked)
                        {
                            using (OpenFileDialog dlg = new OpenFileDialog())
                            {
                                dlg.Title = "Scegli una foto dello studente " + datiAllievi[riga, 1] + " " +
                                    datiAllievi[riga, 2] + ", " + CmbClasses.Text + " " + CmbSchoolYear.Text;
                                dlg.Filter = "jpg files (*.jpg)|*.jpg";
                                dlg.InitialDirectory = TxtPathImages.Text;
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    Student s = new Student();
                                    s.IdStudent = codiceStudente;
                                    s.LastName = datiAllievi[riga, 1];
                                    s.FirstName = datiAllievi[riga, 2];
                                    db.CopyAndLinkOnePhoto(s, newClass, dlg.FileName);
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Importazione terminata");
            this.Close(); 
        }

        private void BtnFileChoose_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(TxtFileOfStudentsImport.Text+ "\\");
            DialogResult r = openFileDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtFileOfStudentsImport.Text = openFileDialog.FileName;
            }
        }

        private void BtnPathImages_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtPathImages.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathImages.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void CmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            idSchoolYear = CmbSchoolYear.SelectedItem.ToString();
            CmbClasses.DataSource = bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }

        private void BtnClassErase_Click(object sender, EventArgs e)
        {
            if (currentClass==null)
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
                db.EraseAllStudentsOfAClass(currentClass);
            }
            // eliminazione della classe 
            db.EraseClassFromClasses(currentClass);

            this.Close(); 
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class c = (Class)CmbClasses.SelectedItem;
            if (c != null)
            {
                FillClassData(c);
            }
        }

        private void CmbClasses_TextChanged(object sender, EventArgs e)
        {
            // !!!! written by the user. It should be fired only when the text part of the combo is manually modified for the first time 
            TxtClassDescription.Text = currentSchool.Name + " " + CmbSchoolYear.Text +
                " " + CmbClasses.Text;
        }

        private void FillClassData(Class Class)
        {
            dtClass = db.GetClassTable(Class.IdClass);
            DgwClass.DataSource = dtClass;

            //dgwAllievi.DataSource = db.GetClass(txtOfficialSchoolAbbreviation.Text, idSchoolYear, cmbClasses.Text);
            DgwStudents.DataSource = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, 
                idSchoolYear, CmbClasses.Text, true);
            TxtClassDescription.Text = SafeDb.SafeString(DgwClass.Rows[DgwClass.CurrentRow.Index].Cells["desc"].Value);
            currentClass = (Class)CmbClasses.SelectedItem;
            TxtStartLinksFolder.Text = currentClass.PathRestrictedApplication; 
        }

        private void BtnPhotoChange_Click(object sender, EventArgs e)
        {
            //if(picStudent.Image != null)
            //{
            //    picStudent.Image = null;
            //    MessageBox.Show("Premere ancora.."); 
            //    return; 
            //}
            // to free the lock on the picture we have to substitute by erasing the picture box
            ////////string fileTemp = Commons.PathImages + "\\" + "TEMP.png";
            //////////if (!File.Exists(fileTemp))
            //////////    File.Copy(fileToCopy, fileTemp);
            ////////picStudent.Image = System.Drawing.Image.FromFile(fileTemp);
            picStudent.Invalidate();
            picStudent.Refresh();
            picStudent.Update();
            Application.DoEvents();
            if (picStudent.Image != null)
            {
                picStudent.Image.Dispose();
            }
            Thread.Sleep(500);

            if (DgwStudents.SelectedCells.Count > -1)
            {
                List<Student> ls = (List<Student>)DgwStudents.DataSource;
                Student s = ls[DgwStudents.SelectedCells[0].RowIndex];
                DialogResult dr = openFileDialog.ShowDialog();
                if (openFileDialog.FileName != "" && !(dr == DialogResult.Cancel))
                {
                    string fileToCopy = openFileDialog.FileName; 
                    db.CopyAndLinkOnePhoto(s, currentClass, openFileDialog.FileName);
                    s.SchoolYear = CmbSchoolYear.Text; 
                    LoadPicture(s); 
                }
            }
            else
            {
                MessageBox.Show("Scegliere un allievo cui cambiare la foto"); 
            }
        }

        //string temp = "TEMP"; 
        private void LoadPicture(Student StudentToLoad)
        {
            try
            //{
            //    string filePathAndName = Commons.PathImages + "\\" +
            //        db.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear);

            //    //string fileTemp = Path.GetDirectoryName(filePathAndName) + "\\" + temp + 
            //    //    Path.GetExtension(filePathAndName);
            //    picStudent.Image = System.Drawing.Image.FromFile(filePathAndName);

            //    //File.Copy(filePathAndName, fileTemp, true);
            //    //picStudent.Image = System.Drawing.Image.FromFile(fileTemp);
            //    //if (temp == "TEMP")
            //    //    temp = "TEMP1";
            //    //else
            //    //    temp = "TEMP";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    picStudent.Image = null;
            //    //picStudent.Invalidate();
            //    //picStudent.Refresh();
            //    //picStudent.Update();
            //    //if (picStudent.Image != null)
            //    //{
            //    //    picStudent.Image.Dispose();
            //    //}
            //}
            {
                string filePathAndName = Commons.PathImages + "\\" +
                    db.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear);

                //string fileTemp = Path.GetDirectoryName(filePathAndName) + "\\" + temp + 
                //    Path.GetExtension(filePathAndName);
                picStudent.Image = System.Drawing.Image.FromFile(filePathAndName);
                picStudent.Visible = true;
                //picStudent.Image = System.Drawing.Image.FromFile(Commons.PathImages + "\\" +
                //    db.GetFilePhoto(StudentToLoad.IdStudent, StudentToLoad.SchoolYear));

                //File.Copy(filePathAndName, fileTemp, true);
                //picStudent.Image = System.Drawing.Image.FromFile(fileTemp);
                //if (temp == "TEMP")
                //    temp = "TEMP1";
                //else
                //    temp = "TEMP";
            }
            catch (Exception ex)
            {
                picStudent.Image = null;
                Console.Beep();
            }
        }

        private void BtnNewYear_Click(object sender, EventArgs e)
        {
            frmNewYear f = new frmNewYear(idSchoolYear);
            f.ShowDialog();
            CmbClasses.DataSource = null; 
            CmbClasses.DataSource = bl.GetClassesOfYear(TxtOfficialSchoolAbbreviation.Text, idSchoolYear);
        }

        private void BtnStudentNew_Click(object sender, EventArgs e)
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
                db.PutStudentInClass(sf.CurrentStudent.IdStudent,
                    ((Class)(CmbClasses.SelectedItem)).IdClass);
                DgwStudents.DataSource = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, 
                    idSchoolYear, CmbClasses.Text, false);
            }
        }

        private void BtnStudentErase_Click(object sender, EventArgs e)
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
            db.DeleteOneStudentFromClass(IdDeletingStudent,
                ((Class)(CmbClasses.SelectedItem)).IdClass);
            DgwStudents.DataSource = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, 
                idSchoolYear, CmbClasses.Text, false);
        }

        private void BtnSaveClassData_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = DgwClass.Rows[0];
            int? idClass = ((Class)CmbClasses.SelectedItem).IdClass; 
            Class c = new Class(idClass, CmbClasses.Text, CmbSchoolYear.Text, TxtOfficialSchoolAbbreviation.Text);
            //c.Description= SafeDb.SafeString(dgr.Cells["desc"].Value);
            c.Description = TxtClassDescription.Text;  
            c.UriWebApp = SafeDb.SafeString(dgr.Cells["uriWebApp"].Value);
            c.PathRestrictedApplication = SafeDb.SafeString(dgr.Cells["pathRestrictedApplication"].Value);

            db.SaveClass(c);
            db.SaveStudentsOfList((List<Student>) DgwStudents.DataSource, null);  

            FillClassData(c); 
        }

        private void BtnToggleDisableStudent_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare nella griglia un allievo di cui cambiare lo stato di attivazione");
                return;
            }
            string disablingStudent = (string)DgwStudents.SelectedRows[0].Cells["LastName"].Value +
                " " + (string)DgwStudents.SelectedRows[0].Cells["FirstName"].Value;
            int IdDisablingStudent = (int)DgwStudents.SelectedRows[0].Cells["IdStudent"].Value;
            db.ToggleDisableOneStudent(IdDisablingStudent);
            DgwStudents.DataSource = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, 
                idSchoolYear, CmbClasses.Text, true);
            string prompt = "Commutato lo stato di abilitazione dell'allievo " + disablingStudent;
            // !!!! dire in che stato è ora 
            // prompt += ".\nStato attuale: "
            MessageBox.Show(prompt); 
        }

        private void BtnModifyStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO!"); 
        }

        private void BtnEndingPeriod_Click(object sender, EventArgs e)
        {
            // make a csv file with all grades and averages 
            MessageBox.Show("TO DO!"); 
        }

        private void DgwStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgwStudents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell c = DgwStudents.Rows[e.RowIndex].Cells["IdStudent"];
                Student s = db.GetStudent((int)c.Value);
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
                s.SchoolYear = currentClass.SchoolYear;

                frmStudent fs = new frmStudent(s, true);
                fs.ShowDialog();

                Class c = (Class)CmbClasses.SelectedItem;
                FillClassData(c);
            }
        }
        private void BtnCreateEmailAddresses_Click(object sender, EventArgs e)
        {
            if (currentClass == null)
            {
                MessageBox.Show("Scegliere la classe per cui generare gli indirizzi email");
                return;
            }
            List<Student> list = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, CmbSchoolYear.Text,
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

        private void BtnPhotoErase_Click(object sender, EventArgs e)
        {
            if (DgwStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionere l'allievo del quale eliminare la foto");
                return; 
            }
            DataGridViewCell c = DgwStudents.SelectedRows[0].Cells["IdStudent"];
            Student s = db.GetStudent((int)c.Value);
            db.EraseStudentsPhoto((int)c.Value, CmbSchoolYear.Text);
            picStudent.Image = null; 
        }
        private void button15_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TxtPathImages.Text;
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                TxtPathImages.Text = folderBrowserDialog.SelectedPath;
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

        private void label10_Click(object sender, EventArgs e)
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
            List<Student> list = db.GetStudentsOfClassList(TxtOfficialSchoolAbbreviation.Text, CmbSchoolYear.Text,
                CmbClasses.SelectedItem.ToString(), false);
            string file = "N.registro\tCognome\tNome\tData di nascita\tLuogo di nascita\temail\tComune residenza\tIdSchoolGrades\r\n";
            foreach (Student s in list)
            {
                file += s.RegisterNumber + "\t" + s.LastName + "\t" + s.FirstName + "\t" + s.BirthDate 
                    + "\t" + s.BirthPlace + "\t" + s.Email 
                    + "\t" + s.Residence + "\t" + s.IdStudent +"\r\n";
            }
            string nomeFile = Commons.PathDatabase + "\\" + CmbSchoolYear.Text + "_" +
                CmbClasses.SelectedItem.ToString() + "_elenco.csv";
            TextFile.StringToFile(nomeFile, file, false);

            MessageBox.Show("Ho generato il file " + nomeFile);
        }

        private void picStudent_Click(object sender, EventArgs e)
        {

        }
    }
}

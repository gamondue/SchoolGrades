using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    public partial class frmClassifica : Form
    {
        Class c;
        public List<Student> lista;

        public frmClassifica(Class C, List<Student> Lista)
        {
            InitializeComponent();

            MessageBox.Show("Programma da aggiustare!!!!");
            return;
            //lista = Lista;
            //Student[] ordinata = (Student[]) lista.Clone();

            //    for (int i = 0; i < ordinata.Length - 1; i++)
            //    {
            //        c = C;
            //        // ricerca del minimo
            //        float media = ordinata[i].Media;
            //        if (float.IsNaN(media)) media = float.MinValue; // attenzione: media == float.NaN non funziona!
            //        float min = media;
            //        int indMin = i;
            //        for (int j = i + 1; j < ordinata.Length; j++)
            //        {
            //            media = ordinata[j].Media; 
            //            if (float.IsNaN (media)) media = float.MinValue;
            //            if (min > media)
            //            {
            //                min = media;
            //                indMin = j;
            //            }
            //        }
            //        // scambio
            //        Student temp = ordinata[indMin];
            //        ordinata[indMin] = ordinata[i];
            //        ordinata[i] = temp;
            //    }
            //    foreach (Student all in ordinata)
            //    {
            //        lstClassifica.Items.Add(all.LastName + " " + all.FirstName + " | " + all.Media + " | "); //+ all.NumeroChiamate);
            //    }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            string fil = "";
            foreach (object riga in lstClassifica.Items)
            {
                fil += riga.ToString() + "\n";
            }
            //string nomeFile = DateTime.Now.ToString("yyyy-MM-dd") + " " + c.NomeFile.Replace("Lista", "Classifica");
            string nomeFile = c.FileName.Replace("Lista", "Classifica");
            gamon.TextFile.StringToFile(nomeFile, fil, false);
        }
    }
}
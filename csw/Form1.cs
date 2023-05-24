using System;
using System.IO;
using System.Windows.Forms;

namespace csw
{
    public partial class Form1 : Form
    {


        public struct punto1
        {
            public string r;
            public string anni;
            public string stalli;
            public string Casual;
        }
        public int ncampi;
        public int lunghmax;
        public punto1[] p;

        public int dim;

        public string path;
        public Form1()
        {
            InitializeComponent();
            path = Path.GetFullPath("..\\..\\..\\files\\caslini.csv");
            dim = 0;
            p = new punto1[200];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta();
            MessageBox.Show("è stato aggiunto il campo  ");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("il numero di campi è " + Contacampi().ToString());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunghezzaMaxRecord().ToString());
        }



        public void Aggiunta(char sep = ';')
        {
            string []linea=File.ReadAllLines(path);
            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    Random r = new Random();
                    linea[0] += ";miovalore";
                    sw.WriteLine(linea[0]);
                    for(int i = 1; i < linea.Length; i++)
                    {
                        linea[i] += sep + r.Next(10, 21).ToString();
                        sw.WriteLine(linea[i]);
                    }
                }
            }
        }

        public int Contacampi(char sep = ';')
        {
            string[]linea=File.ReadAllLines(path);
            ncampi = linea[0].Split(sep).Length;
            return ncampi;
        }

        public int Lunghezza(char sep = ';')
        {
            string[] linea = File.ReadAllLines(path);

            for(int i = 0; i < linea.Length; i++)
            {
                string[]campi=linea[i].Split(sep);
                for (int j = 0; j < ncampi; j++)
                {
                    if (campi[j].Length > lunghmax)
                    {
                        lunghmax = campi[j].Length;

                    }
                    if (campi[j].Length == 0)
                    {
                        break;
                    }
                }
            }
            return lunghmax;
        }

        public int LunghezzaMaxRecord(char a = ';')
        {
            string[] record =File.ReadAllLines(path);
            for(int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(a);
                for (int j = 0; j < Contacampi(); j++)
                {
                    if (campi[j].Length > lunghmax)
                    {
                        lunghmax = campi[j].Length;
                    }
                    if (campi[j].Length == 0)
                    {
                        break;
                    }
                }

            }
            return lunghmax;
        }




    }

}

using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public string cancellato;
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

        private void numerospazibutttonclick(object sender, EventArgs e)
        {
            NumeroSpazi();

        }

        private void visualizzabuttonclick(object sender, EventArgs e)
        {
            Visualizza();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AggiuntaCoda(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("fatto");
        }

        private void button7_Click_1(object sender, EventArgs e)
    {
        MessageBox.Show(ricerca());
    }
        private void button8_Click(object sender, EventArgs e)
        {

        }


        public void Aggiunta(char sep = ';')
    {
        string[] linea = File.ReadAllLines(path);
        if (File.Exists(path))
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                Random r = new Random();
                linea[0] += ";miovalore";
                sw.WriteLine(linea[0]);
                for (int i = 1; i < linea.Length; i++)
                {
                    linea[i] += sep + r.Next(10, 21).ToString();
                    sw.WriteLine(linea[i]);
                }
            }
        }
    }

        public int Contacampi(char sep = ';')
    {
        string[] linea = File.ReadAllLines(path);
        ncampi = linea[0].Split(sep).Length;
        return ncampi;
    }

        public int Lunghezza(char sep = ';')
    {
        string[] linea = File.ReadAllLines(path);

        for (int i = 0; i < linea.Length; i++)
        {
            string[] campi = linea[i].Split(sep);
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
        string[] record = File.ReadAllLines(path);
        for (int i = 0; i < record.Length; i++)
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

        public void NumeroSpazi(char a = ';')
    {
        string[] record = File.ReadAllLines(path);
        using (StreamWriter sw = new StreamWriter(path))
        {
            for (int i = 0; i < record.Length; i++)
            {
                record[i] = record[i].PadRight(200);
                sw.WriteLine(record[i]);
            }
        }

    }

        public void Visualizza()
    {
        dataGridView1.Rows.Clear();
        string[] record = File.ReadAllLines(path);
        for (int i = 0; i < record.Length; i++)
        {
            string[] campi = record[i].Split(';');
            if (campi[1] == "")
            {
                dataGridView1.Rows.Add(campi[0]);
            }
            else
            {
                dataGridView1.Rows.Add(campi[0], campi[1], campi[2]);
            }
        }
    }
        public void AggiuntaCoda(string coda1, string coda2, string coda3, char a = ',')
    {
        if (File.Exists(path))
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(coda1 + a + coda2 + a + coda3 + a);
            }
        }
        else
        {
            MessageBox.Show("Non esiste il file");
        }


    }

        public string ricerca()
    {
        string[] record = File.ReadAllLines(path);
        for (int i = 0; i < record.Length; i++)
        {
            string[] campi = record[i].Split(';');
            if (checkBox1.Checked == true)
            {
                if (campi[0].ToLower() == textBox1.Text.ToLower())
                {
                    return record[i];

                }
                if (checkBox2.Checked == true)
                {
                    if (campi[1].ToLower() == textBox2.Text.ToLower())
                    {
                        return record[i];

                    }
                }
                if (checkBox3.Checked == true)
                {
                    if (campi[2].ToLower() == textBox2.Text.ToLower())
                    {
                        return record[i];
                    }
                }
            }

        }
        return "";
    }


        public bool cancellazioneLogica(string cancellato ) 
        {
            bool canc= false;
            string[]linee=File.ReadAllLines(path);
            using(StreamWriter sw = new StreamWriter(path))
            {
                for(int i= 0; i < linee.Length; i++)
                {
                    string[] campi = linee[i].Split(';');
                    if(cancellato.ToLower() == campi[0].ToLower())
                    {
                        campi[ncampi - 1] = "1";
                        linee[i]=String.Join(";", campi);
                        canc = true;

                        break;
                    }
                }
                for(int i= 0; i < linee.Length; i++)
                {
                    sw.WriteLine(linee[i]);
                }
            }
            return canc;

        }

        

       private void textBox1_TextChanged(object sender, EventArgs e)
       {

       }


    } 
}


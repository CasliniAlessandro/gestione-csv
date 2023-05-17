using System;
using System.IO;
using System.Windows.Forms;

namespace csw
{
    public partial class Form1 : Form
    {
        public string path;
        public Form1()
        {
            InitializeComponent();
            path = Path.GetFullPath("..\\..\\..\\files\\caslini.csv");
            
        }
    }
}

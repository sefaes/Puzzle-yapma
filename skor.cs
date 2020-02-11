using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlabpuzzle
{
    public partial class skor : Form
    {
        public skor()
        {
            InitializeComponent();
        }

        private void skor_Load(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText(@"C:\abcdef.txt");
            string metin;
            while ((metin = sr.ReadLine()) != null)
            {
                sk.Items.Add(metin);
                

            }

            sr.Close();

        }
    }
}

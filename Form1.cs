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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image res;
        OpenFileDialog openFileDialog = null;
        PictureBox box = null;
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog == null)

                openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {

                res = dzenle(Image.FromFile(openFileDialog.FileName));

                if (box == null)
                {
                    box = new PictureBox();
                    box.Height = resBox.Height;
                    box.Width = resBox.Width;
                    resBox.Controls.Add(box);

                }

                box.Image = res;
            }
            
        }

        private void dosyaYaz(string a,string b)
        {

            string dosya_yolu = @"C:\abcdef.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(a);
            sw.Write("=");
            sw.WriteLine(b);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        private bool karKont()
        {
            int a = 0;
            for (int i = 0; i < 16; i++)
            {
                
                if (((hallet)buton[i]).ResYer == ((hallet)buton[i]).Yer)
                {
                    return true;
                }

                else if(((hallet)buton[i]).ResYer != ((hallet)buton[i]).Yer)
                {
                    a++;
                    if (a == 16)
                    {

                        return false;
                    }
                }


            }

            return true;



        }

        private bool tampuan()
        {
            int a = 0;
            for (int i = 0; i < 16; i++)
            {

                if (((hallet)buton[i]).ResYer == ((hallet)buton[i]).Yer)
                {
                    a++;
                }

               

            }
            if (a < 16)
            {

                return false;
            }

            return true;
        }


        private bool btt() {

            for (int i = 0; i < 16; i++)
            {

                if (((hallet)buton[i]).ResYer != ((hallet)buton[i]).Yer)
                {
                    return false;
                }

               

            }
            return true;

        }

        int c = 0;
        hallet aBas = null;
        hallet bSon = null;
        public void tık(object sender,EventArgs e)
        {
            if (aBas == null)
            {
                aBas = (hallet)sender;
                aBas.BorderStyle = BorderStyle.Fixed3D;

               
              
            }

            else if (bSon == null)
            {
                bSon = (hallet)sender;
                aBas.BorderStyle = BorderStyle.Fixed3D;
                bSon.BorderStyle = BorderStyle.FixedSingle;
                yerDegs(aBas, bSon);

                aBas = null;
                bSon = null;
                c++;
            }
          
            la.Text = Convert.ToString(c); 

        }

        private void yerDegs(hallet k1,hallet k2)
        {


           
            int dg = k2.ResYer;
            k2.Image = resim[k1.ResYer];
            k2.ResYer = k1.ResYer;
            k1.Image = resim[dg];
            k1.ResYer = dg;

            if (btt())
            {

                MessageBox.Show("Puzzle Tamamlandı");


                dosyaYaz(kAd.Text, (99-c).ToString());


            }
        }

        private Bitmap dzenle(Image res)
        {

            Bitmap bmpImage = new Bitmap( resBox.Width, resBox.Height);
            Graphics grapImage = Graphics.FromImage(bmpImage);
            grapImage.Clear(Color.White);
            grapImage.DrawImage(res, new Rectangle(0, 0, resBox.Width, resBox.Height));
            grapImage.Flush();
            return bmpImage;
        }


        private void BitmapDzen(Image res,Image [] resim,int index,int numRow,int numCol,int unitX,int unitY )
        {
            resim[index] = new Bitmap(unitX, unitY);
            Graphics grap = Graphics.FromImage(resim[index]);
            grap.Clear(Color.White);
            grap.DrawImage(res, new Rectangle(0, 0, unitX, unitY), new Rectangle(unitX * (index % numCol), unitY * (index / numCol), unitX, unitY), GraphicsUnit.Pixel);
            grap.Flush();
          
        }

        private void karıs(ref int[] dz)
        {
            Random x = new Random();
            int a = dz.Length;
            while (a>1)
            {
                int b = x.Next(a);
                a--;
                int tmp = dz[a];
                dz[a] = dz[b];
                dz[b] = tmp;


            }
           

        }
        PictureBox[] buton = null;
        Image[] resim = null;
        
        private void button2_Click(object sender, EventArgs e)
        {

            if (kAd.Text == "")
            {

                MessageBox.Show("Lütfen kullanıcı Adı giriniz");

            }




            int dgm = 16;
            c = 0;
            if (box != null)
                {
                    resBox.Controls.Remove(box);
                    box.Dispose();
                    box = null;


                }
           
            if (buton == null || buton.Length != dgm)
             {
                 resim = new Image[16];
                 buton = new PictureBox[16];
                
                
            }
          

           

            int numRow = (int)Math.Sqrt(dgm);
                int numCol = numRow;
                int unitX = resBox.Width / numRow;
                int unitY = resBox.Height / numCol;
                int[] l = new int[dgm];
                for (int i = 0; i < dgm; i++)
                {
                    l[i] = i;
                if (buton[i] == null)
                {
                    buton[i] = new hallet();

                    buton[i].Click += new EventHandler(tık);
                }
                    buton[i].BorderStyle = BorderStyle.Fixed3D;
                    buton[i].Width = unitX;
                    buton[i].Height = unitY;
                    ((hallet)buton[i]).Yer = i;
                    BitmapDzen(res, resim, i, numRow, numCol, unitX, unitY);
              
                    buton[i].Location = new Point(unitX * (i % numCol), unitY * (i / numCol));

                    if (!resBox.Controls.Contains(buton[i]))

                        resBox.Controls.Add(buton[i]);

                }
            
            karıs(ref l);
                for (int i = 0; i < dgm; i++)
                {
                    buton[i].Image = resim[l[i]];
                    ((hallet)buton[i]).ResYer = l[i];
                }
            
            if (!karKont())
            {

                MessageBox.Show("Parçaların hepsi farklı yerde yeniden karıştıra basın");

            }

            if (tampuan())
            {

                MessageBox.Show("Tebrikler tam puan sanşlısınız");

            }
            string g = "asdasdasdbbbbb";
            
        }
        private void resBox_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           skor f = new skor();
            f.Show();
            
        }
    }
}

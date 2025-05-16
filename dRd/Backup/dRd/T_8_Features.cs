using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;



namespace dRd
{
    public partial class T_8_Features : Form
    {
        private Image _originalImage;
        private bool _selecting;
        private Rectangle _selection;
        private Image Img;
        private Size OriginalImageSize;
        private Size ModifiedImageSize;
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        public bool Makeselection = false;
        public bool CreateText = false;
        public T_8_Features()
        {
            InitializeComponent();
               picMRI.Image = (Image)Program.resized;
            PictureBox1.Image = (Image)Program.resized;
        }
          private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (splitContainer1.Panel1.Width > PictureBox1.Width)
            {
                _x = (splitContainer1.Panel1.Width - PictureBox1.Width) / 2;
            }
            if (splitContainer1.Panel1.Height > PictureBox1.Height)
            {
                _y = (splitContainer1.Panel1.Height - PictureBox1.Height) / 2;
            }
            PictureBox1.Location = new Point(_x, _y);
        }

          private void button4_Click(object sender, EventArgs e)
          {
              try
              {
                  if (cropWidth < 1)
                  {
                      return;
                  }
                  Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                  //First we define a rectangle with the help of already calculated points
                  Bitmap OriginalImage = new Bitmap(PictureBox1.Image, PictureBox1.Width, PictureBox1.Height);
                  //Original image
                  Bitmap _img = new Bitmap(cropWidth, cropHeight);
                  // for cropinf image
                  Graphics g = Graphics.FromImage(_img);
                  // create graphics
                  g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                  g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                  g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                  //set image attributes
                  g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                  PictureBox1.Image = _img;
                  PictureBox1.Width = _img.Width;
                  PictureBox1.Height = _img.Height;
                  PictureBoxLocation();

              }
              catch (Exception ex)
              {
              }
          }

          private void button3_Click(object sender, EventArgs e)
          {
              Makeselection = true;
          }

          private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
          {
              Cursor = Cursors.Default;
              if (Makeselection)
              {

                  try
                  {
                      if (e.Button == System.Windows.Forms.MouseButtons.Left)
                      {
                          Cursor = Cursors.Cross;
                          cropX = e.X;
                          cropY = e.Y;

                          cropPen = new Pen(Color.Yellow, 1);
                          cropPen.DashStyle = DashStyle.DashDotDot;


                      }
                      PictureBox1.Refresh();
                  }
                  catch (Exception ex)
                  {
                  }
              }
          }

          private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
          {

              Cursor = Cursors.Default;
              if (Makeselection)
              {

                  try
                  {
                      if (PictureBox1.Image == null)
                          return;


                      if (e.Button == System.Windows.Forms.MouseButtons.Left)
                      {
                          PictureBox1.Refresh();
                          cropWidth = e.X - cropX;
                          cropHeight = e.Y - cropY;
                          PictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                      }



                  }
                  catch (Exception ex)
                  {

                  }
              }
          }

          private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
          {
              if (Makeselection)
              {
                  Cursor = Cursors.Default;

              }
          }

          private void button2_Click(object sender, EventArgs e)
          {


              int width = Convert.ToInt32(PictureBox1.Image.Width);
              int height = Convert.ToInt32(PictureBox1.Image.Height);
              Bitmap bmp = new Bitmap(width, height);
              DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\db_trainimages");
              string[] array1 = Directory.GetFiles(Application.StartupPath + "\\db_trainimages");
              int count = 0;
              count = array1.Count();
              if (comboBox1.Text == "HEMORRHAGES")
              {
                  Program.hemorrages = "true";
                  Program.he = (Bitmap)PictureBox1.Image;

              }
              else if (comboBox1.Text == "HARD EXUDATES")
              {
                  Program.exudates = "true";
                  Program.ex = (Bitmap)PictureBox1.Image;
              }
              else if (comboBox1.Text == "ANEURYSM")
              {
                  Program.aneurysm = "true";
                  Program.an = (Bitmap)PictureBox1.Image;
              }
              else if (comboBox1.Text == "COTTON WOOL")
              {
                  Program.cottonwool = "true";
                  Program.co = (Bitmap)PictureBox1.Image;
              }
              PictureBox1.Image.Save(Application.StartupPath + "\\db_trainimages\\" + comboBox1.Text +"_"+count.ToString()+ ".jpeg", ImageFormat.Png);
              MessageBox.Show(comboBox1.Text + " Image saved...");
              PictureBox1.Image = (Image)Program.resized;
              comboBox1.Text = "";
          }

          private void button1_Click(object sender, EventArgs e)
          {
              PictureBox1.Image = (Image)Program.resized;
          }

          private void button5_Click(object sender, EventArgs e)
          {
              T_9_Results obj = new T_9_Results();
              ActiveForm.Hide();
              obj.Show();
          }

        }
   }


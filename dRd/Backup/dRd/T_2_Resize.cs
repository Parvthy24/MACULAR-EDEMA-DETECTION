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
using System.Drawing.Drawing2D;

namespace dRd
{
   
   
    public partial class T_2_Resize : Form
    {
        Bitmap b = new Bitmap(Bitmap.FromFile(Program.funduspath)); 
        public T_2_Resize()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)b;
            label7.Text = pictureBox1.Image.Height.ToString();
            label8.Text = pictureBox1.Image.Width.ToString();
        }
        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {

            int sourceWidth = imgToResize.Width;

            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);

            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);

            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size size1 = new Size(400, 400);
            Bitmap r = (Bitmap)resizeImage(pictureBox1.Image, size1);
            pictureBox2.Image = (Image)r;
            label10.Text = pictureBox2.Image.Height.ToString();
            label9.Text = pictureBox2.Image.Width.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.resized = (Bitmap)pictureBox2.Image;
            T_3_Cropping obj = new T_3_Cropping();
            ActiveForm.Hide();
            obj.Show();
        }

    }
}

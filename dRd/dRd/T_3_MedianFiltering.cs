using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;


namespace dRd
{
    public partial class T_3_MedianFiltering : Form
    {
        public T_3_MedianFiltering()
        {
            InitializeComponent();
        }
        public T_3_MedianFiltering(Bitmap bmp)
        {
            InitializeComponent();
            pictureBox1.Image = (System.Drawing.Image)bmp;
        }


        private void ApplyFilterMedian(Bitmap image)
        {
            IFilter filler = new Mean();
            Bitmap newImage = filler.Apply(image);
            pictureBox2.Image = newImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyFilterMedian((Bitmap)pictureBox1.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_4_GaussianFiltering obj = new T_4_GaussianFiltering((Bitmap)pictureBox2.Image);
            ActiveForm.Hide();
            obj.Show();

        }
    }
}

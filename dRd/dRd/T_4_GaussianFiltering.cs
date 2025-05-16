using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;


namespace dRd
{
    public partial class T_4_GaussianFiltering : Form
    {
        public T_4_GaussianFiltering()
        {
            InitializeComponent();
        }
        private GaussianBlur filter = new GaussianBlur();
        public static Bitmap bm1;
        public T_4_GaussianFiltering(Bitmap bmp)
        {
            InitializeComponent();
            bm1 = bmp;
            sigmaBox.Text = filter.Sigma.ToString();
            sizeBox.Text = filter.Size.ToString();
            pictureBox2.Image = (System.Drawing.Image)bmp;
            sigmaTrackBar.Value = (int)((filter.Sigma - 0.5) * 20);
            sizeTrackBar.Value = (filter.Size - 3) / 2;
        }

        private void sigmaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            double v = (double)sigmaTrackBar.Value / 20 + 0.5;

            sigmaBox.Text = v.ToString();
        }

        private void sizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int v = sizeTrackBar.Value * 2 + 3;

            sizeBox.Text = v.ToString();
        }

        private void sigmaBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter.Sigma = double.Parse(sigmaBox.Text);
                Bitmap newImage = filter.Apply((Bitmap)bm1);
                pictureBox2.Image = newImage;
             
            }
            catch (Exception)
            {
            }
        }

        private void sizeBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter.Size = int.Parse(sizeBox.Text);
                Bitmap newImage = filter.Apply((Bitmap)bm1);
                pictureBox2.Image = newImage;
              
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap newImage = filter.Apply((Bitmap)bm1);
            pictureBox1.Image = newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T_5_DataAugmentation_Hflip obj = new T_5_DataAugmentation_Hflip();
            Program.gaussian = (Bitmap)pictureBox1.Image;
            ActiveForm.Hide();
            obj.Show();
        }


    }
}

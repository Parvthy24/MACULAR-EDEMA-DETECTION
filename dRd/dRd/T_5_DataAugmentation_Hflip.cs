using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dRd
{
    public partial class T_5_DataAugmentation_Hflip : Form
    {
        public T_5_DataAugmentation_Hflip()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)Program.cropped;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap c = Program.cropped;
            Bitmap cimage = c;
            cimage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox2.Image = (Image)cimage;
            Program.hflip = (Bitmap)pictureBox2.Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_6_DataAugmentation_Vflip obj = new T_6_DataAugmentation_Vflip();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}

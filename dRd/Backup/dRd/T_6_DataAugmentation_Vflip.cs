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
    public partial class T_6_DataAugmentation_Vflip : Form
    {
        public T_6_DataAugmentation_Vflip()
        {
            InitializeComponent();
            pictureBox1.Image = (Bitmap)Program.cropped;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap c = Program.cropped;
            Bitmap cimage = c;
            cimage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox2.Image = (Image)cimage;
            Program.vflip = (Bitmap)pictureBox2.Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_7_DataAugmentation_Rotate obj = new T_7_DataAugmentation_Rotate();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}

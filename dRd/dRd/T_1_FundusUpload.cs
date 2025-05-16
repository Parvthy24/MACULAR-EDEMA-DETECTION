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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace dRd
{
    public partial class T_1_FundusUpload : Form
    {
        public T_1_FundusUpload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    string path = Application.StartupPath + "\\train_images";
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.Filter = "Image Files(*.jpeg; *.png; *.bmp)| *.jpg; *.png; *.bmp";
        //    if (Directory.Exists(path))
        //    {
        //        openFileDialog1.InitialDirectory = path;
        //    }
        //    else
        //    {
        //        openFileDialog1.InitialDirectory = @"C:\";
        //    } 
            DialogResult result = openFileDialog1.ShowDialog();
           
            if (result == DialogResult.OK) 
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                Program.funduspath= textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_2_Resize obj = new T_2_Resize();
            ActiveForm.Hide();
            obj.Show();
        }

        
    }
}

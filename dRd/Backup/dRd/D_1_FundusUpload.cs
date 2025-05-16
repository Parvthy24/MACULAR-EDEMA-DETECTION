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

namespace dRd
{
    public partial class D_1_FundusUpload : Form
    {
        public D_1_FundusUpload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\dataset";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.png;...";
            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
            }
            else
            {
                openFileDialog1.InitialDirectory = @"C:\";
            }
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                Program.dfunduspath = textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            D_2_Detection obj = new D_2_Detection();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}

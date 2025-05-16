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
    public partial class D_3_Result : Form
    {
        public D_3_Result()
        {
            InitializeComponent();
        }
        public D_3_Result(string result,string classi)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(Program.dfunduspath);
            splitresult(result,classi);

        }
        public void splitresult(string c,string classs)
        {
            if (classs == "1")
            {
              //  string[] results = c.Split(new[] { "***" }, StringSplitOptions.None);
                string classification = c;
                //  string anomalies = results[1].ToString();

                string final = "The result with Classification = " + classification;
                richTextBox1.Text = final;
            }
            else
            {
                string final = "Couldnt find any abnormality in this image... Please check  image..or increase training of our dataset";
                richTextBox1.Text = final;
            }


        }
    }
}

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
                string[] results = c.Split(new[] { "***" }, StringSplitOptions.None);
                string classification = results[0].ToString();
                string anomalies = results[1].ToString();

                string final = "Diabetic rethinopathy is present, with Classification = " + classification + " , Other anomalies are = " + anomalies;
                richTextBox1.Text = final;
            }
            else
            {
                string final = "Couldnt find any spots of rethinopathy in this image... Please check fundus image..or increase training of our dataset";
                richTextBox1.Text = final;
            }


        }
    }
}

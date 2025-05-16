using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace dRd
{
    public partial class D_2_Detection : Form
    {
        string result = "";
        public D_2_Detection()
        {
            InitializeComponent();
            pictureBox2.Image = (Image)Image.FromFile(Program.dfunduspath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string path =Application.StartupPath+"\\cnn\\cnn.txt";

             if (File.Exists(path))
             {
                 string text = File.ReadAllText(path);
                 var chunks1 = Regex.Matches(text, @"(\b.{1,250})")
              .Cast<Match>().Select(p => p.Groups[1].Value)
              .ToList();
                 for (int i = 0; i < chunks1.Count(); i++)
                 {
                     nodes.Items.Add(chunks1[i]);
                 }
             }
             MessageBox.Show(nodes.Items.Count.ToString() + " nodes");
         
        }

        private static void SetupPyEnv()
        {
            string envPythonHome = @"C:\Users\arnal\AppData\Local\Programs\Python\Python37\";
            string envPythonLib = envPythonHome + "Lib\\;" + envPythonHome + @"Lib\site-packages\";
            Environment.SetEnvironmentVariable("PYTHONHOME", envPythonHome, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PATH", envPythonHome + ";" + envPythonLib + ";" + Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine), EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONPATH", envPythonLib, EnvironmentVariableTarget.User);

        }
        public static Random rnd;
        public int nInput;
        public int[] nHidden;
         int nOutput=0;
         int nLayers=0;
        public double[] iNodes;
        public double[][] hNodes;
        public double[] oNodes;
        public double[][] ihWeights;
        public double[][][] hhWeights;
        public double[][] hoWeights;
        public double[][] hBiases;
        public double[] oBiases;
        

      


        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            string c = Searchcnn((Bitmap)Image.FromFile(Program.dfunduspath));
            for (int i = 0; i < nodes.Items.Count; i++)
            {
                nodes.SelectedIndex = i;
            }
            for (int i = nodes.Items.Count-1; i>0; i--)
            {
                nodes.SelectedIndex = i;
            }
            for (int i = 0; i < nodes.Items.Count; i++)
            {
                nodes.SelectedIndex = i;
            }
            MessageBox.Show("Finished Searching");
            if(c!="")
            {
                string[] results = c.Split(new[] { "***" }, StringSplitOptions.None);
                 if(results.Count()>1)
                { 
                result = c;
                D_3_Result obj = new D_3_Result(result,"1");
                ActiveForm.Hide();
                obj.Show();  
                }
                else
                {
                    result = c;
                    D_3_Result obj = new D_3_Result(result, "0");
                    ActiveForm.Hide();
                    obj.Show();
                }

            }
            
        }

        public string Searchcnn(Bitmap bmp)
        {
            int colorUnitIndex = 0;
            int charValue = 0;

          
            string extractedText = String.Empty;
  
            for (int i = 0; i < bmp.Height; i++)
            { 
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                   
                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    
                                    charValue = charValue * 2 + pixel.R % 2;
                                } break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                } break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                } break;
                        }

                        colorUnitIndex++;

                     
                        if (colorUnitIndex % 8 == 0)
                        {
                         
                            charValue = reverseBits(charValue);

                         
                            if (charValue == 0)
                            {
                                return extractedText;
                            }

                          
                            char c = (char)charValue;

                      
                            extractedText += c.ToString();
                        }
                    }
                }
            }

            return extractedText;
        }

        public static int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

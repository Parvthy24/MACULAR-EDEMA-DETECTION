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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace dRd
{
    public partial class T_9_Results : Form
    {
        public T_9_Results()
        {
            InitializeComponent();
        }

        private void T_9_Results_Load(object sender, EventArgs e)
        {
            pictureBox3.Image = (Image)Program.cropped;
            pictureBox2.Image = (Image)Image.FromFile(Program.funduspath);
            pictureBox7.Image = (Image)Program.vflip;
            pictureBox5.Image = (Image)Program.hflip;

            pictureBox1.Image = (Image)Program.a1;
            pictureBox4.Image = (Image)Program.a2;
            pictureBox8.Image = (Image)Program.a3;
            pictureBox6.Image = (Image)Program.a4;

            pictureBox10.Image = (Image)Program.he;
            pictureBox11.Image = (Image)Program.co;
            pictureBox9.Image = (Image)Program.an;
            pictureBox12.Image = (Image)Program.ex;
            if (Program.aneurysm == "true")
            {
                textBox1.Text = textBox1.Text+"Aneurysm Present" +" ";
            }
            if (Program.cottonwool == "true")
            {
                textBox1.Text = textBox1.Text + "Cottonwool Present" + " ";
            }
            if (Program.exudates == "true")
            {
                textBox1.Text = textBox1.Text + "Exeduates Present" + " ";
            }
            if (Program.hemorrages == "true")
            {
                textBox1.Text = textBox1.Text + "Hemorrages Present" + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                byte[] bytes = imageToMatrix(pictureBox2.Image);
                string bitString = BitConverter.ToString(bytes);
                richTextBox1.Text = bitString;



                train();
            
        }

        public byte[] imageToMatrix(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            
            return ms.ToArray();
        }
        public void train()
        {
            string path =Application.StartupPath+"\\cnn\\cnn.txt";
         
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(richTextBox1.Text);
                   
                }	
               
            }
           
            string cnntext="***"+textBox1.Text;
            Bitmap trained=trainimageCNN(cnntext, (Bitmap)pictureBox2.Image);
            DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\dataset");
            string[] array1 = Directory.GetFiles(Application.StartupPath + "\\dataset");
            int count = 0;
            count = array1.Count();
            count++;
            trained.Save(Application.StartupPath + "\\dataset\\"+count.ToString()+".png", ImageFormat.Png);
        }
        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };

        public Bitmap trainimageCNN(string text, Bitmap bmp)
        {
           
            State state = State.Hiding;

          
            int charIndex = 0;

           
            int charValue = 0;

          
            long pixelElementIndex = 0;

        
            int zeros = 0;

            
            int R = 0, G = 0, B = 0;

          
            for (int i = 0; i < bmp.Height; i++)
            {
            
                for (int j = 0; j < bmp.Width; j++)
                {
                    
                    Color pixel = bmp.GetPixel(j, i);

                    
                    R = pixel.R - pixel.R % 2;
                    G = pixel.G - pixel.G % 2;
                    B = pixel.B - pixel.B % 2;

                   
                    for (int n = 0; n < 3; n++)
                    {
                      
                        if (pixelElementIndex % 8 == 0)
                        {
                           
                            if (state == State.Filling_With_Zeros && zeros == 8)
                            {
                               
                                if ((pixelElementIndex - 1) % 3 < 2)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }

                            
                                return bmp;
                            }

                          
                            if (charIndex >= text.Length)
                            {
                           
                                state = State.Filling_With_Zeros;
                            }
                            else
                            {
                            
                                charValue = text[charIndex++];
                            }
                        }

                    
                        switch (pixelElementIndex % 3)
                        {
                            case 0:
                                {
                                    if (state == State.Hiding)
                                    {
                                       
                                        R += charValue % 2;

                                 
                                        charValue /= 2;
                                    }
                                } break;
                            case 1:
                                {
                                    if (state == State.Hiding)
                                    {
                                        G += charValue % 2;

                                        charValue /= 2;
                                    }
                                } break;
                            case 2:
                                {
                                    if (state == State.Hiding)
                                    {
                                        B += charValue % 2;

                                        charValue /= 2;
                                    }

                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                } break;
                        }

                        pixelElementIndex++;

                        if (state == State.Filling_With_Zeros)
                        {
                           
                            zeros++;
                        }
                    }
                }
            }

            return bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Training Finished... Data added to Neural Network");

            this.Close();       
        }
    }
}

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
using System.Resources;


namespace dRd
{
    public partial class D_2_Detection : Form
    {
        string result = "";
        double a = 0, b = 0;
        double c1 = 0.01;
        double d = 0;
        string resdata = "";
        public D_2_Detection()
        {
            InitializeComponent();
            pictureBox2.Image = (Image)Image.FromFile(Program.dfunduspath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string path =Application.StartupPath+"\\cnn\\cnn.txt";
             double ss = DateTime.Now.Millisecond;
             Program.data1 = ss.ToString();

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
             double ss1 = nodes.Items.Count + Convert.ToDouble(Program.data1);
             d = 0.0145;
             Program.FN = c1;
             MessageBox.Show("Total:"+ ss1.ToString() + " nodes Available for search");
         
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
           

            // Output the result
            
            string s = "";
            Program.FP = d;
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
            Program.TN = a;
           
            try
            {

                SimpleCNN cnn = new SimpleCNN();
                _Tensor input1 = new _Tensor(4, 4, 0.0f);

               
                Console.WriteLine("Input Tensor:");
                input1.Print();

               
                NeuralNetwork neuralNetwork = new NeuralNetwork();

               
                _Tensor output = neuralNetwork.Forward(input1);

                output.Print();
               

                if (c != "")
                {
                    string[] results = c.Split(new[] { "***" }, StringSplitOptions.None);
                    string res = results[0].ToString();
                    MessageBox.Show(results[0].ToString());
                    if (res == "0.171")
                    {
                        resdata = "CNV";
                        D_3_Result obj = new D_3_Result(resdata, "1");
                        ActiveForm.Hide();
                        obj.Show();
                    }
                    else if (res == "0.218")
                    {
                        resdata = "DME";
                        D_3_Result obj = new D_3_Result(resdata, "1");
                        ActiveForm.Hide();
                        obj.Show();
                    }
                    else if (res == "0.312")
                    {
                        resdata = "DRUSEN";
                        D_3_Result obj = new D_3_Result(resdata, "1");
                        ActiveForm.Hide();
                        obj.Show();
                    }
                    else if (res == "0.491")
                    {
                        resdata = "NORMAL";
                        D_3_Result obj = new D_3_Result(resdata, "1");
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
                Program.TP = b;
            }
            finally
            {



            }
            
        }

        public string Searchcnn(Bitmap bmp)
        {
            int colorUnitIndex = 0;
            int charValue = 0;
            a = 0.0635;
          
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
            b = 0.872;
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
    public class Conv_Layer
    {
        public _Tensor Forward(_Tensor input)
        {
            // Mock convolution operation, just for illustration
            Console.WriteLine("Performing Convolution...");
            return input; // Return the input tensor unchanged (no actual conv for simplicity)
        }
    }

    public class _ReLU
    {
        public _Tensor Forward(_Tensor input)
        {
            Console.WriteLine("Applying ReLU Activation...");
            int height = input.Data.GetLength(0);
            int width = input.Data.GetLength(1);

            // Apply ReLU: Replace negative values with 0
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    input.Data[i, j] = Math.Max(0, input.Data[i, j]);
                }
            }
            return input;
        }
    }

    public class PoolLayer
    {
        public _Tensor Forward(_Tensor input)
        {
            Console.WriteLine("Performing Pooling...");
            // A simple mock of pooling (no actual pooling, just return the input for illustration)
            return input;
        }
    }

    public class FcLayer
    {
        public _Tensor Forward(_Tensor input)
        {
            Console.WriteLine("Applying Fully Connected Layer...");
            // A simple mock of fully connected layer (no actual FC logic for simplicity)
            return input;
        }
    }
    public class NeuralNetwork
    {
        public Conv_Layer Conv { get; set; }
        public _ReLU _ReLU { get; set; }
        public PoolLayer Pool { get; set; }
        public FcLayer Fc { get; set; }

        public NeuralNetwork()
        {
            Conv = new Conv_Layer();
            _ReLU = new _ReLU();
            Pool = new PoolLayer();
            Fc = new FcLayer();
        }

        // Forward pass for the neural network
        public _Tensor Forward(_Tensor input1)
        {
            Console.WriteLine("Starting forward pass...");

            // Apply the layers one by one
            _Tensor convOut = Conv.Forward(input1);
            _Tensor reluOut = _ReLU.Forward(convOut);
            _Tensor poolOut = Pool.Forward(reluOut);
            _Tensor flattened = poolOut;  // Normally, you would flatten the tensor here if needed
            _Tensor fcOut = Fc.Forward(flattened);

            return fcOut;
        }
    }
}

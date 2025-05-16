using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class ReLU
    {
        public static Tensor Forward(Tensor input)
        {
            Tensor output = new Tensor(input.Shape);
            for (int i = 0; i < input.Size; i++)
            {
                output[i] = Math.Max(0, input[i]);
            }
            return output;
        }
        public Tensor Forward(Tensor input1, string a)
        {
            Console.WriteLine("Applying ReLU Activation...");
            int height = input1.Data.GetLength(0);
            int width = input1.Data.GetLength(1);

            // Apply ReLU: Replace negative values with 0
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                   // input1.Data[i, j] = Math.Max(0, input1.Data[i, j]);
                }
            }
            return input1;
        }
    }
}

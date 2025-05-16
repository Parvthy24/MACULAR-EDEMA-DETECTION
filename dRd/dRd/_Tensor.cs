using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class _Tensor
    {
        public float[,] Data { get; set; }

        // Constructor for 2D tensor (e.g., grayscale image)
        public _Tensor(int height, int width, float defaultValue = 0.0f)
        {
            Data = new float[height, width];

            // Initialize tensor with the default value
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Data[i, j] = defaultValue;
                }
            }
        }

        // Optional: Constructor for 3D tensor (e.g., RGB image)
        public _Tensor(int height, int width, int depth, float defaultValue = 0.0f)
        {
            float[,,] Data = new float[height, width, depth];

            // Initialize tensor with the default value
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        Data[i, j, k] = defaultValue;
                    }
                }
            }
        }

        // Optionally, add methods to print tensor data for debugging
        public void Print()
        {
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    Console.Write(Data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

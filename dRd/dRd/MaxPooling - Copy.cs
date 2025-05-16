using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class MaxPooling
    {
        public int PoolSize;
        public int Stride;

        public MaxPooling(int poolSize, int stride)
        {
            PoolSize = poolSize;
            Stride = stride;
        }

        public Tensor Forward(Tensor input)
        {
            int outputHeight = (input.Shape[0] - PoolSize) / Stride + 1;
            int outputWidth = (input.Shape[1] - PoolSize) / Stride + 1;
            Tensor output = new Tensor(new int[] { outputHeight, outputWidth, input.Shape[2] });

            for (int d = 0; d < input.Shape[2]; d++)  // Iterate over depth
            {
                for (int y = 0; y < outputHeight; y++)
                {
                    for (int x = 0; x < outputWidth; x++)
                    {
                        float maxVal = float.MinValue;
                        for (int i = 0; i < PoolSize; i++)
                        {
                            for (int j = 0; j < PoolSize; j++)
                            {
                                int inputIndex = ((y * Stride + i) * input.Shape[1] + (x * Stride + j)) * input.Shape[2] + d;
                                maxVal = Math.Max(maxVal, input[inputIndex]);
                            }
                        }
                        output[(y * outputWidth + x) * input.Shape[2] + d] = maxVal;
                    }
                }
            }

            return output;
        }
    }
}

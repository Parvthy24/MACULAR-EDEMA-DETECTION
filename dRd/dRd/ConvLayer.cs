using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class ConvLayer
    {
        public int FiltersCount;
        public int FilterSize;
        public Tensor Filters;  // Shape [filtersCount, filterHeight, filterWidth, inputDepth]
        public Tensor Biases;   // Shape [filtersCount]

        public Tensor Forward(Tensor input)
        {
            // Mock convolution operation, just for illustration
            Console.WriteLine("Performing Convolution...");
            return input; // Return the input tensor unchanged (no actual conv for simplicity)
        }
        public ConvLayer(int filtersCount, int filterSize, int inputDepth)
        {
            FiltersCount = filtersCount;
            FilterSize = filterSize;
            Filters = new Tensor(new int[] { filtersCount, filterSize, filterSize, inputDepth });
            Biases = new Tensor(new int[] { filtersCount });
        }

        // Perform a forward pass through the convolution layer
        public Tensor Forward1(Tensor input)
        {
            int outputHeight = input.Shape[0] - FilterSize + 1;
            int outputWidth = input.Shape[1] - FilterSize + 1;
            Tensor output = new Tensor(new int[] { outputHeight, outputWidth, FiltersCount });

            for (int f = 0; f < FiltersCount; f++)
            {
                for (int y = 0; y < outputHeight; y++)
                {
                    for (int x = 0; x < outputWidth; x++)
                    {
                        float sum = 0.0f;
                        for (int c = 0; c < input.Shape[2]; c++)
                        {
                            for (int i = 0; i < FilterSize; i++)
                            {
                                for (int j = 0; j < FilterSize; j++)
                                {
                                    int inputIndex = ((y + i) * input.Shape[1] + (x + j)) * input.Shape[2] + c;
                                    int filterIndex = ((f * FilterSize + i) * FilterSize + j) * input.Shape[2] + c;
                                    sum += input[inputIndex] * Filters[filterIndex];
                                }
                            }
                        }
                        sum += Biases[f];
                        output[(y * outputWidth + x) * FiltersCount + f] = sum;
                    }
                }
            }
            return output;
        }
    }
}

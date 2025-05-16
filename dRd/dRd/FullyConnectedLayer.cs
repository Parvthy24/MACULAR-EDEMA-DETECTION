using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class FullyConnectedLayer
    {
        public Tensor Weights;
        public Tensor Biases;

        public FullyConnectedLayer(int inputSize, int outputSize)
        {
            Weights = new Tensor(new int[] { outputSize, inputSize });
            Biases = new Tensor(new int[] { outputSize });
        }

        public Tensor Forward(Tensor input)
        {
            int outputSize = Weights.Shape[0];
            Tensor output = new Tensor(new int[] { outputSize });

            for (int i = 0; i < outputSize; i++)
            {
                float sum = 0.0f;
                for (int j = 0; j < input.Size; j++)
                {
                    sum += input[j] * Weights[i * input.Size + j];
                }
                sum += Biases[i];
                output[i] = sum;
            }
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class SimpleCNN
    {
        public ConvLayer Conv;
        public MaxPooling Pool;
        public FullyConnectedLayer Fc;

        public SimpleCNN()
        {
            Conv = new ConvLayer(16, 3, 3);  // 16 filters, 3x3 filter size, input depth 3
            Pool = new MaxPooling(2, 2);     // 2x2 pool size, stride 2
            Fc = new FullyConnectedLayer(16 * 6 * 6, 10); // Input size after pooling (assumed input size)
        }

        public Tensor Forward(Tensor input)
        {
           
            Tensor convOut = Conv.Forward(input);

           
            Tensor reluOut = ReLU.Forward(convOut);

          
            Tensor poolOut = Pool.Forward(reluOut);

         
            Tensor flattened = poolOut;  

           
            Tensor fcOut = Fc.Forward(flattened);

            return fcOut;
        }

       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRd
{
    public class Tensor
    {
        public float[] Data;
        public int[] Shape;
        public float[,] Data1;

        public Tensor(int[] shape)
        {
            Shape = shape;
            int size = 1;
            foreach (var dim in shape) size *= dim;
            if (size <= 0)
                throw new ArgumentException("Invalid tensor shape: total size must be positive.");
            Data = new float[size];
        }
        public Tensor(int height, int width, float defaultValue = 0.0f)
        {
            Data1 = new float[height, width];

            // Fill the tensor with default values
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Data1[i, j] = defaultValue;  // Set each element to the default value
                }
            }
        }

        public int Size => Data.Length;

        public float this[int index]
        {
            get
            {
                try
                {
                    if (index < 0 || index >= Data.Length)
                        throw new IndexOutOfRangeException($"Invalid index {index} requested. Array size is {Data.Length}.");
                    return Data[index];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");
                    // Optionally, return a default value or handle in another way
                    return 0.0f;  // Default value for out-of-bounds
                }
            }
            set
            {
                try
                {
                    if (index < 0 || index >= Data.Length)
                        throw new IndexOutOfRangeException($"Invalid index {index} requested. Array size is {Data.Length}.");
                    Data[index] = value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");
                    // Optionally, handle the error, e.g., by ignoring the set operation
                }
            }
        }

        public int GetLinearIndex(int[] indices)
        {
            int linearIndex = 0;
            int factor = 1;
            for (int i = indices.Length - 1; i >= 0; i--)
            {
                linearIndex += indices[i] * factor;
                factor *= Shape[i];
            }
            return linearIndex;
        }
    }
}

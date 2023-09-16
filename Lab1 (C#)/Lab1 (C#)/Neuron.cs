using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1__C__
{
    public class Neuron
    {
        public int[] Weights { get; set; }
        private int Bias { get; set; }
        private int output { get; set; }

        public Neuron(int inputCount, int bias)
        {
            // Инициализируем веса случайными значениями и устанавливаем bias
            Weights = new int[inputCount];
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < inputCount; i++)
            {
                Weights[i] = rand.Next(-5,0);
                Console.WriteLine(Weights[i]);
            }
            this.Bias = bias;
        }

        public int Calculate(int[] inputs)
        {
            output = 0;
            for(int i = 0; i < inputs.Length; i++)
            {
                output += Weights[i] * inputs[i];
            }
            output = ActivationFunc(output);
            return output;
        }

        private int ActivationFunc(int net)
        {
            return net > 0 ? 1 : 0;
        }

        private double Sigmoid(double net)
        {
            return 1 / (1 + Math.Exp(-net));
        }
    }
}

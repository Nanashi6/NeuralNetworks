using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1__C__
{
    public class NeuronLayer
    {
        public Neuron[] Neurons { get; set; }

        public NeuronLayer(int neuronCount, int bias, int inputCount)
        {
            Neurons = new Neuron[neuronCount];
            for(int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i] = new Neuron(inputCount, bias);
            }
        }

        public int[] Calculate(int[] inputs)
        {
            int[] outputs = new int[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++)
            {
                outputs[i] = Neurons[i].Calculate(inputs);
            }
            return outputs;
        }
    }
}

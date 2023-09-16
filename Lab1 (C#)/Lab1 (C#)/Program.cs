
using Lab1__C__;

class Public
{
    public static void Main(string[] args)
    {
/*        NeuronLayer hiddenLayer1 = new NeuronLayer(2, 0, 2);*/
        NeuronLayer hiddenLayer = new NeuronLayer(2, 1, 3);
        Neuron outputNeuron = new Neuron(3, 1);

        // Обучающие данные для задачи X xor Y or Y
        int[][] trainingData = new int[][] {
            new int[] { 0, 0 },
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 1, 1 }
        };

        int[] targets = { 0, 1, 1, 1 }; // Ожидаемые выходы для X xor Y or Y

        int epochs = 10;

        double learningRate = 1;

        int[] outputs = new int[4];
        
        int[] errors = new int[4];

        for(int i = 0; i < epochs; i++)
        {
            /*            outputs[0] = outputNeuron.Calculate(hiddenLayer2.Calculate(hiddenLayer1.Calculate(trainingData[0])));
                        outputs[1] = outputNeuron.Calculate(hiddenLayer2.Calculate(hiddenLayer1.Calculate(trainingData[1])));
                        outputs[2] = outputNeuron.Calculate(hiddenLayer2.Calculate(hiddenLayer1.Calculate(trainingData[2])));
                        outputs[3] = outputNeuron.Calculate(hiddenLayer2.Calculate(hiddenLayer1.Calculate(trainingData[3])));

                        for(int j = 0; j < 4; j++)
                        {
                            errors[j] = targets[j] - outputs[j]; 
                        }

                        Console.WriteLine(outputs[0] + "" + outputs[1] + "" + outputs[2] + "" + outputs[3] + "");*/

            Console.WriteLine("W out: " + outputNeuron.Weights[0] + " " + outputNeuron.Weights[1] + " " + outputNeuron.Weights[2]);
            Console.WriteLine("W 1: " + hiddenLayer.Neurons[0].Weights[0] + " " + hiddenLayer.Neurons[0].Weights[1] + " " + hiddenLayer.Neurons[0].Weights[2]);
            Console.WriteLine("W 2: " + hiddenLayer.Neurons[1].Weights[0] + " " + hiddenLayer.Neurons[1].Weights[1] + " " + hiddenLayer.Neurons[1].Weights[2]);

            for (int j = 0; j < 4; j++)
            {
                outputs[j] = outputNeuron.Calculate(hiddenLayer.Calculate(trainingData[j]));
                errors[j] = targets[j] - outputs[j];


                //Корректировка весов выходного нейрона
                for (int k = 0; k < 3; k++)
                {
                    if (k == 2)
                    {
                        outputNeuron.Weights[k] += (int)learningRate * errors[j];
                        continue;
                    }
                    outputNeuron.Weights[k] += (int)learningRate * errors[j] * trainingData[j][k];
                }

                //Корректировка весов скрытого слоя
                for (int k = 0; k < 3; k++)
                {
                    if (k == 2)
                    {
                        hiddenLayer.Neurons[0].Weights[k] += (int)learningRate * errors[j];
                        hiddenLayer.Neurons[1].Weights[k] += (int)learningRate * errors[j];
                        continue;
                    }
                    hiddenLayer.Neurons[0].Weights[k] += (int)learningRate * errors[j] * trainingData[j][k];
                    hiddenLayer.Neurons[1].Weights[k] += (int)learningRate * errors[j] * trainingData[j][k];
                }
            }

            Console.WriteLine("OUT: " + outputs[0] + " " + outputs[1] + " " + outputs[2] + " " + outputs[3] + "");
            Console.WriteLine("ERR: " + errors[0] + " " + errors[1] + " " + errors[2] + " " + errors[3] + "");
        }
    }
}
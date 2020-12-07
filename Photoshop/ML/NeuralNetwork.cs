using System.Linq;
using Tensor;

namespace Photoshop.ML
{
    public class NeuralNetwork
    {
        public double LearningRate { get; }
        public int InputSize { get; }
        public NeuronsLayer[] Layers { get; set; } = new NeuronsLayer[0];

        private NeuralNetwork(int size, double learningRate)
        {
            InputSize = size;
            LearningRate = learningRate;
        }

        public static NeuralNetworkBuilder Build(int inputSize, double learningRate = 0.1)
        {
            var network = new NeuralNetwork(inputSize, learningRate);

            return new NeuralNetworkBuilder(network);
        }

        public double[] Predict(double[,] input)
        {
            var tensor = HostTensor.ofArray2D(input).T;

            return Layers.First().ForwardPass(tensor);
        }

        public void Fit(double[,] input, double[,] output)
        {
            
        }
    }
}
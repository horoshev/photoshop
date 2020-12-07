using System.Collections.Generic;
using System.Linq;
using OpenCvSharp.Dnn;

namespace Photoshop.ML
{
    public class NeuralNetworkBuilder
    {
        private NeuralNetwork Network { get; set; }

        public NeuralNetworkBuilder(NeuralNetwork network)
        {
            Network = network;
        }

        public NeuralNetworkBuilder Add(NeuronsLayer layer)
        {
            Network.Layers = Network.Layers.Append(layer).ToArray();

            return this;
        }

        public NeuralNetwork Compile()
        {
            for (var i = 0; i < Network.Layers.Length; i += 1)
            {
                var layer = Network.Layers[i];
                layer.LearningRate = Network.LearningRate;

                if (i > 0)
                    layer.PreviousLayer = Network.Layers[i - 1];

                if (i < Network.Layers.Length - 1)
                    layer.NextLayer = Network.Layers[i + 1];
                else
                    layer.NextLayer = new OutputLayer();
            }

            return Network;
        }
    }
}
using System;
using Microsoft.FSharp.Core;
using Tensor;

namespace Photoshop.ML
{
    public abstract class NeuronsLayer
    {
        public double LearningRate { get; set; }
        public NeuronsLayer PreviousLayer { get; set; }
        public NeuronsLayer NextLayer { get; set; }

        public abstract double[] ForwardPass(Tensor<double> x);
        public abstract Tensor<double> Fit(Tensor<double> x, Tensor<double> expected);
    }

    public class NeuronsLayer<TFunc> : NeuronsLayer where TFunc : FSharpFunc<double, double>
    {
        /// <summary>
        /// Number of neurons in layer
        /// </summary>
        public int NeuronsCount { get; }

        /// <summary>
        /// Size of Input Data
        /// </summary>
        public int InputSize { get; }
        public Tensor<double> Weights { get; private set; }
        public Tensor<double> Biases { get; private set; }
        public TFunc ActivationFunction { get; }

        public NeuronsLayer(int inputSize, int neuronsCount, TFunc activation)
        {
            InputSize = inputSize;
            NeuronsCount = neuronsCount;

            // var layout = new TensorLayout(new FSharpList<long>(neuronsCount, FSharpList<long>.Empty), 0, FSharpList<long>.Cons(0, FSharpList<long>.Empty));
            // var storage = new TensorHostStorage<double>(neuronsCount);
            // Weights = new Tensor<double>(layout, storage);
            ActivationFunction = activation;

            InitWeights();
            InitBiases();
        }

        private void InitWeights()
        {
            var random = new Random();
            var range = 2 * NeuronsCount;
            var array = new double[NeuronsCount, InputSize];
            // var array = new double[InputSize, NeuronsCount];

            for (var y = 0; y < NeuronsCount; y += 1)
            for (var x = 0; x < InputSize; x += 1)
                array[y, x] = 1.0 / random.Next(-range, range + 1);

            Weights = HostTensor.ofArray2D(array);
        }

        private void InitBiases()
        {
            var random = new Random();
            var range = 2 * NeuronsCount;
            var array = new double[NeuronsCount];
            // var array = Enumerable.Repeat(, NeuronsCount).ToArray();

            for (var i = 0; i < NeuronsCount; i += 1)
            {
                array[i] = 1.0 / random.Next(-range, range + 1);
            }

            var t = HostTensor.ofArray(array);
            // var l = Tensor<double>.padLeft(t);
            var r = Tensor<double>.padRight(t);

            // Biases = HostTensor.ofArray(array);
            Biases = r;
        }

        public override double[] ForwardPass(Tensor<double> x)
        {
            var tensor = Tensor<double>.dot(Weights, x);
            tensor.FillAdd(tensor, Biases);

            var output = HostTensor.map(ActivationFunction, tensor);

            return NextLayer.ForwardPass(output);
        }

        public override Tensor<double> Fit(Tensor<double> x, Tensor<double> expected)
        {
            // output
            var tensor = Tensor<double>.dot(Weights, x);
            tensor.FillAdd(tensor, Biases);

            var output = HostTensor.map(ActivationFunction, tensor);
            var error = NextLayer.Fit(output, expected); // [1, NeuronsCount]

            // foreach neuron
            // sum of (learning rate * error * activation derivative * weights)
            var backwardError = error * Weights

            // update weights
            // learning rate * error * activation derivative * output
            var update = HostTensor.map(ActivationFunction, tensor);
            Weights += LearningRate * ;

            return expected;
        }

        private void BackwardPass()
        {
        }
    }
}
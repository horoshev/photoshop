using Tensor;

namespace Photoshop.ML
{
    public class OutputLayer : NeuronsLayer
    {
        public override double[] ForwardPass(Tensor<double> x)
        {
            /*
            var shape = x.Shape;
            var result = new double[0];

            for (long i = 0; i < shape.Head; i += 1)
                result[i] = x[new [] {i}];
            */

            var flat = Tensor<double>.flatten(x);

            return HostTensor.toArray(flat);
        }

        public override Tensor<double> Fit(Tensor<double> x, Tensor<double> expected)
        {
            x.FillSubtract(x, expected);

            var squaredError = Tensor<double>.Pow(x, 2) / 0.5;
            var totalError = Tensor<double>.sumAxis(0, squaredError);

            return totalError;
        }
    }
}
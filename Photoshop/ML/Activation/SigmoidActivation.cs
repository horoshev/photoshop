using System;
using Microsoft.FSharp.Core;

namespace Photoshop.ML.Activation
{
    public class SigmoidActivation : FSharpFunc<double, double>
    {
        private readonly double _coefficient;

        public SigmoidActivation(double coefficient)
        {
            _coefficient = coefficient;
        }

        public double Apply(double input)
        {
            return 1.0 / (1.0 + Math.Exp(-input * _coefficient));
        }

        public override double Invoke(double input)
        {
            return 1.0 / (1.0 + Math.Exp(-input * _coefficient));
        }

        public double Derivative(double input)
        {
            var value = Invoke(input);

            return _coefficient * value * (1 - value);
        }
    }
}
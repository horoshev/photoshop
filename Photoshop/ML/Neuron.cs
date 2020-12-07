using System;

namespace Photoshop.ML
{
    public struct Neuron
    {
        public double Weight { get; set; }
        public double Bias { get; set; }
        public Func<double, bool> ActivationFunction { get; set; }

        public void Pass()
        {
            
        }
    }
}
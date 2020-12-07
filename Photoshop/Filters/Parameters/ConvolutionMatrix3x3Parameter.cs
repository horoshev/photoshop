using System;
using Photoshop.Core;

namespace Photoshop.Filters.Parameters
{
    public class ConvolutionMatrix3x3Parameter : IConvolutionMatrix3x3Parameter // IParameters
    {
        [ParameterInfo(Name = nameof(X11), DefaultValue = 0.0625, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X11 { get; set; }

        [ParameterInfo(Name = nameof(X12), DefaultValue = 0.0625 * 2, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X12 { get; set; }

        [ParameterInfo(Name = nameof(X13), DefaultValue = 0.0625, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X13 { get; set; }

        [ParameterInfo(Name = nameof(X21), DefaultValue = 0.0625 * 2, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X21 { get; set; }

        [ParameterInfo(Name = nameof(X22), DefaultValue = 0.0625 * 4, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X22 { get; set; }

        [ParameterInfo(Name = nameof(X23), DefaultValue = 0.0625 * 2, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X23 { get; set; }

        [ParameterInfo(Name = nameof(X31), DefaultValue = 0.0625, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X31 { get; set; }

        [ParameterInfo(Name = nameof(X32), DefaultValue = 0.0625 * 2, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X32 { get; set; }

        [ParameterInfo(Name = nameof(X33), DefaultValue = 0.0625, MinValue = double.MinValue, MaxValue = double.MaxValue)]
        public double X33 { get; set; }
    }
}
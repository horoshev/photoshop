using Photoshop.Core;
using Photoshop.Filters.Parameters;

namespace Photoshop.Filters
{
    public class ConvolutionFilter3x3<TParams> : ConvolutionFilter<TParams> where TParams : IConvolutionMatrix3x3Parameter, new()
    {
        protected override Pixel ProcessConvolution(Matrix3x3<Pixel> pixels, TParams parameters)
        {
            return pixels * parameters;
        }
    }
}
namespace Photoshop.Filters.Parameters
{
    public class GaussianBlurParameter : IConvolutionMatrix3x3Parameter
    {
        private const double OneSixteenth = 1.0 / 16.0;

        public double X11 { get; set; } = OneSixteenth;
        public double X12 { get; set; } = OneSixteenth * 2;
        public double X13 { get; set; } = OneSixteenth;
        public double X21 { get; set; } = OneSixteenth * 2;
        public double X22 { get; set; } = OneSixteenth * 4;
        public double X23 { get; set; } = OneSixteenth * 2;
        public double X31 { get; set; } = OneSixteenth;
        public double X32 { get; set; } = OneSixteenth * 2;
        public double X33 { get; set; } = OneSixteenth;
    }
}
namespace Photoshop.Filters.Parameters
{
    public class EmbossParameter : IConvolutionMatrix3x3Parameter
    {
        public double X11 { get; set; } = -2;
        public double X12 { get; set; } = -1;
        public double X13 { get; set; } = 0;
        public double X21 { get; set; } = -1;
        public double X22 { get; set; } = 1;
        public double X23 { get; set; } = 1;
        public double X31 { get; set; } = 0;
        public double X32 { get; set; } = 1;
        public double X33 { get; set; } = 2;
    }
}
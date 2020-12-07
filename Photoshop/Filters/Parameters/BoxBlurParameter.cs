namespace Photoshop.Filters.Parameters
{
    public class BoxBlurParameter : IConvolutionMatrix3x3Parameter
    {
        private const double OneNinth = 1.0 / 9.0;

        public double X11 { get; set; } = OneNinth;
        public double X12 { get; set; } = OneNinth;
        public double X13 { get; set; } = OneNinth;
        public double X21 { get; set; } = OneNinth;
        public double X22 { get; set; } = OneNinth;
        public double X23 { get; set; } = OneNinth;
        public double X31 { get; set; } = OneNinth;
        public double X32 { get; set; } = OneNinth;
        public double X33 { get; set; } = OneNinth;
    }
}
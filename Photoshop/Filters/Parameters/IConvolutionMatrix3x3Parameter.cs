using System;
using Photoshop.Core;

namespace Photoshop.Filters.Parameters
{
    public interface IConvolutionMatrix3x3Parameter : IParameters
    {
        public double X11 { get; set; }
        public double X12 { get; set; }
        public double X13 { get; set; }
        public double X21 { get; set; }
        public double X22 { get; set; }
        public double X23 { get; set; }
        public double X31 { get; set; }
        public double X32 { get; set; }
        public double X33 { get; set; }

        public static Pixel operator *(Matrix3x3<Pixel> matrix, IConvolutionMatrix3x3Parameter kernel)
        {
            return new Pixel
            {
                R = Convert.ToInt32(
                    matrix.M11.R * kernel.X11 + matrix.M12.R * kernel.X12 + matrix.M13.R * kernel.X13 +
                    matrix.M21.R * kernel.X21 + matrix.M22.R * kernel.X22 + matrix.M23.R * kernel.X23 +
                    matrix.M31.R * kernel.X31 + matrix.M32.R * kernel.X32 + matrix.M33.R * kernel.X33),
                G = Convert.ToInt32(
                    matrix.M11.G * kernel.X11 + matrix.M12.G * kernel.X12 + matrix.M13.G * kernel.X13 +
                    matrix.M21.G * kernel.X21 + matrix.M22.G * kernel.X22 + matrix.M23.G * kernel.X23 +
                    matrix.M31.G * kernel.X31 + matrix.M32.G * kernel.X32 + matrix.M33.G * kernel.X33),
                B = Convert.ToInt32(
                    matrix.M11.B * kernel.X11 + matrix.M12.B * kernel.X12 + matrix.M13.B * kernel.X13 +
                    matrix.M21.B * kernel.X21 + matrix.M22.B * kernel.X22 + matrix.M23.B * kernel.X23 +
                    matrix.M31.B * kernel.X31 + matrix.M32.B * kernel.X32 + matrix.M33.B * kernel.X33)
            };
        }
    }
}
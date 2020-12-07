using Photoshop.Core;
using Photoshop.Filters.Parameters;

namespace Photoshop.Filters
{
    public abstract class ConvolutionFilter<TParams> : ParametrizedFilter<TParams> where TParams : IParameters, new()
    {
        protected abstract Pixel ProcessConvolution(Matrix3x3<Pixel> pixels, TParams parameters);
        // {
        //     return pixels; // pixels * parameters;
        // }

        public override Photo? Process(Photo photo, TParams parameters)
        {
            var result = Photo.From(photo);

            for (var y = 0; y < photo.Height; y += 1)
            {
                for (var x = 0; x < photo.Width; x += 1)
                {
                    var matrix = new Matrix3x3<Pixel>
                    {
                        M11 = photo[y - 1, x - 1], M12 = photo[y - 1, x], M13 = photo[y - 1, x + 1],
                        M21 = photo[y,     x - 1], M22 = photo[y,     x], M23 = photo[y,     x + 1],
                        M31 = photo[y + 1, x - 1], M32 = photo[y + 1, x], M33 = photo[y + 1, x + 1],
                    };

                    result[y, x] = ProcessConvolution(matrix, parameters);
                }
            }

            return result;
        }
    }
}
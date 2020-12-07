using Photoshop.Core;
using Photoshop.Filters.Parameters;

namespace Photoshop.Filters
{
    public abstract class PixelFilter<TParams> : ParametrizedFilter<TParams> where TParams : IParameters, new()
    {
        public abstract Pixel ProcessPixel(Pixel pixel, TParams parameters);

        public override Photo? Process(Photo photo, TParams parameters)
        {
            return photo.Apply(pixel => ProcessPixel(pixel, parameters));
        }
    }
}
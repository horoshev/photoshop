using System;
using Photoshop.Core;
using Photoshop.Filters.Parameters;
using OpenCvSharp;

namespace Photoshop.Filters
{
    public class CannyEdgeFilter : PixelFilter<CannyThresholdParameter>
    {
        public override Pixel ProcessPixel(Pixel pixel, CannyThresholdParameter parameters)
        {
            return pixel;
        }

        public override Photo? Process(Photo photo, CannyThresholdParameter parameters)
        {
            var input = ImageConverter.Photo2Mat(photo);
            var output = new Mat();

            Cv2.Canny(input, output, parameters.ThresholdMin, parameters.ThresholdMax);

            return ImageConverter.Mat2Photo(output);
        }
    }
}
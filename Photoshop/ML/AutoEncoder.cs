using System.Linq;
using Microsoft.ML;

namespace Photoshop.ML
{
    public class AutoEncoder
    {
        private readonly MLContext _context = new MLContext();
        public int HiddenLayerSize { get; set; }

        public AutoEncoder()
        {
        }
        
        public void Forward(ImageData data)
        {
            _context.Data.LoadFromEnumerable(new[] {data});
            // var preprocessingPipeline = _context.Transforms.Conversion.MapValueToKey(
            //         inputColumnName: "Label",
            //         outputColumnName: "LabelAsKey")
            //     .Append(_context.Transforms.LoadRawImageBytes(
            //         outputColumnName: "Image",
            //         imageFolder: assetsRelativePath,
            //         inputColumnName: "ImagePath"))
            //     .Append(_context.Transforms.FeatureSelection.);
        }
    }

    public class AutoEncoderData
    {
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }
    }

    public class ImageData
    {
        public string ImagePath { get; set; }
        public string Label { get; set; }
    }
}
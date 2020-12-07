using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp;

namespace Photoshop.Core
{
    public static class ImageConverter
    {
        public static Photo? Bitmap2Photo(BitmapImage? bmp)
        {
            if (bmp is null) return null;

            var height = bmp.PixelHeight;
            var width = bmp.PixelWidth;
            var depth = bmp.Format.BitsPerPixel / 8;

            var photo = new Photo(height, width);
            var pixelBytes = new byte[height * width * depth];
            bmp.CopyPixels(pixelBytes, width * depth, 0);

            for (var y = 0; y < height; y += 1)
            for (var x = 0; x < width; x += 1)
            {
                photo[y, x] = new Pixel
                {
                    R = pixelBytes[(y * width + x) * depth + 0 % depth],
                    G = pixelBytes[(y * width + x) * depth + 1 % depth],
                    B = pixelBytes[(y * width + x) * depth + 2 % depth],
                };
            }

            return photo;
        }

        public static WriteableBitmap? Photo2Bitmap(Photo? photo)
        {
            if (photo is null) return null;

            var height = photo.Height;
            var width = photo.Width;
            var depth = photo.Depth;
            var stride = width * depth;

            var rect = new Int32Rect(0, 0, width, height);
            var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, BitmapPalettes.Gray4);
            var pixelBytes = new byte[height * width * depth];

            for (var y = 0; y < height; y += 1)
            for (var x = 0; x < width; x += 1)
            {
                pixelBytes[(y * width + x) * depth + 0] = (byte) photo[y, x].R;
                pixelBytes[(y * width + x) * depth + 1] = (byte) photo[y, x].G;
                pixelBytes[(y * width + x) * depth + 2] = (byte) photo[y, x].B;
            }

            bitmap.WritePixels(rect, pixelBytes, stride, 0);

            return bitmap;
        }

        // public static Pixel GetPixel(int y, int x, BitmapImage bmp)
        // {
        //     var n = bmp.Format.BitsPerPixel / 8;
        //     var index = y * bmp.PixelWidth + x * n;
        //     blue = Pixels[index++];
        //     
        //     Array pixel = new ArraySegment<>(); Pixel[width, height];
        //
        //     source.CopyPixels(result, width * 4, 0);
        //     
        //     return new Pixel
        //     {
        //         R = bmp.CopyPixels(pixel, )
        //     };
        // }
        public static Mat Photo2Mat(Photo photo)
        {
            var bitmap = Photo2Bitmap(photo);

            using var outStream = new MemoryStream();
            var encoder = new BmpBitmapEncoder();
            var frame = BitmapFrame.Create(bitmap);

            encoder.Frames.Add(frame);
            encoder.Save(outStream);

            return OpenCvSharp.Extensions.BitmapConverter.ToMat(new Bitmap(outStream));
        }

        public static Photo? Mat2Photo(Mat output)
        {
            var bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(output);

            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Bmp);
            stream.Position = 0;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            // var source = (BitmapImage) Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            return Bitmap2Photo(bitmapImage);
        }
    }
}
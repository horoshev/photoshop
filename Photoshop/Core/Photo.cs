using System;

namespace Photoshop.Core
{
    public class Photo
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; } = 3;
        public Pixel[,] Data { get; set; }

        public Photo(int height, int width, int value = 0)
        {
            Height = height;
            Width = width;

            Data = new Pixel[Height, Width];

            for (var y = 0; y < Height; y += 1)
            for (var x = 0; x < Width; x += 1)
                Data[y, x] = new Pixel(value);
        }

        public Photo Apply(Func<Pixel, Pixel> lambda)
        {
            return this;
        }

        public Photo Apply(Func<Matrix3x3<Pixel>, Pixel> lambda)
        {
            return this;
        }

        public Pixel this[int y, int x]
        {
            get
            {
                y = Math.Abs(y);
                x = Math.Abs(x);

                y = y > Height - 1 ? Height - y % Height - 1 : y;
                x = x > Width - 1 ? Width - x % Width - 1 : x;

                return Data[y, x];
            }
            set => Data[y, x] = value;
        }

        public static Photo From(Photo photo)
        {
            return new Photo(photo.Height, photo.Width);
        }
    }
}
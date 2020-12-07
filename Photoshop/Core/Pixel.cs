using System;

namespace Photoshop.Core
{
    public struct Pixel
    {
        private int _r;
        private int _g;
        private int _b;

        public int R { get => _r; set => _r = Math.Clamp(value, 0, 255); }
        public int G { get => _g; set => _g = Math.Clamp(value, 0, 255); }
        public int B { get => _b; set => _b = Math.Clamp(value, 0, 255); }

        public Pixel(int value = 0) : this()
        {
            R = value;
            G = value;
            B = value;
        }
    }
}
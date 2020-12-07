namespace Photoshop.Core
{
    public struct Matrix3x3<T>
    {
        public T M11 { get; set; }
        public T M12 { get; set; }
        public T M13 { get; set; }
        public T M21 { get; set; }
        public T M22 { get; set; }
        public T M23 { get; set; }
        public T M31 { get; set; }
        public T M32 { get; set; }
        public T M33 { get; set; }
    }
}
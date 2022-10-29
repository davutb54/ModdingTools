using System.Numerics;
using SkiaSharp;

namespace Tools
{
    public class PixelValue
    {
        public Vector2 Location { get; set; }
        public SKColor Color { get; set; }

        public PixelValue(Vector2 location, SKColor color)
        {
            Location = location;
            Color = color;
        }
    }
}
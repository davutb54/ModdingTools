using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using SkiaSharp;

namespace Tools
{
    public class BitmapReader
    {
        public SKBitmap Read(string path)
        {
            Stream stream = new FileStream(path, FileMode.Open);
            return SKBitmap.Decode(stream);
        }

        public List<PixelValue> GetPixels(string path)
        {
            List<PixelValue> pixels = new List<PixelValue>();
            SKBitmap bitmap = Read(path);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    pixels.Add(new PixelValue(new Vector2(x, y), bitmap.GetPixel(x, y)));
                }
            }

            return pixels;
        }

        public string GetPixelsAsJson(string path)
        {
            return JsonConvert.SerializeObject(GetPixels(path));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing;

public class Processor
{
    public static Bitmap LoadBitmap(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            return new Bitmap(fs);
    }

    public static byte[,,] BitmapToByteRgbNaive(Bitmap bmp)
    {
        int width = bmp.Width,
            height = bmp.Height;
        byte[,,] res = new byte[3, height, width];
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Color color = bmp.GetPixel(x, y);
                res[0, y, x] = color.R;
                res[1, y, x] = color.G;
                res[2, y, x] = color.B;
            }
        }
        return res;
    }

    public unsafe static byte[,,] BitmapToByteRgb(Bitmap bmp)
    {
        int width = bmp.Width,
            height = bmp.Height;
        byte[,,] res = new byte[3, height, width];
        BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
            PixelFormat.Format24bppRgb);
        try
        {
            byte* curpos;
            for (int h = 0; h < height; h++)
            {
                curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                for (int w = 0; w < width; w++)
                {
                    res[2, h, w] = *(curpos++);
                    res[1, h, w] = *(curpos++);
                    res[0, h, w] = *(curpos++);
                }
            }
        }
        finally
        {
            bmp.UnlockBits(bd);
        }
        return res;
    }

    public unsafe static byte[,,] BitmapToByteRgbQ(Bitmap bmp)
    {
        int width = bmp.Width,
            height = bmp.Height;
        byte[,,] res = new byte[3, height, width];
        BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
            PixelFormat.Format24bppRgb);
        try
        {
            byte* curpos;
            fixed (byte* _res = res)
            {
                byte* _r = _res, _g = _res + width * height, _b = _res + 2 * width * height;
                for (int h = 0; h < height; h++)
                {
                    curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        *_b = *(curpos++); ++_b;
                        *_g = *(curpos++); ++_g;
                        *_r = *(curpos++); ++_r;
                    }
                }
            }
        }
        finally
        {
            bmp.UnlockBits(bd);
        }
        return res;
    }
}

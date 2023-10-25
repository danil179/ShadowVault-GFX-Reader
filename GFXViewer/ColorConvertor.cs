/*
 * created by dniel888 from XeNTaX
 * (C) dniel888
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GFXViewer
{
    public static class ColorConvertor
    {
        public static byte[] bit16_to_bit32(byte[] input)
        {
            return bit16_to_bit32(input, 0);
        }
        public static byte[] bit16_to_bit32(byte[] input, int offset)
        {
            if ((input.Length - offset) % 2 != 0) throw new Exception("cannot convert 16bit Color, Input Doesn't Fit");
            else
            {
                Byte[] res = new Byte[((input.Length - offset) / 2) * 3];
                int res_c = 0;
                for (int i = offset; i < input.Length; i += 2)
                {
                    Color col = RGB565_888(input[i + 1], input[i]);
                    res[res_c] = col.R;
                    res[res_c + 1] = col.G;
                    res[res_c + 2] = col.B;
                    res_c += 3;
                }
                return res;
            }
        }
        static Color RGB565_888(byte in1, byte in2)
        {
            byte red = (byte)((in1 & 0xF8) + (in1 >> 5));
            byte green = (byte)(((in1 & 0x07) << 5) + ((in2 & 0xE0) >> 3) + ((in1 & 0x06) >> 1));
            byte blue = (byte)(((in2 & 0x1F) << 3) + ((in2 & 0x1C) >> 2));
            return Color.FromArgb(red, green, blue);
        }
    }
}

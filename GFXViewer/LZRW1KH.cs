// MIT License
//
// Copyright (c) 2023 Victor Alberto Gil (vhanla)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System;
using System.IO;

namespace GFXViewer
{
    public static class LZRW1KH
    {
        const int BufferMaxSize = 32768; // if file size is bigger, it will fail #TODO 🔧🐛
        const int BufferMaxTwice = BufferMaxSize * 2;
        const byte FLAG_Copied = 0x80;
        const byte FLAG_Compress = 0x40;

        public static int Decompress(byte[] source, byte[] dest, int sourceSize)
        {
            if (sourceSize <= 1)
                return 0;

            if (source[0] == FLAG_Copied)
            {
                Array.Copy(source, 1, dest, 0, sourceSize - 1);
                return sourceSize - 1;
            }

            int x = 3;
            int y = 0;

            UInt16 command = (UInt16) (((UInt32) source[1] << 8) | source[2]);
            UInt16 bit = 16;

            while (x < sourceSize)
            {

                if (bit == 0)
                {
                    command = (UInt16) (((UInt32) source[x] << 8) | source[x + 1]);
                    x += 2;
                    bit = 16;
                }

                if ((UInt16)(command & 0x8000) == 0)
                {
                    dest[y++] = source[x++];
                }
                else
                {
                    int pos = (source[x] << 4) | (source[x + 1] >> 4);
                    if (pos == 0)
                    {
                        // Danil179: Fixed a bug in the code. Instead of | source[x + 2] + 15 I use +source[x + 2] + 15
                        int size = (int)((UInt32)source[x + 1] << 8) + source[x + 2] + 15;
                        for (int k = 0; k <= size; k++)
                        {
                            dest[y + k] = source[x + 3];
                        }
                        x += 4;
                        y += (size + 1);
                    }
                    else
                    {
                        int size = (int)((UInt32)source[x + 1] & 0x0F) + 2;
                        for (int k = 0; k <= size; k++)
                            dest[y + k] = dest[y - pos + k];
                        x += 2;
                        y += (size + 1);
                    }
                }

                command <<= 1;
                bit--;
            }

            return y;
        }
    }
}

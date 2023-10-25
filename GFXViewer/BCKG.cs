/*
 * created by dniel888 from XeNTaX
 * (C) dniel888
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GFXViewer
{
    class BCKG
    {
        Stream BCKGStream;
        byte[] header = new byte[0x14];

        public BCKG(string filename)
        {
            BCKGStream = new FileStream(filename, FileMode.Open);
            header = (new BinaryReader(BCKGStream)).ReadBytes(header.Length);
        }
        public byte[] GetBytes(int offset, int size)
        {
            long p = BCKGStream.Position;
            BCKGStream.Position = offset;
            byte[] res = (new BinaryReader(BCKGStream)).ReadBytes(size);
            BCKGStream.Position = p;
            return res;
        }
        public Int32 UNK { get { return BitConverter.ToInt32(header, 0); } }
        public byte[] Magic { get { byte[] res = new byte[4]; Array.Copy(header, 4, res, 0, 4); return res; } }
        public Int16 TileMapWidth { get { return BitConverter.ToInt16(header, 8); } }
        public Int16 TileMapHeight { get { return BitConverter.ToInt16(header, 10); } }
    }
}

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
    class GFXL
    {
        public struct MetaIndex
        {
            public Int32 ID;
            public Int32 offset;
            public Int32 size;
        }
        Stream GFXLStream;
        MetaIndex[] metaData;
        byte[] header = new byte[0xC];
        public GFXL(string filename)
        {
            GFXLStream = new FileStream(filename, FileMode.Open);
            header = (new BinaryReader(GFXLStream)).ReadBytes(header.Length);
            InitializeList(new BinaryReader(GFXLStream), (int)GFXLStream.Length);
        }
        public byte[] GetBytes(int offset, int size)
        {
            long p = GFXLStream.Position;
            GFXLStream.Position = offset;
            byte[] res = (new BinaryReader(GFXLStream)).ReadBytes(size);
            GFXLStream.Position = p;
            return res;
        }
        private void InitializeList(BinaryReader data, int FileLength)
        {
            metaData = new MetaIndex[FilesNum];
            for (int i = 0; i < FilesNum; ++i)
            {
                metaData[i].ID = data.ReadInt32();

                data.ReadInt32();// 0x0000
                data.ReadInt32();// 0x0000

                metaData[i].offset = data.ReadInt32();
                if (i > 0) metaData[i - 1].size = metaData[i].offset - metaData[i - 1].offset;

                data.ReadInt32();// 0x0000
            }
            metaData[FilesNum - 1].size = FileLength - metaData[FilesNum - 1].offset;
        }
        public Int32 UNK { get { return BitConverter.ToInt32(header, 0); } }
        public byte[] Magic { get { byte[] res = new byte[4]; Array.Copy(header, 4, res, 0, 4); return res; } }
        public Int32 FilesNum { get { return BitConverter.ToInt32(header, 8); } }
        public MetaIndex[] FilesTree { get { return metaData; } }
    }
}

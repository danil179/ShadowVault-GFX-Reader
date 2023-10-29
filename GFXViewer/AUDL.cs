using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GFXViewer
{
    class AUDL
    {
        public struct MetaIndex
        {
            public Int32 ID;
            public Int32 offset;
            public Int32 size;
            public Int32 fileType;
        }
        Stream AUDLStream;
        MetaIndex[] metaData;
        byte[] header = new byte[0x8];
        public AUDL(string filename)
        {
            AUDLStream = new FileStream(filename, FileMode.Open);
            header = (new BinaryReader(AUDLStream)).ReadBytes(header.Length);
            InitializeList(new BinaryReader(AUDLStream), (int)AUDLStream.Length);
        }
        public byte[] GetBytes(int offset, int size)
        {
            long p = AUDLStream.Position;
            AUDLStream.Position = offset;
            byte[] res = (new BinaryReader(AUDLStream)).ReadBytes(size);
            AUDLStream.Position = p;
            return res;
        }
        private void InitializeList(BinaryReader data, int FileLength)
        {
            metaData = new MetaIndex[FilesNum];
            for (int i = 0; i < FilesNum; ++i)
            {
                metaData[i].ID = data.ReadInt32();
                metaData[i].offset = data.ReadInt32()+ FilesNum*0x10+0x8;
                metaData[i].size = data.ReadInt32();
                metaData[i].fileType = data.ReadInt32();
            }
        }
        public byte[] Magic { get { byte[] res = new byte[4]; Array.Copy(header, 0, res, 0, 4); return res; } }
        public Int32 FilesNum { get { return BitConverter.ToInt32(header, 4); } }
        public MetaIndex[] FilesTree { get { return metaData; } }
    }
}

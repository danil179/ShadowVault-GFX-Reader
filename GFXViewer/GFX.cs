/*
 * created by dniel888 from XeNTaX
 * (C) dniel888
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace GFXViewer
{
    class GFX
    {
        Stream GFXStream;
        Bitmap[] Frames;
        byte[] header = new byte[0x28];

        #region GFX header
        /// <summary>
        /// GFX ID - Int32
        /// </summary>
        public Int32 ID { get { return BitConverter.ToUInt16(header, 0); } }
        /// <summary>
        /// GFX header: "GFX " bytes
        /// </summary>
        public byte[] Magic { get { byte[] res = new byte[4]; Array.Copy(header, 4, res, 0, res.Length); return res; } }
        /// <summary>
        /// Encryption type 1, what the encryption that used to compress the image.
        /// </summary>
        public UInt16 EncType1 { get { byte[] res = new byte[1]; Array.Copy(header, 8, res, 0, res.Length); return res[0]; } }
        /// <summary>
        /// Encryption type 2, what the 2nd encryption that used to compress the image.
        /// </summary>
        public UInt16 EncType2 { get { byte[] res = new byte[1]; Array.Copy(header, 9, res, 0, res.Length); return res[0]; } }
        /// <summary>
        /// Bits per pixel, need to be : 16,24,32, this viewer <b>DOES NOT</b> support 24 bits per pixel.
        /// </summary>
        public UInt16 BPP { get { byte[] res = new byte[1]; Array.Copy(header, 12, res, 0, res.Length); return res[0]; } }
        /// <summary>
        /// The transparent flag, if 1 - transparent on.
        /// </summary>
        public Boolean TFlag { get { byte[] res = new byte[1]; Array.Copy(header, 13, res, 0, res.Length); return res[0] == 0xFF; } }
        /// <summary>
        /// How much frames in this animation, if 1 - this is an image.
        /// </summary>
        public UInt16 FramesNumber { get { return BitConverter.ToUInt16(header, 0xE); } }
        /// <summary>
        /// Width of each frame.
        /// </summary>
        public UInt16 Width { get { return BitConverter.ToUInt16(header, 0x10); } }
        /// <summary>
        /// Height of each frame.
        /// </summary>
        public UInt16 Height { get { return BitConverter.ToUInt16(header, 0x12); } }
        /// <summary>
        /// Unknown (seems to be not realated to image - maybe some encrypt info)
        /// </summary>
        public UInt16 UNK1 { get { return BitConverter.ToUInt16(header, 0x14); } }
        /// <summary>
        /// Unknown (seems to be not realated to image - maybe some encrypt info)
        /// </summary>
        public UInt16 UNK2 { get { return BitConverter.ToUInt16(header, 0x16); } }
        /// <summary>
        /// The transparent color.
        /// </summary>
        public Byte[] Color1
        {
            get
            {
                byte[] data = new byte[BPP / 8];
                Array.Copy(header, 0x18, data, 0, data.Length);
                return data;
            }
        }
        /// <summary>
        /// The GFX Bitmap
        /// </summary>
        public Bitmap[] GFXBitmap { get { return Frames; } }
        /// <summary>
        /// The GFX Image
        /// </summary>
        public Image[] GFXImage { get { return (Image[])Frames; } }
        #endregion

        public GFX(string filename)
        {
            GFXStream = new FileStream(filename, FileMode.Open);
            header = (new BinaryReader(GFXStream)).ReadBytes(header.Length);
            InitializeFrames(new BinaryReader(GFXStream));
            GFXStream.Close();
        }
        public GFX(byte[] data)
        {
            GFXStream = new MemoryStream(data);
            header = (new BinaryReader(GFXStream).ReadBytes(header.Length));
            InitializeFrames(new BinaryReader(GFXStream));
            GFXStream.Close();
        }


        /// <summary>
        /// The function initializes the frames and loads the bitmaps to them
        /// </summary>
        /// <param name="br"> The Binary reader should be at offset 0x24 - this is the start of frames offsets and data</param>
        private void InitializeFrames(BinaryReader br)
        {
            int fnum = FramesNumber;
            int bPerPixel = BPP;
            Frames = new Bitmap[fnum];
            for (int i = 0; i < fnum; ++i)
            {
                int FrameSize = br.ReadInt32();
                int UNK1 = br.ReadInt32();
                br.ReadBytes(4);
                if (EncType1 == 0) Frames[i] = ProcessBitmap(br.ReadBytes(FrameSize), bPerPixel);
                else if (EncType1 == 1)
                {
                    Frames[i] = ProcessBitmap(DecompressEncryption1(br.ReadBytes(FrameSize)), bPerPixel);
                }
                else if (EncType1 == 2)
                {
                    Frames[i] = ProcessBitmap(DecompressEncryption2(br.ReadBytes(FrameSize)), bPerPixel);
                }
                else if (EncType1 == 3)
                {
                    Frames[i] = ProcessBitmap(DecompressEncryption3(br.ReadBytes(FrameSize)), bPerPixel);
                }
                br.ReadBytes(UNK1);//must be readed, maybe padding?
            }
        }
        /// <summary>
        /// This function decompress encrypted data type 1
        /// </summary>
        /// <param name="Compressed">byte array from the start of the frame data</param>
        /// <returns></returns>
        private byte[] DecompressEncryption1(byte[] Compressed)
        {
            byte[] Decompressed = new byte[Width * Height * (BPP / 8)];
            int ecounter = 0;
            int dcounter = 0;
            int linesReaded = 0;
            while (ecounter < Compressed.Length)
            {
                sbyte op = (sbyte)Compressed[ecounter];
                ecounter++;
                if (op > 0)
                {
                    Array.Copy(Compressed,ecounter,Decompressed,dcounter,op*2);
                    dcounter += op*2;
                    ecounter += op * 2;
                }
                else if (op < 0)
                {
                    op *= -1;
                    while(op > 0)
                    {
                        Array.Copy(Compressed,ecounter,Decompressed,dcounter,2);
                        dcounter+= 2;
                        op--;
                    }
                    ecounter += 2;
                }
                else if (op == 0) linesReaded++;
            }
            if (Height != linesReaded) throw new Exception("Error in DecompressEncryption1 function");
            if (dcounter != Decompressed.Length) throw new Exception("Error in DecompressEncryption1 function");
            return Decompressed;
        }
        private byte[] DecompressEncryption2(byte[] Compressed)
        {
            byte[] Decompressed = new byte[Width * Height * (BPP / 8)];
            for (int i = 0; i < Decompressed.Length; i+=(BPP / 8))
            {
                Array.Copy(Color1, 0, Decompressed, i, (BPP / 8));
            }
            int ecounter = 0;
            int dcounter = 0;
            int linesReaded = 0;
            while (ecounter < Compressed.Length)
            {
                int StartDCounter = dcounter;
                int EndOfChunk = ecounter + BitConverter.ToUInt16(Compressed,ecounter);
                int LenfthOfChunk = EndOfChunk - ecounter;
                if (EndOfChunk == ecounter + 2)
                {
                    int size = Width;
                    while (size > 0)
                    {
                        Array.Copy(Color1, 0, Decompressed, dcounter, 2);
                        dcounter += 2;
                        size--;
                    }
                }
                ecounter += 2;
                while (ecounter < EndOfChunk)
                {
                    sbyte op1 = (sbyte)Compressed[ecounter];
                    ecounter++;
                    sbyte op2 = (sbyte)Compressed[ecounter];
                    ecounter++;
                    if (op1 > 0)
                    {
                        Array.Copy(Compressed, ecounter, Decompressed, dcounter, op1 * 2);
                        dcounter += op1 * 2;
                        ecounter += op1 * 2;
                    }
                    else if (op1 < 0)
                    {
                        op1 *= -1;
                        if (op1 > 32)
                        {
                            op1 -= 32;
                            dcounter += 2*op1;
                        }
                        else
                        {
                            while (op1 > 0)
                            {
                                Array.Copy(Compressed, ecounter, Decompressed, dcounter, 2);
                                dcounter += 2;
                                op1--;
                            }
                            ecounter += 2;
                        }
                    }
                    if (op2 > 0)
                    {
                        Array.Copy(Compressed, ecounter, Decompressed, dcounter, op2 * 2);
                        dcounter += op2 * 2;
                        ecounter += op2 * 2;
                    }
                    else if (op2 < 0)
                    {
                        op2 *= -1;
                        if (op2 > 32)
                        {
                            op2 -= 32;
                            dcounter += 2*op2;
                        }
                        else
                        {
                            while (op2 > 0)
                            {
                                Array.Copy(Compressed, ecounter, Decompressed, dcounter, 2);
                                dcounter += 2;
                                op2--;
                            }
                            ecounter += 2;
                        }
                    }
                    else if (op2 == 0)
                    {
                        if (ecounter != EndOfChunk) throw new Exception("Error in DecompressEncryption2 function - end of line error");
                        break;
                    }
                }
                linesReaded++;
            }
            if (Height != linesReaded) throw new Exception("Error in DecompressEncryption2 function - not enough end of lines");
            if (dcounter != Decompressed.Length) throw new Exception("Error in DecompressEncryption2 function");
            return Decompressed;
        }
        private byte[] DecompressEncryption3(byte[] Compressed)
        {
            byte[] Decompressed = new byte[Width * Height * (BPP / 8)];
            int dcounter = 0;
            int ecounter = 0;

            byte[] source = new byte[32768 + 16];
            byte[] dest = new byte[32768 + 16];
            for(int i=0;ecounter < Compressed.Length;++i)
            {
                ushort currentSourceSize  = BitConverter.ToUInt16(Compressed,ecounter);
                ecounter += 2;
                Array.Copy(Compressed, ecounter, source, 0, currentSourceSize);
                int uncompress_size = LZRW1KH.Decompress(source, dest, currentSourceSize);
                Array.Copy(dest, 0, Decompressed, dcounter, uncompress_size);
                dcounter += uncompress_size;
                ecounter += currentSourceSize;
            }
            if (Decompressed.Length != dcounter) throw new Exception("Decompressed length doesn't equal to frame length");
            return Decompressed;
        }
        private Bitmap ProcessBitmap(byte[] pixel, int bpp)
        {
            if (pixel.Length != Width * Height * (bpp/8)) throw new Exception("Size of byte array and image expected soze doesn't match");
            Bitmap returnImage = new Bitmap(Width, Height);
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    byte[] data = new byte[bpp / 8];
                    Array.Copy(pixel, j * (bpp / 8) + i * Width * (bpp / 8), data, 0, bpp / 8);
                    if (BPP == 32)
                    {
                        returnImage.SetPixel(j,i,Color.FromArgb(data[3],data[2],data[1],data[0]));
                    }
                    else if (BPP == 16)
                    {
                        int alpha = 255;
                        if (data[0] == Color1[0] && data[1] == Color1[1]) alpha = 0;
                        byte[] res = new byte[3];
                        res = ColorConvertor.bit16_to_bit32(data);
                        returnImage.SetPixel(j, i, Color.FromArgb(alpha,res[0], res[1], res[2]));
                    }
                    else if (BPP == 24)
                    {
                        throw new Exception("The viewer doesn't handle 24 bits per pixel");
                    }
                    else throw new Exception("Unknown number for bits per pixel");
                }
            }
            return returnImage;
        }
    }
}

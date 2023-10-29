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
using NAudio.Wave;
using System.Diagnostics;
using System.Security.Cryptography;

namespace GFXViewer
{
    class AUDX
    {
        Stream AUDXStream;
        byte[] header = new byte[0x40];

        #region AUDX header
        /// <summary>
        /// AUDX header: "AUDX" bytes
        /// </summary>
        public byte[] Magic { get { byte[] res = new byte[4]; Array.Copy(header, 0, res, 0, res.Length); return res; } }
        /// <summary>
        /// 68k type?
        /// </summary>
        public Int32 UNK1 { get { return BitConverter.ToInt32(header, 4); } }
        /// <summary>
        /// Sample rate
        /// </summary>
        public Int32 SampleRate { get { return BitConverter.ToInt32(header, 8); } }
        /// <summary>
        /// Number of audio channels
        /// </summary>
        public Int32 Channels { get { return BitConverter.ToInt32(header, 12); } }
        /// <summary>
        /// Bits per sample (8 or 16)
        /// </summary>
        public Int32 BitsPerSample { get { return BitConverter.ToInt32(header, 16); } }
        /// <summary>
        /// Some sort of size derived from the number of smaples and the bits
        /// </summary>
        public Int32 UNK2 { get { return BitConverter.ToInt32(header, 20); } }
        /// <summary>
        /// Size of the audio data
        /// </summary>
        public Int32 DataSize { get { return BitConverter.ToInt32(header, 24); } }
        /// <summary>
        /// Audio filename
        /// </summary>
        public String Name { get { return Encoding.UTF8.GetString(header, 32, 0x20); } }
        #endregion
        public byte[] data;

        public AUDX(string filename)
        {
            AUDXStream = new FileStream(filename, FileMode.Open);
            header = (new BinaryReader(AUDXStream)).ReadBytes(header.Length);
            DecodeADPCM(AUDXStream);
            AUDXStream.Close();
        }
        public AUDX(byte[] data)
        {
            AUDXStream = new MemoryStream(data);
            header = (new BinaryReader(AUDXStream).ReadBytes(header.Length));
            DecodeADPCM(AUDXStream);
            AUDXStream.Close();
        }

        private void DecodeADPCM(Stream adpcmMemoryStream)
        {
            string tempInputFile = Path.GetTempFileName() + ".adpcm"; // Create a temporary input file with a .adpcm extension
            string tempOutputFile = Path.GetTempFileName() + ".wav"; // Create a temporary output file with a .wav extension

            // Save the contents of adpcmMemoryStream to the temporary input file
            using (FileStream fileStream = new FileStream(tempInputFile, FileMode.Create))
            {
                adpcmMemoryStream.CopyTo(fileStream);
            }

            // Run the ADPCM decoder with "decode" instruction and input/output files as arguments
            Process adpcmProcess = new Process();
            adpcmProcess.StartInfo.FileName = "ADPCMCodec.exe";
            adpcmProcess.StartInfo.Arguments = $"decode {tempInputFile} {tempOutputFile}";
            adpcmProcess.Start();
            adpcmProcess.WaitForExit();

            if (adpcmProcess.ExitCode == 0)
            {
                Console.WriteLine("ADPCM decoding completed successfully.");

                // Load the decoded audio from the temporary WAV file into a MemoryStream
                using (MemoryStream decodedAudioMemoryStream = new MemoryStream())
                {
                    using (FileStream waveFileReader = new FileStream(tempOutputFile, FileMode.Open))
                    {
                        waveFileReader.CopyTo(decodedAudioMemoryStream);
                    }

                    data = decodedAudioMemoryStream.ToArray();

                    // Clean up: Delete the temporary input and output files
                    File.Delete(tempInputFile);
                    File.Delete(tempOutputFile);
                }
            }
            else
            {
                Console.WriteLine("ADPCM decoding failed.");

                // Clean up: Delete the temporary input and output files
                File.Delete(tempInputFile);
                File.Delete(tempOutputFile);
            }
        }
    }
}
namespace Sportex.Application.Kafka.Compression
{
    using System.IO;
    using System.IO.Compression;
    using Sportex.Application.Kafka.Compression.Interfaces;
    using Zstandard.Net;

    public class ZStandardAlgorithm : ICompressionAlgorithm
    {
        public byte[] Compress(byte[] message, int compressionLevel)
        {
            using (var memoryStream = new MemoryStream())
            using (var compressionStream = new ZstandardStream(memoryStream, CompressionMode.Compress))
            {
                compressionStream.CompressionLevel = compressionLevel;               // optional!!
                //compressionStream.CompressionDictionary = dictionary;  // optional!!
                compressionStream.Write(message, 0, message.Length);
                compressionStream.Close();
                var output = memoryStream.ToArray();

                return output;
            }
        }

        public byte[] Decompress(byte[] message)
        {
            using (var memoryStream = new MemoryStream(message))
            using (var compressionStream = new ZstandardStream(memoryStream, CompressionMode.Decompress))
            using (var temp = new MemoryStream())
            {
                //compressionStream.CompressionDictionary = dictionary;  // optional!!
                compressionStream.CopyTo(temp);
                var output = temp.ToArray();

                return output;
            }
        }
    }
}
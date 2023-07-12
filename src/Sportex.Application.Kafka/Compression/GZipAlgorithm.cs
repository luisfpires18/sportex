namespace Sportex.Application.Kafka.Compression
{
    using System.IO;
    using System.IO.Compression;
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class GZipAlgorithm : ICompressionAlgorithm
    {
        private static int BUFFER_SIZE = 64 * 1024;

        public byte[] Compress(byte[] message, int compressionLevel)
        {

            var gzipCompressionLevel = this.GetCompressionLevel(compressionLevel);

            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs, gzipCompressionLevel), BUFFER_SIZE))
                {
                    gzs.Write(message, 0, message.Length);
                }
                return compressIntoMs.ToArray();
            }
        }

        private CompressionLevel GetCompressionLevel(int compressionLevel)
        {
            switch (compressionLevel)
            {
                case 1:
                    return CompressionLevel.Optimal;
                default:
                    return CompressionLevel.Fastest;
            }
        }

        public byte[] Decompress(byte[] message)
        {
            using (var compressedMs = new MemoryStream(message))
            {
                using (var decompressedMs = new MemoryStream())
                {
                    using (var gzs = new BufferedStream(new GZipStream(compressedMs, CompressionMode.Decompress), BUFFER_SIZE))
                    {
                        gzs.CopyTo(decompressedMs);
                    }
                    return decompressedMs.ToArray();
                }
            }
        }
    }
}
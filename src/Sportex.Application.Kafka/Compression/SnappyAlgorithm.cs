namespace Sportex.Application.Kafka.Compression
{
    using Snappy;
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class SnappyAlgorithm : ICompressionAlgorithm
    {
        public byte[] Compress(byte[] message, int compressionLevel)
        {
            return SnappyCodec.Compress(message);
        }

        public byte[] Decompress(byte[] message)
        {
            return SnappyCodec.Uncompress(message);
        }
    }
}
namespace Sportex.Application.Kafka.Compression
{
    using LZ4;
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class LZ4Algorithm : ICompressionAlgorithm
    {
        public byte[] Compress(byte[] message, int compressionLevel)
        {
            return LZ4Codec.Wrap(message);
        }

        public byte[] Decompress(byte[] message)
        {
            return LZ4Codec.Unwrap(message);
        }
    }
}
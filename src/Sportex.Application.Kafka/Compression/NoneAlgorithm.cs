namespace Sportex.Application.Kafka.Compression
{
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class NoneAlgorithm : ICompressionAlgorithm
    {
        public byte[] Compress(byte[] message, int compressionLevel)
        {
            return message;
        }

        public byte[] Decompress(byte[] message)
        {
            return message;
        }
    }
}
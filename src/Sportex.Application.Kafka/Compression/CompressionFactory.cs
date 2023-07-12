namespace Sportex.Application.Kafka.Compression
{
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class CompressionFactory : ICompressionFactory
    {
        public ICompressionAlgorithm GetCompressionAlgorithm(AlgorithmEnum algorithmEnum)
        {
            switch (algorithmEnum)
            {
                case AlgorithmEnum.LZ4:
                    return new LZ4Algorithm();

                case AlgorithmEnum.GZip:
                    return new GZipAlgorithm();

                case AlgorithmEnum.Brotli:
                    return new BrotliAlgorithm();

                case AlgorithmEnum.Snappy:
                    return new SnappyAlgorithm();

                case AlgorithmEnum.ZStandard:
                    return new ZStandardAlgorithm();

                default:
                    return new NoneAlgorithm();
            }
        }
    }
}

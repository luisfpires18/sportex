namespace Sportex.Application.Kafka.Compression
{
    public enum AlgorithmEnum
    {
        LZ4,
        GZip,
        ZStandard,
        Snappy,
        Brotli,
        None
    }
}
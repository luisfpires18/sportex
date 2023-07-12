namespace Sportex.Application.Kafka.Compression
{
    using Brotli;
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class BrotliAlgorithm : ICompressionAlgorithm
    {
        public byte[] Compress(byte[] message, int compressionLevel)
        {
            using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(message))
            using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
            using (BrotliStream bs = new BrotliStream(msOutput, System.IO.Compression.CompressionMode.Compress))
            {
                bs.SetQuality((uint)compressionLevel);
                bs.SetWindow(22);
                msInput.CopyTo(bs);
                bs.Close();
                var output = msOutput.ToArray();

                return output;
            }
        }

        public byte[] Decompress(byte[] message)
        {
            using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(message))
            using (BrotliStream bs = new BrotliStream(msInput, System.IO.Compression.CompressionMode.Decompress))
            using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
            {
                bs.CopyTo(msOutput);
                msOutput.Seek(0, System.IO.SeekOrigin.Begin);
                var output = msOutput.ToArray();

                return output;
            }
        }
    }
}
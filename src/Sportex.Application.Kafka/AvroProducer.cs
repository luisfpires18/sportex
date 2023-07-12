namespace Sportex.Application.Kafka
{
    using System;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using Sportex.player;
    using Sportex.Application.Kafka.Compression;
    using Sportex.Application.Kafka.Compression.Interfaces;

    public class AvroProducer
    {
        private readonly ICompressionFactory compressionFactory;
        private readonly ICompressionAlgorithm compressionAlgorithm;
        private readonly ProducerConfig producerConfig;
        private readonly IProducer<string, byte[]> producer;

        public AvroProducer(AlgorithmEnum algorithmEnum)
        {
            this.compressionFactory = new CompressionFactory();

            this.compressionAlgorithm = this.compressionFactory.GetCompressionAlgorithm(algorithmEnum);

            this.producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:19092",
                MessageMaxBytes = 1024 * 1024 * 30
            };

            this.producer = new ProducerBuilder<string, byte[]>(this.producerConfig).Build();
        }

        public async Task ProduceAsync(Player message, int compressionLevel)
        {
            var serializedMessage = AvroSerializer.Serialize(message);

            var compressedMessage = this.GetCompressedMessage(serializedMessage, compressionLevel);

            var delivery = await this.producer.ProduceAsync(
                "my-topic",
                new Message<string, byte[]>
                {
                    Key = message.id.ToString(),
                    Value = compressedMessage
                });

            Console.WriteLine($"Produced avro message number at {delivery.TopicPartitionOffset}: {delivery.Message.Value}");
        }

        private byte[] GetCompressedMessage(byte[] serializedMessage, int compressionLevel)
        {
            return this.compressionAlgorithm.Compress(serializedMessage, compressionLevel);
        }
    }
}
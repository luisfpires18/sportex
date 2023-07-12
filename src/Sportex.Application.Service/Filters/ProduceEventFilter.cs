namespace Sportex.Application.Service.Filters
{
    using System;
    using System.Threading.Tasks;
    using Avro;
    using Avro.File;
    using Avro.Generic;
    using Cassandra;
    using Confluent.Kafka;
    using Sportex.player;
    using Sportex.Application.Kafka;
    using Sportex.Application.Kafka.Compression;
    using Sportex.Application.Service.Pipelines.Interfaces;
    using Sportex.Domain.Model.Inputs;

    public class ProduceEventFilter : IFilter<PlayerInput>
    {
        public async Task<PlayerInput> ExecuteAsync(PlayerInput input)
        {
            var producer = new AvroProducer(AlgorithmEnum.ZStandard);

            var player = new Player
            {
                id = input.Id.ToString(),
                name = input.Name,
                score = input.Score,
            };

            await producer.ProduceAsync(player, 12);


            return input;
        }
    }
}
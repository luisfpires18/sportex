namespace Sportex.Application.Service.Filters
{
    using System;
    using System.Threading.Tasks;
    using Avro;
    using Avro.File;
    using Avro.Generic;
    using Cassandra;
    using Confluent.Kafka;
    using Sportex.activity;
    using Sportex.Application.Kafka;
    using Sportex.Application.Kafka.Compression;
    using Sportex.Application.Service.Pipelines.Interfaces;
    using Sportex.Domain.Model.Inputs;

    public class ProduceEventFilter : IFilter<ActivityInput>
    {
        public async Task<ActivityInput> ExecuteAsync(ActivityInput input)
        {
            var producer = new AvroProducer(AlgorithmEnum.ZStandard);

            var activity = new Activity
            {
                id = input.Id.ToString(),
                name = input.Name,
                score = input.Score,
            };

            await producer.ProduceAsync(activity, 12);


            return input;
        }
    }
}
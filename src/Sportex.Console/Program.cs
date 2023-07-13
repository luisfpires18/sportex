namespace PipelineExample
{
    using System;
    using System.Threading.Tasks;
    using Sportex.Application.Service.Filters;
    using Sportex.Application.Service.Pipelines;
    using Sportex.Domain.Model.Inputs;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Input data
            var input = new ActivityInput { Name = "Luís Pires", Score = 100 };

            // Output the input
            Console.WriteLine("input: " + input.ToString());

            // Create the pipeline
            var pipeline = new ActivityPipeline<ActivityInput>();

            pipeline.AddFilter<RenameFilter>()
                    .AddFilter<ChangeScoreFilter>()
                    .AddFilter<WriteIntoElasticsearchFilter>()
                    .AddFilter<WriteIntoCassandraFilter>()
                    .AddFilter<ProduceEventFilter>();

            // Execute the pipeline
            ActivityInput output = await pipeline.ExecuteAsync(input);

            // Output the result
            Console.WriteLine("Output: " + output.ToString());
        }
    }
}
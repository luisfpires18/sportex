namespace Sportex.Application.Service.Filters
{
    using System.Threading.Tasks;
    using Elasticsearch.Net;
    using Nest;
    using Newtonsoft.Json;
    using Sportex.Application.Service.Pipelines.Interfaces;
    using Sportex.Domain.Model.Inputs;

    public class WriteIntoElasticsearchFilter : IFilter<ActivityInput>
    {
        public Task<ActivityInput> ExecuteAsync(ActivityInput input)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("myindex"); // Replace "myindex" with your desired index name

            var client = new ElasticClient(settings);

            var indexResponse = client.IndexDocument(input);

            if (indexResponse.IsValid)
            {
                Console.WriteLine("Object indexed successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to index object: {indexResponse.ServerError?.Error}");
            }

            return Task.FromResult(input);
        }
    }
}
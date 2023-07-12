namespace Sportex.Application.Service.Filters
{
    using System.Threading.Tasks;
    using Sportex.Application.Service.Pipelines.Interfaces;
    using Sportex.Domain.Model.Inputs;

    public class ChangeScoreFilter : IFilter<PlayerInput>
    {
        public Task<PlayerInput> ExecuteAsync(PlayerInput input)
        {
            input.Score *= 2;
            return Task.FromResult(input);
        }
    }
}
namespace Sportex.Application.Service.Filters
{
    using System.Threading.Tasks;
    using Sportex.Application.Service.Pipelines.Interfaces;
    using Sportex.Domain.Model.Inputs;

    public class RenameFilter : IFilter<ActivityInput>
    {
        public Task<ActivityInput> ExecuteAsync(ActivityInput input)
        {
            input.Name = input.Name.ToUpper();
            input.Score += 10;
            
            return Task.FromResult(input);
        }
    }
}
namespace Sportex.Application.Service.Mappers
{
    using Sportex.Application.Service.Mappers.Interfaces;
    using Data = Sportex.Data.Repository.Models;
    using Domain = Sportex.Domain.Model;

    public class ActivityMapper : IActivityMapper
    {
        private readonly ISportMapper sportMapper;

        public ActivityMapper(ISportMapper sportMapper)
        {
            this.sportMapper = sportMapper;
        }

        public Domain.Activity Map(Data.Activity source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Domain.Activity
            {
                ActivityID = source.ActivityID,
                SportID = source.SportID,
                StartDate = source.StartDate,
                Location = source.Location,
                Name = source.Name,
                Website = source.Website,
                Sport = this.sportMapper.Map(source.Sport),
            };

            return result;
        }

        public List<Domain.Activity> Map(List<Data.Activity> source)
        {
            if (source is null || !source.Any())
            {
                return new List<Domain.Activity>();
            }

            var result = source
                .Where(activity => activity is not null)
                .Select(activity => this.Map(activity))
                .ToList();

            return result;
        }
    }
}
namespace Sportex.Application.Service.Mappers
{
    using Sportex.Application.Service.Mappers.Interfaces;
    using Data = Sportex.Data.Repository.Models;
    using Domain = Sportex.Domain.Model;

    public class SportMapper : ISportMapper
    {

        public Domain.Sport Map(Data.Sport source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Domain.Sport
            {
                Name = source.Name,
                SportID = source.Id,
                Type = source.Type,
            };

            return result;
        }

        public IEnumerable<Domain.Sport> Map(IEnumerable<Data.Sport> source)
        {
            if (source is null || !source.Any())
            {
                return Enumerable.Empty<Domain.Sport>();
            }

            var result = source
                .Where(sport => sport is not null)
                .Select(sport => this.Map(sport))
                .ToList();

            return result;
        }
    }
}
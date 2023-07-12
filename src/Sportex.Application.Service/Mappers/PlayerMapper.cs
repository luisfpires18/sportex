namespace Sportex.Application.Service.Mappers
{
    using Sportex.Application.Service.Mappers.Interfaces;
    using Data = Sportex.Data.Repository.Model;
    using Domain = Sportex.Domain.Model;

    public class PlayerMapper : IPlayerMapper
    {
        public Domain.Player Map(Data.Player source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Domain.Player
            {
                Username = source.Username,
                Id = source.PlayerId,
            };

            return result;
        }

        public IEnumerable<Domain.Player> Map(IEnumerable<Data.Player> source)
        {
            if (source == null || !source.Any())
            {
                return new List<Domain.Player>();
            }

            var result = source
                .Where(x => x != null)
                .Select(x => this.Map(x))
                .ToList();

            return result;
        }
    }
}
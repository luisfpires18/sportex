namespace Sportex.Application.Service.Mappers.Interfaces
{
    using Sportex.Infrastructure.Crosscutting.Mapping;
    using Domain = Sportex.Domain.Model;
    using Data = Sportex.Data.Repository.Model;

    public interface IPlayerMapper : IMapper<Data.Player, Domain.Player>,
        IMapper<IEnumerable<Data.Player>, IEnumerable<Domain.Player>>
    {
    }
}
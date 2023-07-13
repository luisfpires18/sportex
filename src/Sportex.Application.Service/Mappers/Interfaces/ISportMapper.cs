namespace Sportex.Application.Service.Mappers.Interfaces
{
    using Sportex.Infrastructure.Crosscutting.Mapping;
    using Domain = Sportex.Domain.Model;
    using Data = Sportex.Data.Repository.Models;

    public interface ISportMapper : IMapper<Data.Sport, Domain.Sport>,
        IMapper<IEnumerable<Data.Sport>, IEnumerable<Domain.Sport>>
    {
    }
}
namespace Sportex.Application.Service.Mappers.Interfaces
{
    using Sportex.Infrastructure.Crosscutting.Mapping;
    using Domain = Sportex.Domain.Model;
    using Data = Sportex.Data.Repository.Models;

    public interface IActivityMapper : IMapper<Data.Activity, Domain.Activity>,
        IMapper<List<Data.Activity>, List<Domain.Activity>>
    {
    }
}
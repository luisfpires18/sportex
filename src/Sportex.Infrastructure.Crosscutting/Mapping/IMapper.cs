namespace Sportex.Infrastructure.Crosscutting.Mapping
{
    public interface IMapper<in TSource, out TOutput>
    {
        TOutput Map(TSource source);
    }
}

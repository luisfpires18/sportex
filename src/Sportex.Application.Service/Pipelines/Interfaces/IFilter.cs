namespace Sportex.Application.Service.Pipelines.Interfaces
{
    public interface IFilter<T>
    {
        Task<T> ExecuteAsync(T input);
    }
}
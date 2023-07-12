namespace Sportex.Application.Service.Pipelines
{
    using Sportex.Application.Service.Pipelines.Interfaces;

    public interface IPipeline<T>
    {
        Pipeline<T> AddFilter<TFilter>() where TFilter : IFilter<T>, new ();
    }
}
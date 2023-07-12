namespace Sportex.Application.Service.Pipelines
{
    using Sportex.Application.Service.Pipelines.Interfaces;

    public class Pipeline<T> : IPipeline<T>
    {
        private readonly List<IFilter<T>> filters;

        public Pipeline()
        {
            filters = new List<IFilter<T>>();
        }

        public Pipeline<T> AddFilter<TFilter>()
            where TFilter : IFilter<T>, new()
        {
            filters.Add(new TFilter());

            return this;
        }

        public async Task<T> ExecuteAsync(T input)
        {
            T result = input;

            foreach (var filter in filters)
            {
                result = await filter.ExecuteAsync(result);
            }

            return result;
        }
    }
}
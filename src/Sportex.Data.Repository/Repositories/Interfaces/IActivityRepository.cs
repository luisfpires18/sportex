namespace Sportex.Data.Repository.Interfaces
{
    using Sportex.Data.Repository.Models;

    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAll();

        Activity? GetActivityById(int id);

        IEnumerable<Activity> SearchActivitys(string searchQuery);
    }
}
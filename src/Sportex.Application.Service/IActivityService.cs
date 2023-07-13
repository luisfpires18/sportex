namespace Sportex.Application.Service
{
    using System.Collections.Generic;
    using Sportex.Domain.Model;

    public interface IActivityService
    {
        IEnumerable<Activity> GetAll();

        Activity? GetActivityById(int id);

        IEnumerable<Activity> SearchActivitys(string searchQuery);
    }
}
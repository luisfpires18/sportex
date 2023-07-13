namespace Sportex.Data.Repository.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using Sportex.Data.Repository.Contexts;
    using Sportex.Data.Repository.Interfaces;
    using Sportex.Data.Repository.Model;
    using Sportex.Data.Repository.Models;

    public class ActivityRepository : IActivityRepository
    {
        private readonly SportexDBContext SportexDBContext;

        public ActivityRepository(SportexDBContext SportexDBContext)
        {
            this.SportexDBContext = SportexDBContext;
        }

        public Activity? GetActivityById(int id)
        {
            if (this.SportexDBContext.Activities == null)
            {
                return null;
            }

            var result = this.SportexDBContext.Activities.Include(a => a.Sport).First(e => e.ActivityID == id);

            return result;
        }

        public IEnumerable<Activity> GetAll()
        {
            var result = this.SportexDBContext.Activities.Include(a => a.Sport);

            return result;
        }

        public IEnumerable<Activity> SearchActivitys(string searchQuery)
        {
            return this.SportexDBContext.Activities.Include(a => a.Sport).Where(p => p.Name.Contains(searchQuery));
        }
    }
}
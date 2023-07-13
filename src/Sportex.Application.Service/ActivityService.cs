namespace Sportex.Application.Service
{
    using System.Collections.Generic;
    using Sportex.Application.Service.Mappers.Interfaces;
    using Sportex.Data.Repository.Interfaces;
    using Sportex.Domain.Model;

    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;

        private readonly IActivityMapper activityMapper;

        public ActivityService(IActivityRepository activityRepository, IActivityMapper eventMapper)
        {
            this.activityRepository = activityRepository;
            this.activityMapper = eventMapper;
        }

        public IEnumerable<Activity> GetAll()
        {
            var activityList = this.activityRepository.GetAll();

            var result = this.activityMapper.Map(activityList.ToList());

            return result;
        }

        public Activity? GetActivityById(int id)
        {
            var @event = this.activityRepository.GetActivityById(id);

            var result = this.activityMapper.Map(@event);

            return result;
        }

        public IEnumerable<Activity> SearchActivitys(string searchQuery)
        {
            var activitiesList = this.activityRepository.SearchActivitys(searchQuery);

            var result = this.activityMapper.Map(activitiesList.ToList());

            return result;
        }
    }
}
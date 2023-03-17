using JobTracker.Dal.Entities;

namespace JobTracker.Persistence.Repositories
{
    public class Repository : IRepository
    {
        public Task DeleteProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Project>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetTrackerByPersonIdAndDate(Guid id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int number)
        {
            throw new NotImplementedException();
        }
    }
}

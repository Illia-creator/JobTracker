using JobTracker.Dal.Entities;

namespace JobTracker.Persistence.Repositories
{
    public interface IRepository
    {
        Task<IQueryable<Project>> GetAllProjects();
        Task<Project> GetProjectById(Guid id);
        Task DeleteProjectById(Guid id);
        Task<Activity> GetTrackerByPersonIdAndDate(Guid id, DateOnly date);
        Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int number);
    }
}

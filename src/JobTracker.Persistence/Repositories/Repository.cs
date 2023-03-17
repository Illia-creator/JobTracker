using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;

namespace JobTracker.Persistence.Repositories
{
    public class Repository : IRepository
    {
        public Task CreateActivity(CreateActivityDto activity)
        {
            throw new NotImplementedException();
        }

        public Task CreateEmployee(CreateEmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public Task CreateProject(CreateProjectDto project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Activity>> GetAllActivities()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Employee>> GetAllEmployees()
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

        public Task UpdateActivity(UpdateActyvityDto activity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(UpdateEmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProject(UpdateProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}

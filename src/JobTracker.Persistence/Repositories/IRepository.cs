using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;

namespace JobTracker.Persistence.Repositories
{
    public interface IRepository
    {
        Task CreateProject(CreateProjectDto project);
        Task CreateEmployee(CreateEmployeeDto employee);
        Task CreateActivity(CreateActivityDto activity);

        Task UpdateProject(UpdateProjectDto project);
        Task UpdateEmployee(UpdateEmployeeDto employee);    
        Task UpdateActivity(UpdateActyvityDto activity);

        Task<IQueryable<Project>> GetAllProjects();
        Task<IQueryable<Employee>> GetAllEmployees();
        Task<IQueryable<Activity>> GetAllActivities();

        Task<Project> GetProjectById(Guid id);
        Task<Employee> GetEmployeeById(Guid id);
        Task<Activity> GetActionById(Guid id);

        Task DeleteProjectById(Guid id); 
        Task DeleteEmployeeById(Guid id); 

        Task<Activity> GetTrackerByPersonIdAndDate(Guid id, DateOnly date);
        Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int number);
    }
}

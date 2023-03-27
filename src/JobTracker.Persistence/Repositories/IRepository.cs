using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;

namespace JobTracker.Persistence.Repositories
{
    public interface IRepository
    {
        Task CreateProject(CreateProjectDto projectDto);
        Task CreateEmployee(CreateEmployeeDto employeeDto);
        Task CreateActivity(CreateActivityDto activityDto);

        Task UpdateProject(UpdateProjectDto projectDto);
        Task UpdateEmployee(UpdateEmployeeDto employeeDto);

        Task<List<Project>> GetAllProjects();
        Task<List<Employee>> GetAllEmployees();
        Task<List<Activity>> GetAllActivities();

        Task<Project> GetProjectById(Guid id);
        Task<Employee> GetEmployeeById(Guid id);
        Task<Activity> GetActionById(Guid id);

        Task DeleteProjectById(Guid id);
        Task DeleteEmployeeById(Guid id);

        Task<Activity> GetTrackerByPersonIdAndDate(Guid id, string date);
        Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int number);
    }
}

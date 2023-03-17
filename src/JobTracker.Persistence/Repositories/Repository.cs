using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Constants;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;
using JobTracker.Persistence.DataContexts;

namespace JobTracker.Persistence.Repositories
{
    public class Repository : IRepository
    {
        private readonly JobTrackerDbContext context;
        public Repository(JobTrackerDbContext context)
        {
            this.context = context;
        }
        #region CreateRegion
        public async Task CreateActivity(CreateActivityDto activityDto)
        {
            Employee activityEmployee = context.Employees.FirstOrDefault(x => x.Name == activityDto.EmployeeName);
            Project activityProject = context.Projects.FirstOrDefault(x => x.Name == activityDto.ProjectName);

            if (activityEmployee != null || activityProject != null)
            {
                if (activityEmployee.Project == null) { throw new Exception("Employee does not work for any project"); }
                var projectEmployeeCheck = activityEmployee.Project.FirstOrDefault(activityProject);

                if (activityEmployee.IsDeleted == true) { throw new Exception("Employee does not work anymore"); }
                if (activityProject.IsDeleted == true) { throw new Exception("Project is deleted"); }
                if (projectEmployeeCheck == null) { throw new Exception("Employee does not work for this Project"); }

                string role;
                switch (activityDto.Role)
                {
                    case "pm":
                        role = Role.projectMeneger;
                        break;
                    case "se":
                        role = Role.softwareEngineer;
                        break;
                    case "ba":
                        role = Role.businessAnalyst;
                        break;
                    default:
                        throw new Exception("Such role do not exist");
                }

                string activityType;
                switch (activityDto.ActivityType)
                {
                    case "rw":
                        activityType = ActivityTypeConst.regularWork;
                        break;
                    case "ov":
                        activityType = ActivityTypeConst.overtime;
                        break;
                    default:
                        throw new Exception("Such activity do not exist");
                }

                Activity activity = new Activity()
                {
                    Name = activityDto.Name,
                    Role = role,
                    ActivityType = activityType,
                    EmployeeId = activityEmployee.Id,
                    ProjectId = activityProject.Id,
                    Employee = activityEmployee,
                    Project = activityProject
                };

                context.Activities.Add(activity);
                await context.SaveChangesAsync();
            }
            else { throw new Exception("Could not find Employee"); }
        }

        public async Task CreateEmployee(CreateEmployeeDto employeeDto)
        {
            if (context.Employees.FirstOrDefault(x => x.Name == employeeDto.Name) == null)
            {
                Employee employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Sex = employeeDto.Sex,
                    IsDeleted = false,
                    Birthday = DateOnly.Parse(employeeDto.Birthday)
                };

                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Such Employee is Exist");
        }

        public async Task CreateProject(CreateProjectDto projectDto)
        {
            if (context.Projects.FirstOrDefault(x => x.Name == projectDto.Name) == null)
            {
                Project project = new Project
                {
                    Name = projectDto.Name,
                    IsDeleted = false,
                    DateStart = DateOnly.Parse(projectDto.DateStart),
                    DateEnd = DateOnly.Parse(projectDto.DateEnd)
                };
                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Such Project is Exist");
        }
        #endregion CreateRegion

        #region DeleteRegion
        public Task DeleteEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectById(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion DeleteRegion

        #region GetByIdRegion
        public Task<Activity> GetActionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion GetByIdRegion

        #region GetAllRegion
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
        #endregion GetAllRegion

        #region GetSpecificRegion
        public Task<Activity> GetTrackerByPersonIdAndDate(Guid id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int number)
        {
            throw new NotImplementedException();
        }
        #endregion GetSpecificRegion

        #region UpdateRegion
        public Task UpdateActivity(UpdateActyvityDto activityDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProject(UpdateProjectDto projectDto)
        {
            throw new NotImplementedException();
        }
        #endregion UpdateRegion
    }
}

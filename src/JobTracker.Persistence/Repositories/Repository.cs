using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;
using JobTracker.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Activity = JobTracker.Dal.Entities.Activity;

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
            Project project = await context.Projects.FirstOrDefaultAsync(x => x.Id == activityDto.ProjectId);
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == activityDto.EmployeeId);

            if (project == null || project.IsDeleted == true) throw new Exception("Project does not exist or deleted");
            if (employee == null || employee.IsDeleted == true) throw new Exception("Employe does not exist or deleted");

            Activity activity = new Activity()
            {
                Name = activityDto.Name,
                Role = activityDto.Role,
                ActivityType = activityDto.ActivityType,
                EmployeeId = employee.Id,
                ProjectId = project.Id,
                Employee = employee,
                Project = project
            };

            context.Activities.Add(activity);
            await context.SaveChangesAsync();

            await context.SaveChangesAsync();
        }

        public async Task CreateEmployee(CreateEmployeeDto employeeDto)
        {
            Project project = new Project();
            project = context.Projects.FirstOrDefault(x => x.Id == employeeDto.ProjectId);
            if (project == null || project.IsDeleted == true) throw new Exception("Project does not exist or deleted");
            if (context.Employees.FirstOrDefault(x => x.Name == employeeDto.Name) == null)
            {
                Employee employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Sex = employeeDto.Sex,
                    IsDeleted = false,
                    Birthday = DateOnly.Parse(employeeDto.Birthday),
                    ProjectId = project.Id,
                    Project = project
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
                    DateEnd = DateOnly.Parse(projectDto.DateEnd),
                    Employees = new List<Employee>()
                };

                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Such Project is Exist");
        }
        #endregion CreateRegion

        #region DeleteRegion
        public async Task DeleteEmployeeById(Guid id)
        {
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null || employee.IsDeleted == false)
            {
                employee.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            else throw new Exception("Employee does not exist or deleted");
        }

        public async Task DeleteProjectById(Guid id)
        {
            Project project = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (project != null || project.IsDeleted == false)
            {
                project.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            else throw new Exception("Project does not exist or deleted");
        }
        #endregion DeleteRegion

        #region GetByIdRegion

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }
            return employee;
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            Project project = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Employee does not exist");
            }
            return project;
        }

        public async Task<Activity> GetActionById(Guid id)
        {
            Activity activity = await context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {
                throw new Exception("Employee does not exist");
            }
            return activity;
        }
        #endregion GetByIdRegion

        #region GetAllRegion
        public async Task<List<Activity>> GetAllActivities()
        {
            List<Activity> activities = await context.Activities.ToListAsync();
            return activities;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = await context.Employees.ToListAsync();
            return employees;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            List<Project> projects = await context.Projects.ToListAsync();
            return projects;
        }
        #endregion GetAllRegion

        #region GetSpecificRegion
        public async Task<Activity> GetTrackerByPersonIdAndDate(Guid id, string date)
        {
            DateOnly neededDate = DateOnly.Parse(date);
            Activity activity = new Activity();
            activity = await context.Activities.Where(x => x.EmployeeId == id).FirstOrDefaultAsync(x => x.Date == neededDate);

            if (activity == null) throw new Exception("Could cot find Activity");
            else return activity;
        }

        public async Task<Activity> GetTrackingByPersonIdAndWeekNumber(Guid id, int weekNumber)
        {
            Activity activity = new Activity();
            if (weekNumber > 52 || weekNumber < 1) throw new Exception("Wrong week number");
            int week = weekNumber*7;
            activity = await context.Activities.Where(x => x.Date.Day <= week && x.Date.Day >= week - 7).FirstOrDefaultAsync(x => x.Id == id);

            if (activity == null) throw new Exception("Could cot find Activity");
            else return activity;
        }
        #endregion GetSpecificRegion

        #region UpdateRegion

        public async Task UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            Employee employeeToUpdate = new Employee();

            employeeToUpdate = await context.Employees.FirstOrDefaultAsync(x => x.Id == employeeDto.Id);

            if (employeeToUpdate is null || employeeToUpdate.IsDeleted == true) { throw new Exception("Employee is not found or does not work here"); }
            else
            {
                employeeToUpdate.Name = employeeDto.Name;
                employeeToUpdate.Sex = employeeDto.Sex;
                employeeToUpdate.Birthday = DateOnly.Parse(employeeDto.Birthday);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateProject(UpdateProjectDto projectDto)
        {
            Project projectToUpdate = new Project();

            projectToUpdate = await context.Projects.FirstOrDefaultAsync(x => x.Id == projectDto.Id);

            if (projectToUpdate is null || projectToUpdate.IsDeleted == true) throw new Exception("Project is not found or does not work here");
            else
            {
                projectToUpdate.Name = projectDto.Name;
                projectToUpdate.DateEnd = DateOnly.Parse(projectDto.DateEnd);
                projectToUpdate.DateStart = DateOnly.Parse(projectDto.DateStart);

                await context.SaveChangesAsync();
            }
        }

        #endregion UpdateRegion
    }
}

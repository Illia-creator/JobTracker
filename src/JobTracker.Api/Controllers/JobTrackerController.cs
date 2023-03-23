using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.AddReferences;
using JobTracker.Dal.Entities.Dto.Create;
using JobTracker.Dal.Entities.Dto.Update;
using JobTracker.Persistence.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JobTrackerController : ControllerBase
    {
        private readonly IRepository repository;
        public JobTrackerController(IRepository repository)
        {
            this.repository = repository;
        }

        #region CreateRegion
        [HttpPost("create_project")]
        public async Task<IActionResult> AddProject(CreateProjectDto projectDto)
        {
            await repository.CreateProject(projectDto);
            return Ok();
        }

        [HttpPost("create_employee")]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto employeeDto)
        {
            await repository.CreateEmployee(employeeDto);
            return Ok();
        }

        [HttpPost("create_activity")]
        public async Task<IActionResult> AddActivity(CreateActivityDto activityDto)
        {
            await repository.CreateActivity(activityDto);
            return Ok();
        }
        #endregion CreateRegion

        #region DeleteRegion
        [HttpDelete("delete_employee")]
        public async Task<IActionResult> DeleteEmployee(Guid Id)
        {
            await repository.DeleteEmployeeById(Id);
            return Ok();
        }

        [HttpDelete("delete_project")]
        public async Task<IActionResult> DeleteProject(Guid Id)
        {
            await repository.DeleteProjectById(Id);
            return Ok();
        }
        #endregion DeleteRegion

        #region GetByIdRegion

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee(Guid Id) 
        {
            var result = await repository.GetEmployeeById(Id);
            return Ok(result);
        }

        [HttpGet("project")]
        public async Task<IActionResult> GetProject(Guid Id)
        {
            var result = await repository.GetProjectById(Id);
            return Ok(result);
        }

        [HttpGet("action")]
        public async Task<IActionResult> GetAction(Guid Id)
        {
            var result = await repository.GetActionById(Id);
            return Ok(result);
        }

        #endregion GetByIdRegion

        #region GetAllRegion

        [HttpGet("activities")]
        public async Task<IActionResult> GetAllActivities()
        {
            var result = await repository.GetAllActivities();
            return Ok(result);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmpoyees()
        {
            var result = await repository.GetAllEmployees();
            return Ok(result);
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await repository.GetAllProjects();
            return Ok(result);
        }
        #endregion GetAllRegion

        #region GetSpecificRegion
        #endregion GetSpecificRegion

        #region UpdateRegion

        [HttpPut("update_employee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            await repository.UpdateEmployee(employeeDto);
            return Ok();
        }

        [HttpPut("update_project")]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await repository.UpdateProject(projectDto);
            return Ok();
        }
        #endregion UpdateRegion       
    }
    
}

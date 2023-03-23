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
    [Route("[controller]")]
    public class JobTrackerController : ControllerBase
    {
        private readonly IRepository repository;
        public JobTrackerController(IRepository repository)
        {
            this.repository = repository;
        }

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

        [HttpPost("create_reference")]
        public async Task<IActionResult> AddEmployeeInProject(AddEmployeeInProjectDto EmployeeInProjectDto)
        {
            await repository.AddEmployeeInProject(EmployeeInProjectDto);
            return Ok();
        }

        [HttpPut("update_employee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            await repository.UpdateEmployee(employeeDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        { 
           var result = await repository.GetAllActivities();
            return Ok(result);
        }
    }
    
}

using JobTracker.Dal.Entities;
using JobTracker.Dal.Entities.Dto.Create;
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

        [HttpPost("create_Activity")]
        public async Task<IActionResult> AddActivity(CreateActivityDto activityDto)
        {
            await repository.CreateActivity(activityDto);
            return Ok();
        }
    }
}

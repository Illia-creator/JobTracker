namespace JobTracker.Dal.Entities.Dto.AddReferences
{
    public class AddEmployeeInProjectDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get ; set; }   
        public Guid ProjectId { get ; set; }           
    }
}

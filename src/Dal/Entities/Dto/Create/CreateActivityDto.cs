namespace JobTracker.Dal.Entities.Dto.Create
{
    public class CreateActivityDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ActivityType { get; set; }
        public string Date { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}

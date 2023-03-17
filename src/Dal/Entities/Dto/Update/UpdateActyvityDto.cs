namespace JobTracker.Dal.Entities.Dto.Update
{
    public class UpdateActyvityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string ActivityType { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}

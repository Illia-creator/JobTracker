namespace JobTracker.Dal.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string ActivityType { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }

    }
}

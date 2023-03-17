namespace JobTracker.Dal.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly Birthday { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Activity>? Activities { get; set; }
    }
}

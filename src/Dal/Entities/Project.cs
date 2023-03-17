namespace JobTracker.Dal.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateStart{ get; set; }
        public DateOnly DateEnd { get; set;}
        public List<Employee>? Employees { get; set; }
        public List<Activity>? Activities { get; set; }
    }
}

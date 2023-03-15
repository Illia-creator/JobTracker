namespace Dal.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateOnly Birthday { get; set; }
    }
}

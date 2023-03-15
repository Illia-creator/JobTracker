namespace Dal.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateStart{ get; set; }
        public DateOnly DateEnd { get; set;}
    }
}

namespace Dal.Entities
{
    public class Activity
    {
        public string Name { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public string Role { get; set; }
        public string ActivityType { get; set; }
    }
}

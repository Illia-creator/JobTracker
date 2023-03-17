namespace JobTracker.Dal.Entities.Dto.Create
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
}

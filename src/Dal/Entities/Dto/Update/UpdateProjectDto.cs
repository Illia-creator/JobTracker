namespace JobTracker.Dal.Entities.Dto.Update
{
    public class UpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
}

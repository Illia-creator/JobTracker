namespace JobTracker.Dal.Entities.Dto.Update
{
    public class UpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }
}

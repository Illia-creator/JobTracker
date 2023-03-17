namespace JobTracker.Dal.Entities.Dto.Create
{
    public class CreateEmployeeDto
    { 
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateOnly Birthday { get; set; }
        public Guid ProjectId { get; set; }
    }
}

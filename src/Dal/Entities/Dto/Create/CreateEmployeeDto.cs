namespace JobTracker.Dal.Entities.Dto.Create
{
    public class CreateEmployeeDto
    { 
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public Guid ProjectId { get; set; }
    }
}

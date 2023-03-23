﻿namespace JobTracker.Dal.Entities.Dto.Update
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public bool IsDeleted { get; set; }
        public string ProjectName { get; set; }
        public string Birthday { get; set; }
    }
}

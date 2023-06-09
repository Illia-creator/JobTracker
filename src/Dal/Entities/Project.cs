﻿namespace JobTracker.Dal.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly DateStart{ get; set; }
        public DateOnly DateEnd { get; set;}
        public List<Employee> Employees { get; set; }
    }
}

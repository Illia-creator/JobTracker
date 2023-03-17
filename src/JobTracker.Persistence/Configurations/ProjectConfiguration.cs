using JobTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracker.Persistence.Configurations
{
    internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Employees).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
            builder.HasMany(x => x.Activities).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
            // builder.Property(x => x.Name).  настройки 
        }
    }
}

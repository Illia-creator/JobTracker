using JobTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace JobTracker.Persistence.Configurations
{
    internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.DateStart);
            builder.Property(x => x.DateEnd);
            builder.HasMany(x => x.Employees).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
            // builder.Property(x => x.Name).  настройки 
        }
    }
}

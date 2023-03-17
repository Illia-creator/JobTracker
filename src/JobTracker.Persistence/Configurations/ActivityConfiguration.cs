using JobTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracker.Persistence.Configurations
{
    internal sealed class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee).WithMany(x => x.Activities).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Project).WithMany(x => x.Activities).HasForeignKey(x => x.ProjectId);
        }
    }
}

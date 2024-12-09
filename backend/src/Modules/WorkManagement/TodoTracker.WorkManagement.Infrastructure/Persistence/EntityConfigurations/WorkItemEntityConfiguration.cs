using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoTracker.workManagement.Domain;

namespace TodoTracker.WorkManagement.Infrastructure.Persistence.EntityConfigurations;

public class WorkItemEntityConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        builder.ToTable("work_item")
            .HasKey(pk => pk.Id);

        builder.Property(p => p.Id)
            .HasConversion(v => v.Value, v => WorkItemId.From(v));

        builder.Property(p => p.Title)
            .IsRequired();

        builder.Property(p => p.Description);
        
        builder.Property(p => p.Status)
            .HasConversion(v => v.Value, v => Status.From(v));

        builder.Property(p => p.DueDate);
    }
}
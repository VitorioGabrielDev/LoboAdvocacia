using Lobo.Domain.ProcessContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lobo.Infrastructure.ProcessContext.Mapping;

public class TodoMap : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("TODOS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ProcessId)
            .HasColumnName("PROCESS_ID")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("TITLE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Completed)
            .HasColumnName("COMPLETED")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
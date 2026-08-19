using Lobo.Domain.ProcessContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lobo.Infrastructure.ProcessContext.Mapping;

public class ProcessMap : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("PROCESSES");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CUSTOMER_ID")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("STATUS")
            .IsRequired();

        builder.Property(x => x.ProtocolDate)
            .HasColumnName("PROTOCOL_DATE")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.Action)
            .HasColumnName("ACTION")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ChildProcessId)
            .HasColumnName("CHILD_PROCESS_ID");
    }
}
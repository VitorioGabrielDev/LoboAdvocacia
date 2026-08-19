using Lobo.Domain.CustomerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lobo.Infrastructure.CustomerContext.Mapping;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("CUSTOMERS");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasColumnName("FIRST_NAME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(x => x.FullName)
            .HasColumnName("FULL_NAME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(x => x.NationalId)
            .HasColumnName("NATIONAL_ID")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.ContactPhone)
            .HasColumnName("CONTACT_PHONE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(x => x.Neighborhood)
            .HasColumnName("NEIGHBORHOOD")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.City)
            .HasColumnName("CITY")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.State)
            .HasColumnName("STATE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2)
            .IsRequired();
    }
}
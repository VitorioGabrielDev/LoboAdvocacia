using Flunt.Notifications;
using Lobo.Domain.CustomerContext;
using Lobo.Domain.ProcessContext;
using Microsoft.EntityFrameworkCore;
using Lobo.Domain.SharedContext.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lobo.Infrastructure.SharedContext.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<Todo> Todos { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
        
        modelBuilder.Ignore<Notification>();
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {

            if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .HasKey(nameof(Entity.Id))
                    .HasName($"{entityType.ClrType.Name.ToUpper()}_PK");
                
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(Entity.CreatedAt))
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("TIMESTAMP")
                    .IsRequired();
                
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(Entity.UpdatedAt))
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("TIMESTAMP")
                    .IsRequired();
            }
        }
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
            .Entries<Entity>()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        foreach (EntityEntry<Entity> entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.Now;
                    entry.Property(x => x.CreatedAt).CurrentValue = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.Now;
                    break;
            }
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
}
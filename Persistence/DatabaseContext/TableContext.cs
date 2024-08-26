using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.DatabaseContext;

public class TableContext : DbContext
{
    public DbSet<TableSpecification> TableSpecifications { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public TableContext(DbContextOptions<TableContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
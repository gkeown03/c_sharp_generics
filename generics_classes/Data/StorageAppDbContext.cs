using generics_classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace generics_classes.Data
{
    public class StorageAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organisation > Organisations => Set<Organisation>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
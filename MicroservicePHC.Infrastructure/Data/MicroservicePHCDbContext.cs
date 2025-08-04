using MicroservicePHC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MicroservicePHC.Infrastructure.Data
{
    public class MicroservicePHCDbContext(DbContextOptions<MicroservicePHCDbContext> options) : DbContext(options)
    {

        public DbSet<EntityExample> EntityExamples => Set<EntityExample>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

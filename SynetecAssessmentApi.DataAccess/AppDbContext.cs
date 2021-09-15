using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Models;
using System.Reflection;

namespace SynetecAssessmentApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            //Configure references
            modelBuilder.Entity<Employee>()
                .HasOne(w => w.Department)
                .WithMany(p => p.Employees)
                .HasForeignKey(w => w.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

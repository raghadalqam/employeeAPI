using Microsoft.EntityFrameworkCore;
using employeeAPI.Domain;
namespace employeeAPI.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          

            // Many-to-Many between Employee and Project  by using join table EmployeeProject
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId }); //   foregin key for  EmployeeId , ProjectId

            //  relationship  Employee and  EmployeeProject
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects) // we should add  ICollection<EmployeeProject> in  Employee
                .HasForeignKey(ep => ep.EmployeeId);

            //  relationship  Project and EmployeeProject
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects) //  we should add  ICollection<EmployeeProject> in Project
                .HasForeignKey(ep => ep.ProjectId);
        }
    
    }
}

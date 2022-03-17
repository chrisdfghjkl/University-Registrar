using Microsoft.EntityFrameworkCore;

namespace Registrar.Models
{
  public class RegistrarContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudent { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<CourseDepartmentStudent> CourseDepartmentStudent { get; set; }

    public RegistrarContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
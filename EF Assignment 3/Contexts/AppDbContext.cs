using EF_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_3.Data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-3QRHU6G\\SQLEXPRESS;Database=EF03;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }

    public DbSet<Instructor> Instructors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }
}
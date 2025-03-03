using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement;

public class SchoolContext: DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=StudentManagement;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}

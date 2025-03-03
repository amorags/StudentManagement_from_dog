using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }  // ✅ Added Instructor
}
using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public class Instructor
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public DateTime HireDate { get; set; }

    public Department Department { get; set; }
    
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public required Student Student { get; set; }
    
    public int CourseId { get; set; }
    public required Course Course { get; set; }
    
    public string? Grade { get; set; }
}

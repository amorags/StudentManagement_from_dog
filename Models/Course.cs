using System;
using System.Collections.Generic;

namespace DefaultNamespace;


public class Course
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Credits { get; set; }
    
    public required ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
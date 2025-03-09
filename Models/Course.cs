using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Credits { get; set; }

    public int InstructorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Instructor Instructor { get; set; } = null!;
}

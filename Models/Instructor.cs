using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

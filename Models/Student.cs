using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public class Student
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime DateOfBirth { get; set; } // ✅ New attribute

    public required ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}


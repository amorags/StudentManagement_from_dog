using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Budget { get; set; }

    // New relation to Instructor
    public int? DepartmentHeadId { get; set; }
    public Instructor DepartmentHead { get; set; }  // Navigation property
}

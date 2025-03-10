using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public class Department

{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation property to represent the DepartmentHead (Instructor)
        public int DepartmentHeadId { get; set; }
        public Instructor DepartmentHead { get; set; } = null!;
}

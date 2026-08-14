using System;
namespace StudentManagement.API.Models;

public class Student : Person
{
    public string StudentNumber { get; set; } = string.Empty;

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
}

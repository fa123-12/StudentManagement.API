using System;
namespace StudentManagement.API.Models;

public class Teacher : Person
{
    public string Speciality { get; set; } = string.Empty;
    public string TeacherCode { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; }
        = new List<Course>();
}
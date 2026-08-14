using System;
namespace StudentManagement.API.Models;


public class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public int Credits { get; set; }

    public int? TeacherId { get; set; }   // Clé étrangère
    //C'est ce qu'on appelle une propriété de navigation.
    public Teacher? Teacher { get; set; }  // Navigation

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
}
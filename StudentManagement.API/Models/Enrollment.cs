using System;
//La relation Student ↔ Course est Many-to-Many, donc on crée une classe Enrollment.
//Cette classe représente l'inscription d'un étudiant à un cours.
namespace StudentManagement.API.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public int CourseId { get; set; }

    public Course Course { get; set; }= null!;

    public DateTime EnrollmentDate { get; set; }

    public double Grade { get; set; }
}
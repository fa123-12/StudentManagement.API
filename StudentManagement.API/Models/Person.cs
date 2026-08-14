using System;
namespace StudentManagement.API.Models;

public abstract class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; }= string.Empty;

    public string Email { get; set; }=string.Empty;

    public DateTime BirthDate { get; set; }
}
namespace EF_Assignment_3.Models;

public class Student
{
    public int Id { get; set; }

    public required string FullName { get; set; }

    public required string Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
namespace EF_Assignment_3.Models;

public class Instructor
{
    public int Id { get; set; }

    public required string FullName { get; set; }

    public required string Email { get; set; }

    public string? Bio { get; set; }

    public DateTime JoinedDate { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
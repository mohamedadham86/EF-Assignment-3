using EF_Assignment_3.Models.Enums;

namespace EF_Assignment_3.Models;

public class Course
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public CourseLevel Level { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? PublishedDate { get; set; }

    public int InstructorId { get; set; }

    public int CategoryId { get; set; }

    public Instructor Instructor { get; set; } = null!;

    public Category Category { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
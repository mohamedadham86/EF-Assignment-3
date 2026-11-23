using EF_Assignment_3.Models.Enums;

namespace EF_Assignment_3.Models;

public class Enrollment
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public decimal Progress { get; set; }

    public EnrollmentStatus Status { get; set; }

    public decimal? FinalGrade { get; set; }

    public Student Student { get; set; } = null!;

    public Course Course { get; set; } = null!;
}
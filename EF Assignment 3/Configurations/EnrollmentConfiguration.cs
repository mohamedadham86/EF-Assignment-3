using EF_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Assignment_3.Data.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        
        builder.HasKey(e => new { e.StudentId, e.CourseId });

        
        builder.Property(e => e.EnrollmentDate)
            .IsRequired();

        builder.Property(e => e.Progress)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(e => e.Status)
            .IsRequired();

        builder.Property(e => e.FinalGrade)
            .HasPrecision(5, 2)
            .IsRequired(false);

        
        builder.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .IsRequired();

        
        builder.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .IsRequired();
    }
}
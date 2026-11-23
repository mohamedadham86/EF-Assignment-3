using EF_Assignment_3.Models;
using EF_Assignment_3.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EF_Assignment_3.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        
        builder.HasKey(c => c.Id);

       
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(c => c.Price)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(c => c.Level)
            .IsRequired();

        builder.Property(c => c.IsPublished)
            .IsRequired();

        builder.Property(c => c.PublishedDate)
            .IsRequired(false);

        
        builder.HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorId)
            .IsRequired();

        
        builder.HasOne(c => c.Category)
            .WithMany(cat => cat.Courses)
            .HasForeignKey(c => c.CategoryId)
            .IsRequired();


        builder.HasData(
            new Course
            {
                Id = 1,
                Title = "C# Fundamentals",
                Description = "Learn C# programming basics.",
                Price = 199.99m,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 6, 1),
                InstructorId = 1,
                CategoryId = 2
            },
            new Course
            {
                Id = 2,
                Title = "ASP.NET Core Web API",
                Description = "Build RESTful APIs using ASP.NET Core.",
                Price = 499.99m,
                Level = CourseLevel.Intermediate,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 7, 15),
                InstructorId = 1,
                CategoryId = 4
            },
            new Course
            {
                Id = 3,
                Title = "Advanced EF Core",
                Description = "Learn advanced Entity Framework Core concepts.",
                Price = 699.99m,
                Level = CourseLevel.Advanced,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 8, 10),
                InstructorId = 2,
                CategoryId = 4
            },
            new Course
            {
                Id = 4,
                Title = "React for Beginners",
                Description = "Learn React from scratch.",
                Price = 299.99m,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 9, 5),
                InstructorId = 3,
                CategoryId = 5
            },
            new Course
            {
                Id = 5,
                Title = "Frontend Development Basics",
                Description = "Introduction to frontend development.",
                Price = 249.99m,
                Level = CourseLevel.Intermediate,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 3,
                CategoryId = 3
            },
            new Course
            {
                Id = 6,
                Title = "Backend Architecture",
                Description = "Learn backend architecture and design.",
                Price = 799.99m,
                Level = CourseLevel.Advanced,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 2,
                CategoryId = 2
            }
        );
    }
}
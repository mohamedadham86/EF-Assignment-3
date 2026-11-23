
using EF_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Assignment_3.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        
        builder.HasKey(c => c.Id);

       
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .IsRequired(false)
            .HasMaxLength(500);

       
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        
        builder.HasMany(c => c.Courses)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .IsRequired();


        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "Programming and Software Development",
                ParentCategoryId = null
            },
            new Category
            {
                Id = 2,
                Name = "Backend",
                Description = "Backend Development",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 3,
                Name = "Frontend",
                Description = "Frontend Development",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 4,
                Name = "ASP.NET",
                Description = "ASP.NET Core Development",
                ParentCategoryId = 2
            },
            new Category
            {
                Id = 5,
                Name = "React",
                Description = "React Development",
                ParentCategoryId = 3
            }
        );
    }
}

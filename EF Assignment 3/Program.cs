using EF_Assignment_3.Data;
using EF_Assignment_3.Models;
using EF_Assignment_3.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_3
{
    internal class Program
    {
        static void Main()
        {
            SeedStudents();

            SeedEnrollments();
            CreateInstructor();
            CreateCourse();
            AddThreeStudents();
            EnrollStudent();
            FindCourseById();
            FindCourseByTitle();
            FilterCoursesByPrice();
            GetCategoriesHierarchy();
            GetCourseStudents();
            UpdateCoursePrice();
            UpdateEnrollmentProgress();
            PublishCourse();
            DeleteEnrollment();
            DeleteCategoryWithChildren();
            DeleteCourseWithEnrollments();
            IncreasePublishedCoursesPrices();
            DeleteDroppedEnrollments();
            Console.WriteLine("Seeding Completed Successfully.");
        }

        
        static void SeedStudents()
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (!context.Students.Any())
                {
                    List<Student> students = new List<Student>
                    {
                        new Student
                        {
                            FullName = "Mohamed Ahmed",
                            Email = "mohamed@example.com",
                            DateOfBirth = new DateTime(2002, 5, 10)
                        },
                        new Student
                        {
                            FullName = "Ali Hassan",
                            Email = "ali@example.com",
                            DateOfBirth = new DateTime(2001, 8, 15)
                        },
                        new Student
                        {
                            FullName = "Sara Mohamed",
                            Email = "sara@example.com",
                            DateOfBirth = new DateTime(2003, 2, 20)
                        },
                        new Student
                        {
                            FullName = "Omar Khaled",
                            Email = "omar@example.com",
                            DateOfBirth = new DateTime(2002, 11, 5)
                        },
                        new Student
                        {
                            FullName = "Nour Ahmed",
                            Email = "nour@example.com",
                            DateOfBirth = new DateTime(2004, 1, 12)
                        }
                    };

                    context.Students.AddRange(students);
                    context.SaveChanges();

                    Console.WriteLine("Students Seeded Successfully.");
                }
                else
                {
                    Console.WriteLine("Students Already Exist.");
                }
            }
        }

       
        static void SeedEnrollments()
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (!context.Enrollments.Any())
                {
                    List<Enrollment> enrollments = new List<Enrollment>
                    {
                        new Enrollment
                        {
                            StudentId = 1,
                            CourseId = 1,
                            EnrollmentDate = new DateTime(2025, 10, 1),
                            Progress = 100,
                            Status = EnrollmentStatus.Completed,
                            FinalGrade = 95
                        },
                        new Enrollment
                        {
                            StudentId = 1,
                            CourseId = 2,
                            EnrollmentDate = new DateTime(2025, 10, 5),
                            Progress = 40,
                            Status = EnrollmentStatus.Active,
                            FinalGrade = null
                        },
                        new Enrollment
                        {
                            StudentId = 2,
                            CourseId = 1,
                            EnrollmentDate = new DateTime(2025, 10, 10),
                            Progress = 100,
                            Status = EnrollmentStatus.Completed,
                            FinalGrade = 88
                        },
                        new Enrollment
                        {
                            StudentId = 2,
                            CourseId = 3,
                            EnrollmentDate = new DateTime(2025, 10, 12),
                            Progress = 20,
                            Status = EnrollmentStatus.Active,
                            FinalGrade = null
                        },
                        new Enrollment
                        {
                            StudentId = 3,
                            CourseId = 4,
                            EnrollmentDate = new DateTime(2025, 10, 15),
                            Progress = 0,
                            Status = EnrollmentStatus.Dropped,
                            FinalGrade = null
                        },
                        new Enrollment
                        {
                            StudentId = 3,
                            CourseId = 2,
                            EnrollmentDate = new DateTime(2025, 10, 20),
                            Progress = 60,
                            Status = EnrollmentStatus.Active,
                            FinalGrade = null
                        },
                        new Enrollment
                        {
                            StudentId = 4,
                            CourseId = 3,
                            EnrollmentDate = new DateTime(2025, 10, 25),
                            Progress = 100,
                            Status = EnrollmentStatus.Completed,
                            FinalGrade = 92
                        },
                        new Enrollment
                        {
                            StudentId = 5,
                            CourseId = 4,
                            EnrollmentDate = new DateTime(2025, 11, 1),
                            Progress = 10,
                            Status = EnrollmentStatus.Dropped,
                            FinalGrade = null
                        }
                    };

                    context.Enrollments.AddRange(enrollments);
                    context.SaveChanges();

                    Console.WriteLine("Enrollments Seeded Successfully.");
                }
                else
                {
                    Console.WriteLine("Enrollments Already Exist.");
                }
            }
        }
        
        static void CreateInstructor()
        {
            using (AppDbContext context = new AppDbContext())
            {
                Instructor instructor = new Instructor
                {
                    FullName = "Mahmoud Ibrahim",
                    Email = "mahmoud@example.com",
                    Bio = "Experienced .NET Instructor",
                    JoinedDate = DateTime.Now
                };

                context.Instructors.Add(instructor);

                context.SaveChanges();

                Console.WriteLine("Instructor Created Successfully.");
            }
        }
        
        static void CreateCourse()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int instructorId = 4;
                int categoryId = 4;

                
                bool instructorExists = context.Instructors
                    .Any(i => i.Id == instructorId);

                if (!instructorExists)
                {
                    Console.WriteLine("Instructor does not exist.");
                    return;
                }

               
                bool categoryExists = context.Categories
                    .Any(c => c.Id == categoryId);

                if (!categoryExists)
                {
                    Console.WriteLine("Category does not exist.");
                    return;
                }

                Course course = new Course
                {
                    Title = "ASP.NET Core Advanced",
                    Description = "Learn advanced ASP.NET Core concepts.",
                    Price = 599.99m,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = instructorId,
                    CategoryId = categoryId
                };

                context.Courses.Add(course);
                context.SaveChanges();

                Console.WriteLine("Course Created Successfully.");
            }
        }
      
        static void AddThreeStudents()
        {
            using (AppDbContext context = new AppDbContext())
            {
                List<Student> students = new List<Student>
        {
            new Student
            {
                FullName = "Khaled Mohamed",
                Email = "khaled@example.com",
                DateOfBirth = new DateTime(2002, 4, 15)
            },

            new Student
            {
                FullName = "Mariam Ahmed",
                Email = "mariam@example.com",
                DateOfBirth = new DateTime(2003, 7, 20)
            },

            new Student
            {
                FullName = "Youssef Ali",
                Email = "youssef@example.com",
                DateOfBirth = new DateTime(2001, 9, 10)
            }
        };

                context.Students.AddRange(students);

                context.SaveChanges();

                Console.WriteLine("Three Students Added Successfully.");
            }
        }
       
        static void EnrollStudent()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int studentId = 6;
                int courseId = 1;

                
                bool studentExists = context.Students
                    .Any(s => s.Id == studentId);

                if (!studentExists)
                {
                    Console.WriteLine("Student does not exist.");
                    return;
                }

                
                Course? course = context.Courses
                    .FirstOrDefault(c => c.Id == courseId);

                if (course == null)
                {
                    Console.WriteLine("Course does not exist.");
                    return;
                }

                if (!course.IsPublished)
                {
                    Console.WriteLine("Cannot enroll in an unpublished course.");
                    return;
                }

                
                bool alreadyEnrolled = context.Enrollments
                    .Any(e => e.StudentId == studentId && e.CourseId == courseId);

                if (alreadyEnrolled)
                {
                    Console.WriteLine("Student is already enrolled in this course.");
                    return;
                }

                Enrollment enrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    EnrollmentDate = DateTime.Now,
                    Progress = 0,
                    Status = EnrollmentStatus.Active,
                    FinalGrade = null
                };

                context.Enrollments.Add(enrollment);
                context.SaveChanges();

                Console.WriteLine("Student Enrolled Successfully.");
            }
        }
      
        static void FindCourseById()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int courseId = 1;

                Course? course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                Console.WriteLine("Course Found Successfully.");
                Console.WriteLine($"ID: {course.Id}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Price: {course.Price}");
                Console.WriteLine($"Level: {course.Level}");
                Console.WriteLine($"Is Published: {course.IsPublished}");
            }
        }
        
        static void FindCourseByTitle()
        {
            using (AppDbContext context = new AppDbContext())
            {
                string courseTitle = "ASP.NET Core Web API";

                Course? course = context.Courses
                    .FirstOrDefault(c => c.Title == courseTitle);

                if (course == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                Console.WriteLine("Course Found Successfully.");
                Console.WriteLine($"ID: {course.Id}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Description: {course.Description}");
                Console.WriteLine($"Price: {course.Price}");
            }
        }
      
        static void FilterCoursesByPrice()
        {
            using (AppDbContext context = new AppDbContext())
            {
                decimal minPrice = 200;
                decimal maxPrice = 700;

                List<Course> courses = context.Courses
                    .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                    .OrderByDescending(c => c.Price)
                    .ToList();

                if (courses.Count == 0)
                {
                    Console.WriteLine("No Courses Found in This Price Range.");
                    return;
                }

                Console.WriteLine("Courses Between 200 and 700:");

                foreach (Course course in courses)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Title: {course.Title}");
                    Console.WriteLine($"Price: {course.Price}");
                }
            }
        }
        
        static void GetCategoriesHierarchy()
        {
            using (AppDbContext context = new AppDbContext())
            {
                
                List<Category> parentCategories = context.Categories
                    .Where(c => context.Categories
                        .Any(sub => sub.ParentCategoryId == c.Id))
                    .ToList();

                Console.WriteLine("Categories With Subcategories:");

                foreach (Category category in parentCategories)
                {
                    Console.WriteLine($"{category.Id} - {category.Name}");
                }

                
                List<Category> topLevelCategories = context.Categories
                    .Where(c => c.ParentCategoryId == null)
                    .ToList();

                Console.WriteLine("\nTop-Level Categories:");

                foreach (Category category in topLevelCategories)
                {
                    Console.WriteLine($"{category.Id} - {category.Name}");
                }
            }
        }
       
        static void GetCourseStudents()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int courseId = 1;

               
                List<int> studentIds = context.Enrollments
                    .Where(e => e.CourseId == courseId)
                    .Select(e => e.StudentId)
                    .ToList();

                if (studentIds.Count == 0)
                {
                    Console.WriteLine("No Students Enrolled in This Course.");
                    return;
                }

              
                List<Student> students = context.Students
                    .Where(s => studentIds.Contains(s.Id))
                    .ToList();

                Console.WriteLine($"Students Enrolled in Course ID {courseId}:");

                foreach (Student student in students)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"ID: {student.Id}");
                    Console.WriteLine($"Name: {student.FullName}");
                    Console.WriteLine($"Email: {student.Email}");
                }
            }
        }
       
        static void UpdateCoursePrice()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int courseId = 1;
                decimal newPrice = 350;

                Course? course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                Console.WriteLine($"Old Price: {course.Price}");

                course.Price = newPrice;

                context.SaveChanges();

                Console.WriteLine("Course Price Updated Successfully.");
                Console.WriteLine($"New Price: {course.Price}");
            }
        }
        
        static void UpdateEnrollmentProgress()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int studentId = 1;
                int courseId = 1;
                decimal newProgress = 100;

                Enrollment? enrollment = context.Enrollments
                    .Find(studentId, courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment Not Found.");
                    return;
                }

                if (newProgress < 0 || newProgress > 100)
                {
                    Console.WriteLine("Progress must be between 0 and 100.");
                    return;
                }

                enrollment.Progress = newProgress;

                if (newProgress == 100)
                {
                    enrollment.Status = EnrollmentStatus.Completed;
                }

                context.SaveChanges();

                Console.WriteLine("Enrollment Updated Successfully.");
                Console.WriteLine($"Progress: {enrollment.Progress}%");
                Console.WriteLine($"Status: {enrollment.Status}");
            }
        }
       
        static void PublishCourse()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int courseId = 5;

                Course? course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                if (course.IsPublished)
                {
                    Console.WriteLine("Course Is Already Published.");
                    return;
                }

                course.IsPublished = true;
                course.PublishedDate = DateTime.Now;

                context.SaveChanges();

                Console.WriteLine("Course Published Successfully.");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Published Date: {course.PublishedDate}");
            }
        }
        
        static void DeleteEnrollment()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int studentId = 1;
                int courseId = 2;

                
                Enrollment? enrollment = context.Enrollments
                    .Find(studentId, courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment Not Found.");
                    return;
                }

                context.Enrollments.Remove(enrollment);

                context.SaveChanges();

                Console.WriteLine("Enrollment Deleted Successfully.");
            }
        }
        
        static void DeleteCategoryWithChildren()
        {
            int categoryId = 1;

          
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    Category? category = context.Categories.Find(categoryId);

                    if (category == null)
                    {
                        Console.WriteLine("Category Not Found.");
                        return;
                    }

                    context.Categories.Remove(category);
                    context.SaveChanges();

                    Console.WriteLine("Category Deleted Successfully.");
                }
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Cannot Delete Category Because It Has Subcategories.");
            }

            
            using (AppDbContext context = new AppDbContext())
            {
                bool hasSubcategories = context.Categories
                    .Any(c => c.ParentCategoryId == categoryId);

                if (hasSubcategories)
                {
                    Console.WriteLine("Safe Check: Category Has Subcategories. Deletion Prevented.");
                    return;
                }

                Category? category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();

                    Console.WriteLine("Category Deleted Successfully.");
                }
            }
        }
      
        static void DeleteCourseWithEnrollments()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int courseId = 4;

                Course? course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                
                int enrollmentsBefore = context.Enrollments
                    .Count(e => e.CourseId == courseId);

                Console.WriteLine($"Enrollments Before Deletion: {enrollmentsBefore}");

                

                context.Courses.Remove(course);

                context.SaveChanges();

               
                int enrollmentsAfter = context.Enrollments
                    .Count(e => e.CourseId == courseId);

                Console.WriteLine("Course Deleted Successfully.");
                Console.WriteLine($"Enrollments After Deletion: {enrollmentsAfter}");
            }
        }
        
        static void IncreasePublishedCoursesPrices()
        {
            using (AppDbContext context = new AppDbContext())
            {
                CourseLevel selectedLevel = CourseLevel.Intermediate;

                int affectedRows = context.Courses
                    .Where(c => c.IsPublished && c.Level == selectedLevel)
                    .ExecuteUpdate(setters => setters
                        .SetProperty(c => c.Price, c => c.Price * 1.10m));

                Console.WriteLine("Courses Prices Updated Successfully.");
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }
       
        static void DeleteDroppedEnrollments()
        {
            using (AppDbContext context = new AppDbContext())
            {
                int affectedRows = context.Enrollments
                    .Where(e => e.Status == EnrollmentStatus.Dropped)
                    .ExecuteDelete();

                Console.WriteLine("Dropped Enrollments Deleted Successfully.");
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new SchoolContext(
            serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>());

        context.Database.EnsureCreated();

        if (context.Majors.Any())
            return;

        var majors = new[]
        {
            new Major { MajorName = "IT" },
            new Major { MajorName = "Economics" },
            new Major { MajorName = "Mathematics" }
        };
        context.Majors.AddRange(majors);
        context.SaveChanges();

        var learners = new[]
        {
            new Learner
            {
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2005-09-01"),
                MajorID = majors[0].MajorID
            },
            new Learner
            {
                FirstMidName = "Meredith",
                LastName = "Alonso",
                EnrollmentDate = DateTime.Parse("2002-09-01"),
                MajorID = majors[1].MajorID
            }
        };
        context.Learners.AddRange(learners);
        context.SaveChanges();

        var courses = new[]
        {
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
        };
        context.Courses.AddRange(courses);
        context.SaveChanges();

        var enrollments = new[]
        {
            new Enrollment { LearnerID = learners[0].LearnerID, CourseID = 1050, Grade = 5.5f },
            new Enrollment { LearnerID = learners[0].LearnerID, CourseID = 4022, Grade = 7.5f },
            new Enrollment { LearnerID = learners[1].LearnerID, CourseID = 1050, Grade = 3.5f },
            new Enrollment { LearnerID = learners[1].LearnerID, CourseID = 4041, Grade = 7.0f }
        };
        context.Enrollments.AddRange(enrollments);
        context.SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Learner> Learners => Set<Learner>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Major> Majors => Set<Major>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Major>().ToTable(nameof(Major));
        modelBuilder.Entity<Course>().ToTable(nameof(Course));
        modelBuilder.Entity<Learner>().ToTable(nameof(Learner));
        modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));

        modelBuilder.Entity<Major>()
            .HasMany(m => m.Learners)
            .WithOne(l => l.Major)
            .HasForeignKey(l => l.MajorID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Learner>()
            .HasMany(l => l.Enrollments)
            .WithOne(e => e.Learner)
            .HasForeignKey(e => e.LearnerID);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseID);
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }

    [Display(Name = "Mã môn học")]
    public int CourseID { get; set; }

    [Display(Name = "Mã người học")]
    public int LearnerID { get; set; }

    [Range(0, 10)]
    [Display(Name = "Điểm")]
    public float Grade { get; set; }

    public Learner? Learner { get; set; }
    public Course? Course { get; set; }
}

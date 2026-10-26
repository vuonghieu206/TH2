using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Learner
{
    public int LearnerID { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập họ.")]
    [StringLength(100)]
    [Display(Name = "Họ")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên.")]
    [StringLength(100)]
    [Display(Name = "Tên")]
    public string FirstMidName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Ngày nhập học")]
    public DateTime EnrollmentDate { get; set; } = DateTime.Today;

    [Display(Name = "Ngành")]
    public int MajorID { get; set; }

    public Major? Major { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

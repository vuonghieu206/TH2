using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Major
{
    public int MajorID { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên ngành.")]
    [StringLength(100)]
    [Display(Name = "Tên ngành")]
    public string MajorName { get; set; } = string.Empty;

    public ICollection<Learner> Learners { get; set; } = new List<Learner>();
}

using Microsoft.AspNetCore.Mvc;

using THLab1.Models;

namespace MyWebApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new()
        {
            new Student
            {
                Id = 101,
                Name = "Hải Nam",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A1-2018",
                Email = "nam@g.com",
                DateOfBirth = new DateTime(2004, 1, 1)
            },
            new Student
            {
                Id = 102,
                Name = "Minh Tú",
                Branch = Branch.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A1-2019",
                Email = "tu@g.com",
                DateOfBirth = new DateTime(2004, 2, 1)
            },
            new Student
            {
                Id = 103,
                Name = "Hoàng Phong",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "A1-2020",
                Email = "phong@g.com",
                DateOfBirth = new DateTime(2004, 3, 1)
            },
            new Student
            {
                Id = 104,
                Name = "Xuân Mai",
                Branch = Branch.EE,
                Gender = Gender.Female,
                IsRegular = false,
                Address = "A1-2021",
                Email = "mai@g.com",
                DateOfBirth = new DateTime(2004, 4, 1)
            }
        };

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues<Gender>();
            return View();
        }

        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);

                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>().ToList();

            return View(s);
        }
    }
}
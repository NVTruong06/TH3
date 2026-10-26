using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH3.Models;

namespace TH3.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudent = new List<Student>();
        public StudentController()
        {
            listStudent = new List<Student>()
            {
                new Student(){Id = 1, Name = "Truong", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "Hanoi", Email = "UTC@gmail.com"},
                new Student(){Id = 2, Name = "Trg", Branch = Branch.BE, Gender = Gender.Male, IsRegular = true, Address = "Hanoi", Email = "UTC@gmail.com"},
                new Student(){Id = 3, Name = "Nguyen", Branch = Branch.CE, Gender = Gender.Male, IsRegular = true, Address = "Hanoi", Email = "UTC@gmail.com"},
                new Student(){Id = 4, Name = "Van", Branch = Branch.EE, Gender = Gender.Male, IsRegular = true, Address = "Hanoi", Email = "UTC@gmail.com"}
            };
        }
        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(listStudent);
        }
        [HttpGet("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{Text = "IT", Value = "1" },
                new SelectListItem{Text = "BE", Value = "2" },
                new SelectListItem{Text = "CE", Value = "3" },
                new SelectListItem{Text = "EE", Value = "4" }
            };
            return View();
        }
        [HttpPost("Add")]
        public IActionResult Create(Student student)
        {
            student.Id = listStudent.Last<Student>().Id + 1;
            listStudent.Add(student);
            return View("Index", listStudent);
        }
    }
}

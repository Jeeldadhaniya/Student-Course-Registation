using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistrationApp.Models;

namespace StudentCourseRegistrationApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Student or /Student/Index
        public IActionResult Index()
        {
            var students = StudentRepository.GetAll();
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Add(student);
                TempData["SuccessMessage"] = $"Student \"{student.Name}\" was registered successfully!";
                return RedirectToAction(nameof(Index));
            }

            // Server-side validation failed; redisplay form with error messages
            return View(student);
        }

        // GET: /Student/Details/5
        public IActionResult Details(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}

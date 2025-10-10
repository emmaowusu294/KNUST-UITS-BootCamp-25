using ConsoleApp2;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseService _dbService;

        public StudentController()
        {
            _dbService = new DatabaseService();
        }

        // 🔹 LIST ALL STUDENTS
        public IActionResult Index()
        {
            List<Student> students = _dbService.GetStudents();
            return View(students);
        }

        // 🔹 ADD (GET)
        public IActionResult Add()
        {
            return View();
        }

        // 🔹 ADD (POST)
        [HttpPost]
        public IActionResult Add([FromForm] Student request)
        {
            _dbService.AddStudent(request.FirstName, request.LastName,
                request.Gender, request.BirthDate);

            return RedirectToAction(nameof(Index));
        }

        // 🔹 EDIT (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _dbService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        public IActionResult Edit([FromForm] Student request)
        {
            if (request.StudentId == null)
                return BadRequest("Student ID is missing");

            _dbService.UpdateStudent(request.StudentId.Value,
                request.FirstName, request.LastName,
                request.Gender, request.BirthDate);

            return RedirectToAction(nameof(Index));
        }


        // 🔹 Delete (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _dbService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // 🔹 Delete (POST)
        [HttpPost]
        public IActionResult Delete([FromForm] Student request)
        {
            if (request.StudentId == null)
                return BadRequest("Student ID is missing");

            _dbService.DeleteStudent(request.StudentId.Value);

            return RedirectToAction(nameof(Index));
        }

        //FILTER (GET)
        public IActionResult Filter()
        {
            return View();
        }

       

    }
}

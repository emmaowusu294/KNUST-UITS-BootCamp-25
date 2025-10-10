using ConsoleApp2;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private DatabaseService _dbService;

        public StudentController()
        {
            _dbService = new DatabaseService();
        }
        public IActionResult Index()
        {
            List<Student> students = _dbService.GetStudents();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Add([FromForm] Student request)
        {
            _dbService.AddStudent(request.FirstName, request.LastName, 
                request.Gender, request.BirthDate);

            return RedirectToAction(nameof(Index));
        }
    }
}

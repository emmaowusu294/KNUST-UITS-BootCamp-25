//using ConsoleApp2;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Data.SCHOOLContext;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        //private DatabaseService _dbService;
        private SchoolContext _schoolContext;

        public StudentController(SchoolContext schoolContext)
        {
            //_dbService = new DatabaseService();

            _schoolContext = schoolContext;
        }
        public IActionResult Index()
        {
            //List<Student> students = _dbService.GetStudents();
            List<Student> students = _schoolContext.Students.ToList();
            return View(students);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Student request)
        {
            //_dbService.AddStudent(request.FirstName, request.LastName, 
            //    request.Gender, request.BirthDate);
            _schoolContext.Students.Add(request);
            _schoolContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            //Student student = _dbService.GetStudent(id);
            Student student = _schoolContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Student request)
        {
            //_dbService.updateStudent(request);
            _schoolContext.Students.Update(request);
            _schoolContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Delete(int id)
        //{
        //    //Student student = _dbService.GetStudent(id);

        //    return View(student);
        //}

        [HttpPost]
        public IActionResult Delete([FromForm] Student request)
        {
            //_dbService.deleteStudent(request.StudentId);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Filter()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Filter([FromForm] YearFilter filter)
        //{

        //    List<Student> students = _dbService.FilterStudents(filter.StartingYear);
        //    return View(nameof(Index), students);
        //}
    }
}

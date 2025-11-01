using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleStudentApp.Services;
using SimpleStudentApp.ViewModels;

namespace SimpleStudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var viewModel = _studentService.GetAllStudents();
            return View(viewModel);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var viewModel = _studentService.GetStudentById(id.Value);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel); 
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel viewModel, IFormFile studentImageFile)
        {
            if (ModelState.IsValid)
            {
                _studentService.CreateStudent(viewModel, studentImageFile);

                // 2. Redirect to the main list
                return RedirectToAction(nameof(Index));
            }

            // 3. If invalid, return the form with the user's data
            return View(viewModel);
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) { 
                return NotFound();            
            }

            var viewModel = _studentService.GetStudentById(id.Value);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentViewModel viewModel, IFormFile studentImageFile)
        {
            if (id != viewModel.Id) {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool studentExits = _studentService.StudentExists(id);

                if (!studentExits) { 
                    return NotFound();
                }

                _studentService.UpdateStudent(viewModel, studentImageFile);
                return RedirectToAction(nameof(Index));

            }
            return View(viewModel);
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _studentService.GetStudentById(id.Value);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            if (ModelState.IsValid)
            {
                _studentService.DeleteStudent(id);

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
    }
}

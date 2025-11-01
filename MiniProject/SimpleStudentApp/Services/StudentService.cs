using Microsoft.EntityFrameworkCore;
using SimpleStudentApp.Data;
using SimpleStudentApp.Models;
using SimpleStudentApp.ViewModels;

namespace SimpleStudentApp.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD operations

        // List al students
        public List<StudentViewModel> GetAllStudents()
        {
            var viewModels =  _context.Students
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Program = s.Program,
                    EnrollmentDate = s.EnrollmentDate,
                    StudentImage = s.StudentImage,
                    StudentImageMimeType = s.StudentImageMimeType,

                })
                .ToList();

            return viewModels;

        }

        //Create
        public void CreateStudent(StudentViewModel viewModel, IFormFile studentImageFile)
        {
            var student = new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Program = viewModel.Program,
                EnrollmentDate = viewModel.EnrollmentDate
            };

            if (studentImageFile != null && studentImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    studentImageFile.CopyTo(memoryStream); 
                    student.StudentImage = memoryStream.ToArray();

                    student.StudentImageMimeType = studentImageFile.ContentType;
                }
            }

            _context.Students.Add(student);

            _context.SaveChanges();
        }

        // Update
        public void  UpdateStudent(StudentViewModel viewModel, IFormFile studentImageFile)
        {
            var student = _context.Students.Find(viewModel.Id);

            if (student != null)
            {
                student.FirstName = viewModel.FirstName;
                student.LastName = viewModel.LastName;
                student.Program = viewModel.Program;
                student.EnrollmentDate = viewModel.EnrollmentDate;

                //is there a new image???
                if (studentImageFile != null && studentImageFile.Length > 0)
                {
                    // add it to the database
                    using (var memoryStream = new MemoryStream())
                    {
                        studentImageFile.CopyTo(memoryStream);
                        student.StudentImage = memoryStream.ToArray();

                        student.StudentImageMimeType = studentImageFile.ContentType;
                    }
                }

                _context.Students.Update(student);

                _context.SaveChanges();

            }

          
        }


        // Get a single student by its ID
        public StudentViewModel GetStudentById(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return null;
            }

            var ViewModel = new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Program = student.Program,
                EnrollmentDate = student.EnrollmentDate,
                StudentImage = student.StudentImage,
                StudentImageMimeType = student.StudentImageMimeType,
            };

            return ViewModel;
        }

        // For the Delete 
        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }


        public bool StudentExists(int id)
        {
            return _context.Students.Any(S => S.Id == id);
        }
    }

}

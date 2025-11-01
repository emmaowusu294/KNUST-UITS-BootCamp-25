using System.ComponentModel.DataAnnotations;
namespace SimpleStudentApp.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Program { get; set; } = null!;

        [Required]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public byte[]? StudentImage { get; set; }

        public string StudentImageMimeType { get; set; }

    }

}
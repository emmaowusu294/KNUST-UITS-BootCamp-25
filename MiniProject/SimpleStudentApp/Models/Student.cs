using System;
using System.Collections.Generic;

namespace SimpleStudentApp.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Program { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public byte[]? StudentImage { get; set; }

    public string StudentImageMimeType { get; set; }
}

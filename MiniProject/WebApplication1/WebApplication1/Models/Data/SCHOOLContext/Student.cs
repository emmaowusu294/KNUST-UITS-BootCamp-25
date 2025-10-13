using System;
using System.Collections.Generic;

namespace WebApplication1.Models.Data.SCHOOLContext;

public partial class Student
{
    public int Studentid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}

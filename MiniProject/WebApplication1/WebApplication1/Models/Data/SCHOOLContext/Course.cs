using System;
using System.Collections.Generic;

namespace WebApplication1.Models.Data.SCHOOLContext;

public partial class Course
{
    public int Courseid { get; set; }

    public string Coursename { get; set; } = null!;

    public string Coursecode { get; set; } = null!;

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}

using System;
using System.Collections.Generic;

namespace WebApplication1.Models.Data.SCHOOLContext;

public partial class Score
{
    public int Scoreid { get; set; }

    public int Studentid { get; set; }

    public int Courseid { get; set; }

    public decimal Mark { get; set; }

    public string Grade { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

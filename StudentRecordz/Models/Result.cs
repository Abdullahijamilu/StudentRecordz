using System;
using System.Collections.Generic;

namespace StudentRecordz.Models;

public partial class Result
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string Subject { get; set; } = null!;

    public int Score { get; set; }

    public string Grade { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StudentRecordz.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

}

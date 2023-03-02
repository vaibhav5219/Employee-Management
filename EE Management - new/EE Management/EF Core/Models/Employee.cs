using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Emp { get; set; } = null!;

    public int Salary { get; set; }
}

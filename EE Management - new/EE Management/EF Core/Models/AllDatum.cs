using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class AllDatum
{
    public int Empid { get; set; }

    public string Empname { get; set; } = null!;
}

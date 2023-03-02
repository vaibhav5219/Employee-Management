using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class RegularExp
{
    public int? Pid { get; set; }

    public string? Pname { get; set; }

    public DateTime? Pdob { get; set; }

    public int? Pnum { get; set; }
}

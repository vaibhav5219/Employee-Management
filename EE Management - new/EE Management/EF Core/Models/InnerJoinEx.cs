using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class InnerJoinEx
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Cityname { get; set; }

    public string? Pname { get; set; }
}

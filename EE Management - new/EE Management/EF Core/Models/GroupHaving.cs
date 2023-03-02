using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class GroupHaving
{
    public int Id { get; set; }

    public string? NameHello { get; set; }

    public int? SumId { get; set; }

    public int? SumAge { get; set; }

    public int? CityCount { get; set; }

    public int? CountAll { get; set; }
}

using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class DancePartner
{
    public int StudentId { get; set; }

    public string Gender { get; set; } = null!;
}

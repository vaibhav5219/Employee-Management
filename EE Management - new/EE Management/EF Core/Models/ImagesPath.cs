using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class ImagesPath
{
    public int Id { get; set; }

    public string? ImagePath { get; set; }

    public int MovieId { get; set; }
}

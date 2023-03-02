using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class VideosPath
{
    public int Id { get; set; }

    public string? VideoPath { get; set; }

    public int MovieId { get; set; }
}

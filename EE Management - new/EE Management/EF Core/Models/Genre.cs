using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Genre
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}

using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Rental
{
    public int Id { get; set; }

    public DateTime DateRented { get; set; }

    public int CustomerId { get; set; }

    public int MovieId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}

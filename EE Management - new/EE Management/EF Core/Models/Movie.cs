using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte GenreId { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public byte NumberInStock { get; set; }

    public byte NumberAvailable { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();
}

using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsSubscribedToNewsletter { get; set; }

    public byte MembershipTypeId { get; set; }

    public DateTime? Birthdate { get; set; }

    public virtual CustomerAspNetUser? CustomerAspNetUser { get; set; }

    public virtual MembershipType MembershipType { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();
}

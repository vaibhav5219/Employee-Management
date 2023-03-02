using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class MembershipType
{
    public byte Id { get; set; }

    public short SignUpFee { get; set; }

    public byte DurationInMonths { get; set; }

    public byte DiscountRate { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}

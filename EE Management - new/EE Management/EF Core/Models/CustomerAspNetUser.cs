using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class CustomerAspNetUser
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string ApplicationUserId { get; set; } = null!;

    public virtual AspNetUser ApplicationUser { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}

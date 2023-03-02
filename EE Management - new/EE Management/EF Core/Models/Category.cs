﻿using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}

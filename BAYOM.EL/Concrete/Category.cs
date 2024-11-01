﻿using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Category
{
    public int Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
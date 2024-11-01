using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Productbrand
{
    public int Productbrandid { get; set; }

    public string? Productbrandname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

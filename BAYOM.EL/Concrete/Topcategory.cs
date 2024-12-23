using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Topcategory
{
    public byte Topcategoryid { get; set; }

    public string? Topcategoryname { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

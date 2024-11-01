using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Cart
{
    public int Cartid { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Cartdate { get; set; }

    public int? Customerid { get; set; }

    public virtual ICollection<Cartdetail> Cartdetails { get; set; } = new List<Cartdetail>();

    public virtual Customer? Customer { get; set; }
}

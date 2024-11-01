using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Cartdetail
{
    public int Cartdetailid { get; set; }

    public int? Cartid { get; set; }

    public int? Productid { get; set; }

    public byte? Quantity { get; set; }

    public decimal? Total { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}

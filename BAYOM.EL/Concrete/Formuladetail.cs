using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Formuladetail
{
    public int Formuladetailid { get; set; }

    public int? Formulaid { get; set; }

    public int? Productid { get; set; }

    public int? Fromuladetailquatity { get; set; }

    public virtual ICollection<Combination> Combinations { get; set; } = new List<Combination>();

    public virtual Formula? Formula { get; set; }

    public virtual Product? Product { get; set; }
}

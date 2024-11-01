using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Formula
{
    public int Formulaid { get; set; }

    public int? Productid { get; set; }

    public virtual ICollection<Combination> Combinations { get; set; } = new List<Combination>();

    public virtual ICollection<Formuladetail> Formuladetails { get; set; } = new List<Formuladetail>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<Productserino> Productserinos { get; set; } = new List<Productserino>();

    public virtual ICollection<Transactionserino> Transactionserinos { get; set; } = new List<Transactionserino>();
}

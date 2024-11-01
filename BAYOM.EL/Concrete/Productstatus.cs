using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Productstatus
{
    public int Productstatuid { get; set; }

    public string? Productsatusname { get; set; }

    public virtual ICollection<Productserino> Productserinos { get; set; } = new List<Productserino>();
}

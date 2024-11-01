using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Productserino
{
    public int Productserinoid { get; set; }

    public string? Productserinoserino { get; set; }

    public DateTime? Productserinodateofproduction { get; set; }

    public int? Productstatuid { get; set; }

    public int? Productid { get; set; }

    public int? Formulaid { get; set; }

    public virtual Formula? Formula { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Productstatus? Productstatu { get; set; }
}

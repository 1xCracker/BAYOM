using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Transactionserino
{
    public long Transactionserinoid { get; set; }

    public int? Transactionid { get; set; }

    public int? Productid { get; set; }

    public string? Serino { get; set; }

    public int? Formulaid { get; set; }

    public virtual Formula? Formula { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Transaction? Transaction { get; set; }
}

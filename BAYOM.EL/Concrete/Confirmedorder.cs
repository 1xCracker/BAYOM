using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Confirmedorder
{
    public int? Confirmedorderid { get; set; }

    public int? Orderid { get; set; }

    public DateTime? Confirmedorderdate { get; set; }
}

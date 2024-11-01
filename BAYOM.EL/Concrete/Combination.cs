using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Combination
{
    public int Combinationid { get; set; }

    public int? Formuladetailid { get; set; }

    public int? Formulaid { get; set; }

    public string? Serino { get; set; }

    public virtual Formula? Formula { get; set; }

    public virtual Formuladetail? Formuladetail { get; set; }
}

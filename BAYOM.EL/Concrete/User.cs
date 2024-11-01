using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class User
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Userpassword { get; set; }

    public int? Employeeid { get; set; }

    public int? Customerid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}

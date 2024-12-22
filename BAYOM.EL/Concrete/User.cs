using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class User
{
    public int Userid { get; set; }

    public string Useremail { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public int? Employeeid { get; set; }

    public int? Customerid { get; set; }

    public int Userrole { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Userrole UserroleNavigation { get; set; } = null!;
}

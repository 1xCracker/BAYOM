using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Userrole
{
    public int Userroleid { get; set; }

    public string? Userrolename { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}

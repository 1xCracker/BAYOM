using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Department
{
    public int Departmentid { get; set; }

    public string? Departmentname { get; set; }

    public int? Userroleid { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Userrole? Userrole { get; set; }
}

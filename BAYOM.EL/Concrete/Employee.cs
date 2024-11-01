using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Employee
{
    public int Employeeid { get; set; }

    public int? Departmentid { get; set; }

    public string Employeefirstname { get; set; } = null!;

    public string Employeelastname { get; set; } = null!;

    public string Employeephonenumber { get; set; } = null!;

    public string? Employeeadress { get; set; }

    public decimal? Employeesalary { get; set; }

    public string Employeeemail { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Customer
{
    public int Customerid { get; set; }

    public string Customerfirstname { get; set; } = null!;

    public string Customerlastname { get; set; } = null!;

    public string Customerphonenumber { get; set; } = null!;

    public string Customeradress { get; set; } = null!;

    public string Customeremail { get; set; } = null!;

    public int? Userroleid { get; set; }

    public string? Customerstatus { get; set; }

    public string? Customercompanyname { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual Userrole? Userrole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

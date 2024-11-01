using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Transaction
{
    public int Transactionid { get; set; }

    public string? Transactionstatus { get; set; }

    public int? Productid { get; set; }

    public int? Transactionquantity { get; set; }

    public DateTime? Transactiondate { get; set; }

    public decimal? Total { get; set; }

    public int? Transactiontypeid { get; set; }

    public int? Orderid { get; set; }

    public int? Orderdetailid { get; set; }

    public int? Invoiceid { get; set; }

    public int? Customerid { get; set; }

    public int? Employeeid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Orderdetail? Orderdetail { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Transactionserino> Transactionserinos { get; set; } = new List<Transactionserino>();

    public virtual Trnsactiontype? Transactiontype { get; set; }
}

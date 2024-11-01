using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Order
{
    public int Orderid { get; set; }

    public DateTime? Orderdate { get; set; }

    public string? Orderstatus { get; set; }

    public decimal? Total { get; set; }

    public int? Customerid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

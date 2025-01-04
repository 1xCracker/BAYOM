using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Orderdetail
{
    public int Orderdetailid { get; set; }

    public decimal? Orderproductprice { get; set; }

    public int? Orderquantity { get; set; }

    public decimal? Total { get; set; }

    public int? Productid { get; set; }

    public int? Orderid { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

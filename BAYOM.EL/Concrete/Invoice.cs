using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Invoice
{
    public int Invoiceid { get; set; }

    public string? Invoicestatus { get; set; }

    public DateTime? Invoicedate { get; set; }

    public string? Invoiceno { get; set; }

    public int? Invoicetypeid { get; set; }

    public int? Customerid { get; set; }

    public int? Total { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Trnsactiontype? Invoicetype { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

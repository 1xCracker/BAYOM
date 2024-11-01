using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Trnsactiontype
{
    public int Transactiontypeid { get; set; }

    public string? Transactiontypename { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

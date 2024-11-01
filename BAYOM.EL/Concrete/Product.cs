using System;
using System.Collections.Generic;

namespace BAYOM.EL.Concrete;

public partial class Product
{
    public int Productid { get; set; }

    public string? Productname { get; set; }

    public decimal? ProductpriceB { get; set; }

    public string? Productimage { get; set; }

    public int? Categoryid { get; set; }

    public int? Productbrandid { get; set; }

    public string? Productdescription { get; set; }

    public decimal? ProductpriceS { get; set; }

    public virtual ICollection<Cartdetail> Cartdetails { get; set; } = new List<Cartdetail>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Formuladetail> Formuladetails { get; set; } = new List<Formuladetail>();

    public virtual ICollection<Formula> Formulas { get; set; } = new List<Formula>();

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Productbrand? Productbrand { get; set; }

    public virtual ICollection<Productserino> Productserinos { get; set; } = new List<Productserino>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<Transactionserino> Transactionserinos { get; set; } = new List<Transactionserino>();
}

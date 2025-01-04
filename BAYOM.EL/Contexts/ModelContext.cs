using System;
using System.Collections.Generic;
using BAYOM.EL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BAYOM.EL.Contexts;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Cartdetail> Cartdetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Combination> Combinations { get; set; }

    public virtual DbSet<Confirmedorder> Confirmedorders { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Formula> Formulas { get; set; }

    public virtual DbSet<Formuladetail> Formuladetails { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productbrand> Productbrands { get; set; }

    public virtual DbSet<Productserino> Productserinos { get; set; }

    public virtual DbSet<Productstatus> Productstatuses { get; set; }

    public virtual DbSet<Topcategory> Topcategories { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactionserino> Transactionserinos { get; set; }

    public virtual DbSet<Trnsactiontype> Trnsactiontypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("connectionstring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BAYOM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Cartid).HasName("CART_ID_PK");

            entity.ToTable("CARTS");

            entity.Property(e => e.Cartid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_CARTS\".\"NEXTVAL\"")
                .HasColumnName("CARTID");
            entity.Property(e => e.Cartdate)
                .HasColumnType("DATE")
                .HasColumnName("CARTDATE");
            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("SYS_C007720");
        });

        modelBuilder.Entity<Cartdetail>(entity =>
        {
            entity.HasKey(e => e.Cartdetailid).HasName("SYS_C007694");

            entity.ToTable("CARTDETAILS");

            entity.Property(e => e.Cartdetailid)
                .HasPrecision(10)
                .HasColumnName("CARTDETAILID");
            entity.Property(e => e.Cartid)
                .HasPrecision(10)
                .HasColumnName("CARTID");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Quantity)
                .HasPrecision(4)
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Cart).WithMany(p => p.Cartdetails)
                .HasForeignKey(d => d.Cartid)
                .HasConstraintName("SYS_C007695");

            entity.HasOne(d => d.Product).WithMany(p => p.Cartdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("SYS_C007696");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("CATEGORY_ID_PK");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Categoryid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_CATEGORYS\".\"NEXTVAL\"")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Topcategoryid)
                .HasPrecision(2)
                .HasColumnName("TOPCATEGORYID");

            entity.HasOne(d => d.Topcategory).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Topcategoryid)
                .HasConstraintName("TOPCATEGORY_ID_FK");
        });

        modelBuilder.Entity<Combination>(entity =>
        {
            entity.HasKey(e => e.Combinationid).HasName("COMBINATION_ID_PK");

            entity.ToTable("COMBINATION");

            entity.HasIndex(e => e.Serino, "COMBINATION_UNIQ").IsUnique();

            entity.Property(e => e.Combinationid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_COMBINATION\".\"NEXTVAL\"")
                .HasColumnName("COMBINATIONID");
            entity.Property(e => e.Formuladetailid)
                .HasPrecision(10)
                .HasColumnName("FORMULADETAILID");
            entity.Property(e => e.Formulaid)
                .HasPrecision(10)
                .HasColumnName("FORMULAID");
            entity.Property(e => e.Serino)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SERINO");

            entity.HasOne(d => d.Formuladetail).WithMany(p => p.Combinations)
                .HasForeignKey(d => d.Formuladetailid)
                .HasConstraintName("COMBINATION_FORMULADETAIL_ID_FK");

            entity.HasOne(d => d.Formula).WithMany(p => p.Combinations)
                .HasForeignKey(d => d.Formulaid)
                .HasConstraintName("COMBINATION_FORMULA_ID_FK");
        });

        modelBuilder.Entity<Confirmedorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONFIRMEDORDERS");

            entity.Property(e => e.Confirmedorderdate)
                .HasColumnType("DATE")
                .HasColumnName("CONFIRMEDORDERDATE");
            entity.Property(e => e.Confirmedorderid)
                .HasPrecision(10)
                .HasColumnName("CONFIRMEDORDERID");
            entity.Property(e => e.Orderid)
                .HasPrecision(10)
                .HasColumnName("ORDERID");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("CUSTOMER_ID_PK");

            entity.ToTable("CUSTOMERS");

            entity.HasIndex(e => new { e.Customerphonenumber, e.Customeremail }, "CUSTOMER_UNIQ").IsUnique();

            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_CUSTOMERS\".\"NEXTVAL\"")
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Customeradress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERADRESS");
            entity.Property(e => e.Customercompanyname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERCOMPANYNAME");
            entity.Property(e => e.Customeremail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMEREMAIL");
            entity.Property(e => e.Customerfirstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERFIRSTNAME");
            entity.Property(e => e.Customerlastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERLASTNAME");
            entity.Property(e => e.Customerphonenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERPHONENUMBER");
            entity.Property(e => e.Customerstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERSTATUS");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("DEPARTMENT_ID_PK");

            entity.ToTable("DEPARTMENTS");

            entity.Property(e => e.Departmentid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_DEPARTMENTS\".\"NEXTVAL\"")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENTNAME");
            entity.Property(e => e.Userroleid)
                .HasPrecision(10)
                .HasColumnName("USERROLEID");

            entity.HasOne(d => d.Userrole).WithMany(p => p.Departments)
                .HasForeignKey(d => d.Userroleid)
                .HasConstraintName("DEPARTMENT_USERROLE_ID_FK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("EMPLOYEE_ID_PK");

            entity.ToTable("EMPLOYEES");

            entity.HasIndex(e => new { e.Employeephonenumber, e.Employeeemail }, "EMPLOYEE_UNIQ").IsUnique();

            entity.Property(e => e.Employeeid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_EMPLOYEES\".\"NEXTVAL\"")
                .HasColumnName("EMPLOYEEID");
            entity.Property(e => e.Departmentid)
                .HasPrecision(10)
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Employeeadress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEEADRESS");
            entity.Property(e => e.Employeeemail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEEEMAIL");
            entity.Property(e => e.Employeefirstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEEFIRSTNAME");
            entity.Property(e => e.Employeelastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEELASTNAME");
            entity.Property(e => e.Employeephonenumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEEPHONENUMBER");
            entity.Property(e => e.Employeesalary)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("EMPLOYEESALARY");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("EMPLOYEE_DEPARTMENT_ID_FK");
        });

        modelBuilder.Entity<Formula>(entity =>
        {
            entity.HasKey(e => e.Formulaid).HasName("FORMULA_ID_PK");

            entity.ToTable("FORMULA");

            entity.Property(e => e.Formulaid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_FORMULA\".\"NEXTVAL\"")
                .HasColumnName("FORMULAID");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");

            entity.HasOne(d => d.Product).WithMany(p => p.Formulas)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("SYS_C007677");
        });

        modelBuilder.Entity<Formuladetail>(entity =>
        {
            entity.HasKey(e => e.Formuladetailid).HasName("FORMULADETAIL_ID_PK");

            entity.ToTable("FORMULADETAIL");

            entity.Property(e => e.Formuladetailid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_FORMULADETAIL\".\"NEXTVAL\"")
                .HasColumnName("FORMULADETAILID");
            entity.Property(e => e.Formulaid)
                .HasPrecision(10)
                .HasColumnName("FORMULAID");
            entity.Property(e => e.Fromuladetailquatity)
                .HasPrecision(10)
                .HasColumnName("FROMULADETAILQUATITY");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");

            entity.HasOne(d => d.Formula).WithMany(p => p.Formuladetails)
                .HasForeignKey(d => d.Formulaid)
                .HasConstraintName("FORMULADETAIL_FORMULA_ID_FK");

            entity.HasOne(d => d.Product).WithMany(p => p.Formuladetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FORMULADETAIL_PRDCT_ID_FK");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Invoiceid).HasName("SYS_C007698");

            entity.ToTable("INVOICES");

            entity.Property(e => e.Invoiceid)
                .HasPrecision(10)
                .HasColumnName("INVOICEID");
            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Invoicedate)
                .HasColumnType("DATE")
                .HasColumnName("INVOICEDATE");
            entity.Property(e => e.Invoiceno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("INVOICENO");
            entity.Property(e => e.Invoicestatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("INVOICESTATUS");
            entity.Property(e => e.Invoicetypeid)
                .HasPrecision(10)
                .HasColumnName("INVOICETYPEID");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("SYS_C007700");

            entity.HasOne(d => d.Invoicetype).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Invoicetypeid)
                .HasConstraintName("SYS_C007699");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("ORDER_ID_PK");

            entity.ToTable("ORDERS");

            entity.Property(e => e.Orderid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_ORDERS\".\"NEXTVAL\"")
                .HasColumnName("ORDERID");
            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Orderdate)
                .HasColumnType("DATE")
                .HasColumnName("ORDERDATE");
            entity.Property(e => e.Orderstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ORDERSTATUS");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("SYS_C007721");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.Orderdetailid).HasName("ORDERDETAIL_ID_PK");

            entity.ToTable("ORDERDETAILS");

            entity.Property(e => e.Orderdetailid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_ORDERDETAILS\".\"NEXTVAL\"")
                .HasColumnName("ORDERDETAILID");
            entity.Property(e => e.Orderid)
                .HasPrecision(10)
                .HasColumnName("ORDERID");
            entity.Property(e => e.Orderproductprice)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("ORDERPRODUCTPRICE");
            entity.Property(e => e.Orderquantity)
                .HasPrecision(10)
                .HasColumnName("ORDERQUANTITY");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("ORDERDETAIL_ORDER_ID_FK");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("SYS_C007692");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("PRODUCT_ID_PK");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_PRODUCTS\".\"NEXTVAL\"")
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Categoryid)
                .HasPrecision(10)
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Productbrandid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTBRANDID");
            entity.Property(e => e.Productdescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PRODUCTDESCRIPTION");
            entity.Property(e => e.Productimage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCTIMAGE");
            entity.Property(e => e.Productname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.ProductpriceB)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRODUCTPRICE_B");
            entity.Property(e => e.ProductpriceS)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRODUCTPRICE_S");
            entity.Property(e => e.Topcategoryid)
                .HasPrecision(2)
                .HasColumnName("TOPCATEGORYID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("PRODUCT_CATEGORY_ID_FK");

            entity.HasOne(d => d.Productbrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productbrandid)
                .HasConstraintName("SYS_C007665");

            entity.HasOne(d => d.Topcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.Topcategoryid)
                .HasConstraintName("P_TOPCATEGORY_ID_FK");
        });

        modelBuilder.Entity<Productbrand>(entity =>
        {
            entity.HasKey(e => e.Productbrandid).HasName("SYS_C007664");

            entity.ToTable("PRODUCTBRAND");

            entity.Property(e => e.Productbrandid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTBRANDID");
            entity.Property(e => e.Productbrandname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCTBRANDNAME");
        });

        modelBuilder.Entity<Productserino>(entity =>
        {
            entity.HasKey(e => e.Productserinoid).HasName("PRODUCTSERINO_ID_PK");

            entity.ToTable("PRODUCTSERINO");

            entity.HasIndex(e => e.Productserinoserino, "PRODUCTSERINO_UNIQ").IsUnique();

            entity.Property(e => e.Productserinoid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_PRODUCTSERINO\".\"NEXTVAL\"")
                .HasColumnName("PRODUCTSERINOID");
            entity.Property(e => e.Formulaid)
                .HasPrecision(10)
                .HasColumnName("FORMULAID");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Productserinodateofproduction)
                .HasColumnType("DATE")
                .HasColumnName("PRODUCTSERINODATEOFPRODUCTION");
            entity.Property(e => e.Productserinoserino)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PRODUCTSERINOSERINO");
            entity.Property(e => e.Productstatuid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTSTATUID");

            entity.HasOne(d => d.Formula).WithMany(p => p.Productserinos)
                .HasForeignKey(d => d.Formulaid)
                .HasConstraintName("PRODUCTSERINO_FORMULA_ID_FK");

            entity.HasOne(d => d.Product).WithMany(p => p.Productserinos)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("PRODUCTSERINO_PRDCT_ID_FK");

            entity.HasOne(d => d.Productstatu).WithMany(p => p.Productserinos)
                .HasForeignKey(d => d.Productstatuid)
                .HasConstraintName("PRODUCTSERINO_PRDCTSTA_ID_FK");
        });

        modelBuilder.Entity<Productstatus>(entity =>
        {
            entity.HasKey(e => e.Productstatuid).HasName("PRDCTSTATUS_ID_PK");

            entity.ToTable("PRODUCTSTATUS");

            entity.Property(e => e.Productstatuid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_PRODUCTSTATUS\".\"NEXTVAL\"")
                .HasColumnName("PRODUCTSTATUID");
            entity.Property(e => e.Productsatusname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRODUCTSATUSNAME");
        });

        modelBuilder.Entity<Topcategory>(entity =>
        {
            entity.HasKey(e => e.Topcategoryid).HasName("SYS_C007877");

            entity.ToTable("TOPCATEGORIES");

            entity.Property(e => e.Topcategoryid)
                .HasPrecision(2)
                .ValueGeneratedOnAdd()
                .HasColumnName("TOPCATEGORYID");
            entity.Property(e => e.Topcategoryname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TOPCATEGORYNAME");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("TRANSACTION_ID_PK");

            entity.ToTable("TRANSACTIONS");

            entity.Property(e => e.Transactionid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_TRANSACTIONS\".\"NEXTVAL\"")
                .HasColumnName("TRANSACTIONID");
            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Employeeid)
                .HasPrecision(10)
                .HasColumnName("EMPLOYEEID");
            entity.Property(e => e.Invoiceid)
                .HasPrecision(10)
                .HasColumnName("INVOICEID");
            entity.Property(e => e.Orderdetailid)
                .HasPrecision(10)
                .HasColumnName("ORDERDETAILID");
            entity.Property(e => e.Orderid)
                .HasPrecision(10)
                .HasColumnName("ORDERID");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL");
            entity.Property(e => e.Transactiondate)
                .HasColumnType("DATE")
                .HasColumnName("TRANSACTIONDATE");
            entity.Property(e => e.Transactionquantity)
                .HasPrecision(10)
                .HasColumnName("TRANSACTIONQUANTITY");
            entity.Property(e => e.Transactionstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TRANSACTIONSTATUS");
            entity.Property(e => e.Transactiontypeid)
                .HasPrecision(10)
                .HasColumnName("TRANSACTIONTYPEID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("SYS_C007722");

            entity.HasOne(d => d.Employee).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("SYS_C007723");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Invoiceid)
                .HasConstraintName("SYS_C007703");

            entity.HasOne(d => d.Orderdetail).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Orderdetailid)
                .HasConstraintName("SYS_C007702");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("SYS_C007701");

            entity.HasOne(d => d.Product).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("TRANSACTION_PRDCT_ID_FK");

            entity.HasOne(d => d.Transactiontype).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Transactiontypeid)
                .HasConstraintName("SYS_C007680");
        });

        modelBuilder.Entity<Transactionserino>(entity =>
        {
            entity.HasKey(e => e.Transactionserinoid).HasName("TRANSACTIONSERINO_ID_PK");

            entity.ToTable("TRANSACTIONSERINO");

            entity.HasIndex(e => e.Serino, "TRANSACTIONSERINO_UNIQ").IsUnique();

            entity.Property(e => e.Transactionserinoid)
                .HasPrecision(15)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_ORDERDETAILS\".\"NEXTVAL\"")
                .HasColumnName("TRANSACTIONSERINOID");
            entity.Property(e => e.Formulaid)
                .HasPrecision(10)
                .HasColumnName("FORMULAID");
            entity.Property(e => e.Productid)
                .HasPrecision(10)
                .HasColumnName("PRODUCTID");
            entity.Property(e => e.Serino)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SERINO");
            entity.Property(e => e.Transactionid)
                .HasPrecision(10)
                .HasColumnName("TRANSACTIONID");

            entity.HasOne(d => d.Formula).WithMany(p => p.Transactionserinos)
                .HasForeignKey(d => d.Formulaid)
                .HasConstraintName("TRANSACTIONSERINO_FORMULA_ID_FK");

            entity.HasOne(d => d.Product).WithMany(p => p.Transactionserinos)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("TRANSACTIONSERINO_PRODUCT_ID_FK");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Transactionserinos)
                .HasForeignKey(d => d.Transactionid)
                .HasConstraintName("TRANSACTIONSERINO_TRANSACTION_ID_FK");
        });

        modelBuilder.Entity<Trnsactiontype>(entity =>
        {
            entity.HasKey(e => e.Transactiontypeid).HasName("SYS_C007679");

            entity.ToTable("TRNSACTIONTYPE");

            entity.Property(e => e.Transactiontypeid)
                .HasPrecision(10)
                .HasColumnName("TRANSACTIONTYPEID");
            entity.Property(e => e.Transactiontypename)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TRANSACTIONTYPENAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("USERS_ID_PK");

            entity.ToTable("USERS");

            entity.Property(e => e.Userid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_USERS\".\"NEXTVAL\"")
                .HasColumnName("USERID");
            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Employeeid)
                .HasPrecision(10)
                .HasColumnName("EMPLOYEEID");
            entity.Property(e => e.Useremail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USEREMAIL");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERPASSWORD");
            entity.Property(e => e.Userrole)
                .HasPrecision(10)
                .HasColumnName("USERROLE");

            entity.HasOne(d => d.Customer).WithMany(p => p.Users)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("USER_CUSTOMER_ID_FK");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("USER_EMPLOYEE_ID_FK");

            entity.HasOne(d => d.UserroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("USER_USERROLE_ID_FK");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Userroleid).HasName("USERROLE_ID_PK");

            entity.ToTable("USERROLE");

            entity.Property(e => e.Userroleid)
                .HasPrecision(10)
                .HasDefaultValueSql("\"BAYOM\".\"SQ_USERROLE\".\"NEXTVAL\"")
                .HasColumnName("USERROLEID");
            entity.Property(e => e.Userrolename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USERROLENAME");
        });
        modelBuilder.HasSequence("SQ_CARTS");
        modelBuilder.HasSequence("SQ_CATEGORYS");
        modelBuilder.HasSequence("SQ_COMBINATION");
        modelBuilder.HasSequence("SQ_CUSTOMERCARTS");
        modelBuilder.HasSequence("SQ_CUSTOMERORDERS");
        modelBuilder.HasSequence("SQ_CUSTOMERS");
        modelBuilder.HasSequence("SQ_DEPARTMENTS");
        modelBuilder.HasSequence("SQ_EMPLOYEES");
        modelBuilder.HasSequence("SQ_FORMULA");
        modelBuilder.HasSequence("SQ_FORMULADETAIL");
        modelBuilder.HasSequence("SQ_ORDERDETAILS");
        modelBuilder.HasSequence("SQ_ORDERS");
        modelBuilder.HasSequence("SQ_PRODUCTS");
        modelBuilder.HasSequence("SQ_PRODUCTSERINO");
        modelBuilder.HasSequence("SQ_PRODUCTSTATUS");
        modelBuilder.HasSequence("SQ_TRANSACTIONS");
        modelBuilder.HasSequence("SQ_TRANSACTIONSERINO");
        modelBuilder.HasSequence("SQ_USERROLE");
        modelBuilder.HasSequence("SQ_USERS");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using BAYOM.DAL.Abstract;
using BAYOM.DAL.Dto_s;
using BAYOM.EL.Concrete;
using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Repository
{
    public class OrdersRepository : Repository<Orderdetail>, IOrdersRepository
    {
        public OrdersRepository(ModelContext context) : base(context)
        {
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _dbSet
        .Include(o => o.Order)
            .ThenInclude(o => o.Customer)
        .Include(o => o.Order)
            .ThenInclude(o => o.Orderdetails)
                .ThenInclude(od => od.Product)
        .Select(o => o.Order!)
        .Distinct()  // Aynı siparişlerin tekrarını önlemek için
        .Select(g => new OrderDto
        {
            FullName = $"{g.Customer!.Customerfirstname} {g.Customer.Customerlastname}",
            Date = g.Orderdate,
            Address = g.Customer.Customeradress,
            Products = g.Orderdetails
                .Select(od => new OrderProductDto
                {
                    ProductName = od.Product!.Productname,
                    Quantity = od.Orderquantity,
                    Price = od.Orderproductprice,
                    Total = od.Total
                })
                .ToList(),
            Total = g.Total,
            Status = g.Orderstatus
        })
        .ToListAsync();

            return orders;


        }
    }
}

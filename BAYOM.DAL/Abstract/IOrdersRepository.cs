using BAYOM.DAL.Dto_s;
using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Abstract
{
    public interface IOrdersRepository : IRepository<Orderdetail>
    {
        Task<List<OrderDto>>GetAllOrders();
    }
}

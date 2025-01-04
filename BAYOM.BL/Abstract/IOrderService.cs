using BAYOM.DAL.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Abstract
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrders();
    }
}

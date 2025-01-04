using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Dto_s
{
    public class OrdersDto
    {
        public OrderDto Orderdto { get; set; }
        public List<OrderProductDto> Productdto { get; set; }
    }
}

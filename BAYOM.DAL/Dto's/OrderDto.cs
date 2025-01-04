using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Dto_s
{
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string FullName { get; set; }
        public DateTime? Date { get; set; }
        public string Address { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
    }
}

using BAYOM.BL.Abstract;
using BAYOM.DAL.Abstract;
using BAYOM.DAL.Dto_s;
using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork, IOrdersRepository orderRepository) : base(repository, unitOfWork)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
          return await _orderRepository.GetAllOrders();
        }
    }
}

using BAYOM.BL.Abstract;
using BAYOM.DAL.Dto_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYOM.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("Orders")]

        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
          var order = await  _orderService.GetAllOrders();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}

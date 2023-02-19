using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTO;
using PizzeriaApi.Repository.Interface;

namespace PizzeriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("orderlist")]
        public async Task<IActionResult> GetOrderList()
        {
            return Ok(await _orderRepository.GetOrderList());
        }

        [HttpGet]
        [Route("extratoppinglist")]
        public async Task<IActionResult> GetExtraToppingList()
        {
            return Ok(await _orderRepository.GetExtraToppingList());
        }

        [HttpGet]
        [Route("order/{orderId:int}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return Ok(await _orderRepository.GetOrder(orderId));
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveOrder([FromBody] OrderDTO order)
        {
            return Ok(await _orderRepository.SaveOrder(order));
        }

    }
}

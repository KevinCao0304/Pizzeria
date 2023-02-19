using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTO;
using PizzeriaApi.Repository.Interface;

namespace PizzeriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        [HttpGet]
        [Route("pizzalist/{storeId:int}")]
        public async Task<IActionResult> GetPizzaList(int storeId)
        {
            return Ok(await _pizzaRepository.GetPizzaList(storeId));
        }

        [HttpGet]
        [Route("pizza/{pizzaId:int}")]
        public async Task<IActionResult> GetPizza(int pizzaId)
        {
            return Ok(await _pizzaRepository.GetPizza(pizzaId));
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SavePizza([FromBody] PizzaDTO pizza)
        {
            return Ok(await _pizzaRepository.SavePizza(pizza));
        }
        [HttpDelete]
        [Route("delete/{pizzaId:int}")]
        public async Task<IActionResult> DeletePizza(int pizzaId)
        {
            return Ok(await _pizzaRepository.DeletePizza(pizzaId));
        }
    }
}

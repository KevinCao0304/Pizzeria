using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTO;
using PizzeriaApi.Repository;
using PizzeriaApi.Repository.Interface;

namespace PizzeriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        [HttpGet]
        [Route("storelist")]
        public async Task<IActionResult> GetStoreList()
        {
            return Ok(await _storeRepository.GetStoreList());
        }

        [HttpGet]
        [Route("store/{storeId:int}")]
        public async Task<IActionResult> GetStore(int storeId)
        {
            return Ok(await _storeRepository.GetStore(storeId));
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveStore([FromBody] StoreDTO store)
        {
            return Ok(await _storeRepository.SaveStore(store));
        }

        [HttpDelete]
        [Route("delete/{storeId:int}")]
        public async Task<IActionResult> DeleteStore(int storeId)
        {
            return Ok(await _storeRepository.DeleteStore(storeId));
        }
    }
}

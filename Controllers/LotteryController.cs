using Mexican_Lottery_dotnet_API.Models;
using Mexican_Lottery_dotnet_API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mexican_Lottery_dotnet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotteryController : ControllerBase
    {

        private readonly LotteryService _service;

        public LotteryController(LotteryService service)
        {
            _service = service;
        }

        // GET: api/<LotteryController>
        [HttpGet("cards")]
        async public Task<List<Card>> GetCards()
        {
            return await _service.GetCards();
        }

        [HttpGet("tables")]
        async public Task<List<Table>> GetTables()
        {
            return await _service.GetTables();
        }

        [HttpPost("generateTables/{length}")]
        async public Task<List<Table>> GenerateRandomTables(int length)
        {
            return await _service.GenerateRandomTables(length);
        }
    }
}

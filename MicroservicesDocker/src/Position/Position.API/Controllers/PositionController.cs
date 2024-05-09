using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Position.API.Interfaces;
using Position.API.Models;

namespace Position.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _service;

        public PositionController(IPositionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ResponseModel> CreatePosition(PositionDTO position)
        {
            var res = await _service.CreatePosition(position);

            return res;
        }

        [HttpGet]
        public async Task<List<PositionModel>> GetAllPositions()
        {
            var res = await _service.GetAllPositions();

            return res;
        }
    }
}

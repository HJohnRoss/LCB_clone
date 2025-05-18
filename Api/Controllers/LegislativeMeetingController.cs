using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LegislativeMeetingController : ControllerBase
    {
        private readonly LegislativeMeetingData _data;

        public LegislativeMeetingController(LegislativeMeetingData data)
        {
            _data = data;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LegislativeMeetingModel>>> GetAll()
        {
            try
            {
                List<LegislativeMeetingModel> result = await _data.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

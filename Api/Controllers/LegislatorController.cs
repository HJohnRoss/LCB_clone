using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LegislatorController : ControllerBase
    {
        private readonly LegislatorData _data;

        public LegislatorController(LegislatorData data)
        {
            _data = data;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<LegislatorModel>> GetAll()
        {
            try
            {
                List<LegislatorModel> result = _data.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

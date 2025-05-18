using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExhibitController : ControllerBase
    {
        private readonly ExhibitData _exhibitsData;

        public ExhibitController(ExhibitData exhibitData)
        {
            _exhibitsData = exhibitData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ExhibitModel>>> GetAll()
        {
            try
            {
                List<ExhibitModel> result = await _exhibitsData.GetAll()
                    ?? throw new InvalidDataException("result GetAll is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

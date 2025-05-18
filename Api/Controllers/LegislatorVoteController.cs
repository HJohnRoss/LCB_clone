using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegislatorVoteController : ControllerBase
    {
        private readonly LegislatorVoteData _legislatorVoteData;

        public LegislatorVoteController(LegislatorVoteData legislatorVoteData)
        {
            _legislatorVoteData = legislatorVoteData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LegislatorVoteModel>>> GetAll()
        {
            try
            {

                List<LegislatorVoteModel> result = await _legislatorVoteData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

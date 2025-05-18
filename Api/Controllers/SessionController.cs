using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionData _sessionData;

        public SessionController(SessionData sessionData)
        {
            _sessionData = sessionData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SessionModel>>> GetAll()
        {
            try
            {
                List<SessionModel> result = await _sessionData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

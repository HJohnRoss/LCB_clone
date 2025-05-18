using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionMeetingController : ControllerBase
    {
        private readonly SessionMeetingData _sessionMeetingData;

        public SessionMeetingController(SessionMeetingData sessionMeetingData)
        {
            _sessionMeetingData = sessionMeetingData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SessionMeetingModel>>> GetAll()
        {
            try
            {
                List<SessionMeetingModel> result = await _sessionMeetingData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

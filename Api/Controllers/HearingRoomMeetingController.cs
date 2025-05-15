using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HearingRoomMeetingController : ControllerBase
    {
        private readonly HearingRoomMeetingData _hearingRoomMeetingData;

        public HearingRoomMeetingController(HearingRoomMeetingData hearingRoomMeetingData)
        {
            _hearingRoomMeetingData = hearingRoomMeetingData;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<HearingRoomMeetingModel>> GetAll()
        {
            try
            {
                List<HearingRoomMeetingModel> result = _hearingRoomMeetingData.GetAll()
                    ?? throw new InvalidDataException("Hearing Room Meeting get all is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

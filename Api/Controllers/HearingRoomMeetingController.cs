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
        public async Task<ActionResult<List<HearingRoomMeetingModel>>> GetAll()
        {
            try
            {
                List<HearingRoomMeetingModel> result = await _hearingRoomMeetingData.GetAll()
                    ?? throw new InvalidDataException("Hearing Room Meeting get all is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task Create(string meetingName, string youtubeLink, string ccRoomNumber, bool isCCMainRoom, string lvRoomNumber, string time, string date)
        {
            await _hearingRoomMeetingData.Create(meetingName, youtubeLink, ccRoomNumber, isCCMainRoom, lvRoomNumber, time, date);
        }
    }
}

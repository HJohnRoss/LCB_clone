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

        [HttpPost("Create")]
        public void Create(string meetingName, string youtubeLink, string ccRoomNumber, bool isCCMainRoom, string lvRoomNumber, string time, string date)
        {
            _hearingRoomMeetingData.Create(meetingName, youtubeLink, ccRoomNumber, isCCMainRoom, lvRoomNumber, time, date);
            // _hearingRoomMeetingData.Create("Name1", "youtubelink1", "1234", true, "1", "11 am", "11/11/25");
        }
    }
}

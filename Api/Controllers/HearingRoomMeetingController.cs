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

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            try
            {
                HearingRoomMeetingModel result = await _hearingRoomMeetingData.GetOne(id)
                    ?? throw new InvalidDataException("Hearing Room Meeting get one is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(
                    string meetingName,
                    string youtubeLink,
                    string ccRoomNumber,
                    bool isCCMainRoom,
                    string lvRoomNumber,
                    string time,
                    string date,
                    int? agendaId
                )
        {
            try
            {
                await _hearingRoomMeetingData.Create(
                            meetingName,
                            youtubeLink,
                            ccRoomNumber,
                            isCCMainRoom,
                            lvRoomNumber,
                            time,
                            date,
                            agendaId
                        );
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(
                    int id,
                    string? meetingName,
                    string? youtubeLink,
                    string? ccRoomNumber,
                    bool? isCCMainRoom,
                    string? lvRoomNumber,
                    string? time,
                    string? date,
                    int? agendaId
                )
        {
            try
            {
                await _hearingRoomMeetingData.Update(
                            id,
                            meetingName,
                            youtubeLink,
                            ccRoomNumber,
                            isCCMainRoom,
                            lvRoomNumber,
                            time,
                            date,
                            agendaId
                        );
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _hearingRoomMeetingData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

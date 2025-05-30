using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegislativeMeetingLegislatorController : ControllerBase
    {
        private readonly LegislativeMeetingLegislatorData _data;

        public LegislativeMeetingLegislatorController(LegislativeMeetingLegislatorData data)
        {
            _data = data;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(int meetingsId, int membersId)
        {
            try
            {
                await _data.Create(meetingsId, membersId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // NOTE: Legislators
        [HttpGet("GetLegislators/{id}")]
        public async Task<ActionResult<List<LegislativeMeetingModel>>> GetLegislators(int id)
        {
            try
            {
                List<LegislatorModel> results = await _data.GetLegislators(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateLegislators/{legislatorId}")]
        public async Task<ActionResult> UpdateLegislator(int legislatorId, int meetingId)
        {
            try
            {
                await _data.UpdateLegislator(legislatorId, meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteLegislators/{legislatorId}")]
        public async Task<ActionResult> DeleteLegislator(int legislatorId)
        {
            try
            {
                await _data.DeleteLegislator(legislatorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // NOTE: Meetings
        [HttpGet("GetMeetings/{id}")]
        public async Task<ActionResult<List<LegislativeMeetingModel>>> GetMeetings(int id)
        {
            try
            {
                List<LegislativeMeetingModel> results = await _data.GetMeetings(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateMeetings/{meetingId}")]
        public async Task<ActionResult> UpdateMeetings(int legislatorId, int meetingId)
        {
            try
            {
                await _data.UpdateMeeting(legislatorId, meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteMeetings/{meetingId}")]
        public async Task<ActionResult> DeleteMeeting(int meetingId)
        {
            try
            {
                await _data.DeleteMeeting(meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

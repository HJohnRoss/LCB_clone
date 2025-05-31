using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Services;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegislativeMeetingStaffMemberController : ControllerBase
    {
        private LegislativeMeetingStaffMemberService _service;

        public LegislativeMeetingStaffMemberController(LegislativeMeetingStaffMemberService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(int meetingsId, int staffId)
        {
            try
            {
                await _service.Create(meetingsId, staffId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Staff
        [HttpGet("GetStaff/{meetingId}")]
        public async Task<ActionResult<List<StaffMemberModel>>> GetStaff(int meetingId)
        {
            try
            {
                List<StaffMemberModel> staff = await _service.GetStaff(meetingId);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateStaff/{staffId}")]
        public async Task<ActionResult> UpdateStaff(int staffId, int meetingId)
        {
            try
            {
                await _service.UpdateStaff(staffId, meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete/{staffId}")]
        public async Task<ActionResult> DeleteStaff(int staffId)
        {
            try
            {
                await _service.DeleteStaff(staffId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Legislative Meetings
        [HttpGet("GetMeetings/{staffId}")]
        public async Task<ActionResult<List<LegislativeMeetingModel>>> GetMeetings(int staffId)
        {
            try
            {
                List<LegislativeMeetingModel> results = await _service.GetMeetings(staffId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateMeeting/{meetingId}")]
        public async Task<ActionResult> UpdateMeeting(int staffId, int meetingId)
        {
            try
            {
                await _service.UpdateMeeting(staffId, meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteMeeting/{meetingId}")]
        public async Task<ActionResult> DeleteMeeting(int meetingId)
        {
            try
            {
                await _service.DeleteMeeting(meetingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


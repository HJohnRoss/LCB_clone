using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LegislativeMeetingController : ControllerBase
    {
        private readonly LegislativeMeetingData _data;

        public LegislativeMeetingController(LegislativeMeetingData data)
        {
            _data = data;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LegislativeMeetingModel>>> GetAll()
        {
            try
            {
                List<LegislativeMeetingModel> result = await _data.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<LegislativeMeetingModel>> GetOne(int id)
        {
            try
            {
                LegislativeMeetingModel result = await _data.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(
                string house,
                string name,
                string? youtubeLink,
                string? ccRoomNumber,
                bool isCCMainRoom,
                string? lvRoomNumber,
                DateTime dateTime,
                int? agendaId,
                int? committeeId
                )
        {
            try
            {
                await _data.Create(
                        house,
                        name,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        dateTime,
                        agendaId,
                        committeeId
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
                string? house,
                string? name,
                string? youtubeLink,
                string? ccRoomNumber,
                bool? isCCMainRoom,
                string? lvRoomNumber,
                DateTime? date,
                int? agendaId,
                int? committeeId
                )
        {
            try
            {
                await _data.Update(
                        id,
                        house,
                        name,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        date,
                        agendaId,
                        committeeId
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
                await _data.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

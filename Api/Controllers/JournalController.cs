using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalController : ControllerBase
    {
        private readonly JournalData _journalData;

        public JournalController(JournalData journalData)
        {
            _journalData = journalData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<JournalModel>>> GetAll()
        {
            try
            {
                List<JournalModel> result = await _journalData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<JournalModel>> GetOne(int id)
        {
            try
            {
                JournalModel result = await _journalData.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(string filePath, string dayNum, bool isSenate)
        {
            try
            {
                await _journalData.Create(filePath, dayNum, isSenate);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, string? filePath, string? dayNum, bool isSenate)
        {
            try
            {
                await _journalData.Update(id, filePath, dayNum, isSenate);
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
                await _journalData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


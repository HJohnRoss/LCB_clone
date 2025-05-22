using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiscalNoteController : ControllerBase
    {
        private readonly FiscalNoteData _fiscalNoteData;

        public FiscalNoteController(FiscalNoteData fiscalNoteData)
        {
            _fiscalNoteData = fiscalNoteData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<FiscalNoteModel>>> GetAll()
        {
            try
            {
                List<FiscalNoteModel> result = await _fiscalNoteData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<FiscalNoteModel>> GetOne(int id)
        {
            try
            {
                FiscalNoteModel result = await _fiscalNoteData.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(string filePath, string fileName)
        {
            try
            {
                await _fiscalNoteData.Create(filePath, fileName);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, string? filePath, string? fileName)
        {
            try
            {
                await _fiscalNoteData.Update(id, filePath, fileName);
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
                await _fiscalNoteData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

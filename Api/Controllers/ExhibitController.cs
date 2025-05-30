using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExhibitController : ControllerBase
    {
        private readonly ExhibitData _exhibitsData;

        public ExhibitController(ExhibitData exhibitData)
        {
            _exhibitsData = exhibitData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ExhibitModel>>> GetAll()
        {
            try
            {
                List<ExhibitModel> result = await _exhibitsData.GetAll()
                    ?? throw new InvalidDataException("result GetAll is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<ExhibitModel>> GetOne(int id)
        {
            try
            {
                ExhibitModel result = await _exhibitsData.GetOne(id);
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
                await _exhibitsData.Create(filePath, fileName);
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
                await _exhibitsData.Update(id, filePath, fileName);
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
                await _exhibitsData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

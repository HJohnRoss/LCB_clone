using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Services;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmendmentController : ControllerBase
    {
        private readonly AmendmentService _amendmentService;

        // Constructor to inject AmendmentData into the controller
        public AmendmentController(AmendmentService amendmentService)
        {
            _amendmentService = amendmentService;
        }

        // GET api/amendment
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AmendmentModel>>> GetAll()
        {
            try
            {
                // Fetch amendments using the AmendmentData service
                List<AmendmentModel> result = await _amendmentService.GetAll();
                return Ok(result); // Return 200 OK with the data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return 500 if there's an error
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<AmendmentModel>> GetOne(int id)
        {
            try
            {
                AmendmentModel result = await _amendmentService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task Update(int id, string? filePath, string? fileName)
        {
            await _amendmentService.Update(id, filePath, fileName);
        }

        [HttpPost("Create")]
        public async Task Create(string filePath, string fileName)
        {
            await _amendmentService.Create(filePath, fileName);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _amendmentService.Delete(id);
        }
    }
}

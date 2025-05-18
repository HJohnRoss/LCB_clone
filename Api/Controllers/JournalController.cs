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
    }
}

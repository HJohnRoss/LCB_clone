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
        public ActionResult<List<FiscalNoteModel>> GetAll()
        {
            try
            {
                List<FiscalNoteModel> result = _fiscalNoteData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

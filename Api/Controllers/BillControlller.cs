using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly BillData _billData;

        public BillController(BillData billData)
        {
            _billData = billData;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BillModel>>> GetAll()
        {
            try
            {
                List<BillModel> result = await _billData.GetAll()
                    ?? throw new InvalidDataException("GetAll Bills Query is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

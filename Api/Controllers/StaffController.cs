using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StaffMemberController : ControllerBase
    {
        private readonly StaffMemberData _staffMemberData;

        public StaffMemberController(StaffMemberData data)
        {
            _staffMemberData = data;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<StaffMemberModel>> GetAll()
        {
            try
            {
                List<StaffMemberModel> result = _staffMemberData.GetAll()
                    ?? throw new InvalidDataException("Staff Memeber data get all is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

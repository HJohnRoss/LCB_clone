using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmendmentController : ControllerBase
    {
        private readonly AmendmentData _amendmentData;

        // Constructor to inject AmendmentData into the controller
        public AmendmentController(AmendmentData amendmentData)
        {
            _amendmentData = amendmentData;
        }

        // GET api/amendment
        [HttpGet("GetAll")]
        public ActionResult<List<AmendmentModel>> GetAll()
        {
            try
            {
                // Fetch amendments using the AmendmentData service
                List<AmendmentModel> amendments = _amendmentData.GetAll();
                return Ok(amendments); // Return 200 OK with the data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return 500 if there's an error
            }
        }
    }
}

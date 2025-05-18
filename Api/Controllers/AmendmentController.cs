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
                List<AmendmentModel> result = _amendmentData.GetAll();
                return Ok(result); // Return 200 OK with the data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return 500 if there's an error
            }
        }

        [HttpGet("GetOne/{id}")]
        public ActionResult<AmendmentModel> GetOne(int id)
        {
            try
            {
                AmendmentModel result = _amendmentData.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}/{filePath}/{fileName}")]
        public void Update(int id, string filePath, string fileName)
        {
            _amendmentData.Update(id, filePath, fileName);
        }

        [HttpPost("Create/{filePath}/{fileName}")]
        public void Create(string filePath, string fileName)
        {
            _amendmentData.Create(filePath, fileName);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            _amendmentData.Delete(id);
        }
    }
}

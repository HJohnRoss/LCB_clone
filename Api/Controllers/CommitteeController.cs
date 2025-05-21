using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommitteeController : ControllerBase
    {
        private readonly CommitteData _committeeData;

        public CommitteeController(CommitteData committeData)
        {
            _committeeData = committeData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CommitteeModel>>> GetAll()
        {
            try
            {
                List<CommitteeModel> result = await _committeeData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<CommitteeModel>> GetOne(int id)
        {
            try
            {
                CommitteeModel result = await _committeeData.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(string house)
        {
            try
            {
                await _committeeData.Create(house);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, string house)
        {
            try
            {
                await _committeeData.Update(id, house);
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
                await _committeeData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

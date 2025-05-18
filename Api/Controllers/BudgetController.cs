using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetData _budgetData;

        public BudgetController(BudgetData budgetData)
        {
            _budgetData = budgetData;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BudgetModel>>> GetAll()
        {
            try
            {
                List<BudgetModel> result = await _budgetData.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
};

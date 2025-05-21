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

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<BudgetModel>> GetOne(int id)
        {
            try
            {
                BudgetModel result = await _budgetData.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(
                    int departmentNum,
                    string departmentName,
                    int agencyNum,
                    string agencyName,
                    int functionNum,
                    string functionName,
                    int subFunctionNum,
                    string subFunctionName,
                    string budgetName,
                    int fundNum,
                    int budgetNum,
                    string execBudgetPage,
                    string? summary,
                    string? synopsis,
                    string? textFilePath,
                    int? sessionMeetingModelId
                )
        {
            try
            {

                await _budgetData.Create(
                            departmentNum,
                            departmentName,
                            agencyNum,
                            agencyName,
                            functionNum,
                            functionName,
                            subFunctionNum,
                            subFunctionName,
                            budgetName,
                            fundNum,
                            budgetNum,
                            execBudgetPage,
                            summary,
                            synopsis,
                            textFilePath,
                            sessionMeetingModelId
                        );
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(
                int id,
                int? departmentNum,
                string? departmentName,
                int? agencyNum,
                string? agencyName,
                int? functionNum,
                string? functionName,
                int? subFunctionNum,
                string? subFunctionName,
                string? budgetName,
                int? fundNum,
                int? budgetNum,
                string? execBudgetPage,
                string? summary,
                string? synopsis,
                string? textFilePath,
                int? sessionMeetingModelId
            )
        {
            try
            {

                await _budgetData.Update(
                            id,
                            departmentNum,
                            departmentName,
                            agencyNum,
                            agencyName,
                            functionNum,
                            functionName,
                            subFunctionNum,
                            subFunctionName,
                            budgetName,
                            fundNum,
                            budgetNum,
                            execBudgetPage,
                            summary,
                            synopsis,
                            textFilePath,
                            sessionMeetingModelId
                        );
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
                await _budgetData.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

};

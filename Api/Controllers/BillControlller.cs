using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Services;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = billService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BillModel>>> GetAll()
        {
            try
            {
                List<BillModel> result = await _billService.GetAll()
                    ?? throw new InvalidDataException("Bills GetAll uery is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<BillModel>> GetOne(int id)
        {
            try
            {
                BillModel result = await _billService.GetOne(id)
                    ?? throw new InvalidDataException("Bills GetOne Query is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(
                    string summmary,
                    DateTime introDate,
                    bool effectLocalGov,
                    bool effectState,
                    string title,
                    string digest,
                    int? discussedByCommitteeId = null,
                    int? sessionMeetingModelId = null,
                    int? sessionModelId = null
                )
        {
            try
            {
                await _billService.Create(
                            summmary,
                            introDate,
                            effectLocalGov,
                            effectState,
                            title,
                            digest,
                            discussedByCommitteeId,
                            sessionMeetingModelId,
                            sessionModelId
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
                    string? summary = null,
                    DateTime? introDate = null,
                    bool? effectLocalGov = null,
                    bool? effectState = null,
                    string? title = null,
                    string? digest = null,
                    int? discussedByCommitteeId = null,
                    int? sessionMeetingModelId = null,
                    int? sessionModelId = null
                )
        {
            try
            {
                await _billService.Update(
                            id,
                            summary,
                            introDate,
                            effectLocalGov,
                            effectState,
                            title,
                            digest,
                            discussedByCommitteeId,
                            sessionMeetingModelId,
                            sessionModelId
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
                await _billService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

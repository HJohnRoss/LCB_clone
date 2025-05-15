using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaData _agendaData;

        public AgendaController(AgendaData agendaData)
        {
            _agendaData = agendaData;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<AgendaModel>> GetAll()
        {
            try
            {
                List<AgendaModel> result = _agendaData.GetAll()
                    ?? throw new InvalidDataException("GetAll Agendas query is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

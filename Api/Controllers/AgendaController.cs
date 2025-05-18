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
        public async Task<ActionResult<List<AgendaModel>>> GetAll()
        {
            try
            {
                List<AgendaModel> result = await _agendaData.GetAll()
                    ?? throw new InvalidDataException("GetAll Agendas query is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<AgendaModel>> GetOne(int id)
        {
            try
            {
                AgendaModel result = await _agendaData.GetOne(id)
                    ?? throw new InvalidDataException("GetOne Agendas query is null");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task Create(string filePath, string fileName)
        {
            await _agendaData.Create(filePath, fileName);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _agendaData.Delete(id);
        }

        [HttpPut("Update/{id}/{filePath}/{fileName}")]
        public async Task Update(int id, string filePath, string fileName)
        {
            await _agendaData.Update(id, filePath, fileName);
        }
    }
}

using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Services
{
    public class AgendaService
    {
        private readonly AgendaData _agendaData;
        public AgendaService(AgendaData agendaData)
        {
            _agendaData = agendaData;
        }

        public async Task<List<AgendaModel>> GetAll()
        {
            return await _agendaData.GetAll();
        }

        public async Task<AgendaModel> GetOne(int id)
        {
            return await _agendaData.GetOne(id);
        }

        public async Task Create(string filePath, string fileName)
        {
            await _agendaData.Create(filePath, fileName);
        }

        public async Task Delete(int id)
        {
            await _agendaData.Delete(id);
        }

        public async Task Update(int id, string? filePath, string? fileName)
        {
            await _agendaData.Update(id, filePath, fileName);
        }
    }

}

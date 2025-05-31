using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Services
{
    public class AmendmentService
    {
        private readonly AmendmentData _amendmentData;

        public AmendmentService(AmendmentData amendmentData)
        {
            _amendmentData = amendmentData;
        }

        public async Task<List<AmendmentModel>> GetAll()
        {

            return await _amendmentData.GetAll();
        }

        public async Task<AmendmentModel> GetOne(int id)
        {
            return await _amendmentData.GetOne(id);
        }

        public async Task Create(string filePath, string fileName)
        {
            await _amendmentData.Create(filePath, fileName);
        }

        public async Task Update(int id, string? filePath, string? fileName)
        {
            await _amendmentData.Update(id, filePath, fileName);
        }

        public async Task Delete(int id)
        {
            await _amendmentData.Delete(id);
        }
    }
}

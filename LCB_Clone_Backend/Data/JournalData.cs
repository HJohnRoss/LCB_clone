using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class JournalData
    {
        private readonly SqlDataAccess _db;

        public JournalData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<JournalModel>> GetAll()
        {
            string query = "SELECT * FROM Journals;";

            List<JournalModel> result = await _db.LoadData<JournalModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Journals Get All returning null");
            return result;
        }
    }
}

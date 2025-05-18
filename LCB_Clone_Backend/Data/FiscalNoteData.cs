using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class FiscalNoteData
    {
        private readonly SqlDataAccess _db;

        public FiscalNoteData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<FiscalNoteModel>> GetAll()
        {
            string query = "SELECT * FROM FiscalNotes;";

            List<FiscalNoteModel> result = await _db.LoadData<FiscalNoteModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Fiscal note Get All query is null");
            return result;
        }
    }
}

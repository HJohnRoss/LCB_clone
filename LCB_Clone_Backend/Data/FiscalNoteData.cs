using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

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

        public async Task<FiscalNoteModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM FiscalNotes
                WHERE Id = @id;
            ";

            List<FiscalNoteModel> results = await _db.LoadData<FiscalNoteModel, dynamic>(query, new { id });
            FiscalNoteModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Fiscal Note Get One query is null");
            return result;
        }

        public async Task Create(string filePath, string fileName)
        {
            string query = @"
                INSERT INTO FiscalNotes (FilePath, FileName)
                VALUES (@filePath, @fileName);
            ";

            await _db.SaveData(query, new { filePath, fileName });
        }

        public async Task Update(int id, string? filePath, string? fileName)
        {
            List<string> columns = new();
            List<string> values = new();

            if (filePath != null)
            {
                columns.Add("FilePath");
                values.Add("@filePath");
            }
            if (fileName != null)
            {
                columns.Add("FileName");
                values.Add("@fileName");
            }

            string insertStr = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                UPDATE FiscalNotes
                SET {insertStr}
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, filePath, fileName });
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM FiscalNotes
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}


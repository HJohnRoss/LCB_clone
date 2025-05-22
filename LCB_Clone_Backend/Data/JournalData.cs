using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

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

        public async Task<JournalModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM Journals
                WHERE Id = @id;
            ";

            List<JournalModel> results = await _db.LoadData<JournalModel, dynamic>(query, new { id });
            JournalModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Journals Get One returning null");
            return result;
        }

        public async Task Create(string filePath, string dayNum, bool isSenate)
        {
            string query = @"
                INSERT INTO Journals (FilePath, DayNum, IsSenate)
                VALUES (@filePath, @dayNum, @isSenate);
            ";

            await _db.SaveData(query, new { filePath, dayNum, isSenate });
        }

        public async Task Update(int id, string? filePath, string? dayNum, bool? isSenate)
        {
            List<string> columns = new();
            List<string> values = new();

            if (filePath != null)
            {
                columns.Add("FilePath");
                values.Add("@filePath");
            }
            if (dayNum != null)
            {
                columns.Add("DayNum");
                values.Add("@dayNum");
            }
            if (isSenate != null)
            {
                columns.Add("IsSenate");
                values.Add("@isSenate");
            }

            string insertString = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                UPDATE Journals
                SET ({insertString})
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, filePath, dayNum, isSenate });
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM Journals
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}

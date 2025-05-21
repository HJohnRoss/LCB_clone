using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class AmendmentData
    {
        private readonly SqlDataAccess _db;

        public AmendmentData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<AmendmentModel>> GetAll()
        {
            string query = @"
                SELECT Id, FilePath, FileName FROM Amendments;
            ";

            return await _db.LoadData<AmendmentModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Amendments GetAll query is null");
        }

        public async Task<AmendmentModel> GetOne(int id)
        {
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Amendments
                WHERE Id = @id;
            ";

            List<AmendmentModel> results = await _db.LoadData<AmendmentModel, dynamic>(query, new { id })
                ?? throw new InvalidDataException("Amendments GetOne query is null");

            AmendmentModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException($"Amendment Id: {id} is null");
            return result;
        }

        public async Task Create(string filePath, string fileName)
        {
            string query = @"
                INSERT INTO Amendments
                ( FilePath, FileName )
                VALUES ( @filePath, @fileName );
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
                UPDATE Amendments
                SET {insertStr}
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, filePath, fileName });
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM Amendments
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}

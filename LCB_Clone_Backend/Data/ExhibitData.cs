using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class ExhibitData
    {
        private readonly SqlDataAccess _db;

        public ExhibitData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<ExhibitModel>> GetAll()
        {
            string query = @"SELECT * FROM Exhibits;";

            List<ExhibitModel> result = await _db.LoadData<ExhibitModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Exhibits Get All returning null");

            return result;
        }

        public async Task<ExhibitModel> GetOne(int id)
        {
            string query = @"
                    SELECT * FROM Exhibits
                    WHERE Id = @id
            ;";

            List<ExhibitModel> results = await _db.LoadData<ExhibitModel, dynamic>(query, new { id });
            ExhibitModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Exhibit Get One returning null");
            return result;
        }

        public async Task Create(string filePath, string fileName)
        {
            string query = @"
                    INSERT INTO Exhibits (FilePath, FileName)
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

            string insertString = DataHelper.GetInsertValues(columns, values);


            string query = $@"
                    UPDATE Exhibits
                    SET {insertString}
                    WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, filePath, fileName });
        }

        public async Task Delete(int id)
        {
            string query = @"
                    DELETE FROM Exhibits
                    WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}

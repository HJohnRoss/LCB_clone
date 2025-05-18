using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class AmendmentData
    {
        private readonly SqlDataAccess _db;

        public AmendmentData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<AmendmentModel> GetAll()
        {
            string query = @"
                SELECT Id, FilePath, FileName FROM Amendments;
            ";

            return _db.LoadData<AmendmentModel, dynamic>(query, new { }).ToList()
                ?? throw new InvalidDataException("Amendments GetAll query is null");
        }

        public AmendmentModel GetOne(int id)
        {
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Amendments
                WHERE Id = @id;
            ";

            return _db.LoadData<AmendmentModel, dynamic>(query, new { id }).FirstOrDefault()
                ?? throw new InvalidDataException("Amendments GetOne query is null");
        }

        public void Create(string filePath, string fileName)
        {
            string query = @"
                INSERT INTO Amendments
                ( FilePath, FileName )
                VALUES ( @filePath, @fileName );
            ";

            _db.SaveData(query, new { filePath, fileName });
        }

        public void Update(int id, string filePath, string fileName)
        {
            string query = @"
                UPDATE Amendments
                Set FilePath = @filePath,
                    FileName = @fileName
                WHERE Id = @id;
            ";

            _db.SaveData(query, new { id, filePath, fileName });
        }

        public void Delete(int id)
        {
            string query = @"
                DELETE FROM Amendments
                WHERE Id = @id;
            ";

            _db.SaveData(query, new { id });
        }
    }
}

using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class CommitteData
    {
        private readonly SqlDataAccess _db;

        public CommitteData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<CommitteeModel>> GetAll()
        {
            string query = "SELECT * FROM Committees;";

            List<CommitteeModel> result = await _db.LoadData<CommitteeModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Committee GetAll query is null");

            return result;
        }

        public async Task<CommitteeModel> GetOne(int id)
        {
            string query = @"
                    SELECT * FROM Committees
                    WHERE Id = @id;
            ";

            List<CommitteeModel> results = await _db.LoadData<CommitteeModel, dynamic>(query, new { id });
            CommitteeModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Committees Get One query failed");
            return result;
        }

        public async Task Create(string house)
        {
            string query = @"
                    INSERT INTO Committees (House)
                    VALUES (@house);
            ";

            await _db.SaveData(query, new { house });
        }

        public async Task Update(int id, string house)
        {
            string query = @"
                    UPDATE Committees
                    SET House = @house
                    WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, house });
        }

        public async Task Delete(int id)
        {
            string query = @"
                    DELETE FROM Committees
                    WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}

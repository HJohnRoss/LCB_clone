using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class LegislatorData
    {
        private readonly SqlDataAccess _db;

        public LegislatorData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<LegislatorModel>> GetAll()
        {
            string query = "SELECT * FROM Legislators;";

            List<LegislatorModel> result = await _db.LoadData<LegislatorModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Legislator Get All is null");
            return result;
        }

        public async Task<LegislatorModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM Legislators
                WHERE Id = @id;
                ";
            List<LegislatorModel> results = await _db.LoadData<LegislatorModel, dynamic>(query, new { id });
            LegislatorModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Legislator Get One is null");
            return result;
        }

        public async Task Create(

                )
        {

        }
    }
}

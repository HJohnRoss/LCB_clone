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

        public List<LegislatorModel> GetAll()
        {
            string query = "SELECT * FROM Legislators;";

            List<LegislatorModel> result = _db.LoadData<LegislatorModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Legislator Get All is null");
            return result;
        }
    }
}

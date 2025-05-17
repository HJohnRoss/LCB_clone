using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class LegislatorVoteData
    {
        private readonly SqlDataAccess _db;

        public LegislatorVoteData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<LegislatorVoteModel> GetAll()
        {
            string query = "SELECT * FROM LegislatorVotes;";

            List<LegislatorVoteModel> result = _db.LoadData<LegislatorVoteModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Legislator Vote Get all is null");
            return result;
        }
    }
}

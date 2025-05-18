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
            // TODO: Finish query
            string committeeQuery = @"SELECT * FROM Committees";


            List<CommitteeModel> committeeResult = await _db.LoadData<CommitteeModel, dynamic>(committeeQuery, new { })
                ?? throw new InvalidDataException("Committee GetAll query is null");
            return committeeResult;
        }
    }
}

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
            string query = "SELECT * FROM Amendments;";

            List<AmendmentModel> result = _db.LoadData<AmendmentModel, dynamic>(query, new { }).ToList()
                ?? throw new InvalidOperationException("GetAll Amendments query is null");
            return result;

        }
    }
}

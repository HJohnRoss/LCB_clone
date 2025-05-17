using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class SessionData
    {
        private readonly SqlDataAccess _db;

        public SessionData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<SessionModel> GetAll()
        {
            string query = "SELECT * FROM Sessions;";

            List<SessionModel> result = _db.LoadData<SessionModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Sessions Get All is null");
            return result;
        }
    }
}

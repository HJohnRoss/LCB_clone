using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class SessionMeetingData
    {
        private readonly SqlDataAccess _db;

        public SessionMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<SessionMeetingModel> GetAll()
        {
            string query = "SELECT * FROM SessionMeetings;";

            List<SessionMeetingModel> result = _db.LoadData<SessionMeetingModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("SessionMeetings GetAll is null");
            return result;
        }
    }
}

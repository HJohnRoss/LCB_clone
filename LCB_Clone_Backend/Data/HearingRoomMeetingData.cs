using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class HearingRoomMeetingData
    {
        private readonly SqlDataAccess _db;

        public HearingRoomMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<HearingRoomMeetingModel> GetAll()
        {
            string query = "SELECT * FROM HearingRoomMeetings;";

            List<HearingRoomMeetingModel> result = _db.LoadData<HearingRoomMeetingModel, dynamic>(query, new { }).ToList()
                ?? throw new InvalidDataException("HearingRoomMeeting GetAll is null");
            return result;
        }
    }
}


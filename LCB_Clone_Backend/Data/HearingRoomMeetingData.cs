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

        // TODO: ADD AGENDA MODEL
        public void Create(string meetingName, string youtubeLink, string ccRoomNumber, bool isCCMainRoom, string lvRoomNumber, string time, string data)
        {
            string query = @"
                INSERT INTO HearingRoomMeetings (MeetingName, YoutubeLink, CCRoomNumber, IsCCMainRoom, LVRoomNumber, Time, Date)
                VALUES (@meetingName, @youtubeLink, @ccRoomNumber, @isCCMainRoom, @lvRoomNumber, @time, @data);
                ";

            _db.SaveData(
                    query,
                    new { meetingName, youtubeLink, ccRoomNumber, isCCMainRoom, lvRoomNumber, time, data }
                    );
        }
    }
}


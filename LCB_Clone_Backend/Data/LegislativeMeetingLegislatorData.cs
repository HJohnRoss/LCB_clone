using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class LegislativeMeetingLegislatorData
    {
        private readonly SqlDataAccess _db;
        // private readonly Lazy<LegislativeMeetingData> _meetingData;
        // private readonly LegislatorData _legislatorData;

        public LegislativeMeetingLegislatorData(
                SqlDataAccess db
                // Lazy<LegislativeMeetingData> meetingData,
                // LegislatorData legislatorData
                )
        {
            _db = db;
            // _meetingData = meetingData;
            // _legislatorData = legislatorData;
        }

        public async Task Create(int meetingsId, int membersId)
        {
            // LegislatorModel legislators = await _legislatorData.GetOne(membersId)
            //     ?? throw new InvalidDataException("membersId is null");

            // Validates LegislativeMeetings
            // LegislativeMeetingModel meeting = await _meetingData.GetOne(meetingsId)
            //     ?? throw new InvalidDataException("meetingsId is null");

            string query = @"
                INSERT INTO LegislativeMeetingModelLegislatorModel
                (LegislativeMeetingsId, MembersId)
                VALUES (@meetingsId, @membersId);
                ";
            await _db.SaveData(query, new { meetingsId, membersId });
        }

        // NOTE: Get Legislators from meetingId
        public async Task<List<LegislatorModel>> GetLegislators(int meetingId)
        {
            string query = @"
                SELECT * FROM LegislativeMeetingModelLegislatorModel AS legmeet
                INNER JOIN Legislators AS leg ON leg.Id = legmeet.MembersId
                WHERE legmeet.LegislativeMeetingsId = @meetingId;
                ";
            return await _db.LoadData<LegislatorModel, dynamic>(query, new { meetingId })
                ?? throw new InvalidDataException("Get Legislators failed");
        }

        // NOTE: Update a meetings from legislatorId
        public async Task UpdateLegislator(int legislatorId, int meetingId)
        {
            string query = @"
                UPDATE LegislativeMeetingModelLegislatorModel
                SET MembersId = @legislatorId
                WHERE LegislativeMeetingsId = @meetingId;
                ";
            await _db.SaveData(query, new { legislatorId, meetingId });
        }

        // NOTE: Delete from legislatorId
        public async Task DeleteLegislator(int legislatorId)
        {
            string query = @"
                DELETE FROM LegislativeMeetingModelLegislatorModel
                WHERE MembersId = @legislatorId
                ";
            await _db.SaveData(query, new { legislatorId });
        }

        // NOTE: Get all legislators in meeting
        public async Task<List<LegislativeMeetingModel>> GetMeetings(int legislatorId)
        {
            string query = @"
                SELECT * FROM LegislativeMeetingModelLegislatorModel AS legmeet
                INNER JOIN LegislativeMeetings AS lm ON lm.Id = legmeet.LegislativeMeetingsId
                WHERE legmeet.MembersId = @legislatorId;
                ";
            return await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { legislatorId })
                ?? throw new InvalidDataException("Get meetings failed");
        }

        // NOTE: Update Meeting from legislatorId
        public async Task UpdateMeeting(int legislatorId, int meetingId)
        {
            string query = @"
                UPDATE LegislativeMeetingModelLegislatorModel
                SET LegislativeMeetingsId = @meetingId
                WHERE MembersId = @legislatorId;
                ";
            await _db.SaveData(query, new { legislatorId, meetingId });
        }

        // NOTE: Delete from meetingId
        public async Task DeleteMeeting(int meetingId)
        {
            string query = @"
                DELETE FROM LegislativeMeetingModelLegislatorMode
                WHERE LegislativeMeetingsId = @meetingId;
                ";
            await _db.SaveData(query, new { meetingId });
        }
    }
}

using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class LegislativeMeetingStaffMemberData
    {
        private readonly SqlDataAccess _db;

        public LegislativeMeetingStaffMemberData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task Create(int meetingsId, int staffId)
        {
            string query = @"
                INSERT INTO LegislativeMeetingModelStaffMemberModel
                (LegislativeMeetingsId, StaffId)
                VALUES (@meetingsId, @staffId);
                ";
            await _db.SaveData(query, new { meetingsId, staffId });
        }

        // NOTE: Get Staff from meetingId
        public async Task<List<StaffMemberModel>> GetStaff(int meetingId)
        {
            string query = @"
                SELECT * FROM LegislativeMeetingModelStaffMemberModel AS lms
                INNER JOIN StaffMembers AS sm ON sm.Id = lms.MembersId
                WHERE lms.MeetingsId = @meetingId;
                ";
            return await _db.LoadData<StaffMemberModel, dynamic>(query, new { meetingId })
                ?? throw new InvalidDataException("Get Legislators failed");
        }

        // NOTE: Update a meetings from StaffId
        public async Task UpdateStaff(int staffId, int meetingId)
        {
            string query = @"
                UPDATE LegislativeMeetingModelStaffMemberModel
                SET StaffId = @staffId
                WHERE MeetingsId = @meetingId;
                ";
            await _db.SaveData(query, new { staffId, meetingId });
        }

        // NOTE: Delete from StaffId
        public async Task DeleteStaff(int staffId)
        {
            string query = @"
                DELETE FROM LegislativeMeetingModelStaffMemberModel
                WHERE StaffId = @staffId
                ";
            await _db.SaveData(query, new { staffId });
        }

        // NOTE: Get all meetings from staffId
        public async Task<List<LegislativeMeetingModel>> GetMeetings(int staffId)
        {
            string query = @"
                SELECT * FROM LegislativeMeetingModelStaffMemberModel AS lmsm
                INNER JOIN LegislativeMeetings AS m ON m.Id = lmsm.MeetingsId
                WHERE lmsm.MembersId = @staffId
                ";
            return await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { staffId })
                ?? throw new InvalidDataException("Get staff failed");
        }

        // NOTE: Update Meeting from StaffId
        public async Task UpdateMeeting(int staffId, int meetingId)
        {
            string query = @"
                UPDATE LegislativeMeetingModelStaffMemberModel
                SET MeetingsId = @meetingId
                WHERE StaffId = @staffId;
                ";
            await _db.SaveData(query, new { staffId, meetingId });
        }

        // NOTE: Delete from meetingId
        public async Task DeleteMeeting(int meetingId)
        {
            string query = @"
                DELETE FROM LegislativeMeetingModelStaffMemberModel
                WHERE MeetingsId = @meetingId;
                ";
            await _db.SaveData(query, new { meetingId });
        }
    }
}

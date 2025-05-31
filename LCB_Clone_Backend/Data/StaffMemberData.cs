using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class StaffMemberData
    {
        private readonly SqlDataAccess _db;

        public StaffMemberData(SqlDataAccess db)
        {
            _db = db;
        }
        public async Task<List<StaffMemberModel>> GetAll()
        {
            string query = "SELECT * FROM StaffMembers;";

            List<StaffMemberModel> result = await _db.LoadData<StaffMemberModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("StaffMembers Get All returning null");

            foreach (StaffMemberModel staffMember in result)
            {
                await GatherData(staffMember);
            }
            return result;
        }

        public async Task<StaffMemberModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM StaffMembers
                WHERE Id = @id;
                ";

            List<StaffMemberModel> results = await _db.LoadData<StaffMemberModel, dynamic>(query, new { id });
            return results.FirstOrDefault()
                ?? throw new InvalidDataException("StaffMembers Get one returning null");
        }

        public async Task Create(
                string firstName,
                string? middleInitial,
                string lastName,
                string? title,
                int? committesId,
                int? meetingsId,
                int? sessionCommitteesId,
                int? SessionMeetingsId
                )
        {
            List<string> columns = new()
            {
                "FirstName",
                "LastName",
            };
            List<string> values = new()
            {
                "@firstName",
                "@lastName"
            };

            if (middleInitial != null)
            {
                columns.Add("MiddleInitial");
                values.Add("@middleInitial");
            }
            if (title != null)
            {
                columns.Add("Title");
                values.Add("@title");
            }
            if (committesId != null)
            {
                columns.Add("CommitteesId");
                values.Add("@committeesId");
            }
            if (meetingsId != null)
            {
                columns.Add("MeetingsId");
                values.Add("@meetingsId");
            }
            if (sessionCommitteesId != null)
            {
                columns.Add("SessionCommitteesId");
                values.Add("@sessionMeetingsId");
            }
            if (SessionMeetingsId != null)
            {
                columns.Add("SessionCommitteesId");
                values.Add("@sessionMeetingsId");
            }

            string columnStr = DataHelper.GetStringValue(columns);
            string valueStr = DataHelper.GetStringValue(values);

            string query = $@"
                INSERT INTO StaffMembers ({columnStr})
                VALUES ({valueStr});
                ";

            await _db.SaveData(
                    query,
                    new
                    {
                        firstName,
                        middleInitial,
                        lastName,
                        title,
                        committesId,
                        meetingsId,
                        sessionCommitteesId,
                        SessionMeetingsId
                    });
        }

        public async Task Update(
                int id,
                string? firstName,
                string? middleInitial,
                string? lastName,
                string? title,
                int? committesId,
                int? meetingsId,
                int? sessionCommitteesId,
                int? SessionMeetingsId
                )
        {
            StaffMemberModel staffMember = await GetOne(id);
            if (staffMember == null)
            {
                throw new InvalidDataException("staffMember does not exist");
            }

            List<string> columns = new();
            List<string> values = new();

            if (firstName != null)
            {
                columns.Add("FirstName");
                values.Add("@lastName");
            }
            if (middleInitial != null)
            {
                columns.Add("MiddleInitial");
                values.Add("@middleInitial");
            }
            if (lastName != null)
            {
                columns.Add("LastName");
                values.Add("@lastName");
            }
            if (title != null)
            {
                columns.Add("Title");
                values.Add("@title");
            }
            if (committesId != null)
            {
                columns.Add("CommitteesId");
                values.Add("@committeesId");
            }
            if (meetingsId != null)
            {
                columns.Add("MeetingsId");
                values.Add("@meetingsId");
            }
            if (sessionCommitteesId != null)
            {
                columns.Add("SessionCommitteesId");
                values.Add("@sessionMeetingsId");
            }
            if (SessionMeetingsId != null)
            {
                columns.Add("SessionCommitteesId");
                values.Add("@sessionMeetingsId");
            }

            string insertString = DataHelper.GetInsertValues(columns, values);
            string query = $@"
                UPDATE StaffMembers
                SET ({insertString})
                WHERE Id = @id;
                ";
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM StaffMembers
                WHERE Id = @id;
                ";
            await _db.SaveData(query, new { id });
        }

        public async Task GatherData(StaffMemberModel staffMember)
        {
            string query = @"
                    SELECT * FROM Committees
                    WHERE StaffId = @id;
                    ";
            staffMember.Committees =
                await _db.LoadData<CommitteeModel, dynamic>(query, new { id = staffMember.Id });

            query = @"
                SELECT * FROM LegislativeMeetings
                WHERE CommitteeId = @id;
                ";
            staffMember.Meetings =
                await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { id = staffMember.Id });

            query = @"
                SELECT * FROM SessionCommittees
                WHERE CommitteeId = @id;
                ";
            staffMember.SessionCommittees =
                await _db.LoadData<SessionCommitteeModel, dynamic>(query, new { id = staffMember.Id });

            // TODO: SessionMeetings
            query = @"
                SELECT * FROM SessionMeetings
                WHERE 
                ";
            // staffMember.SessionMeetings =
        }
    }
}

using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class SessionMeetingData
    {
        private readonly SqlDataAccess _db;

        public SessionMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<SessionMeetingModel>> GetAll()
        {
            string query = "SELECT * FROM SessionMeetings;";

            List<SessionMeetingModel> result = await _db.LoadData<SessionMeetingModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("SessionMeetings GetAll is null");
            foreach (SessionMeetingModel meeting in result)
            {
                await GatherData(meeting);
            }
            return result;
        }

        public async Task<SessionMeetingModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM SessionMeetings
                WHERE Id = @id;
                ";
            List<SessionMeetingModel> results =
                await _db.LoadData<SessionMeetingModel, dynamic>(query, new { id });
            SessionMeetingModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Legislative Meeting Get One failed");

            await GatherData(result);
            return result;
        }

        public async Task Create(
                string minutesPath,
                string house,
                string name, string? youtubeLink,
                string? ccRoomNumber,
                bool isCCMainRoom,
                string? lvRoomNumber,
                DateTime dateTime,
                int? agendaId,
                int? committeeId,

                int? billsId,
                int? budgetsId,
                int? workSessionId,
                int? membersId,
                int? staffId,
                int? sessionId
                )
        {
            List<string> columns = new()
            {
                "House",
                "Name",
                "IsCCMainRoom",
                "Datetime",
            };
            List<string> values = new()
            {
                "@house",
                "@name",
                "@isCCMainRoom",
                "@dateTime",
            };

            if (youtubeLink != null)
            {
                columns.Add("YoutubeLink"); values.Add("@youtubeLink");
            }
            if (ccRoomNumber != null)
            {
                columns.Add("CCRoomNumber");
                values.Add("@ccRoomNumber");
            }
            if (lvRoomNumber != null)
            {
                columns.Add("LVRoomNumber");
                values.Add("@lvRoomNumber");
            }

            await ValidateId(
                billsId,
                "billsId",
                "BillsId",
                "Bills",
                columns,
                values
                );

            await ValidateId(
                budgetsId,
                "budgetsId",
                "BudgetsId",
                "Budgets",
                columns,
                values
                );

            await ValidateId(
                workSessionId,
                "workSessionId",
                "WorkSessionId",
                "WorkSessions",
                columns,
                values
                );

            await ValidateId(
                membersId,
                "membersId",
                "MembersId",
                "Legislators",
                columns,
                values
                );

            await ValidateId(
                staffId,
                "staffId",
                "StaffId",
                "StaffMembers",
                columns,
                values
                );

            await ValidateId(
                sessionId,
                "sessionId",
                "SessionId",
                "Sessions",
                columns,
                values
                );

            await ValidateId(
                agendaId,
                "agendaId",
                "AgendaId",
                "Agendas",
                columns,
                values
                );
            await ValidateId(
                committeeId,
                "committeeId",
                "CommitteeId",
                "Committees",
                columns,
                values
                );

            string columnStr = DataHelper.GetStringValue(columns);
            string valueStr = DataHelper.GetStringValue(values);

            string query = $@"
                INSERT INTO SessionMeetings ({columnStr})
                VALUES ({valueStr});
                ";

            await _db.SaveData(
                    query,
                    new
                    {
                        minutesPath,
                        house,
                        name,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        dateTime,
                        committeeId,
                        agendaId,
                        billsId,
                        budgetsId,
                        workSessionId,
                        membersId,
                        staffId,
                        sessionId
                    });
        }

        public async Task Update(
                int id,
                string? MinutesPath,
                string? house,
                string? name,
                string? youtubeLink,
                string? ccRoomNumber,
                bool? isCCMainRoom,
                string? lvRoomNumber,
                DateTime? dateTime,
                int? committeeId,
                int? agendaId,
                int? billsId,
                int? budgetsId,
                int? workSessionId,
                int? membersId,
                int? staffId,
                int? sessionId
                )
        {

            List<string> columns = new();
            List<string> values = new();

            if (house != null)
            {
                columns.Add("House");
                values.Add("@house");
            }
            if (name != null)
            {
                columns.Add("Name");
                values.Add("@name");
            }
            if (isCCMainRoom != null)
            {
                columns.Add("IsCCMainRoom");
                values.Add("@isCCMainRoom");
            }
            if (dateTime != null)
            {
                columns.Add("Datetime");
                values.Add("@dateTime");
            }
            if (youtubeLink != null)
            {
                columns.Add("YoutubeLink");
                values.Add("@youtubeLink");
            }
            if (ccRoomNumber != null)
            {
                columns.Add("CCRoomNumber");
                values.Add("@ccRoomNumber");
            }
            if (lvRoomNumber != null)
            {
                columns.Add("LVRoomNumber");
                values.Add("@lvRoomNumber");
            }
            await ValidateId(
                billsId,
                "billsId",
                "BillsId",
                "Bills",
                columns,
                values
                );

            await ValidateId(
                budgetsId,
                "budgetsId",
                "BudgetsId",
                "Budgets",
                columns,
                values
                );

            await ValidateId(
                workSessionId,
                "workSessionId",
                "WorkSessionId",
                "WorkSessions",
                columns,
                values
                );

            await ValidateId(
                membersId,
                "membersId",
                "MembersId",
                "Legislators",
                columns,
                values
                );

            await ValidateId(
                staffId,
                "staffId",
                "StaffId",
                "StaffMembers",
                columns,
                values
                );

            await ValidateId(
                sessionId,
                "sessionId",
                "SessionId",
                "Sessions",
                columns,
                values
                );

            await ValidateId(
                agendaId,
                "agendaId",
                "AgendaId",
                "Agendas",
                columns,
                values
                );
            await ValidateId(
                committeeId,
                "committeeId",
                "CommitteeId",
                "Committees",
                columns,
                values
                );

            string insertStr = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                UPDATE SessionMeetings
                SET {insertStr}
                WHERE Id = @id;
                ";
            Console.WriteLine(query);

            await _db.SaveData(
                    query,
                    new
                    {
                        id,
                        MinutesPath,
                        house,
                        name,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        dateTime,
                        committeeId,
                        agendaId,
                        billsId,
                        budgetsId,
                        workSessionId,
                        membersId,
                        staffId,
                        sessionId
                    });

        }

        // Delete One
        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM SessionMeetings
                WHERE Id = @id;
                ";

            await _db.SaveData(query, new { id });
        }

        // Gathers data for GetOne() and GetAll() for LegislativeMeetings
        public async Task GatherData(SessionMeetingModel meeting)
        {
            string query = @"
                SELECT * FROM Agendas
                WHERE Id = @id;
                ";
            List<AgendaModel> agendas = await _db.LoadData<AgendaModel, dynamic>(
                    query,
                    new { id = meeting.AgendaId }
                    );
            meeting.Agenda = agendas.FirstOrDefault();

            query = @"
                SELECT * FROM SessionCommittees
                WHERE Id = @id;
                ";
            List<SessionCommitteeModel> committees = await _db.LoadData<SessionCommitteeModel, dynamic>(
                    query,
                    new { id = meeting.CommitteeId }
                    );
            meeting.Committee = committees.FirstOrDefault();

            // TODO: Query
            query = @"
                SELECT * FROM LegislativeMeetingModelLegislatorModel
                WHERE LegislativeMeetingsId = @id;
                ";
            // TODO: STAFF
        }

        public async Task ValidateId(
                int? id,
                string idVarName,
                string idTableName,
                string tableName,
                List<string> Columns,
                List<string> Values
                )
        {
            string query = $@"
                        SELECT * FROM {tableName}
                        WHERE Id = @id;
                    ";
            List<LegislativeMeetingModel> results =
                await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { id })
                ?? throw new InvalidDataException($"{tableName} GetOne is invalid");

            if (results.FirstOrDefault() != null)
            {
                Columns.Add($"{idTableName}");
                Values.Add($"@{idVarName}");
            }
        }
    }
}

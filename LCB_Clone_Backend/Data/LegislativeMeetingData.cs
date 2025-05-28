using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class LegislativeMeetingData
    {
        private readonly SqlDataAccess _db;

        // Database access
        public LegislativeMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        // returns a list of all LegislativeMeetings
        public async Task<List<LegislativeMeetingModel>> GetAll()
        {
            string query = "SELECT * FROM LegislativeMeetings;";

            List<LegislativeMeetingModel> result =
                await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Legislative Meeting Get All is null");

            foreach (LegislativeMeetingModel meeting in result)
            {
                await GatherData(meeting);
            }
            return result;
        }

        public async Task<LegislativeMeetingModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM LegislativeMeetings
                WHERE Id = @id;
                ";
            List<LegislativeMeetingModel> results =
                await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { id });
            LegislativeMeetingModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Legislative Meeting Get One failed");

            await GatherData(result);
            return result;
        }

        public async Task Create(
                string house,
                string meetingName,
                string? youtubeLink,
                string? ccRoomNumber,
                bool isCCMainRoom,
                string? lvRoomNumber,
                DateTime dateTime,
                int? agendaId,
                int? committeeId
                )
        {
            List<string> columns = new()
            {
                "House",
                "MeetingName",
                "IsCCMainRoom",
                "Datetime",
            };
            List<string> values = new()
            {
                "@house",
                "@meetingName",
                "@isCCMainRoom",
                "@dateTime",
            };

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
                "CommiteeId",
                "Agendas",
                columns,
                values
                );

            string columnStr = DataHelper.GetStringValue(columns);
            string valueStr = DataHelper.GetStringValue(values);

            string query = $@"
                INSERT INTO LegislativeMeetings ({columnStr})
                VALUES ({valueStr});
                ";

            await _db.SaveData(
                    query,
                    new
                    {
                        house,
                        meetingName,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        dateTime,
                        agendaId,
                        committeeId
                    });
        }

        public async Task Update(
                int id,
                string? house,
                string? meetingName,
                string? youtubeLink,
                string? ccRoomNumber,
                bool? isCCMainRoom,
                string? lvRoomNumber,
                DateTime? dateTime,
                int? agendaId,
                int? committeeId
                )
        {

            List<string> columns = new();
            List<string> values = new();

            if (house != null)
            {
                columns.Add("House");
                values.Add("@house");
            }
            if (meetingName != null)
            {
                columns.Add("MeetingName");
                values.Add("@meetingName");
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

            Console.WriteLine($"committee: {committeeId}");

            string insertStr = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                UPDATE LegislativeMeetings
                SET {insertStr}
                WHERE Id = @id;
                ";
            Console.WriteLine(query);

            await _db.SaveData(
                    query,
                    new
                    {
                        id,
                        house,
                        meetingName,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        dateTime,
                        agendaId,
                        committeeId
                    });

        }

        // Delete One
        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM LegislativeMeetings
                WHERE Id = @id;
                ";

            await _db.SaveData(query, new { id });
        }

        // Gathers data for GetOne() and GetAll() for LegislativeMeetings
        public async Task GatherData(LegislativeMeetingModel meeting)
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
                SELECT * FROM Committees
                WHERE Id = @id;
                ";
            List<CommitteeModel> committees = await _db.LoadData<CommitteeModel, dynamic>(
                    query,
                    new { id = meeting.CommitteeId }
                    );
            meeting.Committee = committees.FirstOrDefault();

            query = @"
                 SELECT * FROM Legislators
                 WHERE LegislativeMeetingModelId = @id;
                ";
            meeting.LegislativeMembers = await _db.LoadData<LegislatorModel, dynamic>(
                    query,
                    new { id = meeting.Id }
                    );

            query = @"
                SELECT * FROM StaffMembers
                WHERE LegislativeMeetingModelId = @id;
                ";
            meeting.MeetingStaff = await _db.LoadData<StaffMemberModel, dynamic>(
                    query,
                    new { id = meeting.Id }
                    );
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
            Console.WriteLine($"id: {id}");
            Console.WriteLine(query);
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

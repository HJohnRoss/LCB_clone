using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

namespace LCB_Clone_Backend.Data
{
    public class HearingRoomMeetingData
    {
        private readonly SqlDataAccess _db;

        public HearingRoomMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<HearingRoomMeetingModel>> GetAll()
        {
            string query = "SELECT * FROM HearingRoomMeetings;";

            List<HearingRoomMeetingModel> result = await _db.LoadData<HearingRoomMeetingModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("HearingRoomMeeting GetAll is null");

            foreach (HearingRoomMeetingModel meeting in result)
            {
                await GatherMeetingData(meeting);
            }
            return result;
        }

        public async Task<HearingRoomMeetingModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM HearingRoomMeetings
                WHERE Id = @id;
            ";

            List<HearingRoomMeetingModel> results = await _db.LoadData<HearingRoomMeetingModel, dynamic>(query, new { id });
            HearingRoomMeetingModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("HearingRoomMeeting Get One is null");

            await GatherMeetingData(result);
            return result;
        }
        public async Task Create(
                    string meetingName,
                    string youtubeLink,
                    string ccRoomNumber,
                    bool isCCMainRoom,
                    string lvRoomNumber,
                    string? date,
                    int? agendaId
                )
        {
            List<string> columns = new() { "MeetingName", "YoutubeLink", "CCRoomNumber", "IsCCMainRoom", "LVRoomNumber" };
            List<string> values = new() { "@meetingName", "@youtubeLink", "@ccRoomNumber", "@isCCMainRoom", "@lvRoomNumber" };

            if (agendaId != null)
            {
                columns.Add("AgendaId");
                values.Add("@agendaId");
            }
            if (date != null)
            {
                columns.Add("Date");
                values.Add("@date");
            }

            string columnStr = DataHelper.GetStringValue(columns);
            string valueStr = DataHelper.GetStringValue(values);

            string query = $@"
                INSERT INTO HearingRoomMeetings ({columnStr})
                VALUES ({valueStr});
            ";

            Console.WriteLine(query);

            await _db.SaveData(
                        query,
                        new
                        {
                            meetingName,
                            youtubeLink,
                            ccRoomNumber,
                            isCCMainRoom,
                            lvRoomNumber,
                            date,
                            agendaId
                        }
                    );
        }

        public async Task GatherMeetingData(HearingRoomMeetingModel meeting)
        {
            string query = @"
                    SELECT * FROM Agendas
                    WHERE Id = @id;
                ";

            List<AgendaModel> agendas = await _db.LoadData<AgendaModel, dynamic>(query, new { id = meeting.AgendaId });
            meeting.Agenda = agendas.FirstOrDefault();
        }

        public async Task Update(
                    int id,
                    string? meetingName,
                    string? youtubeLink,
                    string? ccRoomNumber,
                    bool? isCCMainRoom,
                    string? lvRoomNumber,
                    string? date,
                    int? agendaId
                )
        {
            List<string> columns = new();
            List<string> values = new();

            if (meetingName != null)
            {
                columns.Add("MeetingName");
                values.Add("@meetingName");
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
                columns.Add("IsCCMainRoom");
                values.Add("@isCCMainRoom");
            }
            if (lvRoomNumber != null)
            {
                columns.Add("LVRoomNumber");
                values.Add("@lvRoomNumber");
            }
            if (date != null)
            {
                columns.Add("Date");
                values.Add("@date");
            }
            if (agendaId != null)
            {
                columns.Add("AgendaId");
                values.Add("@agendaId");
            }

            string insertStr = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                UPDATE HearingRoomMeetings
                SET {insertStr}
                WHERE Id = @id;
            ";

            await _db.SaveData(
                    query,
                    new
                    {
                        id,
                        meetingName,
                        youtubeLink,
                        ccRoomNumber,
                        isCCMainRoom,
                        lvRoomNumber,
                        date,
                        agendaId
                    }
                );
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM HearingRoomMeetings
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id });
        }
    }
}

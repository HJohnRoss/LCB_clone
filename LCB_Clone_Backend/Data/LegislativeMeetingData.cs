using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class LegislativeMeetingData
    {
        private readonly SqlDataAccess _db;

        public LegislativeMeetingData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<LegislativeMeetingModel>> GetAll()
        {
            string query = "SELECT * FROM LegislativeMeetings;";

            List<LegislativeMeetingModel> result = await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Legislative Meeting Get All is null");
            return result;
        }

        public async Task<LegislativeMeetingModel> GatherData(LegislativeMeetingModel meeting)
        {
            string query = @"
                SELECT * FROM Agendas
                WHERE Id = @id;
            ";
            List<AgendaModel> agendas = await _db.LoadData<AgendaModel, dynamic>(query, new { id = meeting.AgendaId });
            meeting.Agenda = agendas.FirstOrDefault();


            return meeting;
        }
    }
}

using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class AgendaData
    {
        private readonly SqlDataAccess _db;

        public AgendaData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<AgendaModel> GetAll()
        {
            string agendasQuery = "SELECT * FROM Agendas;";

            List<AgendaModel> agendas = _db.LoadData<AgendaModel, dynamic>(agendasQuery, new { })
                ?? throw new InvalidDataException("Agendas GetAll query is null");
            return agendas;
        }
    }
}

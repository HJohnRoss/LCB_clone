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

        public async Task<List<AgendaModel>> GetAll()
        {
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Agendas;
            ";

            return await _db.LoadData<AgendaModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Agendas GetAll query is null");
        }

        public async Task<AgendaModel> GetOne(int id)
        {
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Agendas
                WHERE Id = @id;
            ";

            List<AgendaModel> results = await _db.LoadData<AgendaModel, dynamic>(query, new { id })
                ?? throw new InvalidDataException("Agendas GetOne query is null");

            AgendaModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException($"Agenda with Id {id} is null");

            return result;
        }

        public async Task Create(string filePath, string fileName)
        {
            string query = @"
                INSERT INTO Agendas ( FilePath, FileName)
                VALUES ( @filePath, @fileName );
            ";

            await _db.SaveData(query, new { filePath, fileName });
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM Agendas
                WHERE Id = @id
            ;";

            await _db.SaveData(query, new { id });
        }

        public async Task Update(int id, string filePath, string fileName)
        {
            string query = @"
                UPDATE Agendas
                SET FilePath = @filePath,
                    FileName = @fileName
                WHERE Id = @id;
            ";

            await _db.SaveData(query, new { id, filePath, fileName });
        }
    }
}

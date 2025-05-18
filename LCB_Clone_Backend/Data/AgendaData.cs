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
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Agendas;
            ";

            return _db.LoadData<AgendaModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Agendas GetAll query is null");
        }

        public AgendaModel GetOne(int id)
        {
            string query = @"
                SELECT Id, FilePath, FileName
                FROM Agendas
                WHERE Id = @id;
            ";

            // NOTE: using FirstOrDefault so i can handle my own exceptions
            // (it can come back null)
            AgendaModel result = _db.LoadData<AgendaModel, dynamic>(query, new { id }).FirstOrDefault()
                ?? throw new InvalidDataException("Agendas GetOne query is null");
            return result;
        }

        public void Create(string filePath, string fileName)
        {
            string query = @"
                INSERT INTO Agendas ( FilePath, FileName)
                VALUES ( @filePath, @fileName );
                ;
            ";

            _db.SaveData(query, new { filePath, fileName });
        }

        public void Delete(int id)
        {
            string query = @"
                DELETE FROM Agendas
                WHERE Id = @id
            ;";

            _db.SaveData(query, new { id });
        }

        public void Update(int id, string filePath, string fileName)
        {
            string query = @"
                UPDATE Agendas
                SET FilePath = @filePath,
                    FileName = @fileName
                WHERE Id = @id;
            ";

            _db.SaveData(query, new { id, filePath, fileName });
        }
    }
}

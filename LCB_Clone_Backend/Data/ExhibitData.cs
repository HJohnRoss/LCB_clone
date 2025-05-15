using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class ExhibitData
    {
        private readonly SqlDataAccess _db;

        public ExhibitData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<ExhibitModel> GetAll()
        {
            string query = @"SELECT * FROM Exhibits;";

            List<ExhibitModel> result = _db.LoadData<ExhibitModel, dynamic>(query, new { }).ToList()
                ?? throw new InvalidDataException("Exhibits query returning null");
            return result;
        }
    }
}

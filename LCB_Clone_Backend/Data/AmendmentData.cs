using LCB_Clone_Backend.Models;
using Microsoft.Extensions.Configuration;

namespace LCB_Clone_Backend.Data
{
    public class AmendmentData : AmendmentModel
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _db;

        public AmendmentData(SqlDataAccess db, IConfiguration config)
        {
            _db = db;
            _connectionString = config.GetConnectionString("Default")
                ?? throw new InvalidOperationException("Connection string is null");
        }

        public List<AmendmentModel> GetAllAmendmentsData()
        {
            string query = @"
                SELECT Id, FilePath, FileName, UploadedAt, BillId
                FROM Amendments;
                ";

            List<AmendmentModel> result = _db.LoadData<AmendmentModel, dynamic>(query, new { }).ToList()
                ?? throw new InvalidOperationException("There are no amendments");
            return result;

        }
    }
}

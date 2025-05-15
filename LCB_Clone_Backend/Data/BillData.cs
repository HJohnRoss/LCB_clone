using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class BillData
    {
        private readonly SqlDataAccess _db;

        public BillData(SqlDataAccess db)
        {
            _db = db;
        }

        public List<BillModel> GetAll()
        {
            string query = "SELECT * FROM Bills";
            List<BillModel> result = _db.LoadData<BillModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Bills Get All null");
            return result;
        }
    }
}

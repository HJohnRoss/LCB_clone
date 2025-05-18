using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class StaffMemberData
    {
        private readonly SqlDataAccess _db;

        public StaffMemberData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<StaffMemberModel>> GetAll()
        {
            string query = "SELECT * FROM StaffMembers;";

            List<StaffMemberModel> result = await _db.LoadData<StaffMemberModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("StaffMembers Get All returning null");
            return result;
        }
    }
}

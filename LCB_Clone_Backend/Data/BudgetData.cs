using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class BudgetData
    {
        private readonly SqlDataAccess _db;

        public BudgetData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<BudgetModel>> GetAll()
        {
            string query = "SELECT * FROM Budgets";

            List<BudgetModel> result = await _db.LoadData<BudgetModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Budgets GetAll failed");
            return result;
        }
    }
}

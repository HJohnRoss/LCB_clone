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

        // NOTE: sessionMeetingModelId add a join for this
        public async Task<BudgetModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM Budgets
                WHERE Id = @id
            ";

            List<BudgetModel> results = await _db.LoadData<BudgetModel, dynamic>(query, new { id });
            BudgetModel result = results.FirstOrDefault()
                ?? throw new InvalidDataException("Bugets GetOne failed");
            return result;
        }

        public async Task Create(
                    string departmentNum,
                    string departmentName,
                    int agencyNum,
                    string agencyName,
                    int functionNum,
                    string functionName,
                    int subFunctionNum,
                    string subFuntionName,
                    string budgetName,
                    int fundNum,
                    int budgetNum,
                    string execBudgetPage,
                    string? summary,
                    string? synopsis,
                    string? textFilePath,
                    int? sessionMeetingModelId
                )
        {
            if (summary != null)
            {

            }
            if (synopsis != null)
            {

            }
            if (textFilePath != null)
            {

            }
            // Validation()
        }

        public async Task ValidateId(
                int? id,
                string idVarName,
                string idTableName,
                string tableName,
                List<string> Columns,
                List<string> Values
                )
        {
            string query = $@"
                        SELECT * FROM {tableName}
                        WHERE Id = @id;
                    ";
            List<SessionCommitteeModel> results = await _db.LoadData<SessionCommitteeModel, dynamic>(query, new { id })
                ?? throw new InvalidDataException($"{tableName} GetOne is invalid");

            if (results.FirstOrDefault() != null)
            {
                Columns.Add($"{idTableName}");
                Values.Add($"@{idVarName}");
            }
        }
    }
}

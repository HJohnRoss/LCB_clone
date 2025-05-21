using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Helpers;

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
                    int departmentNum,
                    string departmentName,
                    int agencyNum,
                    string agencyName,
                    int functionNum,
                    string functionName,
                    int subFunctionNum,
                    string subFunctionName,
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
            List<string> columns = new()
            {
                "DepartmentNum",
                "DepartmentName",
                "AgencyNum",
                "AgencyName",
                "FunctionNum",
                "FunctionName",
                "SubFunctionNum",
                "SubFunctionName",
                "BudgetName",
                "FundNum",
                "BudgetNum",
                "ExecBudgetPage",
            };
            List<string> values = new()
            {
                "@departmentNum",
                "@departmentName",
                "@agencyNum",
                "@agencyName",
                "@functionNum",
                "@functionName",
                "@subFunctionNum",
                "@subFunctionName",
                "@budgetName",
                "@fundNum",
                "@budgetNum",
                "@execBudgetPage",
            };
            if (summary != null)
            {
                columns.Add("Summary");
                values.Add("@summary");
            }
            if (synopsis != null)
            {
                columns.Add("Synopsis");
                values.Add("@synopsis");
            }
            if (textFilePath != null)
            {
                columns.Add("TextFilePath");
                values.Add("@textFilePath");
            }
            await ValidateId(
                    sessionMeetingModelId,
                    "SessionMeetingId",
                    "sessionMeetingId",
                    "SessionMeetings",
                    columns,
                    values
                    );

            string strColumns = DataHelper.GetStringValue(columns);
            string strValues = DataHelper.GetStringValue(values);

            string query = $@"
                INSERT INTO Budgets ({strColumns})
                VALUES ({strValues})
            ";

            await _db.SaveData(
                    query,
                    new
                    {
                        departmentNum,
                        departmentName,
                        agencyNum,
                        agencyName,
                        functionNum,
                        functionName,
                        subFunctionNum,
                        subFunctionName,
                        budgetName,
                        fundNum,
                        budgetNum,
                        execBudgetPage,
                        summary,
                        synopsis,
                        textFilePath,
                        sessionMeetingModelId
                    }
                );
        }

        // Update Function
        public async Task Update(
                    int id,
                    int? departmentNum,
                    string? departmentName,
                    int? agencyNum,
                    string? agencyName,
                    int? functionNum,
                    string? functionName,
                    int? subFunctionNum,
                    string? subFunctionName,
                    string? budgetName,
                    int? fundNum,
                    int? budgetNum,
                    string? execBudgetPage,
                    string? summary,
                    string? synopsis,
                    string? textFilePath,
                    int? sessionMeetingModelId
                )
        {
            List<string> columns = new();
            List<string> values = new();
            if (departmentNum != null)
            {
                // int? departmentNum,
                columns.Add("DepartmentNum");
                values.Add("@departmentNum");
            }
            if (departmentName != null)
            {
                // string? departmentName,
                columns.Add("DepartmentName");
                values.Add("@departmentName");
            }
            if (agencyNum != null)
            {
                // int? agencyNum,
                columns.Add("AgencyNum");
                values.Add("@agencyNum");
            }
            if (agencyName != null)
            {
                // string? agencyName,
                columns.Add("AgencyName");
                values.Add("@agencyName");
            }
            if (functionNum != null)
            {
                // int? functionNum,
                columns.Add("FunctionNum");
                values.Add("@functionNum");
            }
            if (functionName != null)
            {
                // string? functionName,
                columns.Add("FunctionName");
                values.Add("@functionName");
            }
            if (subFunctionNum != null)
            {
                // int? subFunctionNum,
                columns.Add("SubFunctionNum");
                values.Add("@subFunctionNum");
            }
            if (subFunctionName != null)
            {
                // string? subFunctionName,
                columns.Add("SubFunctionName");
                values.Add("@subFunctionName");
            }
            if (budgetName != null)
            {
                // string? budgetName,
                columns.Add("BudgetName");
                values.Add("@budgetName");
            }
            if (fundNum != null)
            {
                // int? fundNum,
                columns.Add("fundNum");
                values.Add("@fundNum");
            }
            if (budgetNum != null)
            {
                // int? budgetNum,
                columns.Add("BudgetNum");
                values.Add("@budgetNum");
            }
            if (execBudgetPage != null)
            {
                // string? execBudgetPage,
                columns.Add("ExecBudgetPage");
                values.Add("@execBudgetPage");
            }
            if (summary != null)
            {
                // string? summary,
                columns.Add("Summary");
                values.Add("@summary");
            }
            if (synopsis != null)
            {
                // string? synopsis,
                columns.Add("Synopsis");
                values.Add("@synopsis");
            }
            if (textFilePath != null)
            {
                // string? textFilePath,
                columns.Add("TextFilePath");
                values.Add("@textFilePath");
            }
            // int? sessionMeetingModelId
            await ValidateId(
                    sessionMeetingModelId,
                    "sessionMeetingId",
                    "SessionMeetingId",
                    "SessionMeetings",
                    columns,
                    values
                );

            string insertString = DataHelper.GetInsertValues(columns, values);

            string query = $@"
                    UPDATE Budgets
                    SET {insertString}
                    WHERE Id = @id;
            ";
            Console.WriteLine(query);

            await _db.SaveData(
                    query,
                    new
                    {
                        id,
                        departmentNum,
                        departmentName,
                        agencyNum,
                        agencyName,
                        functionNum,
                        functionName,
                        subFunctionNum,
                        subFunctionName,
                        budgetName,
                        fundNum,
                        budgetNum,
                        execBudgetPage,
                        summary,
                        synopsis,
                        textFilePath,
                        sessionMeetingModelId
                    });
        }

        public async Task Delete(int id)
        {
            string query = @"
                    DELETE FROM Budgets
                    WHERE Id = @id
                ";

            await _db.SaveData(query, new { id });
        }

        // Validation
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

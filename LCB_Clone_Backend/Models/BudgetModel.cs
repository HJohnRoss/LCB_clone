namespace LCB_Clone_Backend.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }

        public required int DepartmentNum { get; set; }
        public required string DepartmentName { get; set; }

        public required int AgencyNum { get; set; }
        public required string AgencyName { get; set; }

        public required int FunctionNum { get; set; }
        public required string FunctionName { get; set; }

        public required int SubFunctionNum { get; set; }
        public required string SubFunctionName { get; set; }

        public required string BudgetName { get; set; }

        public required int FundNum { get; set; }

        public required int BudgetNum { get; set; }

        public required string ExecBudgetPage { get; set; }

        public string? Summary { get; set; }

        public string? Synopsis { get; set; }

        public string? TextFilePath { get; set; }

        public List<SessionModel> Meetings { get; set; } = new();

        public List<ExhibitModel> Exhibits { get; set; } = new();
    }
}

namespace LCB_Clone_Backend.Models
{
    public class SessionMeetingModel : LegislativeMeetingModel
    {
        public List<BillModel> Bills { get; set; } = new();
        public List<BudgetModel> Budgets { get; set; } = new();
        public List<WorkSessionDocModel> WorkSessionDocs { get; set; } = new();
        public string? MinutesPath { get; set; }
    }
}

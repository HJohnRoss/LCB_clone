namespace LCB_Clone_Backend.Models
{
    // TODO: all of this class
    public class SessionModel
    {
        public int Id { get; set; }

        // NOTE: Calendar Section
        public string? SessionDayCalendar { get; set; } // 120 day calander

        // NOTE: Legislation Section
        public List<BillModel> Bills { get; set; } = new();

        // NOTE: Budget Section
        public List<BudgetModel> Budgets { get; set; } = new();
        public string? ProposedExecutiveBudgetPath { get; set; }
        public string? CapitalImprovementPath { get; set; }
        public string? FiscalReportPath { get; set; }

        // NOTE: Meetings & Floor Sessions Section
        public List<SessionMeetingModel> Meetings { get; set; } = new();

        // NOTE: Session Info Section
        List<LegislatorModel> Legislators { get; set; } = new();
        List<JournalModel> Journals { get; set; } = new();

        // NOTE: Tracking Section
        public string? UserManualPath { get; set; }
    }
}

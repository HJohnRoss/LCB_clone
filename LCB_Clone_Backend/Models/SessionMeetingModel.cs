namespace LCB_Clone_Backend.Models
{
    public class SessionMeetingModel
    {
        public int Id { get; set; }

        public string? MinutesPath { get; set; }

        public required string House { get; set; }

        public required string Name { get; set; }

        public string? YoutubeLink { get; set; }

        public string? CCRoomNumber { get; set; }

        public required bool IsCCMainRoom { get; set; }

        public string? LVRoomNumber { get; set; }

        public DateTime Datetime { get; set; }

        // Joins
        public int? CommitteeId { get; set; }
        public SessionCommitteeModel? Committee { get; set; }

        public int? AgendaId { get; set; }
        public AgendaModel? Agenda { get; set; }

        public List<int> BillsId { get; set; } = new();
        public List<BillModel> Bills { get; set; } = new();

        public List<int> BudgetsId { get; set; } = new();
        public List<BudgetModel> Budgets { get; set; } = new();

        public List<int>? WorkSessionId { get; set; } = new();
        public List<WorkSessionDocModel> WorkSessionDocs { get; set; } = new();

        public List<int> MembersId { get; set; } = new();
        public List<LegislatorModel> Members { get; set; } = new();

        public List<int> StaffId { get; set; } = new();
        public List<StaffMemberModel> Staff { get; set; } = new();

        public int? SessionId { get; set; }
        public SessionModel? Session { get; set; }
    }
}

namespace LCB_Clone_Backend.Models
{
    public class SessionCommitteeModel
    {
        public int Id { get; set; }
        public required string House { get; set; }
        public string? Mon { get; set; }
        public string? Tues { get; set; }
        public string? Wed { get; set; }
        public string? Thurs { get; set; }
        public string? Fri { get; set; }

        // Joins
        public List<int> MeetingsId { get; set; } = new();
        public List<SessionMeetingModel> Meetings { get; set; } = new();

        public List<int> LegislativeMembersId { get; set; } = new();
        public List<LegislatorModel> LegislativeMembers { get; set; } = new();

        public List<int> StaffMembersId { get; set; } = new();
        public List<StaffMemberModel> StaffMembers { get; set; } = new();

        public List<int> SponsoredBillsId { get; set; } = new();
        public List<BillModel> SponsoredBills { get; set; } = new();

        public List<int> BillsDiscussedId { get; set; } = new();
        public List<BillModel> BillsDiscussed { get; set; } = new();
    }
}

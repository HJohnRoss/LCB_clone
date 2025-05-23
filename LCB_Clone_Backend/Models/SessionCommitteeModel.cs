namespace LCB_Clone_Backend.Models
{
    public class SessionCommitteeModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required List<LegislatorModel> LegislativeMembers { get; set; } = new();

        public required List<StaffMemberModel> StaffMembers { get; set; } = new();

        public string? Mon { get; set; }

        public string? Tues { get; set; }

        public string? Wed { get; set; }

        public string? Thurs { get; set; }

        public string? Fri { get; set; }

        public List<BillModel> SponsoredBills { get; set; } = new();

        public List<BillModel> BillsDiscussed { get; set; } = new();
    }
}

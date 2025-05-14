namespace LCB_Clone_Backend.Models
{

    public class CommitteeModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required List<LegislatorModel> LegislativeMembers = new();

        public required List<StaffMemberModel> StaffMembers = new();

        public string? Mon { get; set; }

        public string? Tues { get; set; }

        public string? Wed { get; set; }

        public string? Thurs { get; set; }

        public string? Fri { get; set; }

        public required List<LegislativeMeetingModel> Meetings = new();

        public required List<BillModel> SponsoredBills = new();

        public required List<BillModel> BillsDiscussed = new();
    }
}

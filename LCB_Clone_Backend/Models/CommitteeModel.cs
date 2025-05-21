namespace LCB_Clone_Backend.Models
{

    public class CommitteeModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required List<LegislatorModel> LegislativeMembers { get; set; } = new();

        public required List<StaffMemberModel> StaffMembers { get; set; } = new();

        public required List<LegislativeMeetingModel> Meetings { get; set; } = new();
    }
}

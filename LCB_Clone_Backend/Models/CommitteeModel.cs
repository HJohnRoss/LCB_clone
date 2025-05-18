namespace LCB_Clone_Backend.Models
{

    public class CommitteeModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required List<LegislatorModel> LegislativeMembers = new();

        public required List<StaffMemberModel> StaffMembers = new();

        public required List<LegislativeMeetingModel> Meetings = new();
    }
}

namespace LCB_Clone_Backend.Models
{

    public class CommitteeModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public List<int> LegislatorsId { get; set; } = new();
        public List<LegislatorModel> Legislators { get; set; } = new();

        public List<int> StaffId { get; set; } = new();
        public List<StaffMemberModel> StaffMembers { get; set; } = new();

        public List<int> MeetingsId { get; set; } = new();
        public List<LegislativeMeetingModel> Meetings { get; set; } = new();
    }
}

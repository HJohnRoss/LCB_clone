namespace LCB_Clone_Backend.Models
{
    public class LegislativeMeetingModel : HearingRoomMeetingModel
    {
        public required string House { get; set; }
        public required List<LegislatorModel> LegislativeMembers { get; set; } = new();
        public required List<StaffMemberModel> MeetingStaff { get; set; } = new();
    }
}

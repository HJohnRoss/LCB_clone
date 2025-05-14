namespace Api.Models
{
    public class LegislativeMeeting : HearingRoomMeeting
    {
        public required string House { get; set; }
        public List<Legislator> LegislativeMembers { get; set; } = new List<Legislator>();
        public List<Staff> AllStaff { get; set; } = new List<Staff>();
    }
}

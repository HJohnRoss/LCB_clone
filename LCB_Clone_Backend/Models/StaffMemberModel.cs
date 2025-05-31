namespace LCB_Clone_Backend.Models
{
    public class StaffMemberModel
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public string? Title { get; set; }

        public List<int> CommitteesId { get; set; } = new();
        public List<CommitteeModel> Committees { get; set; } = new();

        public List<int> MeetingsId { get; set; } = new();
        public List<LegislativeMeetingModel> Meetings { get; set; } = new();

        public List<int> SessionCommitteesId { get; set; } = new();
        public List<SessionCommitteeModel> SessionCommittees { get; set; } = new();

        public List<int> SessionMeetingsId { get; set; } = new();
        public List<SessionMeetingModel> SessionMeetings { get; set; } = new();
    }
}

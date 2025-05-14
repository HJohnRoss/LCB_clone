namespace LCB_Clone_Backend.Models
{
    public class MemberVote
    {
        public required Legislator Legislator { get; set; }
        public string? Vote { get; set; }
    }

    public class FiscalNote
    {
        public required string Title { get; set; }
        public required string FiscalNotePath { get; set; }
    }

    public class Exhibit
    {
        public required LegislativeMeeting Meeting { get; set; }
        public required string ExhibitPath { get; set; }
    }




    public class Bill
    {
        public int Id { get; set; }
        public List<HearingRoomMeeting> PreviousMeetings { get; set; } = new List<HearingRoomMeeting>();
        public List<MemberVote> Votes { get; set; } = new List<MemberVote>();
        public List<FiscalNote> FiscalNotes { get; set; } = new List<FiscalNote>();
        public List<Exhibit> Exhibits { get; set; } = new List<Exhibit>();

        public List<Legislator> PrimarySponsors { get; set; } = new List<Legislator>();
        public List<Legislator> CoSponsors { get; set; } = new List<Legislator>();
    }
}

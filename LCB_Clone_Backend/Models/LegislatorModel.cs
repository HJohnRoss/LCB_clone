namespace LCB_Clone_Backend.Models
{
    public class LegislatorModel
    {
        public int Id { get; set; }

        // type
        public required bool IsSenator { get; set; }
        // Name, Title and Contact Info
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? LegislativeTitle { get; set; }
        public required string Email { get; set; }
        public required string CCPhone { get; set; }
        // Addresses and office locations
        public required string HomeAddress { get; set; }
        public required string LVOffice { get; set; }
        public required string CCOffice { get; set; }
        // Legislative Affiliations
        public required string Party { get; set; }
        public required string County { get; set; }
        public required string District { get; set; }
        public required string TermEnd { get; set; }
        // Committees and Bills worked on


        public List<string> LegislativeService { get; set; } = new();
        public List<string> OtherPublicService { get; set; } = new();
        public List<string> HonorsAwards { get; set; } = new();
        public List<string> OtherAchivements { get; set; } = new();
        public List<string> Affiliations { get; set; } = new();
        public List<string> Education { get; set; } = new();

        // Votes
        public List<int> VotesId { get; set; } = new();
        public List<LegislatorVoteModel> Votes { get; set; } = new();

        // Personal Info
        public required string Occupation { get; set; }
        public required string Recreation { get; set; }
        public required string Born { get; set; }
        public required string Spouse { get; set; }
        public required string Children { get; set; }

        public List<int> CommitteesId { get; set; } = new();
        public List<CommitteeModel> Committees { get; set; } = new();

        public List<int> PrimarySponsorBillsId { get; set; } = new();
        public List<BillModel> PrimarySponsorBills { get; set; } = new();

        public List<int> CoSponsorBillsId { get; set; } = new();
        public List<BillModel> CoSponsorBills { get; set; } = new();

        public List<int> LegislativeMeetingsId { get; set; } = new();
        public List<LegislativeMeetingModel> LegislativeMeetings { get; set; } = new();

        public List<int> SessionMeetingsId { get; set; } = new();
        public List<SessionMeetingModel> SessionMeetings { get; set; } = new();
    }
}

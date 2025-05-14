namespace LCB_Clone_Backend.Models
{
    public class LegislatorModel
    {
        public int Id { get; set; }

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
        public required List<CommitteeModel> Committees { get; set; } = new();
        public required List<BillModel> PrimarySponsorBills { get; set; } = new();
        public required List<BillModel> CoSponsorBills { get; set; } = new();
        public List<string> LegislativeService { get; set; } = new();
        public List<string> OtherPublicService { get; set; } = new();
        public List<string> HonorsAwards { get; set; } = new();
        public List<string> OtherAchivements { get; set; } = new();
        public List<string> Affiliations { get; set; } = new();
        public List<string> Education { get; set; } = new();
        // Personal Info
        public required string Occupation { get; set; }
        public required string Recreation { get; set; }
        public required string Born { get; set; }
        public required string Spouse { get; set; }
        public required string Children { get; set; }
    }
}

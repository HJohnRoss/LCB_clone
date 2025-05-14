namespace LCB_Clone_Backend.Models
{
    public class Legislator
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
        public List<Committee> Committees { get; set; } = new List<Committee>();
        public List<Bill> PrimarySponsorBills { get; set; } = new List<Bill>();
        public List<Bill> CoSponsorBills { get; set; } = new List<Bill>();

        // Career
        public List<string> LegislativeService { get; set; } = new List<string>();
        public List<string> OtherPublicService { get; set; } = new List<string>();
        public List<string> HonorsAwards { get; set; } = new List<string>();
        public List<string> OtherAchivements { get; set; } = new List<string>();
        public List<string> Affiliations { get; set; } = new List<string>();
        public List<string> Education { get; set; } = new List<string>();

        // Personal Info
        public required string Occupation { get; set; }
        public required string Recreation { get; set; }
        public required string Born { get; set; }
        public required string Spouse { get; set; }
        public required string Children { get; set; }
    }
}

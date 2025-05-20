namespace LCB_Clone_Backend.Models
{
    public class BillModel
    {
        public int Id { get; set; }

        public required string Summary { get; set; }
        public required DateTime IntroDate { get; set; }
        public required bool EffectLocalGov { get; set; }
        public required bool EffectState { get; set; }
        public required string Title { get; set; }
        public required string Digest { get; set; }

        public List<LegislativeMeetingModel> PreviousMeetings { get; set; } = new();

        public List<LegislatorVoteModel> Votes { get; set; } = new();

        public List<AmendmentModel> Amendments { get; set; } = new();

        public List<ExhibitModel> Exhibits { get; set; } = new();

        public List<LegislatorModel> PrimarySponsors { get; set; } = new();

        public List<LegislatorModel> CoSponsors { get; set; } = new();

        public List<FiscalNoteModel> FiscalNotes { get; set; } = new();

        public List<SessionCommitteeModel> SessionCommitteeSponsors { get; set; } = new();

        // needed for one to many
        public int? DiscussedByCommitteeId { get; set; }
        public SessionCommitteeModel? DiscussedByCommittee { get; set; }
    }
}

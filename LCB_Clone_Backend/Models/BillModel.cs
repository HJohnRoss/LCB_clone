namespace LCB_Clone_Backend.Models
{
    public class BillModel
    {
        public int Id { get; set; }

        public required List<LegislativeMeetingModel> PreviousMeetings { get; set; } = new();
        public required List<LegislatorVoteModel> Votes { get; set; } = new();
        public required List<AmendmentModel> Amendments { get; set; } = new();
        public required List<ExhibitModel> Exhibits { get; set; } = new();
        public required List<LegislatorModel> PrimarySponsors { get; set; } = new();
        public required List<LegislatorModel> CoSponsors { get; set; } = new();
        public AgendaModel? Agenda { get; set; }
        public List<FiscalNoteModel> FiscalNotes { get; set; } = new();

        public int? PrimarySponsoringSessionId { get; set; }
        public SessionMeetingModel? PrimarySponsoringSession { get; set; }

        public int? CoSponsoringSessionId { get; set; }
        public SessionMeetingModel? CoSponsoringSession { get; set; }
    }
}

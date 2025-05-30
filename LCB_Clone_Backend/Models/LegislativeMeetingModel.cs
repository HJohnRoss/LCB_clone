namespace LCB_Clone_Backend.Models
{
    public class LegislativeMeetingModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required string Name { get; set; }

        public string? YoutubeLink { get; set; }

        public string? CCRoomNumber { get; set; }

        public required bool IsCCMainRoom { get; set; }

        public string? LVRoomNumber { get; set; }

        public DateTime Datetime { get; set; }


        // NOTE: Joins
        // Many To Many
        // TODO: this
        public List<LegislatorModel> Members { get; set; } = new();

        // TODO: this
        // Many To Many
        public List<StaffMemberModel> Staff { get; set; } = new();

        // One To One
        public int? AgendaId { get; set; }
        public AgendaModel? Agenda { get; set; }

        // One To One
        public int? CommitteeId { get; set; }
        public CommitteeModel? Committee { get; set; }
    }
}

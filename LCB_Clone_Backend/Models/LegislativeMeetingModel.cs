namespace LCB_Clone_Backend.Models
{
    public class LegislativeMeetingModel
    {
        public int Id { get; set; }

        public required string House { get; set; }

        public required string MeetingName { get; set; }

        public string? YoutubeLink { get; set; }

        public string? CCRoomNumber { get; set; }

        public required bool IsCCMainRoom { get; set; }

        public string? LVRoomNumber { get; set; }

        public DateTime Datetime { get; set; }


        public List<LegislatorModel> LegislativeMembers { get; set; } = new();

        public List<StaffMemberModel> MeetingStaff { get; set; } = new();

        public int? AgendaId { get; set; }
        public AgendaModel? Agenda { get; set; }

        public int? CommitteeId { get; set; }
        public CommitteeModel? Committee { get; set; }
    }
}

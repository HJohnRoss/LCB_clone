namespace LCB_Clone_Backend.Models
{
    public class LegislatorVoteModel
    {
        public int Id { get; set; }
        public string? Vote { get; set; }

        public required BillModel Bill { get; set; }
    }
}

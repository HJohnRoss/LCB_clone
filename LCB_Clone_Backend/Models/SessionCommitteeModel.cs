namespace LCB_Clone_Backend.Models
{
    public class SessionCommitteeModel : CommitteeModel
    {
        public string? Mon { get; set; }

        public string? Tues { get; set; }

        public string? Wed { get; set; }

        public string? Thurs { get; set; }

        public string? Fri { get; set; }

        public List<BillModel> SponsoredBills { get; set; } = new();

        public List<BillModel> BillsDiscussed { get; set; } = new();
    }
}

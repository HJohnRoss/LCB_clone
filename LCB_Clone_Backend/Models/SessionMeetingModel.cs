namespace LCB_Clone_Backend.Models
{
    public class SessionMeetingModel : LegislativeMeetingModel
    {
        public List<BillModel> PrimarySponsoredBills { get; set; } = new();
        public List<BillModel> CoSponsoredBills { get; set; } = new();
    }
}

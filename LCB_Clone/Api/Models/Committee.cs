namespace Api.Models
{
    public class WeekSchedule
    {
        public string? Mon { get; set; }
        public string? Tues { get; set; }
        public string? Wed { get; set; }
        public string? Thurs { get; set; }
        public string? Fri { get; set; }

    }

    public class Committee
    {
        public required string House { get; set; }
        public WeekSchedule Schedule = new WeekSchedule();
        public List<Legislator> LegislativeMembers = new List<Legislator>();
        public List<Staff> StaffMembers = new List<Staff>();

        public List<LegislativeMeeting> Meetings = new List<LegislativeMeeting>();
        public List<Bill> SponsoredBills = new List<Bill>();
        public List<Bill> BillsDiscussed = new List<Bill>();
    }
}

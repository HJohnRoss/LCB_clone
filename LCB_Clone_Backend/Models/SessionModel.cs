namespace LCB_Clone_Backend.Models
{
    // TODO: all of this class
    public class SessionModel
    {
        public int Id { get; set; }

        // NOTE: All Items
        public List<BillModel> AllBills { get; set; } = new();

        // NOTE: Assembly Items
        public List<BillModel> AssemblyBills { get; set; } = new();

        // NOTE: Senete Items
    }
}

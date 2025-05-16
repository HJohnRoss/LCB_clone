namespace LCB_Clone_Backend.Models
{
    public class JournalModel
    {
        public int Id { get; set; }

        public required string LegislativeDay { get; set; }

        public required string FilePath { get; set; }

        public required string Date { get; set; }
    }
}

namespace LCB_Clone_Backend.Models
{
    public class JournalModel
    {
        public int Id { get; set; }
        public required string FilePath { get; set; }
        public required string DayNum { get; set; }
        public required bool IsSenate { get; set; }
    }
}

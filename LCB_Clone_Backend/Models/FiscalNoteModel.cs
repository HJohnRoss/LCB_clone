namespace LCB_Clone_Backend.Models
{
    public class FiscalNoteModel
    {
        public int Id { get; set; }
        public required string? FilePath { get; set; }
        // Optional metadata (expandable)
        public string? FileName { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public required BillModel Bill { get; set; }
    }
}

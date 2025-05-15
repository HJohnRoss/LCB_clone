namespace LCB_Clone_Backend.Models
{
    public class AgendaModel
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        // Optional metadata (expandable)
        public string? FileName { get; set; }
        public required BillModel Bills { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

namespace LCB_Clone_Backend.Models
{
    public class AmendmentModel
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        // Optional metadata (expandable)
        public string? FileName { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        // Foreign Keys
        public required BillModel Bill { get; set; }
    }
}

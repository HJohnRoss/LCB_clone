namespace LCB_Clone_Backend.Models
{
    public class FiscalNoteModel
    {
        public int Id { get; set; }
        public required string FilePath { get; set; }
        public required string FileName { get; set; }

        public int BillId { get; set; }
    }
}

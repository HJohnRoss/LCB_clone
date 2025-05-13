namespace LCB_Clone_Backend.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public required string Title { get; set; }
    }
}

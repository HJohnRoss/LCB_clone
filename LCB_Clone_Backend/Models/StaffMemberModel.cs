namespace LCB_Clone_Backend.Models
{
    public class StaffMemberModel
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public string? Title { get; set; }
    }
}

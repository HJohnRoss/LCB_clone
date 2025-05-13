using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCB_Clone_Backend.Models
{
    public class HearingRoomMeeting
    {
        public int Id { get; set; }
        public required string MeetingName { get; set; }
        public string? YoutubeLink { get; set; }
        public string? CCRoomNumber { get; set; }
        public required bool IsCCMainRoom { get; set; }
        public string? LVRoomNumber { get; set; }
        public required string Time { get; set; }
        public required string Date { get; set; }
        public string? Agenda { get; set; }
    }
}

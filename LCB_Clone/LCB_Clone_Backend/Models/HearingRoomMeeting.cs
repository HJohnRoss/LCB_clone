using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCB_Clone_Backend.Models
{
    public class HearingRoomMeeting
    {
        public int Id { get; set; }
        public string? MeetingName { get; set; }
        public string? YoutubeLink { get; set; }
        public string? CarsonCityRoomNumber { get; set; }
        public bool CarsonCityMainRoom { get; set; }
        public string? LasVegasRoomNumber { get; set; }
        public string? Time { get; set; }
        public string? Agenda { get; set; }
    }
}

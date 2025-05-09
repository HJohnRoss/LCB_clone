using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCB_Clone_Backend.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public List<HearingRoomMeeting> PreviousMeetings { get; set; } = new List<HearingRoomMeeting>();
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public List<FiscalNote> FiscalNotes { get; set; } = new List<FiscalNote>();
        public List<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
    }
}

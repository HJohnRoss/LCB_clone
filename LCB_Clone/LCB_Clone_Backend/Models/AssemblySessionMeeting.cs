using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCB_Clone_Backend.Models
{
    public class AssemblySessionMeeting : HearingRoomMeeting
    {
        public List<Bill> Bills { get; set; } = new List<Bill>();
        public List<Amendment> Ammendments { get; set; } = new List<Amendment>();
    }
}

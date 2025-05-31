using LCB_Clone_Backend.Service;

namespace Api.Controllers
{
    public class LegislativeMeetingStaffMemberController
    {
        private LegislativeMeetingStaffMemberService _service;

        public LegislativeMeetingStaffMemberController(LegislativeMeetingStaffMemberService service)
        {
            _service = service;
        }
    }
}

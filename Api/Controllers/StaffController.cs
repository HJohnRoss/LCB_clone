using Microsoft.AspNetCore.Mvc;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StaffMemberController : ControllerBase
    {
        private readonly StaffMemberModel _staffMember;

        public StaffMemberController(StaffMemberModel staffMember)
        {
            _staffMember = staffMember;
        }
    }
}

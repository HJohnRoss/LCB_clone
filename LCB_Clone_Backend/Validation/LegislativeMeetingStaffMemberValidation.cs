using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Data;

namespace LCB_Clone_Backend.Validation
{
    public class LegislativeMeetingStaffMemberValidation
    {
        private readonly LegislativeMeetingData _meetingData;
        private readonly StaffMemberData _staffMemberData;
        private readonly LegislativeMeetingStaffMemberData _legislativeMeetingStaffMemberData;

        public LegislativeMeetingStaffMemberValidation(
                LegislativeMeetingData meetingData,
                StaffMemberData staffMemberData,
                LegislativeMeetingStaffMemberData legislativeMeetingStaffMemberData
                )
        {
            _meetingData = meetingData;
            _staffMemberData = staffMemberData;
            _legislativeMeetingStaffMemberData = legislativeMeetingStaffMemberData;
        }

        public async Task Create(int meetingsId, int staffId)
        {
            StaffMemberModel staff = await _staffMemberData.GetOne(staffId)
                ?? throw new InvalidDataException("Legislator does not exist");
            LegislativeMeetingModel meeting = await _meetingData.GetOne(meetingsId)
                ?? throw new InvalidDataException("Legislative Meeting does not exist");

            foreach (int id in staff.MeetingsId)
            {
                if (id == meetingsId)
                {
                    throw new InvalidDataException("Already exists");
                }
            }
        }
    }
}

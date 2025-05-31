using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Validation;

namespace LCB_Clone_Backend.Services
{
    public class LegislativeMeetingLStaffMemberService
    {
        private readonly LegislativeMeetingData _meetingData;
        private readonly StaffMemberData _staffmemberData;
        private readonly LegislativeMeetingStaffMemberData _legislativeMeetingStaffMemberData;
        private readonly LegislativeMeetingStaffMemberValidation _legislativeMeetingStaffMemberValidation;

        public LegislativeMeetingLStaffMemberService(
                LegislativeMeetingData meetingData,
                StaffMemberData staffMemberData,
                LegislativeMeetingStaffMemberData legislativeMeetingStaffMemberData,
                LegislativeMeetingStaffMemberValidation legislativeMeetingStaffMemberValidation
                )
        {
            _meetingData = meetingData;
            _staffmemberData = staffMemberData;
            _legislativeMeetingStaffMemberData = legislativeMeetingStaffMemberData;
            _legislativeMeetingStaffMemberValidation = legislativeMeetingStaffMemberValidation;
        }

        public async Task Create(int meetingsId, int staffId)
        {
            await _legislativeMeetingStaffMemberValidation.Create(meetingsId, staffId);

            await _legislativeMeetingStaffMemberData.Create(meetingsId, staffId);
        }

        public async Task<List<StaffMemberModel>> GetLegislators(int meetingId)
        {
            return await _legislativeMeetingStaffMemberData.GetStaff(meetingId);
        }

        // Legislators
        public async Task UpdateStaff(int staffId, int meetingId)
        {
            await _legislativeMeetingStaffMemberData.UpdateStaff(staffId, meetingId);
        }

        public async Task DeleteStaff(int staffId)
        {
            await _legislativeMeetingStaffMemberData.DeleteLegislator(staffId);
        }

        // Legislative Meetings
        public async Task<List<LegislativeMeetingModel>> GetMeetings(int staffId)
        {
            return await _legislativeMeetingStaffMemberData.GetMeetings(staffId);
        }

        public async Task UpdateMeeting(int legislatorId, int meetingId)
        {
            await _legislativeMeetingLegislatorData.UpdateMeeting(legislatorId, meetingId);
        }

        public async Task DeleteMeeting(int meetingId)
        {
            await _legislativeMeetingLegislatorData.DeleteMeeting(meetingId);
        }
    }
}

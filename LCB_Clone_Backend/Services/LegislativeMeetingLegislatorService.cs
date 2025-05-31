using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Validation;

namespace LCB_Clone_Backend.Services
{
    public class LegislativeMeetingLegislatorService
    {
        private readonly LegislativeMeetingData _meetingData;
        private readonly LegislatorData _legislatorData;
        private readonly LegislativeMeetingLegislatorData _legislativeMeetingLegislatorData;
        private readonly LegislativeMeetingLegislatorValidation _legislativeMeetingLegislatorValidation;

        public LegislativeMeetingLegislatorService(
                LegislativeMeetingData meetingData,
                LegislatorData legislatorData,
                LegislativeMeetingLegislatorData legislativeMeetingLegislatorData,
                LegislativeMeetingLegislatorValidation legislativeMeetingLegislatorValidation
                )
        {
            _meetingData = meetingData;
            _legislatorData = legislatorData;
            _legislativeMeetingLegislatorData = legislativeMeetingLegislatorData;
            _legislativeMeetingLegislatorValidation = legislativeMeetingLegislatorValidation;
        }

        public async Task Create(int meetingsId, int membersId)
        {
            await _legislativeMeetingLegislatorValidation.Create(meetingsId, membersId);

            await _legislativeMeetingLegislatorData.Create(meetingsId, membersId);
        }

        public async Task<List<LegislatorModel>> GetLegislators(int meetingId)
        {
            return await _legislativeMeetingLegislatorData.GetLegislators(meetingId);
        }

        // Legislators
        public async Task UpdateLegislator(int legislatorId, int meetingId)
        {
            await _legislativeMeetingLegislatorData.UpdateLegislator(legislatorId, meetingId);
        }

        public async Task DeleteLegislator(int legislatorId)
        {
            await _legislativeMeetingLegislatorData.DeleteLegislator(legislatorId);
        }

        // Legislative Meetings
        public async Task<List<LegislativeMeetingModel>> GetMeetings(int legislatorId)
        {
            return await _legislativeMeetingLegislatorData.GetMeetings(legislatorId);
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

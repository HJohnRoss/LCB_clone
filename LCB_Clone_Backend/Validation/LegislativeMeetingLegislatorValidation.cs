using LCB_Clone_Backend.Models;
using LCB_Clone_Backend.Data;

namespace LCB_Clone_Backend.Validation
{
    public class LegislativeMeetingLegislatorValidation
    {
        private readonly LegislativeMeetingData _meetingData;
        private readonly LegislatorData _legislatorData;
        private readonly LegislativeMeetingLegislatorData _legislativeMeetingLegislatorData;

        public LegislativeMeetingLegislatorValidation(
                LegislativeMeetingData meetingData,
                LegislatorData legislatorData,
                LegislativeMeetingLegislatorData legislativeMeetingLegislatorData
                )
        {
            _meetingData = meetingData;
            _legislatorData = legislatorData;
            _legislativeMeetingLegislatorData = legislativeMeetingLegislatorData;
        }

        public async Task Create(int meetingsId, int membersId)
        {
            LegislatorModel legislator = await _legislatorData.GetOne(membersId)
                ?? throw new InvalidDataException("Legislator does not exist");
            LegislativeMeetingModel meeting = await _meetingData.GetOne(meetingsId)
                ?? throw new InvalidDataException("Legislative Meeting does not exist");

            foreach (int id in legislator.LegislativeMeetingsId)
            {
                if (id == meetingsId)
                {
                    throw new InvalidDataException("Already exists");
                }
            }
        }
    }
}


// TODO: Do the helper function in the class
using LCB_Clone_Backend.Data;
using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Services
{
    public class BillService
    {
        private readonly BillData _billData;

        public BillService(BillData billData)
        {
            _billData = billData;
        }

        public async Task<List<BillModel>> GetAll()
        {
            return await _billData.GetAll();
        }

        public async Task<BillModel> GetOne(int id)
        {
            return await _billData.GetOne(id);
        }

        // TODO: This is bugged for a fact
        public async Task Create(
                string summary,
                DateTime introDate,
                bool effectLocalGov,
                bool effectState,
                string title,
                string digest,
                int? discussedByCommitteeId = null,
                int? sessionMeetingModelId = null,
                int? sessionModelId = null
                )
        {
            // NOTE: Validating queries
            await _billData.Create(
                        summary,
                        introDate,
                        effectLocalGov,
                        effectState,
                        title,
                        digest,
                        discussedByCommitteeId,
                        sessionMeetingModelId,
                        sessionModelId
                    );
        }

        public async Task Delete(int id)
        {
            await _billData.Delete(id);
        }

        public async Task Update(
                int id,
                string? summary = null,
                DateTime? introDate = null,
                bool? effectLocalGov = null,
                bool? effectState = null,
                string? title = null,
                string? digest = null,
                int? agendaId = null,
                int? discussedByCommitteeId = null,
                int? sessionMeetingModelId = null,
                int? sessionModelId = null
                )
        {
            await _billData.Update(
                        id,
                        summary,
                        introDate,
                        effectLocalGov,
                        effectState,
                        title,
                        digest,
                        agendaId,
                        discussedByCommitteeId,
                        sessionMeetingModelId,
                        sessionModelId
                    );
        }
    }
}

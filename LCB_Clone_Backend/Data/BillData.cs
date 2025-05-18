using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class BillData
    {
        private readonly SqlDataAccess _db;

        public BillData(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<BillModel>> GetAll()
        {
            string query = @"
                SELECT *
                FROM Bills
            ";
            List<BillModel> result = await _db.LoadData<BillModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Bills Get All null");

            foreach (BillModel bill in result)
            {
                await GatherBillData(bill);
            }
            return result;
        }

        public async Task<BillModel> GetOne(int id)
        {
            string query = @"
                SELECT * FROM Bills
                WHERE Id = @id;
            ";

            List<BillModel> results = await _db.LoadData<BillModel, dynamic>(query, new { id })
                ?? throw new InvalidDataException("Bill Get One is null");

            BillModel bill = results.FirstOrDefault()
                ?? throw new InvalidDataException($"Bill Id: {id} is null");

            return await GatherBillData(bill);
        }

        public async Task<BillModel> GatherBillData(BillModel bill)
        {
            // Previous Meetings
            string query = @"
                    SELECT * FROM LegislativeMeetings
                    WHERE BillId = @BillId;
                    ";
            bill.PreviousMeetings = await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("PreviousMeetings Join is null");

            // Votes
            query = @"
                    SELECT * FROM LegislatorVotes
                    WHERE BillId = @BillId;
                    ";
            bill.Votes = await _db.LoadData<LegislatorVoteModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("PreviousMeetings query is null");

            // Amendments
            query = @"
                    SELECT * FROM Amendments
                    WHERE BillId = @BillId;
                ";
            bill.Amendments = await _db.LoadData<AmendmentModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Amendments query is null");

            // Exhibits
            query = @"
                    SELECT * FROM Exhibits
                    WHERE BillId = @BillId;
                ";
            bill.Exhibits = await _db.LoadData<ExhibitModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Exhibits query is null");

            // Primary Sponsors
            query = @"
                    SELECT l.* FROM Legislators l
                    INNER JOIN BillLegislatorPrimarySponsor bpls 
                    ON l.Id = bpls.LegislatorId
                    WHERE bpls.BillId = @BillId;
                ";
            bill.PrimarySponsors = await _db.LoadData<LegislatorModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Primary Sponsors query is null");

            // Co Sponsors
            query = @"
                    SELECT l.* FROM Legislators l
                    INNER JOIN BillLegislatorCoSponsor blcs
                    ON l.Id = blcs.LegislatorId
                    WHERE blcs.BillId = @BillId;
                ";
            bill.CoSponsors = await _db.LoadData<LegislatorModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Co Sponsors query is null");

            // Agenda
            query = @"
                    SELECT * FROM Agenda
                    WHERE BillId = @BillId;
                ";
            List<AgendaModel> agendas = await _db.LoadData<AgendaModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Agenda query is null");
            bill.Agenda = agendas.FirstOrDefault()
                ?? throw new InvalidDataException("Agendas List was null");

            // Fiscal Notes
            query = @"
                    SELECT * FROM FiscalNotes
                    WHERE BillId = @BillId;
                ";
            bill.FiscalNotes = await _db.LoadData<FiscalNoteModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Fiscal Notes query is null");

            // Sponsor Session Committee
            query = @"
                    SELECT sc.* FROM SessionCommittees sc
                    INNER JOIN BillSessionCommitteeSponsor bscs
                    ON sc.Id = bscs.SessionCommitteeId
                    WHERE bscs.BillId = @BillId;
                ";
            bill.SessionCommitteeSponsors = await _db.LoadData<SessionCommitteeModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Session Committee Sponsor query is null");

            // Discussed By Committee
            query = @"
                    SELECT * FROM SessionCommittees
                    WHERE Id = @DiscussedByCommitteeId;
                ";
            List<SessionCommitteeModel> sessionCommittees = await _db.LoadData<SessionCommitteeModel, dynamic>(
                    query,
                    new
                    {
                        DiscussedByCommitteeId = bill.DiscussedByCommitteeId
                    })
                ?? throw new InvalidDataException("Discussed By Committee query is null");
            if (sessionCommittees.FirstOrDefault() == null)
            {
                throw new InvalidDataException("Disccussed by committees index is null");
            }
            bill.DiscussedByCommittee = sessionCommittees.FirstOrDefault();

            return bill;
        }
    }
}

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

        public async Task Create(
                string summary,
                DateTime introDate,
                bool effectLocalGov,
                bool effectState,
                string title,
                string digest
                )
        {

            string query = @"
                INSERT INTO Bills (Summary, IntroDate, EffectLocalGov, EffectState, Title, Digest)
                VALUES (@summary, @introDate, @effectLocalGov, @effectState, @title, @digest);
            ";

            await _db.SaveData(query, new { summary, introDate, effectLocalGov, effectState, title, digest });
        }

        public async Task Delete(int id)
        {
            string query = @"
                DELETE FROM Bills
                WHERE Id = @Id
            ";
            await _db.SaveData(query, new { Id = id });
        }

        //TODO:
        // public async Task Update(int id)
        // {
        // }

        // helper function to get all bill data
        public async Task<BillModel> GatherBillData(BillModel bill)
        {
            // Previous Meetings
            string query = @"
                    SELECT * FROM LegislativeMeetings
                    WHERE BillId = @BillId;
                    ";
            bill.PreviousMeetings = await _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("PreviousMeetings query is null");

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
                    ON bpls.LegislatorId = l.Id
                    WHERE bpls.BillId = @BillId;
                ";
            bill.PrimarySponsors = await _db.LoadData<LegislatorModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Primary Sponsors query is null");

            // Co Sponsors
            query = @"
                    SELECT l.* FROM Legislators l
                    INNER JOIN BillLegislatorCoSponsor blcs
                    ON blcs.LegislatorId = l.Id
                    WHERE blcs.BillId = @BillId;
                ";
            bill.CoSponsors = await _db.LoadData<LegislatorModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Co Sponsors query is null");

            // Agenda
            query = @"
                    SELECT * FROM Agendas
                    WHERE BillId = @BillId;
                ";
            List<AgendaModel> agendas = await _db.LoadData<AgendaModel, dynamic>(query, new { BillId = bill.Id });
            // ?? throw new InvalidDataException("Agenda query is null");
            if (agendas != null)
            {
                bill.Agenda = agendas.FirstOrDefault();
            }
            // ?? throw new InvalidDataException("Agendas List was null");

            // Fiscal Notes
            query = @"
                    SELECT * FROM FiscalNotes
                    WHERE BillId = @BillId;
                ";
            bill.FiscalNotes = await _db.LoadData<FiscalNoteModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Fiscal Notes query is null");

            // Sponsor Session Committee
            // NOTE: Might want to change to a one to many at a later date
            // Note sure if this is useful or not
            query = @"
                    SELECT sc.* FROM SessionCommittees sc
                    INNER JOIN BillSessionCommitteeSponsor bscs
                    ON sc.Id = bscs.SessionCommitteeId
                    WHERE bscs.BillId = @BillId;
                ";
            bill.SessionCommitteeSponsors = await _db.LoadData<SessionCommitteeModel, dynamic>(query, new { BillId = bill.Id })
                ?? throw new InvalidDataException("Session Committee Sponsor query is null");

            // Discussed By Committee
            // NOTE: Might want to change to a one to many at a later date
            // Note sure if this is useful or not
            query = @"
                    SELECT * FROM SessionCommittees
                    WHERE Id = @DiscussedByCommitteeId;
                ";
            List<SessionCommitteeModel> sessionCommittees = await
                _db.LoadData<SessionCommitteeModel, dynamic>(
                        query, new { DiscussedByCommitteeId = bill.DiscussedByCommitteeId }
                        );
            if (sessionCommittees != null)
            {
                bill.DiscussedByCommittee = sessionCommittees.FirstOrDefault();
            }

            return bill;
        }
    }
}

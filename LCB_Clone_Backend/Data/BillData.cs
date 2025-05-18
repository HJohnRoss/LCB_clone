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

        public List<BillModel> GetAll()
        {
            string query = @"
                SELECT *
                FROM Bills
            ";
            List<BillModel> result = _db.LoadData<BillModel, dynamic>(query, new { })
                ?? throw new InvalidDataException("Bills Get All null");

            foreach (BillModel bill in result)
            {
                query = @"
                    SELECT * FROM LegislativeMeetings
                    WHERE BillId = @BillId;
                    ";
                bill.PreviousMeetings = _db.LoadData<LegislativeMeetingModel, dynamic>(query, new { BillId = bill.Id })
                    ?? throw new InvalidDataException("PreviousMeetings Join is null");

                query = @"
                    SELECT * FROM LegislatorVotes
                    WHERE BillId = @BillId;
                    ";
                bill.Votes = _db.LoadData<LegislatorVoteModel, dynamic>(query, new { BillId = bill.Id })
                    ?? throw new InvalidDataException("PreviousMeetings Join is null");
                // TODO: Pickup joins 
                // NOTE: make sure to add ";" at the end
                //       This may cause an issue if i leave ; at the and of every select if i see the error
            }
            return result;
        }
    }
}

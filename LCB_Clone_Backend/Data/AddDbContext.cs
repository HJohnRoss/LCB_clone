using Microsoft.EntityFrameworkCore;
using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Creating Sql Tables
        public DbSet<AgendaModel> Agendas => Set<AgendaModel>();
        public DbSet<AmendmentModel> Amendments => Set<AmendmentModel>();
        public DbSet<BillModel> Bills => Set<BillModel>();
        public DbSet<BudgetModel> Budgets => Set<BudgetModel>();
        public DbSet<CommitteeModel> Committees => Set<CommitteeModel>();
        public DbSet<ExhibitModel> Exhibits => Set<ExhibitModel>();
        public DbSet<FiscalNoteModel> FiscalNotes => Set<FiscalNoteModel>();
        public DbSet<HearingRoomMeetingModel> HearingRoomMeetings => Set<HearingRoomMeetingModel>();
        public DbSet<JournalModel> Journals => Set<JournalModel>();
        public DbSet<LegislativeMeetingModel> LegislativeMeetings => Set<LegislativeMeetingModel>();
        public DbSet<LegislatorModel> Legislators => Set<LegislatorModel>();
        public DbSet<LegislatorVoteModel> LegislatorVotes => Set<LegislatorVoteModel>();
        public DbSet<SessionCommitteeModel> SessionCommittees => Set<SessionCommitteeModel>();
        public DbSet<SessionMeetingModel> SessionMeetings => Set<SessionMeetingModel>();
        public DbSet<SessionModel> Sessions => Set<SessionModel>();
        public DbSet<StaffMemberModel> StaffMembers => Set<StaffMemberModel>();
        public DbSet<WorkSessionDocModel> WorkSessions => Set<WorkSessionDocModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BillSetup(modelBuilder);
        }

        public void BillSetup(ModelBuilder modelBuilder)
        {

            // Define a many-to-many relationship between BillModel and LegislatorModel
            // This is creating a table
            modelBuilder.Entity<BillModel>()
                .HasMany(b => b.PrimarySponsors) // Bill has many CoSponsors
                .WithMany(l => l.PrimarySponsorBills) // Legislator has many Bills they co-sponsor
                .UsingEntity<Dictionary<string, object>>(
                    "BillLegislatorPrimarySponsor", // Join table name
                    j => j.HasOne<LegislatorModel>().WithMany().HasForeignKey("LegislatorId"),
                    j => j.HasOne<BillModel>().WithMany().HasForeignKey("BillId")
                );

            modelBuilder.Entity<BillModel>()
                .HasMany(b => b.CoSponsors)
                .WithMany(l => l.CoSponsorBills)
                .UsingEntity<Dictionary<string, object>>(
                        "BillLegislatorCoSponsor",
                        j => j.HasOne<LegislatorModel>().WithMany().HasForeignKey("LegislatorId"),
                        j => j.HasOne<BillModel>().WithMany().HasForeignKey("BillId")
                    );

            // Sponsored Relationship
            modelBuilder.Entity<BillModel>()
                .HasMany(b => b.SessionCommitteeSponsors)
                .WithMany(sc => sc.SponsoredBills)
                .UsingEntity<Dictionary<string, object>>(
                    "BillSessionCommitteeSponsor",
                    j => j.HasOne<SessionCommitteeModel>().WithMany().HasForeignKey("SessionCommitteeId"),
                    j => j.HasOne<BillModel>().WithMany().HasForeignKey("BillId")
                );

            // Creates One 2 many between Bills and Session Committee
            // NOTE:
            // This is needed because I have multiple instances of BillModels in SessionCommittees Table
            modelBuilder.Entity<BillModel>()
                .HasOne(b => b.DiscussedByCommittee)
                .WithMany(sc => sc.BillsDiscussed)
                .HasForeignKey(b => b.DiscussedByCommitteeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

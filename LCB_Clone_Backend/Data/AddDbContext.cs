using Microsoft.EntityFrameworkCore;
using LCB_Clone_Backend.Models;

namespace LCB_Clone_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AgendaModel> Agenda => Set<AgendaModel>();
        public DbSet<AmendmentModel> Amendments => Set<AmendmentModel>();
        public DbSet<BillModel> Bills => Set<BillModel>();
        public DbSet<CommitteeModel> Committees => Set<CommitteeModel>();
        public DbSet<ExhibitModel> Exhibits => Set<ExhibitModel>();
        public DbSet<FiscalNoteModel> FiscalNotes => Set<FiscalNoteModel>();
        public DbSet<HearingRoomMeetingModel> HearingRoomMeetings => Set<HearingRoomMeetingModel>();
        public DbSet<LegislativeMeetingModel> LegislativeMeetings => Set<LegislativeMeetingModel>();
        public DbSet<LegislatorModel> Legislators => Set<LegislatorModel>();
        public DbSet<StaffMemberModel> StaffMembers => Set<StaffMemberModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define a many-to-many relationship between BillModel and LegislatorModel
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
        }
    }
}

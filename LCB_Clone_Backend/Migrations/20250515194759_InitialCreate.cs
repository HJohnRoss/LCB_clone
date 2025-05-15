using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCB_Clone_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    BillsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Bills_BillsId",
                        column: x => x.BillsId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amendments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amendments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amendments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibits_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiscalNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalNotes_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HearingRoomMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetingName = table.Column<string>(type: "TEXT", nullable: false),
                    YoutubeLink = table.Column<string>(type: "TEXT", nullable: true),
                    CCRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IsCCMainRoom = table.Column<bool>(type: "INTEGER", nullable: false),
                    LVRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    AgendaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearingRoomMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HearingRoomMeetings_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegislativeMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    House = table.Column<string>(type: "TEXT", nullable: false),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegislativeMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegislativeMeetings_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegislativeMeetings_HearingRoomMeetings_Id",
                        column: x => x.Id,
                        principalTable: "HearingRoomMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Legislators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    LegislativeTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CCPhone = table.Column<string>(type: "TEXT", nullable: false),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: false),
                    LVOffice = table.Column<string>(type: "TEXT", nullable: false),
                    CCOffice = table.Column<string>(type: "TEXT", nullable: false),
                    Party = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    District = table.Column<string>(type: "TEXT", nullable: false),
                    TermEnd = table.Column<string>(type: "TEXT", nullable: false),
                    LegislativeService = table.Column<string>(type: "TEXT", nullable: false),
                    OtherPublicService = table.Column<string>(type: "TEXT", nullable: false),
                    HonorsAwards = table.Column<string>(type: "TEXT", nullable: false),
                    OtherAchivements = table.Column<string>(type: "TEXT", nullable: false),
                    Affiliations = table.Column<string>(type: "TEXT", nullable: false),
                    Education = table.Column<string>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: false),
                    Recreation = table.Column<string>(type: "TEXT", nullable: false),
                    Born = table.Column<string>(type: "TEXT", nullable: false),
                    Spouse = table.Column<string>(type: "TEXT", nullable: false),
                    Children = table.Column<string>(type: "TEXT", nullable: false),
                    LegislativeMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legislators_LegislativeMeetings_LegislativeMeetingModelId",
                        column: x => x.LegislativeMeetingModelId,
                        principalTable: "LegislativeMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleInitial = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LegislativeMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_LegislativeMeetings_LegislativeMeetingModelId",
                        column: x => x.LegislativeMeetingModelId,
                        principalTable: "LegislativeMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillLegislatorCoSponsor",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    LegislatorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLegislatorCoSponsor", x => new { x.BillId, x.LegislatorId });
                    table.ForeignKey(
                        name: "FK_BillLegislatorCoSponsor_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLegislatorCoSponsor_Legislators_LegislatorId",
                        column: x => x.LegislatorId,
                        principalTable: "Legislators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillLegislatorPrimarySponsor",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    LegislatorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLegislatorPrimarySponsor", x => new { x.BillId, x.LegislatorId });
                    table.ForeignKey(
                        name: "FK_BillLegislatorPrimarySponsor_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLegislatorPrimarySponsor_Legislators_LegislatorId",
                        column: x => x.LegislatorId,
                        principalTable: "Legislators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    House = table.Column<string>(type: "TEXT", nullable: false),
                    Mon = table.Column<string>(type: "TEXT", nullable: true),
                    Tues = table.Column<string>(type: "TEXT", nullable: true),
                    Wed = table.Column<string>(type: "TEXT", nullable: true),
                    Thurs = table.Column<string>(type: "TEXT", nullable: true),
                    Fri = table.Column<string>(type: "TEXT", nullable: true),
                    LegislatorModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Committees_Legislators_LegislatorModelId",
                        column: x => x.LegislatorModelId,
                        principalTable: "Legislators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegislatorVoteModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vote = table.Column<string>(type: "TEXT", nullable: true),
                    LegislatorId = table.Column<int>(type: "INTEGER", nullable: true),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegislatorVoteModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegislatorVoteModel_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegislatorVoteModel_Legislators_LegislatorId",
                        column: x => x.LegislatorId,
                        principalTable: "Legislators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_BillsId",
                table: "Agendas",
                column: "BillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendments_BillId",
                table: "Amendments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLegislatorCoSponsor_LegislatorId",
                table: "BillLegislatorCoSponsor",
                column: "LegislatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLegislatorPrimarySponsor_LegislatorId",
                table: "BillLegislatorPrimarySponsor",
                column: "LegislatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_LegislatorModelId",
                table: "Committees",
                column: "LegislatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_BillId",
                table: "Exhibits",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalNotes_BillId",
                table: "FiscalNotes",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_HearingRoomMeetings_AgendaId",
                table: "HearingRoomMeetings",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislativeMeetings_BillModelId",
                table: "LegislativeMeetings",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Legislators_LegislativeMeetingModelId",
                table: "Legislators",
                column: "LegislativeMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislatorVoteModel_BillModelId",
                table: "LegislatorVoteModel",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislatorVoteModel_LegislatorId",
                table: "LegislatorVoteModel",
                column: "LegislatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_LegislativeMeetingModelId",
                table: "StaffMembers",
                column: "LegislativeMeetingModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amendments");

            migrationBuilder.DropTable(
                name: "BillLegislatorCoSponsor");

            migrationBuilder.DropTable(
                name: "BillLegislatorPrimarySponsor");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "FiscalNotes");

            migrationBuilder.DropTable(
                name: "LegislatorVoteModel");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "Legislators");

            migrationBuilder.DropTable(
                name: "LegislativeMeetings");

            migrationBuilder.DropTable(
                name: "HearingRoomMeetings");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}

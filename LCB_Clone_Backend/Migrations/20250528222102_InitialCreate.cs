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
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    House = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    DayNum = table.Column<string>(type: "TEXT", nullable: false),
                    IsSenate = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    House = table.Column<string>(type: "TEXT", nullable: false),
                    Mon = table.Column<string>(type: "TEXT", nullable: true),
                    Tues = table.Column<string>(type: "TEXT", nullable: true),
                    Wed = table.Column<string>(type: "TEXT", nullable: true),
                    Thurs = table.Column<string>(type: "TEXT", nullable: true),
                    Fri = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessionDayCalendar = table.Column<string>(type: "TEXT", nullable: true),
                    ProposedExecutiveBudgetPath = table.Column<string>(type: "TEXT", nullable: true),
                    CapitalImprovementPath = table.Column<string>(type: "TEXT", nullable: true),
                    FiscalReportPath = table.Column<string>(type: "TEXT", nullable: true),
                    UserManualPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
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
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AgendaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearingRoomMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HearingRoomMeetings_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegislativeMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    House = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingName = table.Column<string>(type: "TEXT", nullable: false),
                    YoutubeLink = table.Column<string>(type: "TEXT", nullable: true),
                    CCRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IsCCMainRoom = table.Column<bool>(type: "INTEGER", nullable: false),
                    LVRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Datetime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AgendaId = table.Column<int>(type: "INTEGER", nullable: true),
                    CommitteeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegislativeMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegislativeMeetings_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegislativeMeetings_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    IntroDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EffectLocalGov = table.Column<bool>(type: "INTEGER", nullable: false),
                    EffectState = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Digest = table.Column<string>(type: "TEXT", nullable: false),
                    DiscussedByCommitteeId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_SessionCommittees_DiscussedByCommitteeId",
                        column: x => x.DiscussedByCommitteeId,
                        principalTable: "SessionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_Sessions_SessionModelId",
                        column: x => x.SessionModelId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinutesPath = table.Column<string>(type: "TEXT", nullable: true),
                    House = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingName = table.Column<string>(type: "TEXT", nullable: false),
                    YoutubeLink = table.Column<string>(type: "TEXT", nullable: true),
                    CCRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IsCCMainRoom = table.Column<bool>(type: "INTEGER", nullable: false),
                    LVRoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AgendaId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionMeetings_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionMeetings_Sessions_SessionModelId",
                        column: x => x.SessionModelId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Amendments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amendments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amendments_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillSessionCommitteeSponsor",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionCommitteeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSessionCommitteeSponsor", x => new { x.BillId, x.SessionCommitteeId });
                    table.ForeignKey(
                        name: "FK_BillSessionCommitteeSponsor_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillSessionCommitteeSponsor_SessionCommittees_SessionCommitteeId",
                        column: x => x.SessionCommitteeId,
                        principalTable: "SessionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiscalNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalNotes_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillModelSessionMeetingModel",
                columns: table => new
                {
                    BillsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PreviousMeetingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillModelSessionMeetingModel", x => new { x.BillsId, x.PreviousMeetingsId });
                    table.ForeignKey(
                        name: "FK_BillModelSessionMeetingModel_Bills_BillsId",
                        column: x => x.BillsId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillModelSessionMeetingModel_SessionMeetings_PreviousMeetingsId",
                        column: x => x.PreviousMeetingsId,
                        principalTable: "SessionMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentNum = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false),
                    AgencyNum = table.Column<int>(type: "INTEGER", nullable: false),
                    AgencyName = table.Column<string>(type: "TEXT", nullable: false),
                    FunctionNum = table.Column<int>(type: "INTEGER", nullable: false),
                    FunctionName = table.Column<string>(type: "TEXT", nullable: false),
                    SubFunctionNum = table.Column<int>(type: "INTEGER", nullable: false),
                    SubFunctionName = table.Column<string>(type: "TEXT", nullable: false),
                    BudgetName = table.Column<string>(type: "TEXT", nullable: false),
                    FundNum = table.Column<int>(type: "INTEGER", nullable: false),
                    BudgetNum = table.Column<int>(type: "INTEGER", nullable: false),
                    ExecBudgetPage = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: true),
                    TextFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    SessionMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_SessionMeetings_SessionMeetingModelId",
                        column: x => x.SessionMeetingModelId,
                        principalTable: "SessionMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Legislators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsSenator = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    LegislativeMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionCommitteeModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legislators_LegislativeMeetings_LegislativeMeetingModelId",
                        column: x => x.LegislativeMeetingModelId,
                        principalTable: "LegislativeMeetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Legislators_SessionCommittees_SessionCommitteeModelId",
                        column: x => x.SessionCommitteeModelId,
                        principalTable: "SessionCommittees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Legislators_SessionMeetings_SessionMeetingModelId",
                        column: x => x.SessionMeetingModelId,
                        principalTable: "SessionMeetings",
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
                    CommitteeModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    LegislativeMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionCommitteeModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    SessionMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Committees_CommitteeModelId",
                        column: x => x.CommitteeModelId,
                        principalTable: "Committees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffMembers_LegislativeMeetings_LegislativeMeetingModelId",
                        column: x => x.LegislativeMeetingModelId,
                        principalTable: "LegislativeMeetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffMembers_SessionCommittees_SessionCommitteeModelId",
                        column: x => x.SessionCommitteeModelId,
                        principalTable: "SessionCommittees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffMembers_SessionMeetings_SessionMeetingModelId",
                        column: x => x.SessionMeetingModelId,
                        principalTable: "SessionMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    SessionMeetingModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSessions_SessionMeetings_SessionMeetingModelId",
                        column: x => x.SessionMeetingModelId,
                        principalTable: "SessionMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetModelSessionModel",
                columns: table => new
                {
                    BudgetsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeetingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetModelSessionModel", x => new { x.BudgetsId, x.MeetingsId });
                    table.ForeignKey(
                        name: "FK_BudgetModelSessionModel_Budgets_BudgetsId",
                        column: x => x.BudgetsId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetModelSessionModel_Sessions_MeetingsId",
                        column: x => x.MeetingsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    BudgetModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibits_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exhibits_Budgets_BudgetModelId",
                        column: x => x.BudgetModelId,
                        principalTable: "Budgets",
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
                name: "CommitteeModelLegislatorModel",
                columns: table => new
                {
                    CommitteesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LegislativeMembersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeModelLegislatorModel", x => new { x.CommitteesId, x.LegislativeMembersId });
                    table.ForeignKey(
                        name: "FK_CommitteeModelLegislatorModel_Committees_CommitteesId",
                        column: x => x.CommitteesId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommitteeModelLegislatorModel_Legislators_LegislativeMembersId",
                        column: x => x.LegislativeMembersId,
                        principalTable: "Legislators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegislatorVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vote = table.Column<string>(type: "TEXT", nullable: true),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    LegislatorModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegislatorVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegislatorVotes_Bills_BillModelId",
                        column: x => x.BillModelId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegislatorVotes_Legislators_LegislatorModelId",
                        column: x => x.LegislatorModelId,
                        principalTable: "Legislators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amendments_BillModelId",
                table: "Amendments",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLegislatorCoSponsor_LegislatorId",
                table: "BillLegislatorCoSponsor",
                column: "LegislatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLegislatorPrimarySponsor_LegislatorId",
                table: "BillLegislatorPrimarySponsor",
                column: "LegislatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillModelSessionMeetingModel_PreviousMeetingsId",
                table: "BillModelSessionMeetingModel",
                column: "PreviousMeetingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DiscussedByCommitteeId",
                table: "Bills",
                column: "DiscussedByCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_SessionModelId",
                table: "Bills",
                column: "SessionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSessionCommitteeSponsor_SessionCommitteeId",
                table: "BillSessionCommitteeSponsor",
                column: "SessionCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetModelSessionModel_MeetingsId",
                table: "BudgetModelSessionModel",
                column: "MeetingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_SessionMeetingModelId",
                table: "Budgets",
                column: "SessionMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeModelLegislatorModel_LegislativeMembersId",
                table: "CommitteeModelLegislatorModel",
                column: "LegislativeMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_BillModelId",
                table: "Exhibits",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_BudgetModelId",
                table: "Exhibits",
                column: "BudgetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalNotes_BillModelId",
                table: "FiscalNotes",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HearingRoomMeetings_AgendaId",
                table: "HearingRoomMeetings",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislativeMeetings_AgendaId",
                table: "LegislativeMeetings",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislativeMeetings_CommitteeId",
                table: "LegislativeMeetings",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Legislators_LegislativeMeetingModelId",
                table: "Legislators",
                column: "LegislativeMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Legislators_SessionCommitteeModelId",
                table: "Legislators",
                column: "SessionCommitteeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Legislators_SessionMeetingModelId",
                table: "Legislators",
                column: "SessionMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislatorVotes_BillModelId",
                table: "LegislatorVotes",
                column: "BillModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LegislatorVotes_LegislatorModelId",
                table: "LegislatorVotes",
                column: "LegislatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionMeetings_AgendaId",
                table: "SessionMeetings",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionMeetings_SessionModelId",
                table: "SessionMeetings",
                column: "SessionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_CommitteeModelId",
                table: "StaffMembers",
                column: "CommitteeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_LegislativeMeetingModelId",
                table: "StaffMembers",
                column: "LegislativeMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_SessionCommitteeModelId",
                table: "StaffMembers",
                column: "SessionCommitteeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_SessionMeetingModelId",
                table: "StaffMembers",
                column: "SessionMeetingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_SessionMeetingModelId",
                table: "WorkSessions",
                column: "SessionMeetingModelId");
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
                name: "BillModelSessionMeetingModel");

            migrationBuilder.DropTable(
                name: "BillSessionCommitteeSponsor");

            migrationBuilder.DropTable(
                name: "BudgetModelSessionModel");

            migrationBuilder.DropTable(
                name: "CommitteeModelLegislatorModel");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "FiscalNotes");

            migrationBuilder.DropTable(
                name: "HearingRoomMeetings");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "LegislatorVotes");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "WorkSessions");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Legislators");

            migrationBuilder.DropTable(
                name: "LegislativeMeetings");

            migrationBuilder.DropTable(
                name: "SessionCommittees");

            migrationBuilder.DropTable(
                name: "SessionMeetings");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}

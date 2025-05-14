-- Config
PRAGMA foreign_keys = ON;

-- Creating Core Tables
CREATE TABLE Legislator (
    Id INTEGER PRIMARY KEY,

    -- Name, Title and Contact Info
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    LegislativeTitle TEXT,
    Email TEXT NOT NULL,
    CCPhone TEXT NOT NULL,

    -- Addresses and office locations
    HomeAddress TEXT NOT NULL,
    LVOffice TEXT NOT NULL,
    CCOffice TEXT NOT NULL,

    -- Legislative Affiliations
    Party TEXT NOT NULL,
    County TEXT NOT NULL,
    District TEXT NOT NULL,
    TermEnd TEXT NOT NULL,

    -- Personal Info
    Occupation TEXT NOT NULL,
    Recreation TEXT NOT NULL,
    Born TEXT NOT NULL,
    Spouse TEXT NOT NULL,
    Children TEXT NOT NULL
);

-- Career
CREATE TABLE LegislativeService (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,
 
    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE OtherPublicService (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE HonorsAwards (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE OtherAchivements (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE Affiliations (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE Education (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Description TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);



-- BILLS
CREATE TABLE Bill (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,

    Name TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE
);
CREATE TABLE FiscalNotes (
    Id INTEGER PRIMARY KEY,

    BillId INTEGER NOT NULL,

    Path TEXT NOT NULL,

    FOREIGN KEY (BillId) REFERENCES Bill(Id) ON DELETE CASCADE
);
CREATE TABLE Exhibits (
    Id INTEGER PRIMARY KEY,

    BillId INTEGER NOT NULL,

    Path TEXT NOT NULL,

    FOREIGN KEY (BillId) REFERENCES Bill(Id) ON DELETE CASCADE
);
-- NOTE: Many 2 Many Legislator and Bill
CREATE TABLE LegislatorBill (
    LegislatorId INTEGER NOT NULL,
    BillId INTEGER NOT NULL,

    IsPrimarySponsor BOOLEAN NOT NULL DEFAULT 0,

    PRIMARY KEY (LegislatorId, BillId),
    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE,
    FOREIGN KEY (BillId) REFERENCES Bill(Id) ON DELETE CASCADE
);

-- Staff
CREATE TABLE STAFF (
    Id INTEGER PRIMARY KEY,

    FirstName TEXT NOT NULL,
    MiddleInitial TEXT,
    LastName TEXT NOT NULL,
    Title TEXT NOT NULL
);

-- Committee
CREATE TABLE Committee (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,
    StaffId INTEGER NOT NULL,
    BillSponsorId INTEGER NOT NULL,
    BillId INTEGER NOT NULL,

    House TEXT NOT NULL,
    -- WeekSchedule
    Mon TEXT,
    Tues TEXT,
    Wed TEXT,
    Thurs TEXT,
    Fri TEXT,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE,
    FOREIGN KEY (StaffId) REFERENCES Staff(Id) ON DELETE CASCADE,
    FOREIGN KEY (BillSponsorId) REFERENCES Bill(Id) ON DELETE CASCADE,
    FOREIGN KEY (BillId) REFERENCES Bill(Id) ON DELETE CASCADE
);

CREATE TABLE HearingRoomMeeting (
    Id INTEGER PRIMARY KEY,

    MeetingName TEXT NOT NULL,
    YoutubeLink TEXT,
    CCRoomNumber TEXT,
    IsCCMainRoom INTEGER NOT NULL,
    LVRoomNumber TEXT,
    Date TEXT NOT NULL,
    Time TEXT NOT NULL,
    Agenda TEXT
);

CREATE TABLE LegislativeHearing (
    Id INTEGER PRIMARY KEY,

    LegislatorId INTEGER NOT NULL,
    StaffId INTEGER NOT NULL,


    MeetingName TEXT NOT NULL,
    YoutubeLink TEXT,
    CCRoomNumber TEXT,
    IsCCMainRoom INTEGER NOT NULL,
    LVRoomNumber TEXT,
    Date TEXT NOT NULL,
    Time TEXT NOT NULL,
    Agenda TEXT,
    House TEXT NOT NULL,

    FOREIGN KEY (LegislatorId) REFERENCES Legislator(Id) ON DELETE CASCADE,
    FOREIGN KEY (StaffId) REFERENCES Staff(Id) ON DELETE CASCADE
);

-- Indexes to optimize foreign key queries and enforcement

-- Career Tables
CREATE INDEX idx_LegislativeService_LegislatorId ON LegislativeService(LegislatorId);
CREATE INDEX idx_OtherPublicService_LegislatorId ON OtherPublicService(LegislatorId);
CREATE INDEX idx_HonorsAwards_LegislatorId ON HonorsAwards(LegislatorId);
CREATE INDEX idx_OtherAchivements_LegislatorId ON OtherAchivements(LegislatorId);
CREATE INDEX idx_Affiliations_LegislatorId ON Affiliations(LegislatorId);
CREATE INDEX idx_Education_LegislatorId ON Education(LegislatorId);

-- Bills and Related
CREATE INDEX idx_Bill_LegislatorId ON BILL(LegislatorId);
CREATE INDEX idx_FiscalNotes_BillId ON FiscalNotes(BillId);
CREATE INDEX idx_Exhibits_BillId ON Exhibits(BillId);

-- Many-to-Many Table
CREATE INDEX idx_LegislatorBill_LegislatorId ON LegislatorBill(LegislatorId);
CREATE INDEX idx_LegislatorBill_BillId ON LegislatorBill(BillId);

-- Committee Table
CREATE INDEX idx_Committee_LegislatorId ON Committee(LegislatorId);
CREATE INDEX idx_Committee_StaffId ON Committee(StaffId);
CREATE INDEX idx_Committee_BillSponsoredId ON Committee(BillSponsorId);
CREATE INDEX idx_Committee_BillId ON Committee(BillId);

-- Legislative Hearing Table
CREATE INDEX idx_LegislativeHearing_LegislatorId ON LegislativeHearing(LegislatorId);
CREATE INDEX idx_LegislativeHearing_StaffId ON LegislativeHearing(StaffId);

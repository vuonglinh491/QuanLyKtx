PRAGMA foreign_keys = ON;

CREATE TABLE Students (
    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentCode TEXT NOT NULL UNIQUE, FullName TEXT NOT NULL,
    DateOfBirth TEXT NOT NULL, Gender TEXT NOT NULL, Phone TEXT NOT NULL,
    Email TEXT NOT NULL, Address TEXT, ClassName TEXT NOT NULL,
    Faculty TEXT NOT NULL, CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE Buildings (
    BuildingID INTEGER PRIMARY KEY AUTOINCREMENT,
    BuildingName TEXT NOT NULL UNIQUE, Description TEXT,
    Capacity INTEGER NOT NULL DEFAULT 0 CHECK (Capacity >= 0)
);
CREATE TABLE Rooms (
    RoomID INTEGER PRIMARY KEY AUTOINCREMENT, BuildingID INTEGER NOT NULL,
    RoomNumber TEXT NOT NULL, Floor INTEGER NOT NULL, Capacity INTEGER NOT NULL,
    CurrentOccupancy INTEGER NOT NULL DEFAULT 0, RoomType TEXT NOT NULL,
    Price NUMERIC NOT NULL, Status TEXT NOT NULL DEFAULT 'Available',
    FOREIGN KEY (BuildingID) REFERENCES Buildings(BuildingID) ON DELETE CASCADE,
    UNIQUE (BuildingID, RoomNumber), CHECK (Capacity > 0),
    CHECK (CurrentOccupancy >= 0 AND CurrentOccupancy <= Capacity),
    CHECK (Price >= 0), CHECK (Status IN ('Available', 'Full', 'Maintenance'))
);
CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL, FullName TEXT NOT NULL, Role TEXT NOT NULL,
    StudentID INTEGER, IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE SET NULL,
    CHECK (Role IN ('QuanLy', 'SinhVien'))
);
CREATE TABLE RoomAssignments (
    AssignmentID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL,
    RoomID INTEGER NOT NULL, StartDate TEXT NOT NULL, EndDate TEXT,
    Status TEXT NOT NULL DEFAULT 'Active',
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID) ON DELETE CASCADE,
    CHECK (Status IN ('Active', 'Ended'))
);
CREATE TABLE Contracts (
    ContractID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL,
    RoomID INTEGER NOT NULL, StartDate TEXT NOT NULL, EndDate TEXT NOT NULL,
    MonthlyFee NUMERIC NOT NULL, Deposit NUMERIC NOT NULL DEFAULT 0,
    Status TEXT NOT NULL DEFAULT 'Active',
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
    CHECK (EndDate >= StartDate), CHECK (MonthlyFee >= 0), CHECK (Deposit >= 0),
    CHECK (Status IN ('Active', 'Expired', 'Terminated'))
);
CREATE TABLE ElectricityWater (
    RecordID INTEGER PRIMARY KEY AUTOINCREMENT, RoomID INTEGER NOT NULL,
    Month INTEGER NOT NULL, Year INTEGER NOT NULL,
    OldElectricIndex NUMERIC NOT NULL DEFAULT 0, NewElectricIndex NUMERIC NOT NULL DEFAULT 0,
    ElectricAmount NUMERIC NOT NULL DEFAULT 0, OldWaterIndex NUMERIC NOT NULL DEFAULT 0,
    NewWaterIndex NUMERIC NOT NULL DEFAULT 0, WaterAmount NUMERIC NOT NULL DEFAULT 0,
    TotalAmount NUMERIC NOT NULL DEFAULT 0,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID) ON DELETE CASCADE,
    UNIQUE (RoomID, Month, Year), CHECK (Month BETWEEN 1 AND 12), CHECK (Year >= 2000),
    CHECK (NewElectricIndex >= OldElectricIndex), CHECK (NewWaterIndex >= OldWaterIndex)
);
CREATE TABLE Payments (
    PaymentID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL,
    ContractID INTEGER, PaymentDate TEXT NOT NULL DEFAULT (date('now')),
    Amount NUMERIC NOT NULL, PaymentType TEXT NOT NULL, Description TEXT,
    Status TEXT NOT NULL DEFAULT 'Paid',
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (ContractID) REFERENCES Contracts(ContractID), CHECK (Amount > 0),
    CHECK (Status IN ('Paid', 'Pending', 'Cancelled'))
);
CREATE TABLE Violations (
    ViolationID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL,
    ViolationDate TEXT NOT NULL DEFAULT (date('now')), ViolationType TEXT NOT NULL,
    Description TEXT, FineAmount NUMERIC NOT NULL DEFAULT 0, Status TEXT NOT NULL DEFAULT 'Unpaid',
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    CHECK (FineAmount >= 0), CHECK (Status IN ('Unpaid', 'Paid'))
);
CREATE TABLE Requests (
    RequestID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL,
    RequestType TEXT NOT NULL, Content TEXT NOT NULL,
    CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, ProcessedAt TEXT,
    Status TEXT NOT NULL DEFAULT 'Pending', ManagerNote TEXT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    CHECK (RequestType IN ('RegisterRoom', 'ChangeRoom', 'LeaveRoom')),
    CHECK (Status IN ('Pending', 'Approved', 'Rejected'))
);

-- Tai khoan quan tri mac dinh de khoi dau quan ly he thong.
-- Mat khau: admin123. Du lieu sinh vien/phong van de trong de nguoi dung tu them.
INSERT INTO Users (Username, PasswordHash, FullName, Role, StudentID, IsActive)
VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Quản Trị Viên KTX', 'QuanLy', NULL, 1);


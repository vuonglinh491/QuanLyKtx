-- =======================================================
-- KỊCH BẢN TẠO CƠ SỞ DỮ LIỆU: DormitoryDB
-- Hệ thống Quản lý Ký túc xá (C# WinForms .NET 8 + SQL Server)
-- =======================================================

-- 1. TẠO DATABASE
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DormitoryDB')
BEGIN
    CREATE DATABASE DormitoryDB;
END
GO

USE DormitoryDB;
GO

-- =======================================================
-- 2. XÓA BẢNG CŨ NẾU ĐÃ TỒN TẠI (THEO THỨ TỰ KHÓA NGOẠI)
-- =======================================================
IF OBJECT_ID(N'dbo.Requests', N'U') IS NOT NULL DROP TABLE dbo.Requests;
IF OBJECT_ID(N'dbo.Violations', N'U') IS NOT NULL DROP TABLE dbo.Violations;
IF OBJECT_ID(N'dbo.Payments', N'U') IS NOT NULL DROP TABLE dbo.Payments;
IF OBJECT_ID(N'dbo.ElectricityWater', N'U') IS NOT NULL DROP TABLE dbo.ElectricityWater;
IF OBJECT_ID(N'dbo.Contracts', N'U') IS NOT NULL DROP TABLE dbo.Contracts;
IF OBJECT_ID(N'dbo.RoomAssignments', N'U') IS NOT NULL DROP TABLE dbo.RoomAssignments;
IF OBJECT_ID(N'dbo.Users', N'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID(N'dbo.Rooms', N'U') IS NOT NULL DROP TABLE dbo.Rooms;
IF OBJECT_ID(N'dbo.Buildings', N'U') IS NOT NULL DROP TABLE dbo.Buildings;
IF OBJECT_ID(N'dbo.Students', N'U') IS NOT NULL DROP TABLE dbo.Students;
GO

-- =======================================================
-- 3. TẠO CÁC BẢNG DỮ LIỆU
-- =======================================================

-- 3.1. Bảng Students (Sinh viên)
CREATE TABLE dbo.Students (
    StudentID       INT IDENTITY(1,1) PRIMARY KEY,
    StudentCode     NVARCHAR(20) NOT NULL UNIQUE,
    FullName        NVARCHAR(100) NOT NULL,
    DateOfBirth     DATE NOT NULL,
    Gender          NVARCHAR(10) NOT NULL,
    Phone           NVARCHAR(20) NOT NULL,
    Email           NVARCHAR(100) NOT NULL,
    Address         NVARCHAR(255) NULL,
    ClassName       NVARCHAR(100) NOT NULL,
    Faculty         NVARCHAR(100) NOT NULL,
    CreatedAt       DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- 3.2. Bảng Buildings (Khu nhà KTX)
CREATE TABLE dbo.Buildings (
    BuildingID      INT IDENTITY(1,1) PRIMARY KEY,
    BuildingName    NVARCHAR(100) NOT NULL UNIQUE,
    Description     NVARCHAR(255) NULL
);
GO

-- 3.3. Bảng Rooms (Phòng ở)
CREATE TABLE dbo.Rooms (
    RoomID              INT IDENTITY(1,1) PRIMARY KEY,
    BuildingID          INT NOT NULL,
    RoomNumber          NVARCHAR(20) NOT NULL,
    Floor               INT NOT NULL,
    Capacity            INT NOT NULL,
    CurrentOccupancy    INT NOT NULL DEFAULT 0,
    RoomType            NVARCHAR(50) NOT NULL,
    Price               DECIMAL(18,2) NOT NULL,
    Status              NVARCHAR(30) NOT NULL DEFAULT 'Available',
    CONSTRAINT FK_Rooms_Buildings FOREIGN KEY (BuildingID) REFERENCES dbo.Buildings(BuildingID) ON DELETE CASCADE,
    CONSTRAINT UQ_Building_Room UNIQUE (BuildingID, RoomNumber),
    CONSTRAINT CK_Rooms_Capacity CHECK (Capacity > 0),
    CONSTRAINT CK_Rooms_Occupancy CHECK (CurrentOccupancy >= 0 AND CurrentOccupancy <= Capacity),
    CONSTRAINT CK_Rooms_Price CHECK (Price >= 0),
    CONSTRAINT CK_Rooms_Status CHECK (Status IN ('Available', 'Full', 'Maintenance'))
);
GO

-- 3.4. Bảng Users (Tài khoản người dùng)
CREATE TABLE dbo.Users (
    UserID          INT IDENTITY(1,1) PRIMARY KEY,
    Username        NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash    NVARCHAR(255) NOT NULL,
    FullName        NVARCHAR(100) NOT NULL,
    Role            NVARCHAR(20) NOT NULL,
    StudentID       INT NULL,
    IsActive        BIT NOT NULL DEFAULT 1,
    CreatedAt       DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Users_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE SET NULL,
    CONSTRAINT CK_Users_Role CHECK (Role IN ('QuanLy', 'SinhVien'))
);
GO

-- 3.5. Bảng RoomAssignments (Phân phòng)
CREATE TABLE dbo.RoomAssignments (
    AssignmentID    INT IDENTITY(1,1) PRIMARY KEY,
    StudentID       INT NOT NULL,
    RoomID          INT NOT NULL,
    StartDate       DATE NOT NULL,
    EndDate         DATE NULL,
    Status          NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_Assignments_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_Assignments_Rooms FOREIGN KEY (RoomID) REFERENCES dbo.Rooms(RoomID) ON DELETE CASCADE,
    CONSTRAINT CK_Assignments_Status CHECK (Status IN ('Active', 'Ended'))
);
GO

-- 3.6. Bảng Contracts (Hợp đồng thuê phòng)
CREATE TABLE dbo.Contracts (
    ContractID      INT IDENTITY(1,1) PRIMARY KEY,
    StudentID       INT NOT NULL,
    RoomID          INT NOT NULL,
    StartDate       DATE NOT NULL,
    EndDate         DATE NOT NULL,
    MonthlyFee      DECIMAL(18,2) NOT NULL,
    Deposit         DECIMAL(18,2) NOT NULL DEFAULT 0,
    Status          NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_Contracts_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_Contracts_Rooms FOREIGN KEY (RoomID) REFERENCES dbo.Rooms(RoomID),
    CONSTRAINT CK_Contracts_Dates CHECK (EndDate >= StartDate),
    CONSTRAINT CK_Contracts_MonthlyFee CHECK (MonthlyFee >= 0),
    CONSTRAINT CK_Contracts_Deposit CHECK (Deposit >= 0),
    CONSTRAINT CK_Contracts_Status CHECK (Status IN ('Active', 'Expired', 'Terminated'))
);
GO

-- 3.7. Bảng ElectricityWater (Điện nước theo tháng của từng phòng)
CREATE TABLE dbo.ElectricityWater (
    RecordID            INT IDENTITY(1,1) PRIMARY KEY,
    RoomID              INT NOT NULL,
    Month               INT NOT NULL,
    Year                INT NOT NULL,
    OldElectricIndex    DECIMAL(18,2) NOT NULL DEFAULT 0,
    NewElectricIndex    DECIMAL(18,2) NOT NULL DEFAULT 0,
    ElectricAmount      DECIMAL(18,2) NOT NULL DEFAULT 0,
    OldWaterIndex       DECIMAL(18,2) NOT NULL DEFAULT 0,
    NewWaterIndex       DECIMAL(18,2) NOT NULL DEFAULT 0,
    WaterAmount         DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalAmount         DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_ElecWater_Rooms FOREIGN KEY (RoomID) REFERENCES dbo.Rooms(RoomID) ON DELETE CASCADE,
    CONSTRAINT UQ_ElecWater_Room_Month_Year UNIQUE (RoomID, Month, Year),
    CONSTRAINT CK_ElecWater_Month CHECK (Month BETWEEN 1 AND 12),
    CONSTRAINT CK_ElecWater_Year CHECK (Year >= 2000),
    CONSTRAINT CK_ElecWater_ElectricIndex CHECK (NewElectricIndex >= OldElectricIndex),
    CONSTRAINT CK_ElecWater_WaterIndex CHECK (NewWaterIndex >= OldWaterIndex)
);
GO

-- 3.8. Bảng Payments (Thanh toán)
CREATE TABLE dbo.Payments (
    PaymentID       INT IDENTITY(1,1) PRIMARY KEY,
    StudentID       INT NOT NULL,
    ContractID      INT NULL,
    PaymentDate     DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    Amount          DECIMAL(18,2) NOT NULL,
    PaymentType     NVARCHAR(30) NOT NULL,
    Description     NVARCHAR(255) NULL,
    Status          NVARCHAR(30) NOT NULL DEFAULT 'Paid',
    CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_Payments_Contracts FOREIGN KEY (ContractID) REFERENCES dbo.Contracts(ContractID),
    CONSTRAINT CK_Payments_Amount CHECK (Amount > 0),
    CONSTRAINT CK_Payments_Status CHECK (Status IN ('Paid', 'Pending', 'Cancelled'))
);
GO

-- 3.9. Bảng Violations (Kỷ luật / Vi phạm)
CREATE TABLE dbo.Violations (
    ViolationID     INT IDENTITY(1,1) PRIMARY KEY,
    StudentID       INT NOT NULL,
    ViolationDate   DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    ViolationType   NVARCHAR(100) NOT NULL,
    Description     NVARCHAR(255) NULL,
    FineAmount      DECIMAL(18,2) NOT NULL DEFAULT 0,
    Status          NVARCHAR(30) NOT NULL DEFAULT 'Unpaid',
    CONSTRAINT FK_Violations_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT CK_Violations_FineAmount CHECK (FineAmount >= 0),
    CONSTRAINT CK_Violations_Status CHECK (Status IN ('Unpaid', 'Paid'))
);
GO

-- 3.10. Bảng Requests (Yêu cầu của sinh viên)
CREATE TABLE dbo.Requests (
    RequestID       INT IDENTITY(1,1) PRIMARY KEY,
    StudentID       INT NOT NULL,
    RequestType     NVARCHAR(30) NOT NULL,
    Content         NVARCHAR(500) NOT NULL,
    CreatedAt       DATETIME NOT NULL DEFAULT GETDATE(),
    ProcessedAt     DATETIME NULL,
    Status          NVARCHAR(30) NOT NULL DEFAULT 'Pending',
    ManagerNote     NVARCHAR(500) NULL,
    CONSTRAINT FK_Requests_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT CK_Requests_Type CHECK (RequestType IN ('RegisterRoom', 'ChangeRoom', 'LeaveRoom')),
    CONSTRAINT CK_Requests_Status CHECK (Status IN ('Pending', 'Approved', 'Rejected'))
);
GO

-- =======================================================
-- 4. CHÈN DỮ LIỆU MẪU (SEED DATA)
-- Mật khẩu mặc định:
--   'admin123' -> SHA-256: 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
--   '123456'   -> SHA-256: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
-- =======================================================

-- 4.1. Thêm Tòa nhà
INSERT INTO dbo.Buildings (BuildingName, Description) VALUES
(N'Tòa Nhà A', N'Khu nhà nam - 4 tầng'),
(N'Tòa Nhà B', N'Khu nhà nữ - 4 tầng'),
(N'Tòa Nhà C', N'Khu nhà chất lượng cao');
GO

-- 4.2. Thêm Sinh viên
INSERT INTO dbo.Students (StudentCode, FullName, DateOfBirth, Gender, Phone, Email, Address, ClassName, Faculty) VALUES
(N'SV001', N'Nguyễn Văn An', '2003-05-15', N'Nam', '0912345678', 'an.nv@gmail.com', N'Hà Nội', N'CNTT1', N'Công nghệ thông tin'),
(N'SV002', N'Trần Thị Mai', '2003-08-20', N'Nữ', '0923456789', 'mai.tt@gmail.com', N'Nam Định', N'KTPM2', N'Công nghệ thông tin'),
(N'SV003', N'Lê Hoàng Long', '2004-01-10', N'Nam', '0934567890', 'long.lh@gmail.com', N'Thái Bình', N'DTVT1', N'Điện tử viễn thông'),
(N'SV004', N'Phạm Thu Hà', '2004-11-25', N'Nữ', '0945678901', 'ha.pt@gmail.com', N'Bắc Ninh', N'QTKD1', N'Quản trị kinh doanh');
GO

-- 4.3. Thêm Phòng
-- Tòa Nhà A (ID=1)
INSERT INTO dbo.Rooms (BuildingID, RoomNumber, Floor, Capacity, CurrentOccupancy, RoomType, Price, Status) VALUES
(1, N'A101', 1, 4, 1, N'Tiêu chuẩn', 600000, 'Available'),
(1, N'A102', 1, 4, 0, N'Tiêu chuẩn', 600000, 'Available'),
(1, N'A201', 2, 4, 0, N'Tiêu chuẩn', 600000, 'Available');

-- Tòa Nhà B (ID=2)
INSERT INTO dbo.Rooms (BuildingID, RoomNumber, Floor, Capacity, CurrentOccupancy, RoomType, Price, Status) VALUES
(2, N'B101', 1, 4, 1, N'Tiêu chuẩn', 600000, 'Available'),
(2, N'B102', 1, 4, 0, N'Tiêu chuẩn', 600000, 'Available');

-- Tòa Nhà C (ID=3)
INSERT INTO dbo.Rooms (BuildingID, RoomNumber, Floor, Capacity, CurrentOccupancy, RoomType, Price, Status) VALUES
(3, N'C101', 1, 2, 0, N'Chất lượng cao', 1200000, 'Available');
GO

-- 4.4. Thêm Users (Tài khoản)
-- Admin: username = admin, password = admin123
-- Sinh viên: username = sv001, password = 123456
-- Sinh viên: username = sv002, password = 123456
INSERT INTO dbo.Users (Username, PasswordHash, FullName, Role, StudentID, IsActive) VALUES
(N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', N'Quản Trị Viên KTX', N'QuanLy', NULL, 1),
(N'sv001', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Nguyễn Văn An', N'SinhVien', 1, 1),
(N'sv002', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Trần Thị Mai', N'SinhVien', 2, 1);
GO

-- 4.5. Phân phòng mẫu
-- SV001 ở phòng A101 (RoomID = 1)
-- SV002 ở phòng B101 (RoomID = 4)
INSERT INTO dbo.RoomAssignments (StudentID, RoomID, StartDate, EndDate, Status) VALUES
(1, 1, '2026-09-01', NULL, 'Active'),
(2, 4, '2026-09-01', NULL, 'Active');
GO

-- 4.6. Hợp đồng mẫu
INSERT INTO dbo.Contracts (StudentID, RoomID, StartDate, EndDate, MonthlyFee, Deposit, Status) VALUES
(1, 1, '2026-09-01', '2027-06-30', 600000, 600000, 'Active'),
(2, 4, '2026-09-01', '2027-06-30', 600000, 600000, 'Active');
GO

-- 4.7. Chỉ số điện nước mẫu cho tháng 9/2026
-- Giá điện: 3,500đ/kWh, Nước: 12,000đ/m3
INSERT INTO dbo.ElectricityWater (RoomID, Month, Year, OldElectricIndex, NewElectricIndex, ElectricAmount, OldWaterIndex, NewWaterIndex, WaterAmount, TotalAmount) VALUES
(1, 9, 2026, 120, 170, 175000, 30, 36, 72000, 247000),
(4, 9, 2026, 80, 125, 157500, 20, 25, 60000, 217500);
GO

-- 4.8. Thanh toán mẫu
INSERT INTO dbo.Payments (StudentID, ContractID, PaymentDate, Amount, PaymentType, Description, Status) VALUES
(1, 1, '2026-09-02', 600000, N'Tiền đặt cọc', N'Tiền cọc phòng hợp đồng 1', 'Paid'),
(1, 1, '2026-09-05', 600000, N'Tiền phòng', N'Thanh toán tiền phòng tháng 9/2026', 'Paid'),
(2, 2, '2026-09-02', 600000, N'Tiền đặt cọc', N'Tiền cọc phòng hợp đồng 2', 'Paid');
GO

-- 4.9. Kỷ luật / Vi phạm mẫu
INSERT INTO dbo.Violations (StudentID, ViolationDate, ViolationType, Description, FineAmount, Status) VALUES
(3, '2026-09-10', N'Nấu ăn trong phòng', N'Sử dụng bếp từ trong phòng sai quy định', 100000, 'Unpaid');
GO

-- 4.10. Yêu cầu sinh viên mẫu
INSERT INTO dbo.Requests (StudentID, RequestType, Content, CreatedAt, ProcessedAt, Status, ManagerNote) VALUES
(3, 'RegisterRoom', N'Em muốn đăng ký vào phòng C101 chất lượng cao', '2026-09-12 08:30:00', NULL, 'Pending', NULL),
(1, 'ChangeRoom', N'Em muốn chuyển sang tầng 2 phòng A201 vì bạn cùng lớp ở đó', '2026-09-15 14:20:00', NULL, 'Pending', NULL);
GO

PRINT N'>>> KHỞI TẠO CƠ SỞ DỮ LIỆU DormitoryDB VÀ CHÈN DỮ LIỆU MẪU THÀNH CÔNG! <<<';

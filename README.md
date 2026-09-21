# QuanLyKtx

Ứng dụng Windows Forms quản lý ký túc xá, xây dựng bằng C# và .NET 8. Dữ liệu được lưu cục bộ bằng SQLite, không cần cài SQL Server.

## Chức năng

- Đăng nhập và phân quyền quản lý/sinh viên.
- Quản lý khu nhà, sức chứa khu, phòng và sức chứa phòng.
- Quản lý sinh viên và tự tạo tài khoản sinh viên.
- Phân phòng, chuyển phòng và trả phòng.
- Quản lý hợp đồng, điện nước, thanh toán và vi phạm.
- Tiếp nhận, phê duyệt yêu cầu của sinh viên.
- Thống kê doanh thu, phòng và vi phạm.

## Công nghệ

- C# / .NET 8 Windows Forms (`net8.0-windows`).
- SQLite thông qua `System.Data.SQLite`.
- `System.Configuration.ConfigurationManager` đọc cấu hình kết nối.
- `SQLitePCLRaw.bundle_e_sqlite3` cung cấp native SQLite runtime cho Windows.
- QuestPDF xuất báo cáo PDF.

## Cấu trúc chính

```text
QuanLyKtx/
├── App.config                         # Cấu hình connection string SQLite
├── Program.cs                         # Điểm khởi chạy và kiểm tra database
├── QuanLyKtx.csproj                   # Target framework và NuGet packages
├── DormitoryDB.sqlite                 # Database SQLite hiện tại khi chạy Debug
├── Database/DormitoryDB.sql           # Schema SQLite và tài khoản admin ban đầu
├── Data/                              # DatabaseConnection và DatabaseHelper
├── Models/                            # Các lớp dữ liệu
├── Services/                          # Nghiệp vụ đăng nhập, sinh viên, phòng...
├── Utils/                             # Session, mật khẩu và validation
└── Forms/                             # Giao diện Login, Manager và Student
```

Các thư mục `.vs/`, `bin/` và `obj/` là file tạm/cache do Visual Studio và .NET tạo ra. Không cần đưa lên Git và có thể xóa bất cứ lúc nào.

## Yêu cầu

- Windows 10/11.
- .NET 8 SDK hoặc Visual Studio 2022 với workload .NET desktop development.
- Quyền ghi vào thư mục dự án hoặc thư mục chứa file thực thi.

## SQLite và kết nối

Cấu hình trong `App.config`:

```xml
<connectionStrings>
  <add name="DormitoryDB"
       connectionString="Data Source=DormitoryDB.sqlite;Version=3;Foreign Keys=True;"
       providerName="System.Data.SQLite" />
</connectionStrings>
```

Ứng dụng xử lý kết nối tại `Data/DatabaseConnection.cs`:

- Khi chạy Debug, database là `DormitoryDB.sqlite` trong thư mục dự án hiện tại.
- Khi chạy Release, database nằm cạnh file `.exe`.
- Nếu database chưa tồn tại, ứng dụng chạy `Database/DormitoryDB.sql` để tạo bảng.
- Kết nối luôn bật foreign key bằng `Foreign Keys=True`.
- Ứng dụng tự kiểm tra và thêm cột `Buildings.Capacity` cho database cũ.
- Ứng dụng tự bảo đảm tài khoản `admin` tồn tại.

Các thao tác truy vấn dùng `DatabaseHelper.cs` và parameterized query để hạn chế SQL injection.

## Schema database

Database gồm các bảng:

| Bảng | Nội dung |
|---|---|
| `Students` | Hồ sơ sinh viên |
| `Buildings` | Khu nhà và sức chứa khu |
| `Rooms` | Phòng, sức chứa, giá và trạng thái |
| `Users` | Tài khoản và quyền đăng nhập |
| `RoomAssignments` | Lịch sử phân phòng |
| `Contracts` | Hợp đồng thuê phòng |
| `ElectricityWater` | Chỉ số và chi phí điện nước |
| `Payments` | Các khoản thanh toán |
| `Violations` | Vi phạm và tiền phạt |
| `Requests` | Yêu cầu của sinh viên |

`Database/DormitoryDB.sql` chỉ chứa schema và tài khoản quản trị ban đầu, không chứa dữ liệu sinh viên, phòng, hợp đồng hoặc giao dịch mẫu.

## Tài khoản đăng nhập

Tài khoản quản trị ban đầu:

```text
Tên đăng nhập: admin
Mật khẩu:      admin123
```

Khi thêm một sinh viên trong màn hình **Quản lý sinh viên**, ứng dụng tự tạo tài khoản:

```text
Tên đăng nhập: mã sinh viên
Mật khẩu:      123456
Quyền:         SinhVien
```

Ví dụ sinh viên có mã `SV001` đăng nhập bằng `SV001 / 123456`. Tên đăng nhập không phân biệt chữ hoa/chữ thường.

## Cài đặt và chạy

Mở terminal tại thư mục chứa `QuanLyKtx.csproj`:

```powershell
dotnet restore
dotnet build
dotnet run --project QuanLyKtx.csproj
```

Hoặc mở `QuanLyKtx.csproj` bằng Visual Studio và nhấn **F5**.

## Kiểm tra kết nối database

Có thể kiểm tra kết nối mà không mở giao diện:

```powershell
dotnet run --project QuanLyKtx.csproj -- --test-db
```

Kết quả thành công có dạng:

```text
DB_SUCCESS: Ket noi C# .NET 8 den SQLite DormitoryDB thanh cong!
SO_TAI_KHOAN: 1
```

`SO_TAI_KHOAN` là số tài khoản hiện có trong database. Database mới thường có 1 tài khoản `admin` và chưa có tài khoản sinh viên.

## Mở database bằng DB Browser for SQLite

1. Mở DB Browser for SQLite.
2. Chọn **Open Database**.
3. Mở file `DormitoryDB.sqlite` tại thư mục dự án khi chạy Debug.
4. Vào **Database Structure** để xem các bảng.
5. Bấm **Refresh** sau khi ứng dụng tạo hoặc cập nhật database.

Không mở file `.sql` bằng **Open Database**. File `Database/DormitoryDB.sql` là script, không phải file database.

## Tạo lại database rỗng

Sao lưu `DormitoryDB.sqlite` trước khi thực hiện. Sau đó xóa file database và chạy ứng dụng lại:

```powershell
Remove-Item .\DormitoryDB.sqlite
dotnet run --project QuanLyKtx.csproj
```

Ứng dụng sẽ tạo lại schema và tài khoản `admin`. Không có dữ liệu sinh viên, phòng, hợp đồng hay giao dịch mẫu.

Script schema tạo các bảng và tài khoản quản trị ban đầu; không chạy lại script trên database đang có dữ liệu cần giữ nếu bạn đã chỉnh sửa schema thủ công.

## Xử lý lỗi thường gặp

- **Không thấy bảng:** mở đúng file `DormitoryDB.sqlite`, không mở `Database/DormitoryDB.sql`.
- **Không tạo được file:** kiểm tra quyền ghi của thư mục chạy ứng dụng.
- **Không nạp được SQLite native runtime:** chạy `dotnet restore`, sau đó `dotnet build` lại.
- **Không đăng nhập được admin:** dùng `admin / admin123`, bảo đảm đang mở đúng file database.
- **Lỗi database bị khóa:** đóng DB Browser hoặc các phiên bản ứng dụng khác rồi chạy lại.
- **Build báo file đang được sử dụng:** đóng ứng dụng QuanLyKtx trước khi build.

## Bảo mật và sao lưu

- Sao lưu `DormitoryDB.sqlite` trước khi sửa dữ liệu trực tiếp.
- Không đưa database chứa dữ liệu thật lên Git hoặc chia sẻ công khai.
- Đổi mật khẩu `admin` trước khi triển khai thực tế.
- Mật khẩu hiện được băm bằng SHA-256 để phù hợp với phiên bản demo hiện tại. Hệ thống thực tế nên dùng PBKDF2, bcrypt hoặc Argon2 kèm salt.
- Không lưu mật khẩu thật trong source code hoặc README ngoài tài khoản demo ban đầu.

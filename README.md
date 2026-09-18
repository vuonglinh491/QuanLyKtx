# QuanLyKtx

Ứng dụng quản lý ký túc xá trên Windows, xây dựng bằng C# và .NET 8 Windows Forms. Hệ thống kết nối SQL Server để quản lý sinh viên, khu nhà, phòng, phân phòng, hợp đồng, điện nước, thanh toán, vi phạm và yêu cầu của sinh viên.

## Mục lục

- [Tính năng](#tính-năng)
- [Công nghệ và kiến trúc](#công-nghệ-và-kiến-trúc)
- [Cấu trúc thư mục](#cấu-trúc-thư-mục)
- [Yêu cầu môi trường](#yêu-cầu-môi-trường)
- [Cài đặt cơ sở dữ liệu](#cài-đặt-cơ-sở-dữ-liệu)
- [Cấu hình kết nối](#cấu-hình-kết-nối)
- [Build và chạy](#build-và-chạy)
- [Tài khoản mẫu](#tài-khoản-mẫu)
- [Mô hình dữ liệu](#mô-hình-dữ-liệu)
- [Kiểm tra và xử lý lỗi](#kiểm-tra-và-xử-lý-lỗi)
- [Bảo mật](#bảo-mật)
- [Đóng góp và giấy phép](#đóng-góp-và-giấy-phép)

## Tính năng

### Quản lý

- Đăng nhập và phân quyền tài khoản quản lý (`QuanLy`) hoặc sinh viên (`SinhVien`).
- Quản lý thông tin sinh viên và tài khoản người dùng.
- Quản lý khu nhà, phòng, sức chứa, giá phòng và trạng thái phòng.
- Phân phòng, theo dõi số người đang ở và kết thúc phân phòng.
- Tạo, cập nhật và theo dõi hợp đồng thuê phòng.
- Ghi chỉ số điện nước theo phòng và theo tháng.
- Quản lý các khoản thanh toán, tiền phòng, tiền cọc và trạng thái thanh toán.
- Theo dõi vi phạm, tiền phạt và trạng thái xử lý.
- Tiếp nhận, phê duyệt hoặc từ chối yêu cầu của sinh viên.
- Xem thống kê hoạt động quản lý ký túc xá.

### Sinh viên

- Xem và cập nhật thông tin cá nhân.
- Xem phòng đang ở và hợp đồng hiện tại.
- Xem các khoản thanh toán và thông tin điện nước.
- Gửi yêu cầu đăng ký phòng, chuyển phòng hoặc trả phòng.
- Theo dõi trạng thái yêu cầu và thông tin vi phạm liên quan.

## Công nghệ và kiến trúc

- **Ngôn ngữ:** C#.
- **Nền tảng:** .NET 8 (`net8.0-windows`).
- **Giao diện:** Windows Forms.
- **Cơ sở dữ liệu:** Microsoft SQL Server.
- **Truy cập dữ liệu:** ADO.NET với `Microsoft.Data.SqlClient`.
- **Quản lý cấu hình:** `System.Configuration.ConfigurationManager`.

Mã nguồn được tổ chức theo các lớp đơn giản:

1. `Forms/` nhận thao tác từ người dùng và hiển thị dữ liệu.
2. `Services/` chứa nghiệp vụ theo từng nhóm chức năng.
3. `Data/` quản lý kết nối và thực thi truy vấn SQL có tham số.
4. `Models/` biểu diễn dữ liệu của hệ thống.
5. `Utils/` chứa session, kiểm tra dữ liệu và tiện ích mật khẩu.

## Cấu trúc thư mục

```text
QuanLyKtx/
├── App.config                         # Chuỗi kết nối SQL Server
├── Program.cs                         # Điểm khởi chạy ứng dụng
├── QuanLyKtx.csproj                   # Cấu hình .NET và NuGet packages
├── Database/DormitoryDB.sql           # Tạo schema và dữ liệu mẫu
├── Data/                              # DatabaseConnection, DatabaseHelper
├── Models/                            # Building, Contract, Room, Student, ...
├── Services/                          # Login, student, room, contract, payment, request
├── Utils/                             # Session, PasswordHelper, ValidationHelper
└── Forms/
    ├── LoginForm.*                    # Đăng nhập
    ├── Manager/                       # Giao diện dành cho quản lý
    └── Student/                       # Giao diện dành cho sinh viên
```

Các thư mục `bin/`, `obj/` và `.vs/` là sản phẩm build hoặc metadata cục bộ, không cần đưa lên Git.

## Yêu cầu môi trường

- Windows 10/11.
- .NET 8 SDK hoặc Visual Studio 2022 có workload **.NET desktop development**.
- SQL Server 2019 trở lên, SQL Server Express hoặc LocalDB.
- SQL Server Management Studio (SSMS) hoặc công cụ tương đương để chạy script.

## Cài đặt cơ sở dữ liệu

Script `Database/DormitoryDB.sql` thực hiện cả việc tạo database và chèn dữ liệu mẫu. Script có thao tác xóa các bảng cũ trước khi tạo lại, vì vậy **không chạy trên database đang chứa dữ liệu cần giữ**.

1. Khởi động SQL Server và bảo đảm tài khoản Windows hiện tại có quyền tạo database.
2. Mở `Database/DormitoryDB.sql` trong SSMS.
3. Kết nối tới đúng SQL Server instance.
4. Chạy toàn bộ script.
5. Kiểm tra database `DormitoryDB` và các bảng `Students`, `Buildings`, `Rooms`, `Users`, `RoomAssignments`, `Contracts`, `ElectricityWater`, `Payments`, `Violations`, `Requests` đã được tạo.

Script có dữ liệu mẫu cho ba khu nhà, sáu phòng, bốn sinh viên, tài khoản đăng nhập, phân phòng, hợp đồng, điện nước, thanh toán, vi phạm và yêu cầu.

## Cấu hình kết nối

Chuỗi kết nối mặc định trong `App.config` là:

```xml
<add name="DormitoryDB"
     connectionString="Server=localhost;Database=DormitoryDB;Trusted_Connection=True;TrustServerCertificate=True;"
     providerName="Microsoft.Data.SqlClient" />
```

Nếu SQL Server dùng instance khác, sửa giá trị `Server`, ví dụ:

```text
Server=.\SQLEXPRESS;Database=DormitoryDB;Trusted_Connection=True;TrustServerCertificate=True;
```

Ứng dụng đọc connection string có tên `DormitoryDB`. Nếu không đọc được cấu hình, mã nguồn sử dụng chuỗi mặc định trỏ tới `localhost`.

## Build và chạy

### Visual Studio

1. Mở `QuanLyKtx.csproj` hoặc thư mục dự án trong Visual Studio.
2. Chọn cấu hình `Debug`.
3. Khôi phục NuGet packages nếu Visual Studio yêu cầu.
4. Nhấn `F5` hoặc **Start** để chạy ứng dụng.

### .NET CLI

Chạy các lệnh sau tại thư mục chứa `QuanLyKtx.csproj`:

```powershell
dotnet restore
dotnet build
dotnet run --project QuanLyKtx.csproj
```

Ứng dụng mở `LoginForm` sau khi khởi động. Có thể dùng tham số kiểm tra kết nối database mà không mở giao diện:

```powershell
dotnet run --project QuanLyKtx.csproj -- --test-db
```

Kết quả thành công bắt đầu bằng `DB_SUCCESS` và hiển thị số tài khoản đọc được từ database.

## Tài khoản mẫu

Các tài khoản này được chèn bởi `DormitoryDB.sql` và chỉ phù hợp cho môi trường demo:

| Vai trò | Tên đăng nhập | Mật khẩu |
|---|---|---|
| Quản lý | `admin` | `admin123` |
| Sinh viên | `sv001` | `123456` |
| Sinh viên | `sv002` | `123456` |

Không sử dụng các tài khoản này trong môi trường thật. Tài khoản sinh viên được liên kết với bản ghi tương ứng trong bảng `Students`.

## Mô hình dữ liệu

| Bảng | Mục đích |
|---|---|
| `Students` | Hồ sơ sinh viên |
| `Buildings` | Khu/tòa nhà ký túc xá |
| `Rooms` | Phòng, sức chứa, giá và trạng thái |
| `Users` | Tài khoản và vai trò đăng nhập |
| `RoomAssignments` | Lịch sử phân sinh viên vào phòng |
| `Contracts` | Hợp đồng thuê phòng |
| `ElectricityWater` | Chỉ số và chi phí điện nước theo phòng/tháng |
| `Payments` | Các khoản thanh toán |
| `Violations` | Vi phạm và tiền phạt |
| `Requests` | Yêu cầu do sinh viên gửi |

Một số ràng buộc chính được database bảo vệ: mã sinh viên và tên đăng nhập là duy nhất, phòng không trùng trong cùng tòa nhà, mỗi phòng chỉ có một bản ghi điện nước cho một tháng, chỉ số mới không nhỏ hơn chỉ số cũ, và các trạng thái phải thuộc tập giá trị hợp lệ.

## Kiểm tra và xử lý lỗi

- **Không kết nối được SQL Server:** kiểm tra SQL Server service, tên instance trong `App.config`, quyền Windows Authentication và firewall.
- **Không tìm thấy database:** chạy lại `Database/DormitoryDB.sql` trên đúng instance.
- **Đăng nhập thất bại:** kiểm tra tài khoản mẫu đã được seed và cột `IsActive` đang bằng `1`.
- **Lỗi build package:** chạy `dotnet restore`, sau đó kiểm tra .NET 8 SDK bằng `dotnet --info`.
- **Ứng dụng không mở được trên máy không phải Windows:** đây là ứng dụng Windows Forms, không hỗ trợ chạy native trên Linux hoặc macOS.

## Bảo mật

- Không commit connection string chứa mật khẩu SQL Server, token hoặc thông tin production.
- Mật khẩu trong dữ liệu mẫu đang dùng SHA-256 trực tiếp để phù hợp với `Utils/PasswordHelper.cs`; cơ chế này chỉ phù hợp cho demo. Hệ thống production nên dùng thuật toán dành riêng cho mật khẩu như PBKDF2, bcrypt hoặc Argon2 kèm salt.
- Đổi hoặc xóa tài khoản mẫu trước khi triển khai thật.
- Các truy vấn trong `DatabaseHelper` được thiết kế để truyền tham số; khi bổ sung chức năng mới cần tiếp tục dùng parameterized query.
- Script khởi tạo có thao tác `DROP TABLE`, nên sao lưu dữ liệu trước khi chạy lại.

## Đóng góp và giấy phép

Khi đóng góp, tạo branch riêng với tên mô tả thay đổi, kiểm tra bằng `dotnet build`, sau đó mở pull request kèm mô tả và cách kiểm thử.

Repository hiện chưa khai báo giấy phép riêng. Nếu dự án được phát hành công khai, hãy bổ sung file `LICENSE` và chọn license phù hợp trước khi phân phối.
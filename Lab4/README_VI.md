# Bài thực hành 4 - Entity Framework Core trên .NET 10

## Nội dung
- ASP.NET Core MVC, TargetFramework `net10.0`.
- Entity Framework Core SQL Server 10.0.0.
- Code First: các model `Major`, `Learner`, `Course`, `Enrollment`.
- `SchoolContext` và `DbInitializer` tạo database `School` và dữ liệu mẫu.
- CRUD bảng `Learner`: danh sách, thêm, sửa, xóa.

## Yêu cầu trước khi chạy
1. Cài .NET 10 SDK.
2. Cài SQL Server LocalDB (thường đi kèm Visual Studio) hoặc sửa chuỗi kết nối để dùng SQL Server đang có.
3. Mở thư mục có file `MyWebApp.csproj` trong Visual Studio/VS Code.

## Chuỗi kết nối
Mặc định trong `appsettings.json`:
`Server=(localdb)\\MSSQLLocalDB;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`

Nếu máy dùng SQL Server Express, có thể đổi thành:
`Server=.\\SQLEXPRESS;Database=School;Trusted_Connection=True;TrustServerCertificate=True`

Nếu dùng SQL Authentication, thay `Trusted_Connection=True` bằng `User Id=...;Password=...;TrustServerCertificate=True`. Không đưa mật khẩu thật lên GitHub.

## Chạy
Mở terminal tại thư mục dự án và chạy:

```bash
dotnet --list-sdks
dotnet restore
dotnet run
```

Mở địa chỉ HTTPS/HTTP được in trong terminal. Trang mặc định sẽ chuyển đến `/Learner`.

Lần chạy đầu, chương trình gọi `EnsureCreated()` để tạo database và thêm dữ liệu mẫu. Nếu database `School` đã tồn tại với schema khác, `EnsureCreated()` không cập nhật schema cũ; hãy dùng database mới hoặc tự đồng bộ schema trước khi chạy.

## Ghi chú
- Dự án được tạo theo nội dung phần Code First và CRUD Learner trong tài liệu bạn gửi.
- Phần Database First chưa được thêm vì tài liệu trích xuất hiện có chỉ mô tả phần này ở tiêu đề, chưa có các bước/code chi tiết.
- Cần có kết nối SQL Server để chạy ứng dụng; đây không phải bản không dùng SQL.

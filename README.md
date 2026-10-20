# 📝 CHƯƠNG 1:
## 👤 Thông tin sinh viên
- **Họ và tên:** Chau Sóc Rong
- **MSSV:** 0024419459
- **Lớp:** K24-ĐHCNTT24E-IT
- **Sở thích:** Lập trình, bóng chuyền, đá bóng
---

# 📝 CHƯƠNG 2: REFACTORING EDUHUB - SOLID & DESIGN PATTERNS

## Nhiệm vụ 1: Phân tích các vi phạm SOLID trong ClubManager

### 1. Vi phạm Single Responsibility Principle (SRP)
- **Vấn đề**: Hàm `CreateClub` kiêm nhiệm quá nhiều trách nhiệm: vừa kiểm tra dữ liệu đầu vào, vừa lưu thông tin, vừa ghi log ra file và vừa gửi thông báo.
- **Hậu quả**: Class trở thành "God Class", rất khó đọc, khó bảo trì, dễ phát sinh lỗi khi sửa đổi và bất khả thi khi viết Unit Test.
- **Cách sửa**: Tách thành các lớp riêng biệt đảm nhận đúng một vai trò: `ClubService` (điều phối nghiệp vụ), `IAppLogger` (ghi log) và `INotificationService` (gửi thông báo).

### 2. Vi phạm Open/Closed Principle (OCP)
- **Vấn đề**: Sử dụng chuỗi lệnh điều kiện `if/else` dài để kiểm tra các loại email khác nhau (Gmail, Yahoo...).
- **Hậu quả**: Mỗi khi hệ thống muốn mở rộng thêm kênh mới (SMS, Slack), lập trình viên bắt buộc phải mở class cũ ra sửa code.
- **Cách sửa**: Định nghĩa interface `INotificationService` và áp dụng Factory Pattern; khi cần kênh mới chỉ việc tạo class mới cài đặt interface đó mà không sửa code cũ.

### 3. Vi phạm Interface Segregation & Liskov Substitution (ISP & LSP)
- **Vấn đề**: Lớp Repository ôm đồm tất cả các thao tác đọc/ghi dữ liệu cho mọi đối tượng trong một interface lớn.
- **Hậu quả**: Các class con hoặc thành phần sử dụng bị ép buộc phải cài đặt cả những phương thức mà chúng không dùng tới.
- **Cách sửa**: Chia nhỏ interface thành các phần chuyên biệt hơn (`IClubReader`, `IClubRepository`).

### 4. Vi phạm Dependency Inversion Principle (DIP)
- **Vấn đề**: Lớp nghiệp vụ trực tiếp gọi `File.AppendAllText`, `Console.WriteLine` và tự khởi tạo (`new`) các đối tượng cụ thể bên trong phương thức.
- **Hậu quả**: Code bị phụ thuộc chặt (tight coupling) vào hệ thống file và console thực tế, không thể viết Unit Test tự động độc lập.
- **Cách sửa**: Đưa các phụ thuộc vào thông qua Constructor (Dependency Injection) và quy định `Program.cs` là nơi duy nhất khởi tạo các đối tượng cụ thể.
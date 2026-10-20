using System;
using EduHub.Ch01.Domain;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== CHƯƠNG TRÌNH DEMO BÀI TẬP CHƯƠNG 1 (EDUHUB) ===\n");

// 1. Tạo CLB
Console.WriteLine("[Bước 1] Khởi tạo Câu lạc bộ:");
var club = Club.Create("Tech Club", "CLB Công nghệ Sinh viên");
Console.WriteLine($"-> Đã tạo CLB: {club.Name} - {club.Description}\n");

// 2. Thêm thành viên
Console.WriteLine("[Bước 2] Thêm thành viên vào CLB:");
var m1 = Member.Create("An", "an@dthu.edu.vn", "001");
var m2 = Member.Create("Bình", "binh@dthu.edu.vn", "002");

club.AddMember(m1);
club.AddMember(m2);
Console.WriteLine($"-> Số lượng thành viên trong CLB '{club.Name}': {club.Members.Count} người.\n");

// 3. Tạo sự kiện
Console.WriteLine("[Bước 3] Tạo sự kiện:");
var ev = Event.Create(club.Id, "Workshop AI", DateTime.Now.AddDays(1), 50, false);
Console.WriteLine($"-> Sự kiện: {ev.Title} | Sức chứa: {ev.Capacity} chỗ.\n");

// 4. Đăng ký và Confirm
Console.WriteLine("[Bước 4] Đăng ký sự kiện và Xác nhận (Confirm):");
var reg1 = Registration.Create(m1.Id, ev.Id);
var reg2 = Registration.Create(m2.Id, ev.Id);

reg1.Confirm();
reg2.Confirm();
Console.WriteLine($"-> Trạng thái đăng ký m1: {reg1.Status}");
Console.WriteLine($"-> Trạng thái đăng ký m2: {reg2.Status}\n");

// 5. Check-in
Console.WriteLine("[Bước 5] Thực hiện Check-in:");
var checkIn = CheckIn.Create(reg1.Id, "Đúng giờ");
Console.WriteLine($"-> {checkIn.Summary()}\n");

// 6. Báo cáo
Console.WriteLine("[Bước 6] Báo cáo tổng quan:");
Console.WriteLine($"Sự kiện: {ev.Title} | Đăng ký: 2 | Check-in: 1\n");

// 7 & 8. Thử vi phạm quy tắc nghiệp vụ (Huỷ phiếu rồi cố tình Confirm lại)
Console.WriteLine("[Bước 7 & 8] Thử vi phạm quy tắc nghiệp vụ:");
reg2.Cancel();
Console.WriteLine($"-> Đã hủy đăng ký reg2. Trạng thái hiện tại: {reg2.Status}");

try 
{
    Console.WriteLine("-> Đang thử Confirm lại phiếu reg2 đã Cancel...");
    reg2.Confirm(); // Sẽ ném ngoại lệ InvalidOperationException
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"[BẮT LỖI THÀNH CÔNG]: {ex.Message}");
}



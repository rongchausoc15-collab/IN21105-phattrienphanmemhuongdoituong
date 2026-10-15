# User Stories - EduHub Ch01

## 1. Sinh viên (Member)
### US1: Đăng ký tham gia Câu lạc bộ
- **As a** sinh viên, **I want** đăng ký tham gia CLB, **So that** có thể tham gia các hoạt động chung của CLB.
- **Acceptance Criteria:**
  - Given sinh viên chọn CLB hợp lệ, When gửi yêu cầu tham gia, Then hệ thống ghi nhận thành viên mới thuộc CLB đó.

### US2: Đăng ký tham gia Sự kiện
- **As a** sinh viên, **I want** đăng ký tham gia sự kiện do CLB tổ chức, **So that** tôi có vé tham gia và check-in.
- **Acceptance Criteria:**
  - Given sự kiện còn chỗ trống, When sinh viên thực hiện đăng ký, Then tạo phiếu đăng ký (Registration) với trạng thái `Pending`.

---

## 2. Ban quản lý Câu lạc bộ (Club Organizer)
### US3: Tạo sự kiện mới
- **As a** ban quản lý CLB, **I want** tạo sự kiện mới có giới hạn sức chứa, **So that** thành viên có thể đăng ký tham gia.
- **Acceptance Criteria:**
  - Given nhập đầy đủ thông tin sự kiện và số lượng giới hạn (Capacity), When tạo sự kiện, Then lưu thông tin sự kiện thành công vào hệ thống.

### US4: Xem báo cáo và quản lý đăng ký
- **As a** ban quản lý CLB, **I want** xem danh sách đăng ký và thực hiện check-in, **So that** quản lý được số lượng thành viên tham gia thực tế.

---

## 3. Quản trị hệ thống (Admin)
### US5: Quản lý thông tin hệ thống
- **As a** admin, **I want** kiểm soát thông tin thành viên và CLB, **So that** hệ thống vận hành minh bạch và chính xác.
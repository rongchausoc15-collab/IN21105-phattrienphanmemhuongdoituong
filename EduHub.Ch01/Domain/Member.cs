namespace EduHub.Ch01.Domain;

public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string StudentCode { get; private set; } = string.Empty;
    public DateTime JoinedAt { get; private set; }

    private Member() { }

    public static Member Create(string name, string email, string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên thành viên không được để trống.", nameof(name));
        
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Email không hợp lệ.", nameof(email));

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã số sinh viên không được để trống.", nameof(studentCode));

        return new Member
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Email = email.Trim(),
            StudentCode = studentCode.Trim(),
            JoinedAt = DateTime.UtcNow
        };
    }
}
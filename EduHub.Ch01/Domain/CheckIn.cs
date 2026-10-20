namespace EduHub.Ch01.Domain;

public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Note { get; private set; } = string.Empty;

    private CheckIn() { }

    public static CheckIn Create(Guid registrationId, string note = "")
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException("Mã đăng ký không hợp lệ.", nameof(registrationId));

        return new CheckIn
        {
            Id = Guid.NewGuid(),
            RegistrationId = registrationId,
            CheckedInAt = DateTime.UtcNow,
            Note = note?.Trim() ?? string.Empty
        };
    }

    public string Summary()
    {
        return $"[CheckIn] Mã phiếu: {RegistrationId} | Thời gian: {CheckedInAt:HH:mm:ss dd/MM/yyyy} | Ghi chú: {Note}";
    }
}
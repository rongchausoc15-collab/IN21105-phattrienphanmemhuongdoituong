namespace EduHub.Ch01.Domain;

public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

public class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public RegistrationStatus Status { get; private set; }
    public DateTime RegisteredAt { get; private set; }

    private Registration() { }

    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("Mã thành viên không hợp lệ.", nameof(memberId));

        if (eventId == Guid.Empty)
            throw new ArgumentException("Mã sự kiện không hợp lệ.", nameof(eventId));

        return new Registration
        {
            Id = Guid.NewGuid(),
            MemberId = memberId,
            EventId = eventId,
            Status = RegistrationStatus.Pending,
            RegisteredAt = DateTime.UtcNow
        };
    }

    public void Confirm()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Không thể xác nhận phiếu đang ở trạng thái Cancelled.");

        Status = RegistrationStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = RegistrationStatus.Cancelled;
    }
}
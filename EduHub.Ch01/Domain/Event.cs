namespace EduHub.Ch01.Domain;

public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsCancelled { get; private set; }

    private Event() { }

    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isCancelled = false)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("Mã CLB không hợp lệ.", nameof(clubId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tiêu đề sự kiện không được để trống.", nameof(title));

        if (capacity <= 0)
            throw new ArgumentException("Sức chứa sự kiện phải lớn hơn 0.", nameof(capacity));

        return new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title.Trim(),
            Date = date,
            Capacity = capacity,
            IsCancelled = isCancelled
        };
    }

    public bool HasCapacity(int currentRegistrations)
    {
        return currentRegistrations < Capacity;
    }
}
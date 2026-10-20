namespace EduHub.Ch01.Domain;

public class Club
{
    private readonly List<Member> _members = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<Member> Members => _members.AsReadOnly();

    private Club() { }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống.", nameof(name));

        return new Club
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Description = description?.Trim() ?? string.Empty,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);

        if (_members.Any(m => m.Id == member.Id || m.StudentCode == member.StudentCode))
            throw new InvalidOperationException($"Thành viên {member.Name} (MSSV: {member.StudentCode}) đã tồn tại trong CLB.");

        _members.Add(member);
    }
}
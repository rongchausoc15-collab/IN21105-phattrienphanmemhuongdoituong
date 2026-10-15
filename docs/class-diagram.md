# Class Diagram - EduHub Domain

```mermaid
classDiagram
    class Member {
        +Guid Id
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +bool IsActive()
        +Create(string name, string email, string studentCode) Member
    }

    class Club {
        +Guid Id
        +string Name
        +string Description
        +DateTime CreatedAt
        +IReadOnlyCollection~Member~ Members
        +AddMember(Member member) void
        +int MemberCount()
        +Create(string name, string description) Club
    }

    class Event {
        +Guid Id
        +Guid ClubId
        +string Title
        +DateTime Date
        +int Capacity
        +bool HasCapacity(int currentRegistrations)
        +Create(Guid clubId, string title, DateTime date, int capacity) Event
    }

    class Registration {
        +Guid Id
        +Guid MemberId
        +Guid EventId
        +string Status
        +Confirm() void
        +Cancel() void
        +Create(Guid memberId, Guid eventId) Registration
    }

    class CheckIn {
        +Guid Id
        +Guid RegistrationId
        +DateTime CheckedInAt
        +string Summary()
        +Create(Guid registrationId) CheckIn
    }

    Club "1" --> "*" Member : contains
    Club "1" --> "*" Event : organizes
    Event "1" --> "*" Registration : receives
    Registration "0..1" --> "1" CheckIn : verified by
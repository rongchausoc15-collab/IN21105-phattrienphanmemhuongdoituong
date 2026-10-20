namespace EduHub.Ch02.Factories
{
    // 1. Interface chung cho các kênh thông báo
    public interface INotificationService
    {
        void Send(string recipient, string message);
    }

    // 2. Các lớp cụ thể (Email, SMS)
    public class EmailNotificationService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"[EMAIL] to {recipient}: {message}");
        }
    }

    public class SmsNotificationService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"[SMS] to {recipient}: {message}");
        }
    }

    // 3. Factory Pattern: Chịu trách nhiệm tạo đối tượng theo yêu cầu
    public static class NotificationServiceFactory
    {
        public static INotificationService CreateService(string channelType)
        {
            return channelType.ToLower() switch
            {
                "email" => new EmailNotificationService(),
                "sms" => new SmsNotificationService(),
                _ => throw new ArgumentException("Kênh thông báo không hợp lệ!")
            };
        }
    }
}
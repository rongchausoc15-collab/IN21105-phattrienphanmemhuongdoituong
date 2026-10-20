using System;
using System.Collections.Generic;

namespace EduHub.Ch02.Services
{
    // 1. Interface Observer
    public interface IClubObserver
    {
        void OnClubCreated(string clubName);
    }

    // 2. Observer cụ thể 1: Gửi email thông báo
    public class EmailNotifierObserver : IClubObserver
    {
        public void OnClubCreated(string clubName)
        {
            Console.WriteLine($"[OBSERVER - EMAIL] Đã gửi thông báo: Câu lạc bộ '{clubName}' vừa được thành lập!");
        }
    }

    // 3. Observer cụ thể 2: Ghi log hệ thống
    public class LogNotifierObserver : IClubObserver
    {
        public void OnClubCreated(string clubName)
        {
            Console.WriteLine($"[OBSERVER - LOG] Hệ thống ghi nhận sự kiện tạo CLB: '{clubName}'");
        }
    }

    // 4. Subject (Chủ thể phát sự kiện)
    public class ClubEventManager
    {
        private readonly List<IClubObserver> _observers = new List<IClubObserver>();

        public void Attach(IClubObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IClubObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string clubName)
        {
            foreach (var observer in _observers)
            {
                observer.OnClubCreated(clubName);
            }
        }
    }
}
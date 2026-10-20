using System;
using System.Collections.Generic;

namespace EduHub.Ch02.Repositories
{
    // 1. Interface chung cho kho dữ liệu
    public interface IClubRepository
    {
        void AddClub(string clubName);
        List<string> GetAllClubs();
    }

    // 2. Kho dữ liệu cơ bản (Concrete Component)
    public class ClubRepository : IClubRepository
    {
        private readonly List<string> _clubs = new List<string>();

        public void AddClub(string clubName)
        {
            _clubs.Add(clubName);
        }

        public List<string> GetAllClubs()
        {
            return _clubs;
        }
    }

    // 3. Decorator: Thêm tính năng ghi log mà không sửa code gốc
    public class LoggingClubRepository : IClubRepository
    {
        private readonly IClubRepository _innerRepository;

        public LoggingClubRepository(IClubRepository innerRepository)
        {
            _innerRepository = innerRepository;
        }

        public void AddClub(string clubName)
        {
            Console.WriteLine($"[LOG - DECORATOR] Đang chuẩn bị thêm câu lạc bộ: {clubName}");
            _innerRepository.AddClub(clubName);
            Console.WriteLine($"[LOG - DECORATOR] Đã thêm thành công câu lạc bộ: {clubName}");
        }

        public List<string> GetAllClubs()
        {
            Console.WriteLine("[LOG - DECORATOR] Đang truy vấn danh sách câu lạc bộ...");
            return _innerRepository.GetAllClubs();
        }
    }
}
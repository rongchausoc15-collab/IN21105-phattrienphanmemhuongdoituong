using System;
using System.Collections.Generic;

namespace EduHub.Ch02.Services
{
    // 1. Interface cho Strategy xuất báo cáo
    public interface IReportStrategy
    {
        void GenerateReport(List<string> clubs);
    }

    // 2. Concrete Strategy 1: Báo cáo dạng Console
    public class ConsoleReportStrategy : IReportStrategy
    {
        public void GenerateReport(List<string> clubs)
        {
            Console.WriteLine("=== BÁO CÁO CÂU LẠC BỘ (CONSOLE) ===");
            foreach (var club in clubs)
            {
                Console.WriteLine($"- {club}");
            }
        }
    }

    // 3. Concrete Strategy 2: Báo cáo dạng CSV
    public class CsvReportStrategy : IReportStrategy
    {
        public void GenerateReport(List<string> clubs)
        {
            Console.WriteLine("=== BÁO CÁO CÂU LẠC BỘ (ĐỊNH DẠNG CSV) ===");
            Console.WriteLine("STT,TenCauLacBo");
            for (int i = 0; i < clubs.Count; i++)
            {
                Console.WriteLine($"{i + 1},{clubs[i]}");
            }
        }
    }

    // 4. Context: Lớp sử dụng Strategy
    public class ReportService
    {
        private IReportStrategy _strategy;

        public ReportService(IReportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IReportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExportReport(List<string> clubs)
        {
            _strategy.GenerateReport(clubs);
        }
    }
}
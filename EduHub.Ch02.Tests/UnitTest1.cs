using Xunit;
using EduHub.Ch02.Factories;
using EduHub.Ch02.Repositories;
using EduHub.Ch02.Services;

namespace EduHub.Ch02.Tests
{
    public class EduHubUnitTests
    {
        [Fact]
        public void Test1_EmailNotificationFactory_ReturnsCorrectService()
        {
            // Arrange & Act
            var service = NotificationServiceFactory.CreateService("email");

            // Assert
            Assert.NotNull(service);
            Assert.IsType<EmailNotificationService>(service);
        }

        [Fact]
        public void Test2_SmsNotificationFactory_ReturnsCorrectService()
        {
            // Arrange & Act
            var service = NotificationServiceFactory.CreateService("sms");

            // Assert
            Assert.NotNull(service);
            Assert.IsType<SmsNotificationService>(service);
        }

        [Fact]
        public void Test3_NotificationFactory_ThrowsException_WhenChannelInvalid()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => NotificationServiceFactory.CreateService("invalid_channel"));
        }

        [Fact]
        public void Test4_ClubRepository_CanAddAndRetrieveClubs()
        {
            // Arrange
            IClubRepository repo = new ClubRepository();

            // Act
            repo.AddClub("IT Club");
            var clubs = repo.GetAllClubs();

            // Assert
            Assert.Single(clubs);
            Assert.Contains("IT Club", clubs);
        }

        [Fact]
        public void Test5_LoggingClubRepository_DelegatesAndLogsCorrectly()
        {
            // Arrange
            IClubRepository innerRepo = new ClubRepository();
            IClubRepository loggingRepo = new LoggingClubRepository(innerRepo);

            // Act
            loggingRepo.AddClub("AI Club");
            var clubs = loggingRepo.GetAllClubs();

            // Assert
            Assert.Single(clubs);
            Assert.Contains("AI Club", clubs);
        }

        [Theory]
        [InlineData("Music Club")]
        [InlineData("Sport Club")]
        public void Test6_Theory_ClubRepository_MultipleClubs(string clubName)
        {
            // Arrange
            IClubRepository repo = new ClubRepository();

            // Act
            repo.AddClub(clubName);

            // Assert
            Assert.Contains(clubName, repo.GetAllClubs());
        }
    }
}
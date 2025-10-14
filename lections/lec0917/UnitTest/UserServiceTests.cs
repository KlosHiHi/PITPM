using FluentAssertions;
using Library.Users;
using Moq;

namespace UnitTest
{
    public class ReposituryFixture : IDisposable
    {
        public Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
        public ReposituryFixture()
        {
            mockRepository.Setup(r => r.GetUserById(1)).Returns(new User("Test", "test@test.test"));
            mockRepository.Setup(r => r.GetUserById(It.IsNotIn(1))).Returns(() => null);
        }

        public void Dispose()
        {
        }
    }

    public class UserServiceTests(ReposituryFixture fixture) : IClassFixture<ReposituryFixture>
    {
        private readonly ReposituryFixture _fixture = fixture;

        [Fact]
        public void GetUser_WithCorrectId_ReturnsNull()
        {
            UserService service = new(_fixture.mockRepository.Object);

            var user = service.GetUser(1);
            
            user.Should().NotBeNull();
            user.Name.Should().Be("Test");
        }

        [Fact]
        public void GetUser_WithCorrectId_ReturnsUser()
        {
            UserService service = new(_fixture.mockRepository.Object);

            var user = service.GetUser(2);

            user.Should().BeNull();
            _fixture.mockRepository.Verify(r => r.GetUserById(It.IsNotIn(1)), Times.Once());
        }
    }
}

using System.Threading.Tasks;
using ChatApi.Repositories;
using ChatApi.Services;
using Moq;
using NUnit.Framework;

namespace ChatApiTests.Services
{
    class UserServiceTests
    {
        private UserService service;
        private Mock<IUserRepository> userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            service = new UserService(userRepositoryMock.Object);
        }

        [Test]
        public async Task GetUserByUsername_OK() 
        {
            //Arrange
            userRepositoryMock
                .Setup(x => x.GetByUsername(It.IsAny<string>()))
                .ReturnsAsync(new ChatApi.Domain.User { Id = 1, Username = "User1" });

            //Act
            var result = await service.GetUserByUsername("User1");

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetUserByUsername_NotFound()
        {
            //Arrange
            userRepositoryMock
                .Setup(x => x.GetByUsername(It.IsAny<string>()))
                .ReturnsAsync((ChatApi.Domain.User)null);

            //Act
            var result = await service.GetUserByUsername("User1");

            //Assert
            Assert.IsNull(result);
        }
    }
}

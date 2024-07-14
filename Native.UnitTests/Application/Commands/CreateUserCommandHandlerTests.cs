using Moq;
using Native.Application.Commands.CreateUser;
using Native.Core.Entities;
using Native.Core.Repositories;
using Native.Core.Services;

namespace Native.UnitTests.Application.Commands;
public class CreateUserCommandHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_CreateUserExecuted_ReturnUserId()
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var authService = new Mock<IAuthService>();

        authService.Setup(s => s.ComputeSha256Hash(It.IsAny<string>())).Returns(It.IsAny<string>());

        var createUserCommand = new CreateUserCommand
        {
            Email = "test@test.com",
            Password = "Native@1"
        };

        var createSneakerCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);

        // Act
        var id = await createSneakerCommandHandler.Handle(createUserCommand, new CancellationToken());

        // Assert
        Assert.True(id >= 0);

        userRepository.Verify(pr => pr.AddAsync(It.IsAny<User>()), Times.Once);
    }
}
using Moq;
using Native.Application.Commands.LoginUser;
using Native.Core.Entities;
using Native.Core.Repositories;
using Native.Core.Services;

namespace Native.UnitTests.Application.Commands;
public class LoginUserCommandHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_LoginUserExecuted_ReturnLoginUser()
    {
        var loginUserCommand = new LoginUserCommand
        {
            Email = "test@test.com",
            Password = "Native@1"
        };

        // Arrange
        var userRepository = new Mock<IUserRepository>();
        var authService = new Mock<IAuthService>();

        var user = new User(loginUserCommand.Email, loginUserCommand.Password);

        authService.Setup(s => s.ComputeSha256Hash(It.IsAny<string>())).Returns("test");
        authService.Setup(s => s.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>())).Returns("test");
        userRepository.Setup(s => s.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

        var createSneakerCommandHandler = new LoginUserCommandHandler(authService.Object, userRepository.Object);

        // Act
        var login = await createSneakerCommandHandler.Handle(loginUserCommand, new CancellationToken());

        // Assert
        Assert.True(!string.IsNullOrEmpty(login.Token));

        userRepository.Verify(pr => pr.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}

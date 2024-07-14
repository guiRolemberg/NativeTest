using Moq;
using Native.Application.Queries.GetUser;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Queries;
public class GetUserQueryHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_GetUserExecuted_ReturnUser()
    {
        // Arrange
        var expectedResult = new User("test@test.com", "swfrgwetgf");

        var userRepository = new Mock<IUserRepository>();
        var getUserQuery = new GetUserQuery(1);
        var getUserQueryHandler = new GetUserQueryHandler(userRepository.Object);

        userRepository.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(expectedResult);

        // Act
        var user = await getUserQueryHandler.Handle(getUserQuery, new CancellationToken());

        // Assert
        Assert.True(!string.IsNullOrEmpty(user.Email));
        userRepository.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once);
    }
}
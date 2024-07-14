using Moq;
using Native.Application.Queries.GetSneakerById;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Queries;
public class GetSneakerByIdQueryHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_GetSneakerByIdExecuted_ReturnSneaker()
    {
        // Arrange
        var expectedResult = new Sneaker(1, "test", "test", 1, 1, 9999, 1);

        var sneakerRepository = new Mock<ISneakerRepository>();
        var getSneakerByIdQuery = new GetSneakerByIdQuery(1);
        var getSneakerByIdQueryHandler = new GetSneakerByIdQueryHandler(sneakerRepository.Object);

        sneakerRepository.Setup(s => s.GetDetailsByIdAsync(It.IsAny<int>())).ReturnsAsync(expectedResult);

        // Act
        var sneaker = await getSneakerByIdQueryHandler.Handle(getSneakerByIdQuery, new CancellationToken());

        // Assert
        Assert.True(sneaker.Price > 0);
        sneakerRepository.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
    }
}
using Moq;
using Native.Application.Queries.GetAllSneakers;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Queries;
public class GetAllSneakersQueryHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_GetAllSneakersExecuted_ReturnSneakers()
    {
        // Arrange
        var expectedResult = new List<Sneaker>()
        {
            new(1, "test", "test", 1, 1, 9999, 1)
        };

        var sneakerRepository = new Mock<ISneakerRepository>();
        var getAllSneakersQuery = new GetAllSneakersQuery(1);
        var getAllSneakersQueryHandler = new GetAllSneakersQueryHandler(sneakerRepository.Object);

        sneakerRepository.Setup(s => s.GetAllAsync(It.IsAny<int>())).ReturnsAsync(expectedResult);

        // Act
        var sneakers = await getAllSneakersQueryHandler.Handle(getAllSneakersQuery, new CancellationToken());

        // Assert
        Assert.True(sneakers.Count > 0);
        sneakerRepository.Verify(pr => pr.GetAllAsync(It.IsAny<int>()), Times.Once);
    }
}
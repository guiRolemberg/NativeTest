using Moq;
using Native.Application.Queries.GetAllSearchSneakers;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Queries;
public class GetAllSearchSneakersQueryHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_GetAllSearchSneakersExecuted_ReturnSneakers()
    {
        // Arrange
        var expectedResult = new List<Sneaker>()
        {
            new(1, "test", "test", 1, 1, 9999, 1)
        };

        var sneakerRepository = new Mock<ISneakerRepository>();
        var getAllSearchSneakersQuery = new GetAllSearchSneakersQuery(1, "Nike");
        var getAllSearchSneakersQueryHandler = new GetAllSearchSneakersQueryHandler(sneakerRepository.Object);

        sneakerRepository.Setup(s => s.GetAllSearchAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(expectedResult);

        // Act
        var sneakers = await getAllSearchSneakersQueryHandler.Handle(getAllSearchSneakersQuery, new CancellationToken());

        // Assert
        Assert.True(sneakers.Count > 0);
        sneakerRepository.Verify(pr => pr.GetAllSearchAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
    }
}
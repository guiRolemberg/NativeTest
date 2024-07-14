using Moq;
using Native.Application.Commands.UpdateSneaker;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Commands;
public class UpdateSneakerCommandHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_UpdateSneakerExecuted_ReturnSneakerId()
    {
        // Arrange
        var sneaker = new Sneaker(1, "test", "test", 1, 10, 1999, 4);

        var sneakerRepository = new Mock<ISneakerRepository>();
        sneakerRepository.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(sneaker);

        var updateSneakerCommand = new UpdateSneakerCommand
        {
            Name = "Air Jordan",
            Brand = "Nike",
            Price = 50000,
            Size = 38,
            Rate = 5
        };

        var updateSneakerCommandHandler = new UpdateSneakerCommandHandler(sneakerRepository.Object);

        // Act
        var id = await updateSneakerCommandHandler.Handle(updateSneakerCommand, new CancellationToken());

        // Assert
        sneakerRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Sneaker>()), Times.Once);
    }
}
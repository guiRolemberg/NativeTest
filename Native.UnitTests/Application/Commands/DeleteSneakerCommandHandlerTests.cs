using Moq;
using Native.Application.Commands.DeleteSneaker;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Commands;
public class DeleteSneakerCommandHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_DeleteSneakerExecuted_ReturnUnitValue()
    {
        // Arrange
        var id = It.IsAny<int>();

        var sneakerRepository = new Mock<ISneakerRepository>();
        sneakerRepository.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(It.IsAny<Sneaker>());

        var createSneakerCommand = new DeleteSneakerCommand(id);

        var createSneakerCommandHandler = new DeleteSneakerCommandHandler(sneakerRepository.Object);

        // Act
        await createSneakerCommandHandler.Handle(createSneakerCommand, new CancellationToken());

        // Assert
        sneakerRepository.Verify(pr => pr.DeleteAsync(It.IsAny<Sneaker>()), Times.Once);
    }
}
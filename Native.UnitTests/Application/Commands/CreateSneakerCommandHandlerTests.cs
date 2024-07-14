using Moq;
using Native.Application.Commands.CreateSneaker;
using Native.Core.Entities;
using Native.Core.Repositories;

namespace Native.UnitTests.Application.Commands;
public class CreateSneakerCommandHandlerTests
{
    [Fact]
    internal async Task InputDataIsOk_CreateSneakerExecuted_ReturnSneakerId()
    {
        // Arrange
        var sneakerRepository = new Mock<ISneakerRepository>();

        var createSneakerCommand = new CreateSneakerCommand
        {
            IdUser = 1,
            Name = "Air Jordan",
            Brand = "Nike",
            Price = 50000,
            Size = 38,
            Rate = 5
        };

        var createSneakerCommandHandler = new CreateSneakerCommandHandler(sneakerRepository.Object);

        // Act
        var id = await createSneakerCommandHandler.Handle(createSneakerCommand, new CancellationToken());

        // Assert
        Assert.True(id >= 0);

        sneakerRepository.Verify(pr => pr.AddAsync(It.IsAny<Sneaker>()), Times.Once);
    }
}

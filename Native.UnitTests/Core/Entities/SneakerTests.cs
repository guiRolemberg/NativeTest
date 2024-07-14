using Native.Core.Entities;

namespace Native.UnitTests.Core.Entities;
public class SneakerTests
{
    [Fact]
    public void TestIfSneakerWorks()
    {
        var sneaker = new Sneaker(1, "test", "test", 1, 1, 9999, 1);

        Assert.NotNull(sneaker.Name);
        Assert.NotEmpty(sneaker.Name);

        Assert.NotNull(sneaker.Brand);
        Assert.NotEmpty(sneaker.Brand);

        sneaker.Update("test2", "test2", 1, 1, 9999, 1);

        Assert.Equal("test2", sneaker.Name);
    }
}

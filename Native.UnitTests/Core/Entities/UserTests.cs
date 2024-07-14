using Native.Core.Entities;

namespace Native.UnitTests.Core.Entities;
public class UserTests
{
    [Fact]
    public void TestIfUserWorks()
    {
        var user = new User("test@test.com", "gtasfvbwesrgb");

        Assert.NotNull(user.Email);
        Assert.NotEmpty(user.Email);

        Assert.NotNull(user.Password);
        Assert.NotEmpty(user.Password);

        Assert.True(user.Active);
    }
}

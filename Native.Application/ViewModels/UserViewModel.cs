namespace Native.Application.ViewModels;
public class UserViewModel(string email)
{
    public string Email { get; private set; } = email;
}
namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IAuthenticationAppService
{
    public bool Login(string username, string password);
}
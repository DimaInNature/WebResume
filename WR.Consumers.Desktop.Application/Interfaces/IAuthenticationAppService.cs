namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IAuthenticationAppService
{
    public Task<string?> Authorize(string username, string password);
}
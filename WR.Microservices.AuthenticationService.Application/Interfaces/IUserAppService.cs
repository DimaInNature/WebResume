namespace WR.Microservices.AuthenticationService.Application.Interfaces;

public interface IUserAppService
{
    public Task<User?> GetAsync(string username, string password);
}
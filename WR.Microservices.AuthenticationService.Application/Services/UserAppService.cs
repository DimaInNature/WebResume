namespace WR.Microservices.AuthenticationService.Application.Services;

public class UserAppService : IUserAppService
{
	private readonly IMediator _mediator;

	public UserAppService(IMediator mediator) =>
		_mediator = mediator;

	public async Task<User?> GetAsync(string username, string password) =>
		await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(username, password));
}
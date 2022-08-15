namespace WR.Microservices.AuthenticationService.Application.Services;

public class UserAppService : IUserAppService
{
	private readonly IMediator _mediator;

	public UserAppService(Mediator mediator) =>
		_mediator = mediator;
}
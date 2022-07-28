namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUsersListQuery : IRequest<IEnumerable<UserEntity>> { }
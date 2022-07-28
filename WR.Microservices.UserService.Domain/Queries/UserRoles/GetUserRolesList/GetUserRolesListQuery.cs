namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRolesListQuery : IRequest<IEnumerable<UserRoleEntity>> { }
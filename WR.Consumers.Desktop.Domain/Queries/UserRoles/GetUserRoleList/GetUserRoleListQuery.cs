namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<IEnumerable<UserRole>>;
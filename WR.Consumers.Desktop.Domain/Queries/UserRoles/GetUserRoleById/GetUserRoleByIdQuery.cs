namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleByIdQuery
    : IRequest<UserRole?>
{
    public Guid Id { get; }

    public GetUserRoleByIdQuery(Guid id) => Id = id;

    public GetUserRoleByIdQuery() { }
}
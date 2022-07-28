namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRoleByPredicateQuery : IRequest<UserRoleEntity?>
{
    public Func<UserRoleEntity, bool>? Predicate { get; }

    public GetUserRoleByPredicateQuery(
       Func<UserRoleEntity, bool> predicate) =>
       Predicate = predicate;

    public GetUserRoleByPredicateQuery() { }
}
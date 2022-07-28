namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRolesListByPredicateQuery 
    : IRequest<IEnumerable<UserRoleEntity>>
{
    public Func<UserRoleEntity, bool>? Predicate { get; }

    public GetUserRolesListByPredicateQuery(
        Func<UserRoleEntity, bool> predicate) =>
        Predicate = predicate;

    public GetUserRolesListByPredicateQuery() { }
}
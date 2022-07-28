namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUsersListByPredicateQuery 
    : IRequest<IEnumerable<UserEntity>>
{
    public Func<UserEntity, bool>? Predicate { get; }

    public GetUsersListByPredicateQuery(
        Func<UserEntity, bool> predicate) =>
        Predicate = predicate;

    public GetUsersListByPredicateQuery() { }
}
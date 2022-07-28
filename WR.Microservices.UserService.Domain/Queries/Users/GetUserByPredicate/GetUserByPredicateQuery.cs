namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUserByPredicateQuery : IRequest<UserEntity?>
{
    public Func<UserEntity, bool>? Predicate { get; }

	public GetUserByPredicateQuery(
		Func<UserEntity, bool> predicate) =>
		Predicate = predicate;

	public GetUserByPredicateQuery() { }
}
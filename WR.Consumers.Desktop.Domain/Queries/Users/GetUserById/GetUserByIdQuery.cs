namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByIdQuery
    : IRequest<User?>
{
    public Guid Id { get; }

    public GetUserByIdQuery(Guid id) => Id = id;

    public GetUserByIdQuery() { }
}
namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserListQuery : IRequest<IEnumerable<User>>;
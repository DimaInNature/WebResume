namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByLoginAndPasswordQuery : IRequest<User?>
{
    public string Username { get; } = string.Empty;

    public string Password { get; } = string.Empty;

    public GetUserByLoginAndPasswordQuery(
        string username, string password) =>
        (Username, Password) = (username, password);

    public GetUserByLoginAndPasswordQuery() { }
}
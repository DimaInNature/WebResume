namespace WR.Microservices.UserService.Persistence.Entities;

public class UserEntity : IDatabaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRoleEntity? UserRole { get; set; }

    public Guid? UserRoleId { get; set; }
}
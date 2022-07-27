namespace WR.Microservices.UserService.Persistence.Entities;

public class UserRoleEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
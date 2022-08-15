namespace WR.Microservices.AuthenticationServices.Domain.Core.Models;

public class UserRole
{
    public Guid Id { get; }

    public string Name { get; set; } = string.Empty;
}
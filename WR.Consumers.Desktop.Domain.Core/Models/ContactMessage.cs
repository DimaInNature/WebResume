namespace WR.Consumers.Desktop.Domain.Core.Models;

public class ContactMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string SenderName { get; set; } = string.Empty;

    public string SenderEmail { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
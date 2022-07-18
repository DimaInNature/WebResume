namespace WebResume.Domain.Models;

public class ContactMessage
{
    public Guid Id { get; set; }

    public string SenderName { get; set; } = string.Empty;

    public string SenderEmail { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
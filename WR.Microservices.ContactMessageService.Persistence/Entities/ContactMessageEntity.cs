namespace WR.Microservices.ContactMessageService.Persistence.Entities;

public class ContactMessageEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string SenderName { get; set; }

    public string SenderEmail { get; set; }

    public string Message { get; set; }
}

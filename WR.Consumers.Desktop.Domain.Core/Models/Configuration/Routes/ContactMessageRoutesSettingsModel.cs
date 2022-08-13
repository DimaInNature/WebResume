namespace WR.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class ContactMessageRoutesSettingsModel
{
    public string CreateContactMessageRoute { get; set; } = string.Empty;

    public string UpdateContactMessageRoute { get; set; } = string.Empty;

    public string DeleteContactMessageRoute { get; set; } = string.Empty;

    public string GetContactMessagesListRoute { get; set; } = string.Empty;

    public string GetContactMessageByIdRoute { get; set; } = string.Empty;

    public string DeleteContactMessage(Guid id) =>
        string.Format(format: DeleteContactMessageRoute, arg0: id);

    public string GetContactMessageById(Guid id) =>
        string.Format(format: GetContactMessageByIdRoute, arg0: id);
}
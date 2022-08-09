namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class ReadContactMessagesViewModel : BaseReadViewModel<ContactMessage>
{
    private readonly IContactMessageAppService _messageService;

    public ReadContactMessagesViewModel(IContactMessageAppService messageService)
    {
        _messageService = messageService;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var messages = await _messageService.GetAllAsync();

        filter = filter.ToLower();

        GeneralDataList = messages.Where(
            predicate: message =>
            message.SenderEmail.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData()
    {
        var response = await _messageService.GetAllAsync();

        GeneralDataList = response.ToList();
    }

    #endregion
}
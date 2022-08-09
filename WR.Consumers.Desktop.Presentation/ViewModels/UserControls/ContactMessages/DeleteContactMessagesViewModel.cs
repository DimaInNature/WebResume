namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class DeleteContactMessagesViewModel : BaseDeleteViewModel<ContactMessage>
{
    private readonly IContactMessageAppService _messageService;

    public DeleteContactMessagesViewModel(IContactMessageAppService messageService)
    {
        _messageService = messageService;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        await _messageService.DeleteAsync(id: SelectedGeneralValue.Id);

        MessageBox.Show(
           messageBoxText: "The deletion was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

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

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData()
    {
        var response = await _messageService.GetAllAsync();

        GeneralDataList = response.ToList();
    }

    #endregion
}
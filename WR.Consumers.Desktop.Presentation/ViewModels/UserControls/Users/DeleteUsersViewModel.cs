namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class DeleteUsersViewModel : BaseDeleteViewModel<User>
{
    private readonly IUserAppService _userService;

    public DeleteUsersViewModel(IUserAppService userService)
    {
        _userService = userService;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        await _userService.DeleteAsync(id: SelectedGeneralValue.Id);

        MessageBox.Show(
           messageBoxText: "The deletion was successfu",
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
        var users = await _userService.GetAllAsync();

        filter = filter.ToLower();

        GeneralDataList = users.Where(predicate:
            user =>
            user.Username.ToLower().Contains(value: filter))
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
        var response = await _userService.GetAllAsync();

        GeneralDataList = response.ToList();
    }

    #endregion
}
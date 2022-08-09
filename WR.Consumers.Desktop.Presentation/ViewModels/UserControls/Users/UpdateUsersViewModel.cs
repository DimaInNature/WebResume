namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class UpdateUsersViewModel : BaseUpdateViewModel<User, UserRole>
{
    private readonly IUserAppService _userService;

    private readonly IUserRoleAppService _userRoleService;

    public UpdateUsersViewModel(
        IUserAppService userService,
        IUserRoleAppService userRoleService)
    {
        (_userService, _userRoleService) = (userService, userRoleService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedGeneralValue is not null &&
        SelectedAggregatedValue is not null &&
        new string[]
        {
            SelectedGeneralValue.Username,
            SelectedGeneralValue.Password
        }.AllIsNotNullOrWhiteSpace();

    protected async override void ExecuteUpdateCommand(object obj)
    {
        if (SelectedGeneralValue is null || SelectedAggregatedValue is null) return;

        SelectedGeneralValue.UserRoleId = SelectedAggregatedValue.Id;

        await _userService.UpdateAsync(entity: SelectedGeneralValue);

        MessageBox.Show(
           messageBoxText: "The change was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override void SelectGeneralValue()
    {
        if (SelectedGeneralValue is not null)
        {
            SelectedAggregatedValue = SelectedGeneralValue.UserRole;

            SelectedAggredatedValueIndex = AggregatedDataList
                .FindIndex(match: role => role.Id == SelectedAggregatedValue?.Id);
        }
    }

    protected override async void Find(string filter)
    {
        var users = await _userService.GetAllAsync();

        filter = filter.ToLower();

        GeneralDataList = users.Where(predicate:
            user =>
            user.Username.ToLower().Contains(value: filter))
            .ToList();
    }

    protected override async Task UpdateData() => await InitializeData();

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private async Task InitializeData()
    {
        var userResponse = await _userService.GetAllAsync();

        GeneralDataList = userResponse.ToList();

        var userRoleResponse = await _userRoleService.GetAllAsync();

        AggregatedDataList = userRoleResponse.ToList();
    }

    #endregion
}
namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class ReadUsersViewModel : BaseReadViewModel<User>
{
    private readonly IUserAppService _userService;

    public ReadUsersViewModel(IUserAppService userService)
    {
        _userService = userService;

        Task.Run(function: () => InitializeData());
    }

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

    private async Task InitializeData()
    {
        var response = await _userService.GetAllAsync();

        GeneralDataList = response.ToList();
    }

    protected override void SelectGeneralValue() { }

    #endregion
}
namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls;

internal sealed class CreateUsersViewModel : BaseCreateViewModel
{
    private readonly IUserAppService _userService;

    private readonly IUserRoleAppService _userRoleService;

    #region Accessors

    public string Username
    {
        get => _username ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value.Equals(value: string.Empty))
            {
                _username = null;

                OnPropertyChanged(propertyName: nameof(Username));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _username = value;

            OnPropertyChanged(propertyName: nameof(Username));
        }
    }

    public string Password
    {
        get => _password ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value.Equals(value: string.Empty))
            {
                _password = null;

                OnPropertyChanged(propertyName: nameof(Password));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _password = value;

            OnPropertyChanged(propertyName: nameof(Password));
        }
    }

    public List<UserRole> UserRoles
    {
        get => _userRoles ?? new();
        set
        {
            _userRoles = value;

            OnPropertyChanged(propertyName: nameof(UserRoles));
        }
    }

    public UserRole? SelectedRole
    {
        get => _selectedRole;
        set
        {
            _selectedRole = value;

            OnPropertyChanged(propertyName: nameof(SelectedRole));
        }
    }

    #endregion

    #region Private

    private string? _username;

    private string? _password;

    private UserRole? _selectedRole;

    private List<UserRole> _userRoles = new();

    #endregion

    public CreateUsersViewModel(
        IUserAppService userService,
        IUserRoleAppService userRoleSerivce)
    {
        (_userService, _userRoleService) = (userService, userRoleSerivce);

        InitializeCommands();

        Task.Run(function: () => InitializeUserRoles());
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        new string[] { Username, Password }.AllIsNotNullOrWhiteSpace() &&
        SelectedRole is not null;

    protected override async void ExecuteCreate(object obj)
    {
        if (SelectedRole is null)
        {
            MessageBox.Show(
                messageBoxText: "The user role was not selected",
                caption: "Warning",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Warning);

            return;
        }

        User user = new(Username, Password, userRoleId: SelectedRole.Id);

        await _userService.CreateAsync(user);

        MessageBox.Show(
            messageBoxText: "The addition was successful",
            caption: "Success",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Username = string.Empty;
        Password = string.Empty;
        SelectedRole = default;
    }

    private async Task InitializeUserRoles()
    {
        var response = await _userRoleService.GetAllAsync();

        UserRoles = response.ToList();
    }

    #endregion
}
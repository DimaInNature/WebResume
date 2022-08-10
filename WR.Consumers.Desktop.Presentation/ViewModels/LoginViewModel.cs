namespace WR.Consumers.Desktop.Presentation.ViewModels;

internal sealed class LoginViewModel : BaseViewModel
{
    private readonly IUserAppService _userAppService;

    #region Acessors

    public ICommand? LoginCommand { get; private set; }

    public ICommand? RegistrationCommand { get; private set; }

    public string EnterUserLogin
    {
        get => _enterUserLogin ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value == string.Empty)
            {
                _enterUserLogin = null;

                OnPropertyChanged(nameof(EnterUserLogin));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _enterUserLogin = value;

            OnPropertyChanged(nameof(EnterUserLogin));
        }
    }

    public SecureString SecurePassword
    {
        get => _securePassword ?? new();
        set
        {
            _securePassword = value;

            OnPropertyChanged(nameof(SecurePassword));
            OnPropertyChanged(nameof(Password));
        }
    }

    public unsafe string Password
    {
        [SecurityCritical]
        get => new(value: (char*)(void*)Marshal.SecureStringToBSTR(s: SecurePassword));
        [SecurityCritical]
        set
        {
            value ??= string.Empty;

            using (SecureString secureString = new())
            {
                foreach (char c in value)
                    secureString.AppendChar(c);
            }
            _password = value;
            IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
        }
    }

    public bool IsPasswordWatermarkVisible
    {
        get => _isPasswordWatermarkVisible;
        set
        {
            if (value.Equals(_isPasswordWatermarkVisible)) return;

            _isPasswordWatermarkVisible = value;

            OnPropertyChanged(nameof(IsPasswordWatermarkVisible));
        }
    }

    #endregion

    #region Private

    private string? _enterUserLogin;

    private SecureString? _securePassword;

    private string? _password;

    private bool _isPasswordWatermarkVisible = true;

    #endregion

    public bool IsConnectionStopped = false;

    public LoginViewModel(IUserAppService userAppService)
    {
        _userAppService = userAppService;

        InitializationCommands();
    }

    private async void ExecuteLogin(object obj)
    {
        var user = await _userAppService.GetAsync(username: EnterUserLogin, Password);

        if (user is null | string.IsNullOrWhiteSpace(value: user?.Username))
        {
            MessageBox.Show(
                messageBoxText: "User is not exist.",
                caption: "Authorization error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            IsConnectionStopped = true;

            return;
        }

        if (user?.UserRole?.Name is not "Admin" and not "Employee")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights.",
                caption: "Security system.",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            IsConnectionStopped = true;

            return;
        }

        (obj as MainView)?.Show();

        (obj as Window)?.Close();

        IsConnectionStopped = true;
    }

    private bool CanExecuteLogin(object obj) =>
        new string[] { EnterUserLogin, Password }.AllIsNotNullOrWhiteSpace();

    private async void ExecuteRegistration(object obj)
    {
        User user = new(EnterUserLogin, Password);

        User? createdUser = await _userAppService.CreateAsync(entity: user);

        if(createdUser is null)
        {
            if(string.IsNullOrWhiteSpace(value: createdUser?.Username) is false)
            {
                MessageBox.Show(
                    messageBoxText: "User is already exists.",
                    caption: "Registration error",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error);

                IsConnectionStopped = true;
            }

            return;
        }

        IsConnectionStopped = true;

        (obj as MainView)?.Show();

        (obj as Window)?.Close();
    }

    private bool CanExecuteRegistration(object obj) =>
        new string[] { EnterUserLogin, Password }.AllIsNotNullOrWhiteSpace();

    private void InitializationCommands()
    {
        LoginCommand = new RelayCommand(executeAction: ExecuteLogin,
            canExecuteFunc: CanExecuteLogin);

        RegistrationCommand = new RelayCommand(executeAction: ExecuteRegistration,
            canExecuteFunc: CanExecuteRegistration);
    }
}
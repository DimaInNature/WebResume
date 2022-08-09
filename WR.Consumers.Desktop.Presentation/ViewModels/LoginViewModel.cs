namespace WR.Consumers.Desktop.Presentation.ViewModels;

public sealed class LoginViewModel : BaseViewModel
{
    #region Members

    public bool IsConnectionStopped = false;

    #region Properties

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

    #endregion

    #region Commands

    public ICommand? LoginCommand { get; private set; }

    public ICommand? RegistrationCommand { get; private set; }

    #endregion

    #region View

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

    #region Dependencies

    #endregion

    #endregion
}
namespace WR.Consumers.Desktop.Presentation.Views;

public partial class LoginView : Window
{
    private readonly LoginViewModel? _viewModel = ((App)ThisApplication.Current)
        .ServiceProvider?.GetService<LoginViewModel>();

    public LoginView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException(message: "ViewModel is null");

        DataContext = _viewModel;
    }
}
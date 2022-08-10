namespace WR.Consumers.Desktop.Presentation.Views;

public partial class LoginView : Window
{
    private readonly LoginViewModel _viewModel = ViewModelConnector.Connect<LoginViewModel>();

    public LoginView()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.IsConnectionStopped = false;

        (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (false, false);

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (true, true));
        });
    }

    private void MaximazedButton_Click(object sender, RoutedEventArgs e) =>
       WindowState = WindowState switch
       {
           WindowState.Normal => WindowState.Maximized,
           _ => WindowState.Normal,
       };

    private void RollUpButton_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void ExitButton_Click(object sender, RoutedEventArgs e) =>
        ThisApplication.Current.Shutdown();

    private void EnterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        _viewModel.Password = EnterPasswordPasswordBox.Password;

        _viewModel.SecurePassword = EnterPasswordPasswordBox.SecurePassword;
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        ThisApplication.Current.Shutdown();

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.IsConnectionStopped = false;

        (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (false, false);

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (true, true));
        });
    }
}
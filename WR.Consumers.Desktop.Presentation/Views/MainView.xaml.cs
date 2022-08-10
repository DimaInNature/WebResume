namespace WR.Consumers.Desktop.Presentation.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<MainViewModel>();
    }

    private void Window_MouseLeftDown(object sender, MouseButtonEventArgs e) => DragMove();

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

    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, HomeMenuButton.IsChecked) = ("Web Resume - Home", true);

        CollapseFrame();
    }

    private void ReadButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, ReadMenuButton.IsChecked) = ("Web Resume - Read", true);

        SetFrame(source: new ReadMenuView());
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, CreateMenuButton.IsChecked) = ("Web Resume - Create", true);

        SetFrame(source: new CreateMenuView());
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, UpdateMenuButton.IsChecked) = ("Web Resume - Update", true);

        SetFrame(source: new UpdateMenuView());
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, DeleteMenuButton.IsChecked) = ("Web Resume - Delete", true);

        SetFrame(source: new DeleteMenuView());
    }

    private void LogoutMenuButton_Click(object sender, RoutedEventArgs e)
    {
        new LoginView().Show();

        Close();
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseFrame() =>
        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Collapsed, null);
}
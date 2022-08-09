namespace WR.Consumers.Desktop.Presentation.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<MainViewModel>();
    }
}
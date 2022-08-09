namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Users;

public partial class ReadUsersView : UserControl
{
    public ReadUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadUsersViewModel>();
    }
}
namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Users;

public partial class CreateUsersView : UserControl
{
    public CreateUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<CreateUsersViewModel>();
    }
}
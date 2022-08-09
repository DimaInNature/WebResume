namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Users;

public partial class DeleteUsersView : UserControl
{
    public DeleteUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<DeleteUsersViewModel>();
    }
}
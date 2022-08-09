namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Users;

public partial class UpdateUsersView : UserControl
{
    public UpdateUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<UpdateUsersViewModel>();
    }
}
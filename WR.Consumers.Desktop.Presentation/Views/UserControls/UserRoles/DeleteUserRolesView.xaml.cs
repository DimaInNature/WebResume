namespace WR.Consumers.Desktop.Presentation.Views.UserControls.UserRoles;

public partial class DeleteUserRolesView : UserControl
{
    public DeleteUserRolesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<DeleteUserRolesViewModel>();
    }
}
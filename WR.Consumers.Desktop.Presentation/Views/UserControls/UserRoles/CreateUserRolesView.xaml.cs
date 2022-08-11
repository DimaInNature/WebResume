namespace WR.Consumers.Desktop.Presentation.Views.UserControls.UserRoles;

public partial class CreateUserRolesView : UserControl
{
    public CreateUserRolesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<CreateUserRolesViewModel>();
    }
}
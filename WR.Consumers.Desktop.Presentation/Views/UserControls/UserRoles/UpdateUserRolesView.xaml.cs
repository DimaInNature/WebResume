namespace WR.Consumers.Desktop.Presentation.Views.UserControls.UserRoles;

public partial class UpdateUserRolesView : UserControl
{
    public UpdateUserRolesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<UpdateUserRolesViewModel>();
    }
}
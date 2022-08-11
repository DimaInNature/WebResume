namespace WR.Consumers.Desktop.Presentation.Views.UserControls.UserRoles;

public partial class ReadUserRolesView : UserControl
{
    public ReadUserRolesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadUserRolesViewModel>();
    }
}
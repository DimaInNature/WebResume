namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class CreateMenuView : UserControl
{
    public CreateMenuView() => InitializeComponent();

    private void UserButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUsersView());

    private void UserRoleButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUserRolesView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}
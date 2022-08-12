namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class ReadMenuView : UserControl
{
    public ReadMenuView() => InitializeComponent();

    private void UserButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadUsersView());

    private void ContactMessagesButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadContactMessagesView());

    private void PetProjectsButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadPetProjectsView());

    private void UserRoleButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadUserRolesView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}
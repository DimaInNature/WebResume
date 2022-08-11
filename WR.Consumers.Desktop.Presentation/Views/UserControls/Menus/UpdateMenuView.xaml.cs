namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class UpdateMenuView : UserControl
{
    public UpdateMenuView() => InitializeComponent();

    private void UserButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUsersView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}
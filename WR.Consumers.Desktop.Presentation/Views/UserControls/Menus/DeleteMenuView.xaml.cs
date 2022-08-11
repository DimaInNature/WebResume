namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class DeleteMenuView : UserControl
{
    public DeleteMenuView() => InitializeComponent();


    private void UserButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteUsersView());

    private void ContactMessagesButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteContactMessagesView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}
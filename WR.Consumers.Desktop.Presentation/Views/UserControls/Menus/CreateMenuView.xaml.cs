namespace WR.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class CreateMenuView : UserControl
{
    public CreateMenuView() => InitializeComponent();

    private void UserButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUsersView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}
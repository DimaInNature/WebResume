namespace WR.Consumers.Desktop.Presentation.Views.UserControls.ContactMessages;

public partial class DeleteContactMessagesView : UserControl
{
    public DeleteContactMessagesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<DeleteContactMessagesViewModel>();
    }
}
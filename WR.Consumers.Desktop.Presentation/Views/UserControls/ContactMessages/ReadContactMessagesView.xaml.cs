namespace WR.Consumers.Desktop.Presentation.Views.UserControls.ContactMessages;

public partial class ReadContactMessagesView : UserControl
{
    public ReadContactMessagesView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadContactMessagesViewModel>();
    }
}
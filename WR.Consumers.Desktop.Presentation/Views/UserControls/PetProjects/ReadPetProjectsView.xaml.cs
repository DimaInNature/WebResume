namespace WR.Consumers.Desktop.Presentation.Views.UserControls.PetProjects;

public partial class ReadPetProjectsView : UserControl
{
    public ReadPetProjectsView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadPetProjectsViewModel>();
    }
}
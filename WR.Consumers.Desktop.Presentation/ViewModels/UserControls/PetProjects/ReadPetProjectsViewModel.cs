namespace WR.Consumers.Desktop.Presentation.ViewModels.UserControls.PetProjects;

internal sealed class ReadPetProjectsViewModel
    : BaseReadViewModel<PetProject>
{
    private readonly IPetProjectAppService _petProjectService;

    public ReadPetProjectsViewModel(
        IPetProjectAppService petProjectAppService)
    {
        _petProjectService = petProjectAppService;
        Task.Run(function: () => InitializeData());
    }

    protected override async Task UpdateData() => await InitializeData();

    private async Task InitializeData()
    {
        var response = await _petProjectService.GetAllByOwnerNameAsync(ownerName: "DimaInNature");

        GeneralDataList = response.ToList();
    }

    protected override void SelectGeneralValue() { }

    protected override void Find(string filter) { }
}
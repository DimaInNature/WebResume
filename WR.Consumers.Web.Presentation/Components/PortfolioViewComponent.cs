namespace WR.Consumers.Web.Presentation.Components;

public class PortfolioViewComponent : ViewComponent
{
    private readonly IPetProjectAppService _petProjectAppService;

    public PortfolioViewComponent(IPetProjectAppService petProjectAppService) =>
        _petProjectAppService = petProjectAppService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _petProjectAppService.GetAllAsync(ownerName: "DimaInNature");

        return View(model.OrderByDescending(x => x.StarsCount));
    }
}